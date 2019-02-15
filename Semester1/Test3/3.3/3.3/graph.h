#pragma once
#include <fstream>

// creates a graph
bool **createGraph(const int size);

// deletes a graph
void deleteGraph(bool **graph, const int size);

// depth-first search
void dfs(bool **graph, int size, bool **visited, int iteration, int number);

// reads the file and returns incidence matrix
int **readIncidenceMatrix(std::ifstream &file, int size, int roads);

// prints adjacence matrix
void printAdjacencMatrix(bool **graph, int size);

// converts incidence matrix into adjacence 
bool **fromIncidenceToAdjacenceMatrix(int **incidenceMatrix, int size, int roads, bool **graph);