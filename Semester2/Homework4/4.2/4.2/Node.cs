using System;

namespace _4._2
{ /// <summary>
  /// Node of the list
  /// </summary>
    class Node
    {
        /// <summary>
        /// Node's constructor
        /// </summary>
        /// <param name="value">Element to add into the node</param>
        /// <param name="position">Position on which to add the element</param>
        public Node(string value, int position)
        {
            this.value = value;
            this.position = position;
            next = null;
        }

        /// <summary>
        /// Get/set of the value of the node
        /// </summary>
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

        /// <summary>
        /// Get/set of the position of the node
        /// </summary>
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

        /// <summary>
        /// Get/set of the next of the node
        /// </summary>
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
