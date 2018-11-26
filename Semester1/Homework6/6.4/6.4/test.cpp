#include "pch.h"
#include "test.h"
#include "mergeSort.h"
#include <iostream>
#include <string>
using namespace std;

void test()
{
	setlocale(LC_ALL, "Russian");

	List *test1 = createList();
	List *test2 = createList();

	test1 = addIntoList(test1, "Emily", "65123");
	test1 = addIntoList(test1, "Spenser", "23109");
	test1 = addIntoList(test1, "Hannah", "3126587");
	test1 = addIntoList(test1, "Alison", "65192");
	test1 = addIntoList(test1, "Aria", "7895365");
	test2 = addIntoList(test2, "Emily", "65123");
	test2 = addIntoList(test2, "Spenser", "23109");
	test2 = addIntoList(test2, "Hannah", "3126587");
	test2 = addIntoList(test2, "Alison", "65192");
	test2 = addIntoList(test2, "Aria", "7895365");

	test1 = mergeSort(test1, false);
	test2 = mergeSort(test2, true);

	bool compare1 = (nameOfElement(test1) == "Alison" ? true : false);
	bool compare2 = (nameOfElement(test2) == "Spenser" ? true : false);
	bool compare3 = (numberOfElement(nextOfList(test1)) == "7895365" ? true : false);
	bool compare4 = (nameOfElement(nextOfList(nextOfList(nextOfList(test2)))) == "Alison" ? true : false);
	bool compare5 = (nameOfElement(nextOfList(nextOfList(nextOfList(nextOfList(test1))))) == "Spenser" ? true : false);
	bool compare6 = (numberOfElement(nextOfList(nextOfList(nextOfList(nextOfList(test2))))) == "7895365" ? true : false);

	if (compare1 && compare2 && compare3 && compare4 && compare5 && compare6)
	{
		cout << "Тест пройден." << endl;
	}
	else
	{
		cout << "Тест провален." << endl;
	}
}