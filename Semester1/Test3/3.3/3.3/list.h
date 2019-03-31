#pragma once

#pragma once

// a list
struct List;

// creates a new list
List *createList();

// deletes a list and all its' elements
void deleteList(List *list);

// adds a new element into the list
List *addIntoList(List *list, int value);

// checks if a list is empty
bool isEmptyList(List *list);

// checks if a value exists in a list
bool existsList(List *list, int value);

// returns the number of the element
int valueOfElement(List *list);

// returns a pointer to the next element
List* nextOfList(List *list);

// returns the number of records in a list
int numberOfRecords(List *list);

// prints list
void printList(List *list);

// makes list->next = nullptr
void nextNullptr(List *list);

// makes list->next = list2
void nextTo(List *list, List* list2);