#include "pch.h"
#include "postfix.h"
#include "stack.h"
#include <iostream>
using namespace std;

int lengthOfLine(char string[])
{
	int i = 0;
	while ((string[i] != '\0') || (string[i + 1] != '\0'))
	{
		++i;
	}
	return i;
}

int postfix(char string[]) // works only with single digits
{
	Stack* stack = createStack();
	int i = 0;
	while (i < lengthOfLine(string))
	{
		if ((string[i] != '+') && (string[i] != '-') && (string[i] != '*') && (string[i] != '/') && (string[i] != ' '))
		{
			int value = string[i] - 48;
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