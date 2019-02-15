#include "pch.h"
#include <iostream>
#include "queue.h"
using namespace std;

struct Element
{
	int value;
	int priority;
	Element *next; // in front
	Element *previous; // behind
};

struct Queue
{
	Element *head;
	Element *tail;
	int maxPriority;
};

Queue *createQueue()
{
	return new Queue{ nullptr };
}

bool isEmpty(Queue *queue)
{
	return queue->head == nullptr;
}

Queue *enqueue(Queue *queue, int value, int priority)
{
	if (priority < 0)
	{
		cout << "Error adding value with priority < 0" << endl;
		return queue;
	}

	Element *newElement = new Element{ value, priority, queue->tail, nullptr };
	if (isEmpty(queue))
	{
		queue->head = newElement;
		queue->tail = newElement;
		queue->maxPriority = priority;
	}
	else
	{
		Element *current = queue->head;
		while (current->previous != nullptr)
		{
			current = current->previous;
		}
		if (newElement->priority > queue->maxPriority)
		{
			queue->maxPriority = newElement->priority;
		}
		current->previous = newElement;
		newElement->next = current;
		queue->tail = newElement;
	}
	return queue;
}

int dequeue(Queue *queue)
{
	if (isEmpty(queue))
	{
		return -1;
	}
	
	Element *needed = queue->head;
	while (needed->priority != queue->maxPriority)
	{
		needed = needed->previous;
	}
	
	if ((needed == queue->tail) && (needed == queue->head))
	{
		int value = needed->value;
		delete needed;
		queue->head = nullptr;
		queue->tail = nullptr;
		queue->maxPriority = -1;
		return value;
	}
	else if (needed == queue->tail)
	{
		queue->tail = needed->next;
		needed->next->previous = nullptr;
	}
	else if (needed == queue->head)
	{
		queue->head = needed->previous;
		needed->previous->next = nullptr;
	}
	else
	{
		needed->next->previous = needed->previous;
		needed->previous->next = needed->next;
	}

	int maximumPriority = -1;
	Element *current = queue->head;
	while (current != nullptr)
	{
		if (maximumPriority < current->priority)
		{
			maximumPriority = current->priority;
		}
		current = current->previous;
	}
	queue->maxPriority = maximumPriority;

	int value = needed->value;
	delete needed;
	return value;
}

void deleteQueue(Queue *queue)
{
	if (!isEmpty(queue))
	{
		Element *current = queue->head;
		while (current != nullptr)
		{
			Element *temp = current;
			current = current->previous;
			delete temp;
		}
	}
	delete queue;
}
// Модуль должен иметь функцию enqueue(), принимающую на вход значение и численный приоритет, и функцию dequeue(), 
// возвращающую значение с наивысшим приоритетом и удаляющую его из очереди. Если очередь пуста, dequeue() должен возвращать -1.