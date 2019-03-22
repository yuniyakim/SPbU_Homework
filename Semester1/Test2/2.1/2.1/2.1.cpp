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

	int a = 0;
	int b = 0;
	cout << "Введите числа a и b" << endl;
	cin >> a >> b;
	while (a > b)
	{
		cout << "Введены неверные числа" << endl;
		cout << "Введите числа a и b" << endl;
		cin >> a >> b;
	}

	List *smaller = createList();
	List *between = createList();
	List *bigger = createList();

	ifstream fileRead("f.txt", ios::in);
	if (!fileRead.is_open())
	{
		cout << "Файл не найден" << endl;
		return 1;
	}

	while (!fileRead.eof())
	{
		int value = 0;
		fileRead >> value;
		if (value < a)
		{
			smaller = addIntoList(smaller, value);
		}
		else if (value > b)
		{
			bigger = addIntoList(bigger, value);
		}
		else
		{
			between = addIntoList(between, value);
		}
		fileRead.ignore(1);
	}

	fileRead.close();

	ofstream fileWrite;
	fileWrite.open("g.txt", ios::out);

	int number1 = numberOfRecords(smaller);
	List *temp1 = smaller;
	for (int i = 0; i < number1; ++i)
	{
		fileWrite << valueOfElement(temp1) << " ";
		temp1 = nextOfList(temp1);
	}

	int number2 = numberOfRecords(between);
	List *temp2 = between;
	for (int i = 0; i < number2; ++i)
	{
		fileWrite << valueOfElement(temp2) << " ";
		temp2 = nextOfList(temp2);
	}

	int number3 = numberOfRecords(bigger);
	List *temp3 = bigger;
	for (int i = 0; i < number3; ++i)
	{
		fileWrite << valueOfElement(temp3) << " ";
		temp3 = nextOfList(temp3);
	}

	fileWrite.close();
	
	deleteList(smaller);
	deleteList(between);
	deleteList(bigger);

	return 0;
}

// Даны числа a и b. 
// За один просмотр файла f, элементами которого являются целые числа, и без использования дополнительных файлов переписать его элементы в файл g так, 
// чтобы первоначально были записаны все числа, меньше заданного a, затем все числа из отрезка [a,b], затем все остальные. 
// Взаимный порядок в каждой из групп должен быть сохранен, предположений о количестве элементов делать нельзя (пользоваться контейнерами из стандартной библиотеки – тоже).