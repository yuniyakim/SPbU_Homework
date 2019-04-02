#include "pch.h"
#include "test.h"
#include "theMostFrequentElement.h"
#include "quickSort.h"
#include <stdio.h>

void test()
{
	int massTest[12]{ 1, 4, 8, 2, 4, 6, 12, 5, 0, 8, 12, 12 };

	quickSort(massTest, 0, 11);

	if ((massTest[1] == 1) && (massTest[8] >= massTest[7]) && (theMostFrequentElement(massTest, 12) == 12))
	{
		printf("Test passed\n");
	}
	else
	{
		printf("Test failed\n");
	}
	printf("\n");
}