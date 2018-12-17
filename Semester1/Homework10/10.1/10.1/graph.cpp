#include "pch.h"
#include <iostream>
#include "graph.h"
using namespace std;

int **createGraph(const int size)
{
	int **graph = new int*[size]; // создаем двумерный динамический массив
	for (int i = 0; i < size; i++)
	{
		graph[i] = new int[size];
	}
	for (int i = 0; i < size; i++) // обнул€ем массив
	{
		for (int j = 0; j < size; j++)
		{
			graph[i][j] = 0;
		}
	}
	return graph;
}

void deleteGraph(int **graph, const int size)
{
	for (int i = 0; i < size; i++)
	{
		delete[] graph[i];
	}
	delete[] graph;
}

int *createArray(const int size)
{
	int *array = new int[size];
	for (int i = 0; i < size; i++)
	{
		array[i] = -1;
	}
	return array;
}

void citiesRoadsCountries(int **graph, int amountOfCities, int *cityToCountry, int amountOfCapitals, int *capitals)
{
	int freeCities = amountOfCities - amountOfCapitals;
	while (freeCities > 0)
	{
		for (int i = 0; i < amountOfCapitals; i++)
		{
			int minimumLength = 10000000;
			int numberOfClosestCity = -1;
			for (int j = 0; j < amountOfCities; j++)
			{
				if ((cityToCountry[j] == -1) && (graph[j][capitals[i]] != 0) && (graph[j][capitals[i]] < minimumLength)) // ищем ближайший незан€тый св€занный со столицей город
				{
					minimumLength = graph[j][amountOfCapitals];
					numberOfClosestCity = j;
				}
			}
			for (int k = 0; k < amountOfCities; k++)
			{
				if ((cityToCountry[k] == capitals[i]) && (capitals[i] != k)) // если город принадлежит текущей стране и не €вл€етс€ столицей
				{
					for (int p = 0; p < amountOfCities; ++p)
					{
						if ((cityToCountry[p] == -1) && (graph[k][p] != 0) && (graph[k][p] < minimumLength)) // то ищем ближайщий незан€тый св€занный с нестоличным город
						{
							minimumLength = graph[k][p];
							numberOfClosestCity = p;
						}
					}
				}
			}
			if (numberOfClosestCity != -1)
			{
				cityToCountry[numberOfClosestCity] = capitals[i];
				freeCities--;
			}
			if (freeCities == 0)
			{
				break;
			}
		}
	}
}

void printCountriesCities(int *cityToCountry, int amountOfCities, int *capitals, int amountOfCapitals)
{
	for (int i = 0; i < amountOfCapitals; i++)
	{
		cout << "Ќомер государства " << i << endl;
		cout << "√орода ";
		for (int k = 0; k < amountOfCities; k++)
		{
			if (cityToCountry[k] == capitals[i])
			{
				cout << k << " ";
			}
		}
		cout << "\n";
	}
}

// Ёто типа алгоритма обхода в ширину, только пошагового: в цикле по странам, дл€ каждой страны находим ближайший к стране город и добавл€ем его. 
// ≈сли стране нечего добавл€ть (все соседние города захвачены), пропускаем страну, если ни одной стране нечего добавить, то всЄ.
//  ак искать ближайший город-- - вообще говор€, как угодно, хоть полным просмотром графа, но можно и поддерживать очередь соседних городов, как в алгоритме ƒейкстры


// ≈сть множество городов и дороги, св€зывающие эти города. ƒл€ каждой дороги задана еЄ длина. 
// «адача Ц распределить города между государствами по такому алгоритму: 
// задаютс€ k столиц каждого государства, далее по очереди каждому государству добавл€етс€ ближайший незан€тый город, 
// непосредственно св€занный дорогой с каким-либо городом, уже принадлежащим государству (столицей или каким-либо городом, добавленным на одном из предыдущих шагов). 
// ѕроцесс продолжаетс€ до тех пор, пока все города не будут распределены. √раф дорог св€зный. 
// ¬о входном файле: n Ц число городов и m Ц число дорог. ƒалее следуют сами дороги в формате: i j len, i и j Ц номера городов, len Ц длина дороги. 
// ƒалее задано число k Ц число столиц, далее Ц k чисел Ц номера столиц. Ќадо вывести на консоль номера государств и списки городов, принадлежащих государствам.