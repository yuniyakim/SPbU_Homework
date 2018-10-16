#include "pch.h"
#include "binaryNumbers.h"
#include <stdio.h>

void test()
{
	int numberTest1 = 107;
	int arrayTest1[8]{ 0 };
	intoTwosComplement(numberTest1, arrayTest1);

	int numberTest2 = 46;
	int arrayTest2[8]{ 0 };
	intoTwosComplement(numberTest2, arrayTest2);

	int numberTest3 = -67;
	int arrayTest3[8]{ 0 };
	intoTwosComplement(numberTest3, arrayTest3);

	int numberTest4 = -120;
	int arrayTest4[8]{ 0 };
	intoTwosComplement(numberTest4, arrayTest4);
	
	int sum13 = 0;
	int sum14 = 0;
	int sum23 = 0;
	int sum24 = 0;

	int arraySum13[8]{ 0 };
	int arraySum14[8]{ 0 };
	int arraySum23[8]{ 0 };
	int arraySum24[8]{ 0 };

	sumOfTwosComplements(numberTest1, numberTest3, arrayTest1, arrayTest3, arraySum13);
	sumOfTwosComplements(numberTest1, numberTest4, arrayTest1, arrayTest4, arraySum14);
	sumOfTwosComplements(numberTest2, numberTest3, arrayTest2, arrayTest3, arraySum23);
	sumOfTwosComplements(numberTest2, numberTest4, arrayTest2, arrayTest4, arraySum24);

	sum13 = fromTwosComplement(arraySum13);
	sum14 = fromTwosComplement(arraySum14);
	sum23 = fromTwosComplement(arraySum23);
	sum24 = fromTwosComplement(arraySum24);

	if ((arrayTest1[3] == 0) && (arrayTest2[6] == 1) && (arrayTest3[0] == 1) && (arrayTest4[4] == 1) && (arraySum13[5] == 0) &&
		(arraySum14[3] == 1) && (arraySum23[0] == 1) && (arraySum24[1] == 0) && (sum13 == 40) && (sum14 == -13) && (sum23 == -21) && (sum24 == -74))
	{
		printf("Test passed\n");
	}
	else
	{
		printf("Test failed\n");
	}
	printf("\n");
}
