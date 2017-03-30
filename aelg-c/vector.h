#include <stdlib.h>

#define Vector_as_array(type, v) ((type*)Vector_data(v))

typedef struct VectorS *Vector;

void Vector_push(Vector v, void* data);
void Vector_pop(Vector v, void *elem);
void* Vector_data(Vector v);
int Vector_size(Vector v);
Vector Vector_copy(Vector v);

Vector Vector_create_char(void);
void Vector_push_char(Vector v, char c);
char* Vector_data_char(Vector v);

Vector Vector_create_int(void);
void Vector_push_int(Vector v, int n);
int Vector_pop_int(Vector v);
int* Vector_data_int(Vector v);

Vector Vector_create(size_t element_size);

void Vector_free(Vector v);
