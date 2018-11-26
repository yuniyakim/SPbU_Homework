#include "pch.h"
#include <iostream>
#include "list.h"
#include <fstream>
#include <string>
#include "mergeSort.h"
#include "test.h"
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	test();

	ifstream file("6.4.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден." << endl;
		return 1;
	}

	List *list = createList();
	while (!file.eof()) 
	{
		string name = "";
		string number = "";
		file >> name;
		file.ignore(3);
		file >> number;
		list = addIntoList(list, name, number);
	}

	file.close();

	int sorting = 0;
	cout << "Выберите тип сортировки:" << endl;
	cout << "1 - по имени" << endl;
	cout << "2 - по номеру телефона" << endl;
	cin >> sorting;
	if (sorting != 1 && sorting != 2)
	{
		cout << "Ошибка ввода." << endl;
	}
	else if (sorting == 1)
	{
		list = mergeSort(list, false);
	}
	else
	{
		list = mergeSort(list, true);
	}

	printList(list);
	deleteList(list);

	return 0;
}

// Реализовать сортировку слиянием. Во входном файле последовательность записей "имя - номер телефона". 
// Программа должна отсортировать эти записи либо по имени, либо по номеру телефона, в зависимости от выбора пользователя, и вывести результат на экран. 
// Количество записей заранее неизвестно, так что надо реализовывать списками на указателях.

