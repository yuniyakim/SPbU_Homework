#include "pch.h"
#include <iostream>
#include <fstream>
using namespace std;

bool **createGraph(const int size)
{
	bool **graph = new bool*[size];
	for (int i = 0; i < size; i++)
	{
		graph[i] = new bool[size];
		for (int j = 0; j < size; j++)
		{
			graph[i][j] = false;
		}
	}
	return graph;
}

void deleteGraph(bool **graph, const int size)
{
	for (int i = 0; i < size; i++)
	{
		delete[] graph[i];
	}
	delete[] graph;
}

void dfs(bool **graph, int size, bool **visited, int iteration, int number)
{
	visited[iteration][number] = true;
	for (int i = 0; i <= size; i++)
	{
		if ((graph[number][i] != 0) && (!visited[iteration][i]))
		{
			dfs(graph, size, visited, iteration, i);
		}
	}
}

int **readIncidenceMatrix(ifstream &file, int size, int roads)
{
	int **matrix = new int*[size];
	for (int i = 0; i < size; i++)
	{
		matrix[i] = new int[roads];
		for (int j = 0; j < roads; j++)
		{
			file >> matrix[i][j];
		}
	}
	return matrix;
}

void printAdjacencMatrix(bool **graph, int size)
{
	for (int i = 0; i < size; i++)
	{
		for (int k = 0; k < size; k++)
		{
			cout << graph[i][k] << " ";
		}
		cout << "\n";
	}
}

bool **fromIncidenceToAdjacenceMatrix(int **incidenceMatrix, int size, int roads, bool **graph)
{
	for (int column = 0; column < roads; column++)
	{
		int from = -1;
		int to = -1;
		for (int row = 0; row < size && (from == -1 || to == -1); row++)
		{
			if (incidenceMatrix[row][column] == 1)
			{
				from = row;
			}
			else if (incidenceMatrix[row][column] == -1)
			{
				to = row;
			}
		}
		if (from >= 0 && to >= 0)
		{
			graph[from][to] = true;
		}
	}
	return graph;
}