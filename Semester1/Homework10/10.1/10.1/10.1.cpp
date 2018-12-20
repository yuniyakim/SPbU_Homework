#include "pch.h"
#include <iostream>
#include <fstream>
#include "graph.h"
#include "test.h"
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	test();

	ifstream file("10.1.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден" << endl;
		return 1;
	}

	int amountOfCities = 0;
	int amountOfRoads = 0;
	int amountOfCapitals = 0;
	file >> amountOfCities;
	file >> amountOfRoads;

	int **graph = createGraph(amountOfCities);

	for (int i = 0; i < amountOfRoads; i++)
	{
		int city1 = 0;
		int city2 = 0;
		int length = 0;
		file >> city1 >> city2 >> length;
		graph[city1][city2] = length;
		graph[city2][city1] = length;
	}

	file >> amountOfCapitals;

	int *cityToCountry = createArray(amountOfCities);
	int *capitals = createArray(amountOfCapitals);
	for (int i = 0; i < amountOfCapitals; i++)
	{
		int capital = -1;
		file >> capital;
		capitals[i] = capital;
		cityToCountry[capitals[i]] = capitals[i]; // номера столиц будут номерами государств для удобства
	}

	file.close();

	citiesRoadsCountries(graph, amountOfCities, cityToCountry, amountOfCapitals, capitals);
	printCountriesCities(cityToCountry, amountOfCities, capitals, amountOfCapitals);

	deleteGraph(graph, amountOfCities);
	delete[] cityToCountry;
	delete[] capitals;

	return 0;
}

// Есть множество городов и дороги, связывающие эти города. Для каждой дороги задана её длина. 
// Задача – распределить города между государствами по такому алгоритму: 
// задаются k столиц каждого государства, далее по очереди каждому государству добавляется ближайший незанятый город, 
// непосредственно связанный дорогой с каким-либо городом, уже принадлежащим государству (столицей или каким-либо городом, добавленным на одном из предыдущих шагов). 
// Процесс продолжается до тех пор, пока все города не будут распределены. Граф дорог связный. 
// Во входном файле: n – число городов и m – число дорог. Далее следуют сами дороги в формате: i j len, i и j – номера городов, len – длина дороги. 
// Далее задано число k – число столиц, далее – k чисел – номера столиц. Надо вывести на консоль номера государств и списки городов, принадлежащих государствам.