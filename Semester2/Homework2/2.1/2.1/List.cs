using System;

namespace _2._1
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

        public bool IsContained(int position)
        {
            return !(IsEmpty() || position > length || position < 1);
        }

        public int Length()
        {
            return length;
        }

        public void print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                Node temp = head;
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
            Node temp = head;
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
                Node newElement = new Node(value, position);
                if (position == 1)
                {
                    newElement.Next = head;
                    head = newElement;
                    ++length;
                    Renumbering();
                }
                else
                {
                    Node temp = head;
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
            else if (!IsContained(position))
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
                    Node temp = head;
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
            else if (!IsContained(position))
            {
                Console.WriteLine("List overflow");
            }
            else
            {
                Node temp = head;
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
            else if (!IsContained(position))
            {
                Console.WriteLine("List overflow");
            }
            else
            {
                Node temp = head;
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

/* Написать связный список в виде класса. От списка хочется:
- Добавлять/удалять элемент по произвольной позиции, задаваемой целым числом
- Узнавать размер, проверять на пустоту
- Получать или устанавливать значение элемента по позиции, задаваемой целым числом */
