#include "pch.h"
#include "quickSort.h"

void swap(int mass[], int element1, int element2)
{
	int help = mass[element1];
	mass[element1] = mass[element2];
	mass[element2] = help;
}

int partition(int mass[], int low, int high)
{
	int pivot = mass[high];
	int i = low;

	for (int j = low; j <= high - 1; ++j)
	{
		if (mass[j] <= pivot)
		{
			swap(mass, i, j);
			++i;
		}
	}
	swap(mass, i, high);
	return i;
}

void quickSort(int mass[], int low, int high)
{
	if (low < high)
	{
		int p = partition(mass, low, high);
		quickSort(mass, low, p - 1);
		quickSort(mass, p + 1, high);
	}
}