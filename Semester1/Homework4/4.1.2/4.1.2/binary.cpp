#include "pch.h"
#include <stdio.h>

void printBinary(bool number[])
{
	for (int i = 0; i < 32; ++i)
	{
		printf("%d", number[i]);
	}
	printf("\n");
	printf("\n");
}

void intoTwosComplement(int number, bool array[])
{
	int bit = 0b00000001;
	for (int i = 31; i >= 0; --i)
	{
		array[i] = ((number & bit) ? 1 : 0);
		bit = bit << 1;
	}
};

void additionOfBinaries(bool array1[], bool array2[], bool sum[], bool &carry, int i)
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

void sumOfTwosComplements(bool array1[], bool array2[], bool sum[])
{
	bool carry = 0;
	for (int i = 31; i >= 0; --i)
	{
		additionOfBinaries(array1, array2, sum, carry, i);
	}
}

int fromTwosComplements(bool array[])
{
	int number = 0;
	int multiplier = 1;
	for (int i = 31; i >= 0; --i)
	{
		number = number + (array[i] == true ? multiplier : 0);
		multiplier = multiplier * 2;
	}
	return number;
}