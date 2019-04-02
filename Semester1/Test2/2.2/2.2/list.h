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
bool isEmpty(List *list);

// returns the number of the element
int valueOfElement(List *list);

// returns a pointer to the next element
List* nextOfList(List *list);

// returns the number of records in a list
int numberOfRecords(List *list);

// prints the list
void printList(List *list);

// returns a pointer to the previous element
List *previousOfList(List *list);

// checks if a list is symmetric
bool isSymmetric(List *list);