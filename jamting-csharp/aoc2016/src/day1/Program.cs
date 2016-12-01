using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public class Program
    {
        public static int Distance(Tuple<int, int> pos) => Math.Abs(pos.Item1) + Math.Abs(pos.Item2);

        public static bool BunnyHQFound = false;

        public static int Turn(char lr) => lr.Equals('R') ? 1 : -1;

        public static int NewDir(int dir, char lr) => (dir + Turn(lr) + 4) % 4;

        public static List<Tuple<int, int>> Places = new List<Tuple<int, int>>();

        public static List<Tuple<int, int>> Deltas = new List<Tuple<int, int>>
        {
            Tuple.Create( 0, 1 ),
            Tuple.Create( 1, 0 ),
            Tuple.Create( 0, -1 ),
            Tuple.Create( -1, 0 )
        };

        public static Tuple<int, int> Walk(Tuple<int, int> from, int direction, int distance)
        {
            var x = from.Item1;
            var y = from.Item2;
            for (var d = 0; d < distance; d++)
            {
                var thisplace = Tuple.Create(x, y);
                if (Places.Any(p => p.Equals(thisplace)) && !BunnyHQFound)
                {
                    BunnyHQFound = true;
                    Console.WriteLine("BunnyHQ found @ " + thisplace + ". Distance: " + Distance(thisplace));
                }
                else
                {
                    Places.Add(thisplace);
                }
                x = x + Deltas[direction].Item1;
                y = y + Deltas[direction].Item2;
            }
            return Tuple.Create(x, y);
        }

        // Dirs: 0, 1, 2, 3 (N, E, S, W)

        public static void Main(string[] args)
        {
            const string input = "R5, L2, L1, R1, R3, R3, L3, R3, R4, L2, R4, L4, R4, R3, L2, L1, L1, R2, R4, R4, L4, R3, L2, R1, L4, R1, R3, L5, L4, L5, R3, L3, L1, L1, R4, R2, R2, L1, L4, R191, R5, L2, R46, R3, L1, R74, L2, R2, R187, R3, R4, R1, L4, L4, L2, R4, L5, R4, R3, L2, L1, R3, R3, R3, R1, R1, L4, R4, R1, R5, R2, R1, R3, L4, L2, L2, R1, L3, R1, R3, L5, L3, R5, R3, R4, L1, R3, R2, R1, R2, L4, L1, L1, R3, L3, R4, L2, L4, L5, L5, L4, R2, R5, L4, R4, L2, R3, L4, L3, L5, R5, L4, L2, R3, R5, R5, L1, L4, R3, L1, R2, L5, L1, R4, L1, R5, R1, L4, L4, L4, R4, R3, L5, R1, L3, R4, R3, L2, L1, R1, R2, R2, R2, L1, L1, L2, L5, L3, L1";
            var inputList = input.Replace(" ", "").Split(',');
           
            var curpos = Tuple.Create(0, 0);
            var curdir = 0;
            
            foreach (var item in inputList)
            {
                var turn = item[0];
                var distance = int.Parse(item.Substring(1));
                var newdir = NewDir(curdir, turn);
                var newpos = Walk(curpos, newdir, distance);
                curpos = newpos;
                curdir = newdir;
            }
            Console.WriteLine("Ended @ " + curpos + ". Distance : " + Distance(curpos));
            Console.ReadLine();
        }
    }
}
