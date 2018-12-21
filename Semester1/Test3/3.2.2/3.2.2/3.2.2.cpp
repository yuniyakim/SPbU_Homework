#include "pch.h"
#include <iostream>
#include "queue.h"
using namespace std;

int main()
{
	Queue *queue = createQueue();
	queue = enqueue(queue, 10, 2);
	queue = enqueue(queue, 8, 3);
	queue = enqueue(queue, 1, 5);
	queue = enqueue(queue, 14, 2);
	queue = enqueue(queue, 4, -4);
	queue = enqueue(queue, 24, 1);
	queue = enqueue(queue, 16, 2);

	cout << dequeue(queue) << endl;
	cout << dequeue(queue) << endl;
	cout << dequeue(queue) << endl;
	cout << dequeue(queue) << endl;
	cout << dequeue(queue) << endl;
	cout << dequeue(queue) << endl;
	cout << dequeue(queue) << endl;
	cout << dequeue(queue) << endl;

	deleteQueue(queue);
	return 0;
}

// Реализовать очередь с приоритетами в виде отдельного модуля. 
// Модуль должен иметь функцию enqueue(), принимающую на вход значение и численный приоритет, и функцию dequeue(), 
// возвращающую значение с наивысшим приоритетом и удаляющую его из очереди. Если очередь пуста, dequeue() должен возвращать -1.