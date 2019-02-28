using System;

namespace _2._2
{
    class List
    {
        public List()
        {
            head = null;
            length = 0;
        }

        public bool IsEmpty()
        {
            return length == 0;
        }

        public bool IsContainedByPosition(int position)
        {
            return !(IsEmpty() || position > length || position < 1);
        }

        public bool IsContainedByValue(string value)
        {
            var temp = head;
            for (int i = 1; i <= length; ++i)
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

        public int Length()
        {
            return length;
        }

        public int PositionByValue(string value)
        {
            var temp = head;
            for (int i = 1; i <= length; ++i)
            {
                if (temp.Value == value)
                {
                    return i;
                }
                temp = temp.Next;
            }
            return 0;
        }

        public void print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                var temp = head;
                for (int i = 0; i < length; ++i)
                {
                    Console.WriteLine($"Value: {temp.Value}, position: {temp.Position}");
                    if (temp.Next != null)
                    {
                        temp = temp.Next;
                    }
                }
            }
        }

        private void Renumbering()
        {
            var temp = head;
            for (int i = 1; i <= length; ++i)
            {
                temp.Position = i;
                if (temp.Next != null)
                {
                    temp = temp.Next;
                }
            }
        }

        public void Push(string value, int position)
        {
            if (IsEmpty())
            {
                head = new Node(value, 1);
                ++length;
            }
            else if (position > length + 1 || position < 1)
            {
                Console.WriteLine("List overflow");
            }
            else
            {
                var newElement = new Node(value, position);
                if (position == 1)
                {
                    newElement.Next = head;
                    head = newElement;
                    ++length;
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
                    ++length;
                    Renumbering();
                }
            }
        }

        public void Delete(int position)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            else if (!IsContainedByPosition(position))
            {
                Console.WriteLine("List overflow");
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
                    if (position == length)
                    {
                        temp.Next = null;
                    }
                    else
                    {
                        temp.Next = temp.Next.Next;
                    }
                }
                --length;
                Renumbering();
            }
        }

        public void GetValue(int position)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            else if (!IsContainedByPosition(position))
            {
                Console.WriteLine("List overflow");
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

        public void SetValue(string value, int position)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            else if (!IsContainedByPosition(position))
            {
                Console.WriteLine("List overflow");
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
        private int length;
    }
}