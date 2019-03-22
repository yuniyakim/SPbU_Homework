#pragma once

// a stack
struct Stack;

// creates a new stack
Stack* createStack();

// deletes a stack and all its' elements
void deleteStack(Stack* stack);

// puts incoming value into the head of a stack
void push(Stack* stack, char value);

// returns a value from the head of a stack and deletes it
int pop(Stack* stack);

// checks if a stack is empty
bool isEmptyStack(Stack* stack);

// deletes an element in the head of a stack
void deleteHead(Stack* stack);

// returns a valur from the head
char valueOfHead(Stack* stack);

// checks if a value exists in a stack
bool existsStack(Stack *stack, int value);