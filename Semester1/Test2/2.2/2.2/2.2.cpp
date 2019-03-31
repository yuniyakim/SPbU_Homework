#include "pch.h"
#include "list.h"
#include "test.h"
#include <fstream>
#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	test();

	List *list = createList();

	ifstream fileRead("2.2.txt", ios::in);
	if (!fileRead.is_open())
	{
		cout << "Файл не найден" << endl;
		return 1;
	}

	while (!fileRead.eof())
	{
		int value = 0;
		fileRead >> value;
		list = addIntoList(list, value);
		fileRead.ignore(1);
	}

	fileRead.close();

	if (isSymmetric(list))
	{
		cout << "Список симметричен" << endl;
	}
	else
	{
		cout << "Список не симметричен" << endl;
	}

	deleteList(list);

	return 0;
}

// Проверить список на симметричность. 
// В файле даны натуральные числа, построить по ним список и определить, симметричен ли он. 
// Например, список из 1 2 3 2 1 симметричен, 1 2 3 4 2 1 - нет.