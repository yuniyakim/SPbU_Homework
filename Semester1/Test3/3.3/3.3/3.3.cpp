#include "pch.h"
#include <iostream>
#include <fstream>
#include "graph.h"
using namespace std;

int main()
{
	ifstream file("3.3.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден" << endl;
		return 1;
	}

	int size = 0;
	int roads = 0;
	file >> size;
	file >> roads;
	int **matrix = readIncidenceMatrix(file, size, roads);

	file.close();

	bool **graph = createGraph(size);
	graph = fromIncidenceToAdjacenceMatrix(matrix, size, roads, graph);
	printAdjacencMatrix(graph, size);

	bool **visited = createGraph(size);
	for (int i = 0; i < size; i++)
	{
		dfs(graph, size, visited, i, i);
	}

	for (int k = 0; k < size; k++)
	{
		bool flag = true;
		for (int l = 0; l < size; l++)
		{
			if (!visited[l][k])
			{
				flag = false;
			}
		}
		if (flag)
		{
			cout << k << endl;
		}
	}

	for (int i = 0; i < size; i++)
	{
		delete[] matrix[i];
	}
	delete[] matrix;

	deleteGraph(visited, size);
	deleteGraph(graph, size);
	return 0;
}

// Дан ориентированный граф в виде матрицы инцидентности. 
// Написать функцию поиска таких вершин, которые достижимы из всех остальных вершин (то есть из любой вершины графа можно построить путь в эту вершину).