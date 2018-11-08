#pragma once

// structure of an element
struct Node
{
	int initialPosition;
	Node *next;
};

// list
struct List
{
	Node *head;
};

// adds the given amount of elements to the list
void addElements(List *list, int const amount);

// deletes elements in a list according to given period AND! returns an initial number of the last element
int deleteElements(List *list, int const period);

// checks if list is empty
bool isEmpty(List *list);

// finds the amount of elements in the list
int amountOfElements(List *list);