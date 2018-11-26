#include "pch.h"
#include "mergeSort.h"
#include "list.h"
#include <iostream>
#include <string>
using namespace std;

List *merge(List *first, List *second, bool sorting)
{
	if (first == nullptr)
		return second;
	if (second == nullptr)
		return first;
	
	bool compare = false;
	if (!sorting)
	{
		compare = (nameOfElement(first) < nameOfElement(second) ? true : false);
	}
	else
	{
		compare = (numberOfElement(first) < numberOfElement(second) ? true : false);
	}

	List *temp = createList();
	List *nextOfTemp = createList();
	if (compare)
	{
		temp = first;
		nextTo(temp, merge(nextOfList(first), second, sorting));
	}
	else
	{
		temp = second;
		nextTo(temp, merge(first, nextOfList(second), sorting));
	}
	return temp;
}

List *division(List *list)
{
	List *temp = nullptr;
	List *temp2 = nullptr;
	temp = list;
	temp2 = nextOfList(list);

	int number = numberOfRecords(list) / 2;
	for (int i = 0; i < number - 1; ++i)
	{
		temp = nextOfList(temp);
		temp2 = nextOfList(temp2);
	}
	nextNullptr(temp);
	return temp2;
}

List *mergeSort(List *list, bool sorting)
{
	if (list == nullptr)
		return nullptr;
	else if (nextOfList(list) == nullptr)
		return list;

	List *temp = createList();
	temp = division(list);
	return merge(mergeSort(list, sorting), mergeSort(temp, sorting), sorting);
}