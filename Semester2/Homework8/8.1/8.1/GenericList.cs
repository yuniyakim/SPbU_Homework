using System;
using System.Collections.Generic;

namespace _8._1
{
    public class GenericList<T> : IList<T>
    {
        private Node head = null;
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Node of the list
        /// </summary>
        private class Node
        {
            public T value;
            public Node next;

            /// <summary>
            /// Node's constructor
            /// </summary>
            /// <param name="value">Node's value</param>
            public Node(T value)
            {
                this.value = value;
                next = null;
            }
        }

        /*/// <summary>
        /// Checks if the list is empty
        /// </summary>
        /// <returns></returns>
        private bool IsEmpty() => Count == 0;*/

        /// <summary>
        /// Checks if the list is read-only
        /// </summary>
        /// <returns></returns>
        public bool IsReadOnly() => false;

        /// <summary>
        /// Gets or sets the element at the specified position
        /// </summary>
        /// <param name="position">Specified position</param>
        /// <returns>Value of the element at the specified position</returns>
        public T this[int position]
        {
            get
            {
                if (position > Count || position <= 0)
                {
                    throw new InvalidPositionException();
                }

                var temp = head;
                for (int i = 1; i < position; ++i)
                {
                    temp = temp.next;
                }
                return temp.value;
            }
            set
            {
                if (position > Count || position <= 0)
                {
                    throw new InvalidPositionException();
                }

                var temp = head;
                for (int i = 1; i < position; ++i)
                {
                    temp = temp.next;
                }
                temp.value = value;
            }
        }

        /// <summary>
        /// Adds the value into the list
        /// </summary>
        /// <param name="value">Given value</param>
        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                var temp = head;
                for (int i = 1; i < Count; ++i)
                {
                    temp = temp.next;
                }
                temp.next = new Node(value);
            }
            ++Count;
        }

        /// <summary>
        /// Returns the index of a specified value
        /// </summary>
        /// <param name="value">Specified value</param>
        /// <returns>Index of a specified value</returns>
        public int IndexOf(T value)
        {
            var temp = head;
            for (int i = 1; i <= Count; ++i)
            {
                if (temp.value.Equals(value))
                {
                    return i;
                }
                if (temp != null)
                {
                    temp = temp.next;
                }
            }

            throw new UnexistingElementException();
        }
    }
}

// Переделать список на генерики. Список должен реализовывать интерфейс System.Collections.Generic.IList, 
// в том числе иметь энумератор, чтобы можно было по нему ходить foreach.