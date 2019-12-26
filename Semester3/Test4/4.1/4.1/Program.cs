using System;
using System.IO;

namespace _4._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

/*
Реализовать консольное приложение, вычисляющее check-сумму директории файловой системы по такому правилу:

f(file) = MD5(<содержимое>)
f(dir) = MD5(<имя папки> + f(file1) + ...)
Результирующая check-сумма не должна зависеть от случайных факторов.
*/
