#include "pch.h"
#include "postfix.h"
#include "stack.h"
#include <iostream>
using namespace std;

struct Element
{
	int value;
	Element *next;
};

struct Stack
{
	Element *head;
};

int postfix(char string[]) // works only with single digits
{
	Stack* stack = createStack();
	int i = 0;
	const int length = strlen(string);
	while (i < length)
	{
		if ((string[i] != '+') && (string[i] != '-') && (string[i] != '*') && (string[i] != '/') && (string[i] != ' '))
		{
			const int value = string[i] - '0';
			push(stack, value);
		}
		else
		{		
			if (string[i] != ' ')
			{
				switch (string[i])
				{
				case '+':
				{
					stack->head->value = stack->head->next->value + stack->head->value;
					break;
				}

				case '-':
				{
					stack->head->value = stack->head->next->value - stack->head->value;
					break;
				}
				case '*':
				{
					stack->head->value = stack->head->next->value * stack->head->value;
					break;
				}
				case '/':
				{
					stack->head->value = stack->head->next->value / stack->head->value;
					break;
				}
				}
				Element *temp = stack->head->next;
				stack->head->next = stack->head->next->next;
				delete temp;
			}
		}
		++i;
	}
	int const result = pop(stack);
	deleteStack(stack);
	return result;
}