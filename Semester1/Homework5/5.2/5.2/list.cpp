#include "pch.h"
#include "list.h"
#include <iostream>
using namespace std;

void addElements(List *list, int const amount)
{
	if (amount != 0)
	{
		Node *newElement = new Node{ 1, nullptr };
		list->head = newElement;
		list->head->next = list->head;
		Node *temp = list->head;
		for (int i = 2; i <= amount; ++i)
		{
			Node *newElement = new Node{ i, list->head };
			temp->next = newElement;
			temp = temp->next;
		}
	}
}

int deleteElements(List *list, int const period)
{
	Node *temp = list->head;
	for (int i = amountOfElements(list); i > 1; --i)
	{
		for (int k = 1; k < period; ++k)
		{
			temp = temp->next;
		}
		if (temp->next == list->head) // убирать следующий за темп
		{		
			Node *tempHead = list->head;
			list->head = list->head->next;
			temp->next = list->head;
			delete tempHead;
		}
		else
		{
			Node *temp1 = temp->next; // если удаляемый элемент не корень!
			temp->next = temp1->next;
			delete temp1;
		}
	}
	return temp->initialPosition;
};

int amountOfElements(List *list)
{
	if (isEmpty(list))
	{
		return 0;
	}
	else
	{
		int amount = 1;
		Node *temp2 = list->head;
		while (temp2->next != list->head)
		{
			temp2 = temp2->next;
			++amount;
		}
		return amount;
		delete temp2;
	}
};

bool isEmpty(List *list)
{
	return (list->head == nullptr ? true : false);
}