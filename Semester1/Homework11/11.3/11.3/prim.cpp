#include "pch.h"
#include <iostream>
#include <fstream>
#include "prim.h"
using namespace std;

int **createGraph(const int size)
{
	int **graph = new int*[size]; // создаем двумерный динамический массив
	for (int i = 0; i < size; i++)
	{
		graph[i] = new int[size];
		for (int j = 0; j < size; j++)
		{
			graph[i][j] = 10000000;
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

int *createIntArray(const int size)
{
	int *array = new int[size];
	for (int i = 0; i < size; i++)
	{
		array[i] = -1;
	}
	return array;
}

int *createIntArrayWithInf(const int size)
{
	int *array = new int[size];
	for (int i = 0; i < size; i++)
	{
		array[i] = 10000000;
	}
	return array;
}

bool *createBoolArray(const int size)
{
	bool *array = new bool[size];
	for (int i = 0; i < size; i++)
	{
		array[i] = false;
	}
	return array;
}

int **createArrayTwo(const int size)
{
	int **array = new int*[size];
	for (int i = 0; i < size; i++)
	{
		array[i] = new int[2];
		array[i][0] = 0;
		array[i][1] = 0;
	}
	return array;
}

void deleteArrayTwo(int **array, const int size)
{
	for (int i = 0; i < size; i++)
	{
		delete[] array[i];
	}
	delete[] array;
}

void printMST(int **MST, const int size)
{
	cout << "Минимальное остовное дерево: " << endl;
	for (int i = 0; i < size; i++)
	{
		cout << MST[i][0] << " -> " << MST[i][1] << endl;
	}
}

int **readAndPrim(const int size, ifstream &file)
{
	int **graph = createGraph(size);
	bool *included = createBoolArray(size);
	int *minimumDistanceToNode = createIntArrayWithInf(size);
	int *endOfEdge = createIntArray(size);
	minimumDistanceToNode[0] = 0;
	int **MST = createArrayTwo(size - 1);
	int counter = 0;
	
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			int input = 0;
			file >> input;
			if (input != 0)
			{
				graph[i][j] = input;
			}
		}
	}

	for (int i = 0; i < size; i++) 
	{
		int index = -1;
		for (int j = 0; j < size; j++)
		{
			if (!included[j] && (index == -1 || minimumDistanceToNode[j] < minimumDistanceToNode[index])) // ищем ближайшую невключенную вершину
			{
				index = j;
			}
		}

		if (minimumDistanceToNode[index] == 10000000)
		{
			cout << "Минимальное остовное дерево не существует";
			break;
		}

		included[index] = true;

		if (endOfEdge[index] != -1) // если существует ребро 
		{
			MST[counter][0] = index;
			MST[counter][1] = endOfEdge[index];
			counter++;
		}

		for (int k = 0; k < size; k++) // обновляем минимальное расстояние 
		{
			if (graph[index][k] < minimumDistanceToNode[k])
			{
				minimumDistanceToNode[k] = graph[index][k];
				endOfEdge[k] = index;
			}
		}
	}
	
	deleteGraph(graph, size);
	delete[] included;
	delete[] minimumDistanceToNode;
	delete[] endOfEdge;

	return MST;
}