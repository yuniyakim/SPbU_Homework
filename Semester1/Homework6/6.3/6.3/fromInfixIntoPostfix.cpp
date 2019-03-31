#include "pch.h"
#include "stack.h"
#include "fromInfixIntoPostfix.h"
#include <iostream>
using namespace std;

bool isMultiplicationOrDivision(char symbol)
{
	return ((symbol == '*') || (symbol == '/'));
}

bool isAdditionOrSubtraction(char symbol)
{
	return ((symbol == '+') || (symbol == '-'));
}

bool isAnOpeningBracket(char symbol)
{
	return symbol == '(';
}

bool isAClosingBracket(char symbol)
{
	return symbol == ')';
}

void fromInfixIntoPostfix(char input[], char output[])
{
	Stack* stack = createStack();
	int i = 0;
	const int length = strlen(input);
	int outputString = 0;
	while (i < length)
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
			while (!isEmpty(stack) && (isAdditionOrSubtraction(valueOfHead(stack)) || isMultiplicationOrDivision(valueOfHead(stack))) 
				&& ((isAdditionOrSubtraction(input[i]) || isMultiplicationOrDivision(input[i])) && isMultiplicationOrDivision(valueOfHead(stack))))
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
			while (!isAnOpeningBracket(valueOfHead(stack)))
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

	deleteStack(stack);
}