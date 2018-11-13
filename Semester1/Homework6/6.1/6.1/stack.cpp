#include "pch.h"
#include "stack.h"
#include <iostream>
using namespace std;

Stack* createStack()
{
	return new Stack{ nullptr };
}

void deleteStack(Stack* stack)
{
	while (stack->head != nullptr) 
	{
		Element *temp = stack->head->next;
		delete stack->head;
		stack->head = temp;
	}
	delete stack;
}

void push(Stack* stack, int value)
{
	if (isEmpty(stack))
	{
		Element *head = new Element{ value, nullptr };
		stack->head = head;
	}
	else
	{
		Element *element = new Element{ value, stack->head };
		stack->head = element;
	}
}

int pop(Stack* stack)
{
	int const value = stack->head->value;
	Element *temp = stack->head->next;
	delete stack->head;
	stack->head = temp;
	return value;
}

bool isEmpty(Stack* stack)
{
	return stack->head == nullptr;
}