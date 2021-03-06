#include "pch.h"
#include <stdio.h>
#include <cstdlib>

void sort(int mass[], int n)
{
	int first = mass[0];
	int left = 0;
	int right = n - 1; 
	while (left < right)
	{
		while ((mass[right] >= first) && (left < right))
		{
			--right;
		}
		if (left != right)
		{
			mass[left] = mass[right];
			++left;
		}
		while ((mass[left] <= first) && (left < right))
		{
			++left;
		}
		if (left != right)
		{
			mass[right] = mass[left];
			--right;
		}
	}
	mass[left] = first;
}

void test()
{
	int massTest[10]{ 4, 6, 8, 1, 9, 5, 1, 4, 2, 7 };
	sort(massTest, 10);
	if ((massTest[3] == 4) && (massTest[8] >= massTest[3]) && (massTest[2] < massTest[3]) && (massTest[9] >= massTest[3]))
	{
		printf("Test passed\n");
	}
	else
	{
		printf("Test failed\n");
	}
}

int main()
{
	test();

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

	sort(mass, n);

	for (int i = 0; i < n; ++i)
	{
		printf("mass[%u] = %u\n", i, mass[i]);
	}

	delete[] mass;
	return 0;
}