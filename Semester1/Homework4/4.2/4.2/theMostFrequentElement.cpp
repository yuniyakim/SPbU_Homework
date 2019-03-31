#include "pch.h"
#include "theMostFrequentElement.h"

int theMostFrequentElement(int mass[], int n)
{
	int mostFrequent = 0;
	int amountOfMostFrequent = 0;
	int amountOfPreFrequent = 1;
	int i = 0;

	for (i = 0; i < n - 1; ++i)
	{
		if (mass[i] == mass[i + 1])
		{
			++amountOfPreFrequent;
		}
		else
		{
			if (amountOfPreFrequent > amountOfMostFrequent)
			{
				amountOfMostFrequent = amountOfPreFrequent;
				mostFrequent = i;
			}
			amountOfPreFrequent = 1;
		}
	}
	if (amountOfPreFrequent > amountOfMostFrequent)
	{
		amountOfMostFrequent = amountOfPreFrequent;
		mostFrequent = i;
	}
	return mass[mostFrequent];
}