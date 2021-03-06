#include "pch.h"
#include "brackets.h"
#include "test.h"
#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	test();

	char string[20]{};
	cout << "Введите скобочную последовательность " << endl;
	cin.getline(string, 50);
	cout << (isBrackets(string) ? "Последовательность корректна." : "Последовательность некорректна.") << endl;

	return 0;
}

// Написать программу проверки баланса скобок в строке, скобки могут быть трёх видов: (), [], {}. 
// Скобочная последовательность вида ({)} считается некорректной, ({}) - корректной.