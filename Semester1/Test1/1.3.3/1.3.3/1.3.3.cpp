#include "pch.h"
#include <stdio.h>

int main()
{
	FILE *file = fopen("g.txt", "r");
	if (!file)
	{
		printf("File not found\n");
		return 1;
	}
	int x = 0;
	fscanf(file, "%d", &x);
	fclose(file);

	FILE *file1 = fopen("f.txt", "r");
	if (!file1)
	{
		printf("File not found\n");
		return 1;
	}
	FILE *file2 = fopen("h.txt", "a+");
	int buffer = 0;
	while (!feof(file1))
	{
		fscanf(file1, "%d ", &buffer);
		if (buffer < x)
		{
			fprintf(file2, "%d ", buffer);
		}
	}
	fclose(file1);
	fclose(file2);

	return 0;
}

// P.S. тесты вы разрешили не делать к этой задаче :)

// Дан файл f.txt, содержащий в себе целые числа, и файл g.txt, содержащий в себе одно целое число x.
// Создать файл h.txt, куда вывести все числа из файла f.txt, меньшие x, в том же порядке, что и в исходном файле.