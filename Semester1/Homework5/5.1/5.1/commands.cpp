#include "pch.h"
#include "commands.h"
#include <iostream>
using namespace std;

void printCommands()
{
	cout << "0 Ц выйти\n";
	cout << "1 Ц добавить значение в сортированный список\n";
	cout << "2 Ц удалить значение из списка\n";
	cout << "3 Ц распечатать список" << endl;
}

bool isElementContained(List *list, int inputValue)
{
	Element *temp = list->head;
	while ((temp != nullptr) && (temp->value > inputValue))
	{
		temp = temp->next;
	}
	return (temp != nullptr) && (temp->value == inputValue);
}

void addValueIntoList(List *list, int inputValue)
{
	if ((list->head == nullptr) || (list->head->next == nullptr))
	{
		if (list->isEmpty)
		{
			Element *newElement = new Element{ inputValue, nullptr };
			list->head = newElement;
			list->isEmpty = false;
		}
		else
		{
			if (inputValue > list->head->value)
			{
				Element *newElement = new Element{ inputValue, list->head };
				list->head = newElement;
			}
			else
			{
				Element *newElement = new Element{ inputValue, nullptr };
				list->head->next = newElement;
			}
		}
	}
	else
	{
		
		if (inputValue >= list->head->value)
		{
			Element *newElement = new Element{ inputValue, list->head };
			list->head = newElement;
		}
		else
		{
			Element *newElement = new Element{ inputValue, nullptr };
			Element *temp = list->head;
			while ((temp->next != nullptr) && (temp->next->value >= inputValue))
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

void deleteValueFromList(List *list, int inputValue)
{
	if (!isElementContained(list, inputValue))
	{
		cout << "ƒанное значение не содержитс€ в списке.\n" << endl;
		return;
	}
	Element *temp = list->head;
	if (temp->value == inputValue)
	{
		if (list->head->next == nullptr)
		{
			list->isEmpty = true;
			list->head = nullptr;
		}
		else
		{
			list->head = temp->next;
		}
		delete temp;
	}
	else
	{
		while (temp->next->value != inputValue)
		{
			temp = temp->next;
		}
		Element *temp2 = temp->next;
		temp->next = temp->next->next;
		delete temp2;
	}	
}

void printList(List *list)
{
	if (!list->isEmpty)
	{
		Element *temp = list->head;
		while (temp != nullptr)
		{
			cout << temp->value << " ";
			temp = temp->next;
		}
		cout << "\n" << endl;
	}
	else
	{
		cout << "—писок пуст.\n" << endl;
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
