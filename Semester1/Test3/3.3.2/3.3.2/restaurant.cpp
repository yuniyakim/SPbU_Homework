#include "pch.h"
#include <iostream>
#include <fstream>
#include "restaurant.h"
using namespace std;

bool validData(int hourStart, int minuteStart, int hourFinish, int minuteFinish)
{
	return (hourStart >= 0 && hourStart < 24 && minuteStart >= 0 && minuteStart < 60 && hourFinish >= 0 && hourFinish < 24 && minuteFinish >= 0 && minuteFinish < 60);
}

int readAndSummarize(ifstream &file)
{
	int amountOfVisitorsInHour[24]{};
	while (!file.eof())
	{
		int hourStart = 0;
		int minuteStart = 0;
		int hourFinish = 0;
		int minuteFinish = 0;
		file >> hourStart >> minuteStart >> hourFinish >> minuteFinish;

		if (!validData(hourStart, minuteStart, hourFinish, minuteFinish))
		{
			return -2;
		}

		for (int i = hourStart; i <= hourFinish; i++)
		{
			amountOfVisitorsInHour[i]++;
		}
	}

	int maxHour = -1;
	int maxAmount = 0;
	for (int i = 0; i < 24; i++)
	{
		if (amountOfVisitorsInHour[i] > maxAmount)
		{
			maxAmount = amountOfVisitorsInHour[i];
			maxHour = i;
		}
	}
	return maxHour;
}