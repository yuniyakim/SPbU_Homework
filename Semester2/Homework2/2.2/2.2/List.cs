using System;

namespace _2._2
{
    public class List
    { 
        public Node Head { get; set; }
        public int Length { get; set; }

        public bool IsEmpty => Length == 0;

        private bool IsContained(int position) => !(IsEmpty || position > Length || position < 1);

        public bool IsContainedByValue(string value)
        {
            var temp = Head;
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

        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                var temp = Head;
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

        public int PositionByValue(string value)
        {
            var temp = Head;
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

        public void Add(string value, int position)
        {
            if (IsEmpty)
            {
                Head = new Node(value);
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
                newElement.Next = Head;
                Head = newElement;
                ++Length;
            }
            else
            {
                var temp = Head;
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
                    Head = null;
                }
                else
                {
                    Head = Head.Next;
                }
            }
            else
            {
                var temp = Head;
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
            var temp = Head;
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
            var temp = Head;
            for (int i = 1; i < position; ++i)
            {
                temp = temp.Next;
            }
            temp.Value = value;
        }
    }
}