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
                if (temp.value == value)
                {
                    return true;
                }
                if (temp.next != null)
                {
                    temp = temp.next;
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
                    Console.WriteLine($"Value: {temp.value}, position: {i}");
                    if (temp.next != null)
                    {
                        temp = temp.next;
                    }
                }
            }
        }
        public int PositionByValue(string value)
        {
            var temp = Head;
            for (int i = 1; i <= Length; ++i)
            {
                if (temp.value == value)
                {
                    return i;
                }
                temp = temp.next;
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
                newElement.next = Head;
                Head = newElement;
                ++Length;
            }
            else
            {
                var temp = Head;
                for (int i = 1; i < position - 1; ++i)
                {
                    if (temp.next != null)
                    {
                        temp = temp.next;
                    }
                }
                newElement.next = temp.next;
                temp.next = newElement;
                ++Length;
            }
        }

        public void Delete(int position)
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
            }
            else if (!IsContained(position))
            {
                Console.WriteLine("Invalid position");
            }
            else
            {
                if (position == 1)
                {
                    if (Length == 1)
                    {
                        Head = null;
                    }
                    else
                    {
                        Head = Head.next;
                    }
                }
                else
                {
                    var temp = Head;
                    for (int i = 1; i < position - 1; ++i)
                    {
                        temp = temp.next;
                    }
                    if (position == Length)
                    {
                        temp.next = null;
                    }
                    else
                    {
                        temp.next = temp.next.next;
                    }
                }
                --Length;
            }
        }

        public void PrintValueByPosition(int position)
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
            }
            else if (!IsContained(position))
            {
                Console.WriteLine("Invalid position");
            }
            else
            {
                var temp = Head;
                int currentPosition;
                for (currentPosition = 1; currentPosition < position; ++currentPosition)
                {
                    temp = temp.next;
                }
                Console.WriteLine($"Value: {temp.value}, position: {currentPosition}");
            }
        }

        public void SetValue(string value, int position)
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
            }
            else if (!IsContained(position))
            {
                Console.WriteLine("Invalid position");
            }
            else
            {
                var temp = Head;
                for (int i = 1; i < position; ++i)
                {
                    temp = temp.next;
                }
                temp.value = value;
            }
        }
    }
}