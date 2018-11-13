#include "pch.h"
#include "brackets.h"
#include "stack.h"
#include <iostream>
using namespace std;

int lengthOfLine(char string[])
{
	int i = 0;
	while (string[i] != '\0') 
	{
		++i;
	}
	return i;
}

bool brackets(char string[])
{
	Stack* stack = createStack();
	int i = 0;
	while (i < lengthOfLine(string))
	{
		if ((string[i] == '(') || (string[i] == '[') || (string[i] == '{'))
		{
			push(stack, string[i]);
		}
		else if (stack->head == nullptr)
		{
			return false;
		}
		else if (((string[i] == ')') && (stack->head->value == '(')) || ((string[i] == ']') && (stack->head->value == '[')) || ((string[i] == '}') && (stack->head->value == '{')))
		{
			deleteHead(stack);
		}
		else return false;
		++i;
	}
	if (isEmpty(stack))
	{
		delete(stack);
		return true;
	}
	else
	{
		deleteStack(stack);
		return false;
	}
}