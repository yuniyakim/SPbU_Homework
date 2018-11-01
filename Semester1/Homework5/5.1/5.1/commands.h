#pragma once

// structure of a list
struct element
{
	int value;
	element *next;
};

// structure with isEmpty element
struct List
{
	element *head;
	bool isEmpty = true;
};

//  prints list of commands
void printCommands();

// checks if the element is contained in the list
bool isElementContained(List *list, int inputValue);

// adds value into the list
void addValueIntoList(List *list, int inputValue);

// deletes value from the list
void deleteValueFromList(List *list, int inputValue);

// prints list
void printList(List *list);