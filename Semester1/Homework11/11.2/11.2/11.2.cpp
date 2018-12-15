#include "pch.h"
#include <iostream>
#include <string>
#include "kmp.h"
#include "test.h"
#include <fstream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	test();

	ifstream file("11.2.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден." << endl;
		return 1;
	}
	string str = "";
	getline(file, str);
	file.close();

	string key = "";
	cout << "Введите образец " << endl;
	cin >> key;
	int index = kmp(str, key);
	if (index == -1)
	{
		cout << "Образец не содержится в строке" << endl;
	}
	else
	{
		cout << "Вхождение образца в строку начинается с символа номер " << index << endl;
	}

	return 0; 
}

// Реализовать поиск подстроки любым из рассмотренных алгоритмов. 
// Из файла читается текст, с консоли - строка, программа должна выводить на консоль позицию первого вхождения введённой строки в файле.
