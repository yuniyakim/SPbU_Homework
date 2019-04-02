#pragma once
#include <string>

// a list
struct List;

// creates a new list
List *createList();

// deletes a list and all its' elements
void deleteList(List *list);

// adds a new element into the list
List *addIntoList(List *list, std::string name, std::string number);

// checks if a list is empty
bool isEmpty(List *list);

// returns the name of the element
std::string nameOfElement(List *list);

// returns the number of the element
std::string numberOfElement(List *list);

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