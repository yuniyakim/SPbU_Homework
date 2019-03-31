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
	int **mst = readAndPrim(size, file);
	file.close();
	printMST(mst, size - 1);

	deleteArrayTwo(mst, size - 1);
	return 0;
}

// По данному неориентированному графу построить минимальное остовное дерево одним из рассмотренных алгоритмов. 
// В файле задаётся матрица смежности, программа должна вывести на консоль минимальное остовное дерево в каком-либо представлении.