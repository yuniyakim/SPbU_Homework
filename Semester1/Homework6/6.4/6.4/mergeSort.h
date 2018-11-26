#pragma once
#include "list.h"
#include <string>

// merge function that returns a sorted list with elements of first and second lists
List *merge(List *first, List *second, bool sorting);

// divides a list into two and returns the second one
List *division(List *list);

// merge sorting according to chosen type of sorting
List *mergeSort(List *list, bool sorting);