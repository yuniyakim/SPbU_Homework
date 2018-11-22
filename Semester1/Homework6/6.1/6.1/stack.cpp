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

void push(Stack* stack, int value)
{
	Element *element = new Element{ value, stack->head };
	stack->head = element;
} 

int pop(Stack* stack)
{
	if (stack->head != nullptr)
	{
		int const value = stack->head->value;
		Element *temp = stack->head->next;
		delete stack->head;
		stack->head = temp;
		return value;
	}
	else
	{
		cout << "Стек пуст. Ошибка." << endl;
	}
}

bool isEmpty(Stack* stack)
{
	return stack->head == nullptr;
}