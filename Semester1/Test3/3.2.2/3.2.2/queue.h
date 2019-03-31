#pragma once

// structure queue
struct Queue;

// creates a queue
Queue *createQueue();

// adds a value into a queue
Queue *enqueue(Queue *queue, int value, int priority);

// deletes an element with max priority and returns its' value
int dequeue(Queue *queue);

// deletes a queue
void deleteQueue(Queue *queue);