#pragma once
#include <string>

// a list
struct List;

// creates a new list
List *createList();

// deletes a list and all its' elements
void deleteList(List *list);

// adds a new element into the list
List *addIntoList(List *list, std::string key);

// checks if a list is empty
bool isEmpty(List *list);

// returns the key of the element
std::string keyOfElement(List *list);

// returns a pointer to the next element
List *nextOfList(List *list);

// returns the number of records in a list
int numberOfRecords(List *list);

// prints the list
void printList(List *list);

// increses amount of the list
void increaseAmount(List *list);

// returns amount of the list
int amountOfList(List *list);