#include "pch.h"
#include <iostream>
#include "hash.h"
#include "list.h"
#include "test.h"
#include <string>
using namespace std;

void test()
{
	setlocale(LC_ALL, "Russian");

	HashTable *test = createHashTable(30);

	addIntoHashTable(test, "Test");
	addIntoHashTable(test, "Check");
	addIntoHashTable(test, "Hash-table");
	addIntoHashTable(test, "Check");
	addIntoHashTable(test, "Program");
	addIntoHashTable(test, "Hash-table");
	addIntoHashTable(test, "Check");

	if ((amountOfKey(test, "Check") == 3) && (amountOfKey(test, "Hash-table") == 2) && (amountOfKey(test, "Program") == 1) && (amountOfKey(test, "Test") == 1))
	{
		cout << "Тест пройден" << endl;
		cout << "\n";
	}
	else
	{
		cout << "Тест провален" << endl;
		cout << "\n";
	}

	deleteHashTable(test);
}