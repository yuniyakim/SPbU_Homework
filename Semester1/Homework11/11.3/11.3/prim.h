#pragma once
#include <fstream>

// deletes an array of MST
void deleteArrayTwo(int **array, const int size);

// prints an array of MST
void printMST(int **MST, const int size);

// reads data from file and executes Prim algorithm
int **readAndPrim(const int size, std::ifstream &file);