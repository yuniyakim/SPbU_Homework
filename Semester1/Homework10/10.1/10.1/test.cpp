#include "pch.h"
#include <iostream>
#include "graph.h"
#include "test.h"
using namespace std;

void test()
{
	int amountOfCities = 6;
	int amountOfRoads = 7;
	int amountOfCapitals = 2;

	int **graphTest = createGraph(amountOfCities);
	int *capitalsTest = createArray(amountOfCapitals);
	int *cityToCountryTest = createArray(amountOfCities);

	graphTest[0][3] = 7;
	graphTest[3][0] = 7;
	graphTest[0][5] = 3;
	graphTest[5][0] = 3;
	graphTest[1][4] = 5;
	graphTest[4][1] = 5;
	graphTest[1][5] = 8;
	graphTest[5][1] = 8;
	graphTest[2][4] = 9;
	graphTest[4][2] = 9;
	graphTest[2][5] = 1;
	graphTest[5][2] = 1;
	graphTest[4][5] = 6;
	graphTest[5][4] = 6;

	capitalsTest[0] = 2;
	capitalsTest[1] = 0;

	for (int i = 0; i < amountOfCapitals; i++)
	{
		cityToCountryTest[capitalsTest[i]] = capitalsTest[i]; 
	}

	citiesRoadsCountries(graphTest, amountOfCities, cityToCountryTest, amountOfCapitals, capitalsTest);

	if ((cityToCountryTest[0] == 0) && (cityToCountryTest[1] == 2) && (cityToCountryTest[2] == 2) && (cityToCountryTest[3] == 0) && (cityToCountryTest[4] == 2) && (cityToCountryTest[5] == 2))
	{
		cout << "Тест пройден" << endl;
	}
	else
	{
		cout << "Тест провален" << endl;
	}

	deleteGraph(graphTest, amountOfCities);
	delete[] cityToCountryTest;
	delete[] capitalsTest;
}