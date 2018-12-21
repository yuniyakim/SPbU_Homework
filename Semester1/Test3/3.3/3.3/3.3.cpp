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
	file >> size;
	int **graph = createGraph(size);

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

	vector<int> reachable(size);
	reachable = vertexes(graph, size);
	for (int i = 0; i < reachable.size(); i++)
	{
		cout << reachable[i] << endl;
	}

	deleteGraph(graph, size);
	return 0;
}

// Дан ориентированный граф в виде матрицы инцидентности. 
// Написать функцию поиска таких вершин, которые достижимы из всех остальных вершин (то есть из любой вершины графа можно построить путь в эту вершину).