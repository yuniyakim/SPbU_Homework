#pragma once
#include <vector>

// creates a graph
int **createGraph(const int size);

// deletes a graph
void deleteGraph(int **graph, const int size);

std::vector<int> vertexes(int **graph, int size);