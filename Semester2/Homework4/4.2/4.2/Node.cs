using System;

namespace _4._2
{
    class Node
    {
        public Node(string value, int position)
        {
            this.value = value;
            this.position = position;
            next = null;
        }

        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public Node Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        private string value;
        private int position;
        private Node next;
    }
}

/* Написать связный список в виде класса. От списка хочется:
- Добавлять/удалять элемент по произвольной позиции, задаваемой целым числом
- Узнавать размер, проверять на пустоту
- Получать или устанавливать значение элемента по позиции, задаваемой целым числом */
