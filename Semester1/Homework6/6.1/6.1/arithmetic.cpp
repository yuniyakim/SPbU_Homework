#include "pch.h"
#include "arithmetic.h"
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

void addition(Stack * stack)
{
	stack->head->value = stack->head->next->value + stack->head->value;
};

void subtraction(Stack* stack)
{
	stack->head->value = stack->head->next->value - stack->head->value;
};

void multiplication(Stack* stack)
{
	stack->head->value = stack->head->next->value * stack->head->value;
};

void division(Stack* stack)
{
	stack->head->value = stack->head->next->value / stack->head->value;
};

