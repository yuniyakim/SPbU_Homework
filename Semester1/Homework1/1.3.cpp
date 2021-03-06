#include "pch.h"
#include <cstdlib>
#include <stdio.h>

void change(int mass[], int begin, int end) // функция, которая переставляет элементы
{
	int end0 = end;
	for (int i = begin, j = end; i < j; i++, j--)
	{
		int help = mass[i];
		mass[i] = mass[end0];
		mass[end0] = help;
		end0--;
	}
}

int main()
{
	int m;
	int n;
	printf("m = ");
	scanf("%u", &m);
	printf("n = ");
	scanf("%u", &n);
	int *mass = new int[m + n + 1];
	for (int i = 1; i <= m + n; i++)
	{
		mass[i] = rand() % 100;
		printf("mass[%u] = %u\n", i, mass[i]);
	}
	change(mass, 1, m);
	change(mass, (m + 1), (m + n));
	change(mass, 1, (m + n));
	printf("\n");
	for (int i = 1; i <= m + n; i++)
	{
		printf("mass[%u] = %u\n", i, mass[i]);
	}
	delete[]mass;
	return 0;
}