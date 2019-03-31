#include "pch.h"
#include "list.h"
#include <iostream>
#include <string>
using namespace std;

struct List
{
	string name;
	string number;
	List *next;
};

List *createList()
{
	return nullptr;
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

List *addIntoList(List *list, string name, string number)
{
	List *newList = new List{ name, number, nullptr };
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
	}
	return list;
}

bool isEmpty(List *list)
{
	return list == nullptr;
}

string nameOfElement(List *list)
{
	return list->name;
}

string numberOfElement(List *list)
{
	return list->number;
}

List *nextOfList(List *list)
{
	List *temp = list->next;
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
	const int number = numberOfRecords(list);
	List *temp = list;
	for (int i = 0; i < number; ++i)
	{
		cout << nameOfElement(temp) << " - " << numberOfElement(temp) << endl;
		temp = nextOfList(temp);
	}
}

void nextNullptr(List *list)
{
	list->next = nullptr;
}

void nextTo(List *list, List *list2)
{
	list->next = list2;
}