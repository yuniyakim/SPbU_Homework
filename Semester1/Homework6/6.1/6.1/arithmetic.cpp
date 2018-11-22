#include "pch.h"
#include "arithmetic.h"
#include "stack.h"
#include <iostream>
using namespace std;

void addition(Stack * stack)
{
	int sum = pop(stack) + pop(stack);
	push(stack, sum);
};

void subtraction(Stack* stack)
{
	int number1 = pop(stack);
	int number2 = pop(stack);
	int diff = number2 - number1;
	push(stack, diff);
};

void multiplication(Stack* stack)
{
	int prod = pop(stack) * pop(stack);
	push(stack, prod);
};

void division(Stack* stack)
{
	int number1 = pop(stack);
	int number2 = pop(stack); 
	int quot = number2 / number1;
	push(stack, quot);
};

