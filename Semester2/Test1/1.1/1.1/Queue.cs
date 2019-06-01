using System;

namespace _1._1
{
    /// <summary>
    /// Priority queue's class
    /// </summary>
    public class Queue
    {
        private Node head = null;
        private Node tail = null;

        /// <summary>
        /// Node of the list
        /// </summary>
        private class Node
        {
            public string Value { get; }
            public int Priority { get; }
            public Node Next { get; set; }

            /// <summary>
            /// Node's constructor
            /// </summary>
            /// <param name="value">Node's value</param>
            public Node(string value, int priority)
            {
                this.Value = value;
                this.Priority = priority;
                Next = null;
            }
        }

        /// <summary>
        /// Checks if the queue is empty
        /// </summary>
        /// <returns>True if the queue is empty and false if it's not</returns>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// Enqueues a value into the queue
        /// </summary>
        /// <param name="value">Value of given element</param>
        /// <param name="priority">Priority of given element</param>
        public void Enqueue(string value, int priority)
        {
            var newNode = new Node(value, priority);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        /// <summary>
        /// Defines the value of highest priority in the queue
        /// </summary>
        /// <returns>Value of highest priority in the queue</returns>
        public int HighestPriority()
        {
            if (IsEmpty())
            {
                throw new EmptyQueueException("Queue is empty");
            }

            var current = head;
            var priority = head.Priority;
            while (current.Next != null)
            {
                if (priority < current.Priority)
                {
                    priority = current.Priority;
                }
                current = current.Next;
            }
            if (priority < current.Priority)
            {
                priority = current.Priority;
            }
            return priority;
        }

        /// <summary>
        /// Defines the position of element with highest priority in the queue
        /// </summary>
        /// <returns>Position of element with highest priority in the queue</returns>
        public int HighestPriorityPosition()
        {
            if (IsEmpty())
            {
                throw new EmptyQueueException("Queue is empty");
            }

            var current = head;
            var counter = 1;
            var maxPriority = HighestPriority();
            while (current.Priority != maxPriority)
            {
                current = current.Next;
                ++counter;
            }
            return counter;
        }

        /// <summary>
        /// Dequeues a value with highest priority
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            if (IsEmpty())
            {
                throw new EmptyQueueException("Queue is empty");
            }

            var current = head;
            int position = HighestPriorityPosition();

            if (position == 1)
            {
                head = head.Next;
                return current.Value;
            }

            for (int i = 1; i < position - 1; ++i)
            {
                current = current.Next;
            }
            var value = current.Next.Value;
            current.Next = current.Next.Next;
            return value;
        }
    }
}

// Реализовать очередь с приоритетами. Очередь должна иметь метод Enqueue(), принимающий на вход значение и численный приоритет, 
// и метод Dequeue(), возвращающий значение с наивысшим приоритетом и удаляющий его из очереди. 
// Тип хранимых значений -- любой. Если очередь пуста, Dequeue() должен бросать исключение. Комментарии и юнит-тесты обязательны.