using System;

namespace _3._2
{
    /// <summary>
    /// List on the nodes
    /// </summary>
    public class List
    {
        /// <summary>
        /// Constructor of the list
        /// </summary>
        public List()
        {
            head = null;
            Length = 0;
        }

        /// <summary>
        /// Checks if the list is empty
        /// </summary>
        /// <returns>True if the list is empty and false if it's not</returns>
        public bool IsEmpty { get => Length == 0; }

        /// <summary>
        /// Checks if the element with given position is contained in the list
        /// </summary>
        /// <param name="position">Position on which containment is checked</param>
        /// <returns>True if the element is contained and false if it's not</returns>
        public bool IsContainedByPosition(int position)
        {
            return !(IsEmpty || position > Length || position < 1);
        }

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
                    Console.WriteLine($"Value: {temp.Value}, position: {temp.Position}");
                    if (temp.Next != null)
                    {
                        temp = temp.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Renumbers positions of elements in the list
        /// </summary>
        private void Renumbering()
        {
            var temp = head;
            for (int i = 1; i <= Length; ++i)
            {
                temp.Position = i;
                if (temp.Next != null)
                {
                    temp = temp.Next;
                }
            }
        }

        /// <summary>
        /// Adds the element into the list
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="position">Position on which the element must be added</param>
        public void Push(string value, int position)
        {
            if (IsEmpty)
            {
                head = new Node(value, 1);
                ++Length;
            }
            else if (position > Length + 1 || position < 1)
            {
                throw new InvalidOperationException("List overflow");
            }
            else
            {
                var newElement = new Node(value, position);
                if (position == 1)
                {
                    newElement.Next = head;
                    head = newElement;
                    ++Length;
                    Renumbering();
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
                    Renumbering();
                }
            }
        }

        /// <summary>
        /// Deletes the element from the list
        /// </summary>
        /// <param name="position">Position by which deletion completes</param>
        public void Delete(int position)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty");
            }
            else if (!IsContainedByPosition(position))
            {
                throw new InvalidOperationException("List overflow");
            }
            else
            {
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
                Renumbering();
            }
        }

        /// <summary>
        /// Gets the value of the element in the list by its' position
        /// </summary>
        /// <param name="position">Position by which value is searched</param>
        public void GetValue(int position)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty");
            }
            else if (!IsContainedByPosition(position))
            {
                throw new InvalidOperationException("List overflow");
            }
            else
            {
                var temp = head;
                for (int i = 1; i < position; ++i)
                {
                    temp = temp.Next;
                }
                Console.WriteLine($"Value: {temp.Value}, position: {temp.Position}");
            }
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
            else if (!IsContainedByPosition(position))
            {
                throw new InvalidOperationException("List overflow");
            }
            else
            {
                var temp = head;
                for (int i = 1; i < position; ++i)
                {
                    temp = temp.Next;
                }
                temp.Value = value;
            }
        }

        private Node head;
        public int Length { get; set; }
    }
}