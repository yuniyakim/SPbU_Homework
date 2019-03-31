#include "pch.h"
#include "list.h"
#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите число" << endl;
	int input = 0;
	List *list = createList();
	cin >> input;
	while (input != 0)
	{
		addValueIntoList(list, input);
		cin >> input;
	}
	printList(list);
	deleteList(list);
	return 0;
}

// Написать программу, которая вводит с клавиатуры набор целых чисел (в любом порядке, конец — число 0), 
// и выводящую числа из этого набора в порядке возрастания и без повторений, с указанием того, сколько каждое число раз встретилось в этом наборе.