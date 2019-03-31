using System;

namespace _2._1
{
    public class List
    {
        private Node head = null;
        public int length { get; set; }

        private class Node
        {
            public Node(string value)
            {
                this.value = value;
                next = null;
            }

            public string value { get; set; }
            public Node next { get; set; }
        }

        public List()
        {
        }

        public bool IsEmpty => length == 0;

        private bool IsContained(int position) => !(IsEmpty || position > length || position < 1);

        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                var temp = head;
                for (int i = 0; i < length; ++i)
                {
                    Console.WriteLine($"Value: {temp.value}, position: {i}");
                    if (temp.next != null)
                    {
                        temp = temp.next;
                    }
                }
            }
        }

        public void Add(string value, int position)
        {
            if (IsEmpty)
            {
                head = new Node(value);
                ++length;
            }
            else if (position > length + 1 || position < 1)
            {
                Console.WriteLine("Invalid position");
            }
            else
            {
                var newElement = new Node(value);
                if (position == 1)
                {
                    newElement.next = head;
                    head = newElement;
                    ++length;
                }
                else
                {
                    var temp = head;
                    for (int i = 1; i < position - 1; ++i)
                    {
                        if (temp.next != null)
                        {
                            temp = temp.next;
                        }
                    }
                    newElement.next = temp.next;
                    temp.next = newElement;
                    ++length;
                }
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
                    if (length == 1)
                    {
                        head = null;
                    }
                    else
                    {
                        head = head.next;
                    }
                }
                else
                {
                    var temp = head;
                    for (int i = 1; i < position - 1; ++i)
                    {
                        temp = temp.next;
                    }
                    if (position == length)
                    {
                        temp.next = null;
                    }
                    else
                    {
                        temp.next = temp.next.next;
                    }
                }
                --length;
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
                var temp = head;
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
                var temp = head;
                for (int i = 1; i < position; ++i)
                {
                    temp = temp.next;
                }
                temp.value = value;
            }
        }
    }
}