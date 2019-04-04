using System;

namespace _2._1
{
    public class List
    {
        private Node head = null;
        public int Length { get; set; }

        private class Node
        {
            public Node(string value)
            {
                this.Value = value;
                Next = null;
            }

            public string Value { get; set; }
            public Node Next { get; set; }
        }

        public bool IsEmpty => Length == 0;

        private bool IsContained(int position) => !(IsEmpty || position > Length || position < 1);

        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
                return;
            }
            var temp = head;
            for (int i = 1; i <= Length; ++i)
            {
                Console.WriteLine($"Value: {temp.Value}, position: {i}");
                if (temp.Next != null)
                {
                    temp = temp.Next;
                }
            }
        }

        public void Add(string value, int position)
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

        public void Delete(int position)
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