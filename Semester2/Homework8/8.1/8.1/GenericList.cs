using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._1
{
    /// <summary>
    /// Generic list's class with specified type of values
    /// </summary>
    /// <typeparam name="T">Type of values</typeparam>
    public class GenericList<T> : IList<T>
    {
        private Node head = null;
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Node of the list
        /// </summary>
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            /// <summary>
            /// Node's constructor
            /// </summary>
            /// <param name="value">Node's value</param>
            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        /// <summary>
        /// Checks if the list is read-only
        /// </summary>
        /// <returns>False</returns>
        public bool IsReadOnly => false;

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
                    temp = temp.Next;
                }
                return temp.Value;
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
                    temp = temp.Next;
                }
                temp.Value = value;
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
                    temp = temp.Next;
                }
                temp.Next = new Node(value);
            }
            ++Count;
        }

        /// <summary>
        /// Inserts an element with given value to the specified position
        /// </summary>
        /// <param name="position">Specified position</param>
        /// <param name="value">Given value</param>
        public void Insert(int position, T value)
        {
            if (position > Count + 1 || position <= 0)
            {
                throw new InvalidPositionException();
            }

            var newNode = new Node(value);
            if (position == 1)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                var temp = head;
                for (int i = 1; i < position - 1; ++i)
                {
                    temp = temp.Next;
                }
                newNode.Next = temp.Next;
                temp.Next = newNode;
            }
            ++Count;
        }

        /// <summary>
        /// Returns the index of a specific value
        /// </summary>
        /// <param name="value">Specific value</param>
        /// <returns>Index of a specific value</returns>
        public int IndexOf(T value)
        {
            var temp = head;
            for (int i = 1; i <= Count; ++i)
            {
                if (temp.Value.Equals(value))
                {
                    return i;
                }
                temp = temp.Next;
            }

            return -1;
        }

        /// <summary>
        /// Checks if the specific value is contained in the list
        /// </summary>
        /// <param name="value">Specific value</param>
        /// <returns>True if contained, false otherwise</returns>
        public bool Contains(T value)
        {
            if (IndexOf(value) == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Removes the element on the specified position
        /// </summary>
        /// <param name="position">Specified position</param>
        public void RemoveAt(int position)
        {
            if (position > Count || position <= 0)
            {
                throw new InvalidPositionException();
            }

            if (position == 1)
            {
                head = head.Next;
            }
            else
            {
                var temp = head;
                for (int i = 1; i < position - 1; ++i)
                {
                    temp = temp.Next;
                }
                temp.Next = temp.Next.Next;
            }

            --Count;
        }

        /// <summary>
        /// Removes the element with the specific value
        /// </summary>
        /// <param name="value">Specific value</param>
        /// <returns>True if succeeded, false otherwise</returns>
        public bool Remove(T value)
        {
            var position = IndexOf(value);
            if (position == -1)
            {
                return false;
            }

            RemoveAt(position);
            return true;
        }

        /// <summary>
        /// Clears the list
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Copies list's elements to the specified array, starting at a particular array's position
        /// </summary>
        /// <param name="array">Specified array</param>
        /// <param name="position">Starting position</param>
        public void CopyTo(T[] array, int position)
        {
            var temp = head;
            for (int i = position; i <= Count; ++i)
            {
                array[i] = temp.Value;
                temp = temp.Next;
            }
        }

        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns>List enumerator</returns>
        public IEnumerator<T> GetEnumerator() => new ListEnumerator(this);

        /// <summary>
        /// Gets object-enumerator
        /// </summary>
        /// <returns>Object-enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// List enumerator
        /// </summary>
        private class ListEnumerator : IEnumerator<T>
        {
            private GenericList<T> list;
            private Node current = null;

            /// <summary>
            /// List enumerator's constructor
            /// </summary>
            /// <param name="list">Given list</param>
            public ListEnumerator(GenericList<T> list)
            {
                this.list = list;
            }

            /// <summary>
            /// Gets the current element
            /// </summary>
            object IEnumerator.Current => current;

            /// <summary>
            /// Gets the value of the current element
            /// </summary>
            public T Current => current.Value;

            /// <summary>
            /// Moves to the next element in the list
            /// </summary>
            /// <returns>True if succeeded, false otherwise</returns>
            public bool MoveNext()
            {
                if (current == null)
                {
                    if (list.head == null)
                    {
                        return false;
                    }

                    current = list.head;
                    return true;
                }

                if (current.Next == null)
                {
                    return false;
                }

                current = current.Next;
                return true;
            }

            /// <summary>
            /// Sets enumerator to its initial position
            /// </summary>
            public void Reset() => current = null;

            /// <summary>
            /// Disposes
            /// </summary>
            public void Dispose()
            {
            }
        }
    }
}

// Переделать список на генерики. Список должен реализовывать интерфейс System.Collections.Generic.IList, 
// в том числе иметь энумератор, чтобы можно было по нему ходить foreach.