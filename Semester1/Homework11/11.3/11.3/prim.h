#pragma once
#include <fstream>

// creates an array for MST
int **createArrayTwo(int size);

// deletes an array of MST
void deleteArrayTwo(int **array, int size);

// prints an array of MST
void printMST(int **MST, int size);

// reads data from file and executes Prim algorithm
int **readAndPrim(int size, std::ifstream &file);