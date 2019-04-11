using System;

namespace _4._2
{
    /// <summary>
    /// List on the nodes
    /// </summary>
    public class List
    {
        private Node head = null;
        private int Length { get; set; }

        /// <summary>
        /// Node of the list
        /// </summary>
        private class Node
        {
            public string Value { get; set; }
            public Node Next { get; set; }

            /// <summary>
            /// Node's constructor
            /// </summary>
            /// <param name="value">Node's value</param>
            public Node(string value)
            {
                this.Value = value;
                Next = null;
            }
        }

        /// <summary>
        /// Checks if the list is empty
        /// </summary>
        /// <returns>True if the list is empty and false if it's not</returns>
        public bool IsEmpty => Length == 0;

        /// <summary>
        /// Checks if the element with given position is contained in the list
        /// </summary>
        /// <param name="position">Position on which containment is checked</param>
        /// <returns>True if the element is contained and false if it's not</returns>
        public bool IsContained(int position) => !(IsEmpty || position > Length || position < 1);

        /// <summary>
        /// Checks if the element with given value is contained in the list
        /// </summary>
        /// <param name="value">Value on which containment is checked</param>
        /// <returns>True if the element is contained and false if it's not</returns>
        public bool IsContainedByValue(string value)
        {
            var temp = head;
            for (int i = 1; i <= Length; ++i)
            {
                if (temp.Value == value)
                {
                    return true;
                }
                if (temp.Next != null)
                {
                    temp = temp.Next;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns element's position in the list by its' value
        /// </summary>
        /// <param name="value">Value by which position is searched</param>
        /// <returns>The position of the element</returns>
        public int PositionByValue(string value)
        {
            var temp = head;
            for (int i = 1; i <= Length; ++i)
            {
                if (temp.Value == value)
                {
                    return i;
                }
                temp = temp.Next;
            }
            return 0;
        }

        /// <summary>
        /// Prints the list
        /// </summary>
        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                var temp = head;
                for (int i = 0; i < Length; ++i)
                {
                    Console.WriteLine($"Value: {temp.Value}, position: {i}");
                    if (temp.Next != null)
                    {
                        temp = temp.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Adds the element into the list
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="position">Position on which the element must be added</param>
        public virtual void Add(string value, int position)
        {
            if (IsEmpty)
            {
                head = new Node(value);
                ++Length;
                return;
            }
            if (position > Length + 1 || position < 1)
            {
                throw new InvalidOperationException("Invalid position");
            }
            var newElement = new Node(value);
            if (position == 1)
            {
                newElement.Next = head;
                head = newElement;
                ++Length;
            }
            else
            {
                var temp = head;
                for (int i = 1; i < position - 1; ++i)
                {
                    if (temp.Next != null)
                    {
                        temp = temp.Next;
                    }
                }
                newElement.Next = temp.Next;
                temp.Next = newElement;
                ++Length;
            }
        }

        /// <summary>
        /// Deletes the element from the list
        /// </summary>
        /// <param name="position">Position by which deletion completes</param>
        public virtual void Delete(int position)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty");
            }
            if (!IsContained(position))
            {
                throw new InvalidOperationException("Invalid position");
            }
            if (position == 1)
            {
                if (Length == 1)
                {
                    head = null;
                }
                else
                {
                    head = head.Next;
                }
            }
            else
            {
                var temp = head;
                for (int i = 1; i < position - 1; ++i)
                {
                    temp = temp.Next;
                }
                if (position == Length)
                {
                    temp.Next = null;
                }
                else
                {
                    temp.Next = temp.Next.Next;
                }
            }
            --Length;
        }

        /// <summary>
        /// Gets the value of the element in the list by its' position
        /// </summary>
        /// <param name="position">Position by which value is searched</param>
        public string GetValue(int position)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty");
            }
            if (!IsContained(position))
            {
                throw new InvalidOperationException("Invalid position");
            }
            var temp = head;
            int currentPosition;
            for (currentPosition = 1; currentPosition < position; ++currentPosition)
            {
                temp = temp.Next;
            }
            return temp.Value;
        }

        /// <summary>
        /// Sets the element's value to given in the list by its' position
        /// </summary>
        /// <param name="value">Value that must replace the current</param>
        /// <param name="position">Position by which the needed element is searched</param>
        public void SetValue(string value, int position)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty");
            }
            if (!IsContained(position))
            {
                throw new InvalidOperationException("Invalid position");
            }
            var temp = head;
            for (int i = 1; i < position; ++i)
            {
                temp = temp.Next;
            }
            temp.Value = value;
        }
    }
}

/* Написать связный список в виде класса. От списка хочется:
- Добавлять/удалять элемент по произвольной позиции, задаваемой целым числом
- Узнавать размер, проверять на пустоту
- Получать или устанавливать значение элемента по позиции, задаваемой целым числом */
