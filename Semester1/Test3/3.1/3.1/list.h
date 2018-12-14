#pragma once

// structure of a list
struct Element;

// structure with isEmpty element
struct List;

// creates a new list
List *createList();

// deletes the list 
void deleteList(List *list);

// checks if an element is contained
bool isElementContained(List *list, int inputValue);

// adds value into the sorted list
void addValueIntoList(List *list, int inputValue);

// prints list
void printList(List *list);