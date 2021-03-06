#include "pch.h"
#include <stdio.h>
#include <cstdlib>

void bubbleSort(int mass[], int n)
{
	for (int i = 0; i < n - 1; ++i)
	{
		for (int k = 0; k < n - i - 1; ++k)
		{
			if (mass[k] > mass[k + 1])
			{
				int help = mass[k]; // вспомогательная переменная для перестановки элементов массива
				mass[k] = mass[k + 1];
				mass[k + 1] = help;
			}
		}
	}
}

void test(int *mass, int n)
{
	int help = 0;
	for (int i = 0; i < n - 1; ++i)
	{
		if (mass[i] > mass[i + 1])
		{
			printf("Element number %u is in the wrong place\n", i);
			++help;
		}
	}
	if (help == 0)
	{
		printf("Test passed\n");
	}
}

int main()
{
	int n = 0;

	printf("Enter the number of elements in your massive ");
	scanf("%u", &n);

	int *mass = new int[n];

	for (int i = 0; i < n; ++i) // заполняем массив случайными числами
	{
		mass[i] = rand() % 11;
		printf("mass[%u] = %u\n", i, mass[i]);
	}
	printf("\n");

	bubbleSort(mass, n);

	test(mass, n);

	printf("\n");
	for (int i = 0; i < n; ++i)
	{
		printf("mass[%u] = %u\n", i, mass[i]);
	}

	delete[] mass;
	return 0;
}