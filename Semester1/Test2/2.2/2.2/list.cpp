#include "pch.h"
#include "list.h"
#include <iostream>
using namespace std;

struct List
{
	int value;
	List *next;
	List *previous;
};

List *createList()
{
	List *temp{ nullptr };
	return temp;
}

void deleteList(List *list)
{
	List *temp = list;
	while (temp != nullptr) 
	{
		List *temp2 = temp;
		temp = temp->next;
		delete temp2;
	}
}

List *addIntoList(List *list, int value)
{
	List *newList = new List{ value, nullptr, nullptr };
	if (list == nullptr)
	{
		list = newList;
	}
	else
	{
		List *temp = list;
		while (temp->next != nullptr)
		{
			temp = temp->next;
		}
		temp->next = newList;
		newList->previous = temp;
	}
	return list;
}

bool isEmpty(List *list)
{
	return list == nullptr;
}

int valueOfElement(List *list)
{
	return list->value;
}

List *nextOfList(List *list)
{
	List *temp = list->next;
	return temp;
}

List *previousOfList(List *list)
{
	List *temp = list->previous;
	return temp;
}

int numberOfRecords(List *list)
{
	int numberOfRecords = 0;
	List *temp = list;
	while (temp != nullptr)
	{
		temp = nextOfList(temp);
		++numberOfRecords;
	}
	return numberOfRecords;
}

void printList(List *list)
{
	int number = numberOfRecords(list);
	List *temp = list;
	for (int i = 0; i < number; ++i)
	{
		cout << valueOfElement(temp) << " ";
		temp = nextOfList(temp);
	}
}

bool isSymmetric(List *list)
{
	bool check = true;
	List *tempLeft = list;
	List *tempRight = list;
	int number = numberOfRecords(list);
	for (int i = 0; i < number - 1; ++i)
	{
		tempRight = tempRight->next;
	}
	for (int k = 0; k < (number / 2); ++k)
	{
		if (valueOfElement(tempLeft) != valueOfElement(tempRight))
		{
			check = false;
		}
		tempLeft = nextOfList(tempLeft);
		tempRight = previousOfList(tempRight);
	}
	return check;
}
