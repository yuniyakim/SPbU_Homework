#include "pch.h"
#include "brackets.h"
#include "stack.h"
#include <iostream>
using namespace std;

bool isBrackets(char string[])
{
	Stack* stack = createStack();
	const int length = strlen(string);
	int i = 0;
	while (i < length)
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
		deleteStack(stack);
		return true;
	}
	else
	{
		deleteStack(stack);
		return false;
	}
}