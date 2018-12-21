#pragma once
#include <vector>

// creates a graph
bool **createGraph(const int size);

// deletes a graph
void deleteGraph(bool **graph, const int size);

std::vector<int> vertexes(bool **graph, int size);