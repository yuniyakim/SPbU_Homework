#include "pch.h"
#include "postfix.h"
#include "stack.h"
#include "arithmetic.h"
#include <iostream>
using namespace std;

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
					addition(stack);
					break;
				}

				case '-':
				{
					subtraction(stack);
					break;
				}
				case '*':
				{
					multiplication(stack);
					break;
				}
				case '/':
				{
					division(stack);
					break;
				}
				}
				//Element *temp = stack->head->next;
				//stack->head->next = stack->head->next->next;
				//delete temp;
			}
		}
		++i;
	}
	int const result = pop(stack);
	deleteStack(stack);
	return result;
}