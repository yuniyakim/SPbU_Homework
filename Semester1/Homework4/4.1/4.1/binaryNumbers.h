#pragma once

// функция перевода десятичного числа в дополнительный код
void intoTwosComplement(int number, int array[]);

// функция, печатающая двоичное число
void printBinaryNumber(int array[]);

// функция, считающая сумму дополнительных кодов двух чисел
void sumOfTwosComplements(int number1, int number2, int array1[], int array2[], int sum[]);

// функция, возвращающая модуль числа
int moduleOfNumber(int number);

// функция перевода дополнительного кода в десятичное число
int fromTwosComplement(int array[]);