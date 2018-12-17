#include "pch.h"
#include <iostream>
#include "prim.h"
#include "test.h"
using namespace std;

void test()
{
	ifstream file("test.txt", ios::in);

	int size = 0;
	file >> size;
	int **MST = createArrayTwo(size);
	MST = readAndPrim(size, file);
	file.close();
	
	if ((MST[0][0] == 1) && (MST[0][1] == 0) && (MST[1][0] == 3) && (MST[1][1] == 1) && (MST[2][0] == 2) && (MST[2][1] == 3))
	{
		cout << "Тест пройден" << endl;
	}
	else
	{
		cout << "Тест провален" << endl;
	}

	deleteArrayTwo(MST, size - 1);
}