#include "pch.h"
#include <stdio.h>
#include "binary.h"
#include <locale.h>

void test()
{
	setlocale(LC_ALL, "Russian");

	int number1 = 161734789; // 00001001101000111110000010000101
	bool array1[32]{ 0 };
	intoTwosComplement(number1, array1);
	int number2 = 110238892; // 00000110100100100001110010101100
	bool array2[32]{ 0 };
	intoTwosComplement(number2, array2);
	int number3 = -291284682; // 11101110101000110101100100110110
	bool array3[32]{ 0 };
	intoTwosComplement(number3, array3);
	int number4 = -789113567; // 11010000111101110001010100100001
	bool array4[32]{ 0 };
	intoTwosComplement(number4, array4);

	bool sum1[32]{ 0 };
	sumOfTwosComplements(array1, array2, sum1);
	int sum11 = fromTwosComplements(sum1);
	bool sum2[32]{ 0 };
	sumOfTwosComplements(array1, array3, sum2);
	int sum22 = fromTwosComplements(sum2);
	bool sum3[32]{ 0 };
	sumOfTwosComplements(array2, array4, sum3);
	int sum33 = fromTwosComplements(sum3);
	bool sum4[32]{ 0 };
	sumOfTwosComplements(array3, array4, sum4);
	int sum44 = fromTwosComplements(sum4);

	if ((sum11 == 271973681) && (sum22 == -129549893) && (sum33 == -678874675) && (sum44 == -1080398249) && (array1[10] == 1) && (array3[0] == 1)
		&& (array4[31] == 1) && (sum1[3] == 1) && (sum2[9] == 1) && (sum3[2] == 0) && (sum4[1] == 0))
	{
		printf("Тест пройден.\n");
		printf("\n");
	}
	else
	{
		printf("Тест провален.\n");
		printf("\n");
	}
}