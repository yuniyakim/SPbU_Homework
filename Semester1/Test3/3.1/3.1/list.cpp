#include "pch.h"
#include "list.h"
#include <iostream>
using namespace std;

struct Element
{
	int value;
	int amount;
	Element *next;
};

struct List
{
	Element *head;
	bool isEmpty = true;
};

List *createList()
{
	return new List{ nullptr };
}

void addValueIntoList(List *list, int inputValue)
{
	if (!isElementContained(list, inputValue))
	{
		if ((list->head == nullptr) || (list->head->next == nullptr))
		{
			if (list->isEmpty)
			{
				Element *newElement = new Element{ inputValue, 1, nullptr };
				list->head = newElement;
				list->isEmpty = false;
			}
			else
			{
				if (inputValue < list->head->value)
				{
					Element *newElement = new Element{ inputValue, 1, list->head };
					list->head = newElement;
				}
				else
				{
					Element *newElement = new Element{ inputValue, 1, nullptr };
					list->head->next = newElement;
				}
			}
		}
		else
		{

			if (inputValue <= list->head->value)
			{
				Element *newElement = new Element{ inputValue, 1, list->head };
				list->head = newElement;
			}
			else
			{
				Element *newElement = new Element{ inputValue, 1, nullptr };
				Element *temp = list->head;
				while ((temp->next != nullptr) && (temp->next->value <= inputValue))
				{
					temp = temp->next;
				}
				if (temp->next != nullptr)
				{
					newElement->next = temp->next;
					temp->next = newElement;
				}
				else
				{
					temp->next = newElement;
				}
			}
		}
	}
	else
	{
		Element *temp = list->head;
		while (temp->value != inputValue)
		{
			temp = temp->next;
		}
		temp->amount++;
	}
}

bool isElementContained(List *list, int inputValue)
{
	Element *temp = list->head;
	while ((temp != nullptr) && (temp->value < inputValue))
	{
		temp = temp->next;
	}
	if ((temp == nullptr) || (temp->value != inputValue))
	{
		return false;
	}
	else return true;
}

void printList(List *list)
{
	if (!list->isEmpty)
	{
		Element *temp = list->head;
		while (temp != nullptr)
		{
			cout << temp->value << " " << temp->amount << endl;
			temp = temp->next;
		}
	}
	else
	{
		cout << "Список пуст.\n" << endl;
	}
}

void deleteList(List *list)
{
	while (list->head != nullptr)
	{
		Element *temp = list->head;
		list->head = list->head->next;
		delete temp;
	}
	delete list;
}