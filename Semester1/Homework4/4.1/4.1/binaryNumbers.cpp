#include "pch.h"
#include "binaryNumbers.h"
#include <stdio.h>
#include <cmath>

void printBinaryNumber(int array[])
{
	for (int i = 0; i < 8; ++i)
	{
		printf("%u ", array[i]);
	}
	printf("\n");
	printf("\n");
}

void addOne(int array[])
{
	int help = 7;
	while (array[help] == 1)
	{
		array[help] = 0;
		--help;
	}
	array[help] = 1;
}

void intoTwosComplement(int number, int array[])
{
	int help = number;
	if ((help < -128) || (help > 127))
	{
		printf("Введено недопустимое число\n");
		printf("\n");
	}
	else
	{
		if (help> 0)
		{
			for (int i = 7; i > 0; --i)
			{
				if (help % 2 == 0)
				{
					array[i] = 0;
					help = help / 2;
				}
				else
				{
					array[i] = 1;
					help = help / 2;
				}
			}
		}
		else
		{
			if (help != 0)
			{
				for (int i = 7; i > 0; --i)
				{
					if (help % 2 == 0)
					{
						array[i] = 1;
						help = help / 2;
					}
					else
					{
						array[i] = 0;
						help = help / 2;
					}
				}
				addOne(array);
				array[0] = 1;
			}
		}
	}
}

int moduleOfNumber(int number)
{
	if (number >= 0)
	{
		return number;
	}
	else
	{
		return -number;
	}
}

void additionOfBinaries(int array1[], int array2[], int sum[], int &carry, int i)
{
	if (array1[i] + array2[i] + carry < 2)
	{
		sum[i] = array1[i] + array2[i] + carry;
		carry = 0;
	}
	else
	{
		if (array1[i] + array2[i] + carry == 2)
		{
			sum[i] = 0;
			carry = 1;
		}
		else
		{
			sum[i] = 1;
			carry = 1;
		}
	}
}

void sumOfTwosComplements(int number1, int number2, int array1[], int array2[], int sum[])
{
	int carryHelp = 0;
	int *carry = &carryHelp;
	if ((number1 >= 0) && (number2 >= 0))
	{
		if (number1 + number2 < 128)
		{
			for (int i = 7; i > 0; --i)
			{
				additionOfBinaries(array1, array2, sum, carryHelp, i);
			}
		}
		else
		{
			printf("Переполнение");
		}
	}
	else
	{
		if (((number1 >= 0) && (number2 < 0) && (moduleOfNumber(number2) > moduleOfNumber(number1))) || ((number2 >= 0) && (number1 < 0) &&
			(moduleOfNumber(number1) > moduleOfNumber(number2))))
		{
			for (int i = 7; i > 0; --i)
			{
				additionOfBinaries(array1, array2, sum, carryHelp, i);
			}
			sum[0] = 1;
		}
		else
		{
			if (((number1 > 0) && (number2 <= 0) && (moduleOfNumber(number1) > moduleOfNumber(number2))) || ((number2 > 0) && (number1 <= 0) &&
				(moduleOfNumber(number2) > moduleOfNumber(number1))))
			{
				for (int i = 7; i > 0; --i)
				{
					additionOfBinaries(array1, array2, sum, carryHelp, i);
				}
			}
			else
			{
				if (moduleOfNumber(number1) + moduleOfNumber(number2) < 128)
				{
					for (int i = 7; i > 0; --i)
					{
						additionOfBinaries(array1, array2, sum, carryHelp, i);
					}
					sum[0] = 1;
				}
				else
				{
					printf("Переполнение");
				}
			}
		}
	}
}

int fromTwosComplement(int array[])
{
	int help[8]{ 0 };
	for (int i = 0; i < 8; ++i)
	{
		help[i] = array[i];
	}
	int number = 0;
	if (help[0] == 0)
	{
		for (int i = 1; i <= 7; ++i)
		{
			if (help[i] == 1)
			{
				number = number + pow(2, 7 - i);
			}
		}
		return number;
	}
	else
	{
		if ((help[0] == 1) && (help[1] == 0) && (help[2] == 0) && (help[3] == 0) && (help[4] == 0) && (help[5] == 0) &&
			(help[6] == 0) && (help[7] == 0))
		{
			return -128;
		}
		else
		{
			for (int i = 7; i > 0; --i)
			{
				if (help[i] == 0)
				{
					help[i] = 1;
				}
				else
				{
					help[i] = 0;
				}
			}
			addOne(help);
			for (int i = 1; i <= 7; ++i)
			{
				if (help[i] == 1)
				{
					number = number + pow(2, 7 - i);
				}
			}
			return -number;
		}
	}
}