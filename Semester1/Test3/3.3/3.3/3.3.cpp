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
	bool **graph = createGraph(size);

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < roads; j++)
		{
			int input = 0;
			file >> input;
			graph[i][j] = input;
		}
	}
	
	for (int column = 0; column < roads; column++)
	{
		int from = -1;
		int to = -1;
		for (int row = 0; row < size && (from == -1 || to == -1); row++)
		{
			if (graph[row][column] == 1)
			{
				from = row;
			}
			else if (graph[row][column] == -1)
			{
				to = row;
			}
		}
		graph[from][to] = true;
	}

	vector<int> reachable(size);
	reachable = vertexes(graph, size);
	for (int i = 0; i < reachable.size(); i++)
	{
		if (reachable[i] != -1)
		{
			cout << reachable[i] << endl;
		}
	}

	deleteGraph(graph, size);
	return 0;
}

// Дан ориентированный граф в виде матрицы инцидентности. 
// Написать функцию поиска таких вершин, которые достижимы из всех остальных вершин (то есть из любой вершины графа можно построить путь в эту вершину).