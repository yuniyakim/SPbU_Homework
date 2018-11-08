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

	if (!((amountOfElements(list1) == 10) && (amountOfElements(list2) == 3) && (amountOfElements(list3) == 7) && !isEmpty(list1) && !isEmpty(list3)))
	{
		cout << "Test failed.\n" << endl;
		return;
	}

	if ((deleteElements(list1, 3) == 5) && (deleteElements(list2, 5) == 2) && (deleteElements(list3, 2) == 1))
	{
		cout << "Test passed.\n" << endl;
	}
	else
	{
		cout << "Test failed.\n" << endl;
	}

	delete list1;
	delete list2;
	delete list3;
}