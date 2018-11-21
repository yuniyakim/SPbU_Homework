#include "pch.h"
#include "stack.h"
#include "fromInfixIntoPostfix.h"
#include <iostream>
using namespace std;

<<<<<<< HEAD
struct Element
{
	char value;
	Element *next;
};

struct Stack
{
	Element *head;
};
=======
int lengthOfLine(char string[])
{
	int i = 0;
	while (string[i] != '\0')
	{
		++i;
	}
	return i;
}
>>>>>>> 4cdc42aecbcc09b17a1336d6df2cd0155eb09127

bool isMultiplicationOrDivision(char symbol)
{
	if ((symbol == '*') || (symbol == '/'))
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool isAdditionOrSubtraction(char symbol)
{
	if ((symbol == '+') || (symbol == '-'))
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool isAnOpeningBracket(char symbol)
{
	if (symbol == '(')
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool isAClosingBracket(char symbol)
{
	if (symbol == ')')
	{
		return true;
	}
	else
	{
		return false;
	}
}

void fromInfixIntoPostfix(char input[], char output[])
{
	Stack* stack = createStack();
	int i = 0;
<<<<<<< HEAD
	const int length = strlen(input);
	int outputString = 0;
	while (i < length)
=======
	int outputString = 0;
	while (i < lengthOfLine(input))
>>>>>>> 4cdc42aecbcc09b17a1336d6df2cd0155eb09127
	{
		if (isdigit(input[i]) && isdigit(input[i + 1]))
		{
			output[outputString] = input[i];
			++outputString;
		}
		else if (isdigit(input[i]))
		{
			output[outputString] = input[i];
			++outputString;
			output[outputString] = ' ';
			++outputString;
		}	
		else if ((isAdditionOrSubtraction(input[i])) || (isMultiplicationOrDivision(input[i])))
		{
			if (isAdditionOrSubtraction(input[i]) && !isEmpty(stack) && isMultiplicationOrDivision(stack->head->value))
			{ 
				output[outputString] = pop(stack);
				++outputString;
				output[outputString] = ' ';
				++outputString;
			}
			push(stack, input[i]);
		}
		else if (isAnOpeningBracket(input[i]))
		{
			push(stack, input[i]);
		}
		else if (isAClosingBracket(input[i]))
		{
			while (!isAnOpeningBracket(stack->head->value))
			{
				output[outputString] = pop(stack);
				++outputString;
				output[outputString] = ' ';
				++outputString;
			}
			deleteHead(stack);
		}
		++i;
	}

	while (!isEmpty(stack))
	{
		output[outputString] = pop(stack);
		++outputString;
		output[outputString] = ' ';
		++outputString;
	}

<<<<<<< HEAD
	deleteStack(stack);
=======
	delete(stack);
>>>>>>> 4cdc42aecbcc09b17a1336d6df2cd0155eb09127
}