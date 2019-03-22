#include "pch.h"
#include "list.h"
#include <iostream>
#include <string>
using namespace std;

struct List
{
	string key;
	int amount;
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

List *addIntoList(List *list, const string &key)
{
	List *newList = new List{ key, 1, nullptr };
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

std::string keyOfElement(List *list)
{
	return list->key;
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
	List *temp = list;
	while (temp != nullptr)
	{
		cout << keyOfElement(temp) << " ";
		temp = nextOfList(temp);
	}
}

void increaseAmount(List *list)
{
	list->amount++;
}

int amountOfList(List *list)
{
	return list->amount;
}