#include "pch.h"
#include "list.h"
#include <fstream>
#include <iostream>
using namespace std;

void test()
{
	setlocale(LC_ALL, "Russian");

	int a = 15;
	int b = 30;

	List *smaller = createList();
	List *between = createList();
	List *bigger = createList();

	ifstream fileRead("fTest.txt", ios::in);

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
	fileWrite.open("gTest.txt", ios::out);

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

	int test[8]{};
	ifstream fileReadTest("gTest.txt", ios::in);
	for (int i = 0; i < 8; ++i)
	{
		fileReadTest >> test[i];
		fileRead.ignore(1);
	}
	if (test[0] == 5 && test[1] == 1 && test[2] == 16 && test[3] == 21 && test[4] == 17 && test[5] == 98 && test[6] == 34 && test[7] == 83)
	{
		cout << "Тест пройден." << endl;
	}
	else
	{
		cout << "Тест провален." << endl;
	}
}