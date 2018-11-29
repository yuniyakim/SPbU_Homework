#include "pch.h"
#include <iostream>
#include "list.h"
using namespace std;

void test()
{
	setlocale(LC_ALL, "Russian");

	List *list1 = new List{ nullptr };
	addElements(list1, 10);
	List *list2 = new List{ nullptr };
	addElements(list2, 3);
	List *list3 = new List{ nullptr };
	addElements(list3, 7);

	if ((amountOfElements(list1) == 10) && (amountOfElements(list2) == 3) && (amountOfElements(list3) == 7) && !isEmpty(list1) && !isEmpty(list3) &&
		(deleteElements(list1, 3) == 5) && (deleteElements(list2, 5) == 2) && (deleteElements(list3, 2) == 1))
	{
		cout << "Тест пройден.\n" << endl;
	}
	else
	{
		cout << "Тест провален.\n" << endl;
	}

	deleteList(list1);
	deleteList(list2);
	deleteList(list3);
}