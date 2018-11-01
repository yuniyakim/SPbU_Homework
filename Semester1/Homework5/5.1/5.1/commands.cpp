#include "pch.h"
#include "commands.h"
#include <iostream>
using namespace std;

void printCommands()
{
	cout << "0 Ц выйти\n1 Ц добавить значение в сортированный список\n2 Ц удалить значение из списка\n3 Ц распечатать список" << endl;
}

bool isElementContained(List *list, int inputValue)
{
	element *temp = list->head;
	while ((temp != NULL) && (temp->value > inputValue))
	{
		temp = temp->next;
	}
	if ((temp == NULL) || (temp->value != inputValue))
	{
		return 0;
	}
	else
	{
		return 1;
	}
}

void addValueIntoList(List *list, int inputValue)
{
	if ((list->head == NULL) || (list->head->next == NULL))
	{
		if (list->isEmpty == 1)
		{
			element *newElement = new element{ inputValue, nullptr };
			list->head = newElement;
			list->isEmpty = 0;
		}
		else
		{
			if (inputValue > list->head->value)
			{
				element *newElement = new element{ inputValue, list->head };
				list->head = newElement;
			}
			else
			{
				element *newElement = new element{ inputValue, nullptr };
				list->head->next = newElement;
			}
		}
	}
	else
	{
		
		if (inputValue >= list->head->value)
		{
			element *newElement = new element{ inputValue, list->head };
			list->head = newElement;
		}
		else
		{
			element *newElement = new element{ inputValue, nullptr };
			element *temp = list->head;
			while ((temp->next != NULL) && (temp->next->value >= inputValue))
			{
				temp = temp->next;
			}
			if (temp->next != NULL)
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
	if (isElementContained(list, inputValue))
	{
		element *temp = list->head;
		if (temp->value == inputValue)
		{
			if (list->head->next == NULL)
			{
				list->isEmpty = 1;
				list->head = NULL;
			}
			else
			{
				list->head = temp->next;
			}
			delete temp;

		}
		else
		{
			element *temp2 = list->head;
			while (temp->next->value != inputValue)
			{
				temp = temp->next;
			}
			temp2 = temp->next;
			temp->next = temp->next->next;
			delete temp2;
		}
		
	}
	else
	{
		cout << "ƒанное значение не содержитс€ в списке.\n" << endl;
	}
}

void printList(List *list)
{
	if (list->isEmpty != 1)
	{
		element *temp = list->head;
		while(temp != NULL)
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


