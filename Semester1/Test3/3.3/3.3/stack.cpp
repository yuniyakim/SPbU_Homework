#include "pch.h"
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

void push(Stack* stack, char value)
{
	if (isEmptyStack(stack))
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
	const int value = stack->head->value;
	Element *temp = stack->head->next;
	delete stack->head;
	stack->head = temp;
	return value;
}

bool isEmptyStack(Stack* stack)
{
	return stack->head == nullptr;
}

void deleteHead(Stack* stack)
{
	Element *temp = stack->head->next;
	delete stack->head;
	stack->head = temp;
}

char valueOfHead(Stack* stack)
{
	return stack->head->value;
}

bool existsStack(Stack *stack, int value)
{
	if (isEmptyStack(stack))
	{
		return false;
	}

	Element *temp = stack->head;
	while (temp != nullptr)
	{
		if (value == temp->value)
		{
			return true;
		}
		temp = temp->next;
	}
	return false;
}