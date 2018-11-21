#pragma once

<<<<<<< HEAD
// an element
struct Element;

// a stack
struct Stack;
=======
// structure of an element
struct Element
{
	char value;
	Element *next;
};

// structure of a stack itself
struct Stack
{
	Element *head;
};
>>>>>>> 4cdc42aecbcc09b17a1336d6df2cd0155eb09127

// creates a new stack
Stack* createStack();

// deletes a stack and all its' elements
void deleteStack(Stack* stack);

// puts incoming value into the head of a stack
void push(Stack* stack, char value);

// returns a value from the head of a stack and deletes it
char pop(Stack* stack);

// checks if a stack is empty
bool isEmpty(Stack* stack);

// deletes an element in the head of a stack
void deleteHead(Stack* stack);