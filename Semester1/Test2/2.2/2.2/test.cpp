#include "pch.h"
#include "list.h"
#include "test.h"
#include <fstream>
#include <iostream>
using namespace std;

void test()
{
	List *test1 = createList();

	ifstream fileRead1("test1.txt", ios::in);

	while (!fileRead1.eof())
	{
		int value = 0;
		fileRead1 >> value;
		test1 = addIntoList(test1, value);
		fileRead1.ignore(1);
	}

	fileRead1.close();


	List *test2 = createList();

	ifstream fileRead2("test2.txt", ios::in);

	while (!fileRead2.eof())
	{
		int value = 0;
		fileRead2 >> value;
		test2 = addIntoList(test2, value);
		fileRead2.ignore(1);
	}

	fileRead2.close();
	

	List *test3 = createList();

	ifstream fileRead3("test3.txt", ios::in);

	while (!fileRead3.eof())
	{
		int value = 0;
		fileRead3 >> value;
		test3 = addIntoList(test3, value);
		fileRead3.ignore(1);
	}

	fileRead3.close();

	if (isSymmetric(test1) && isSymmetric(test2) && !isSymmetric(test3))
	{
		cout << "Тест пройден." << endl;
	}
	else
	{
		cout << "Тест провален." << endl;
	}

	deleteList(test1);
	deleteList(test2);
	deleteList(test3);
}