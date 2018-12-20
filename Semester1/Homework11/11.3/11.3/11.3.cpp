#include "pch.h"
#include <iostream>
#include <fstream>
#include "prim.h"
#include "test.h"
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	test();

	ifstream file("11.3.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден" << endl;
		return 1;
	}

	int size = 0;
	file >> size;
	int **MST = createArrayTwo(size - 1);
	MST = readAndPrim(size, file);
	file.close();
	printMST(MST, size - 1);

	deleteArrayTwo(MST, size - 1);
	return 0;
}

// По данному неориентированному графу построить минимальное остовное дерево одним из рассмотренных алгоритмов. 
// В файле задаётся матрица смежности, программа должна вывести на консоль минимальное остовное дерево в каком-либо представлении.