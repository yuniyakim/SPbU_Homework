#include "pch.h"
#include "tree.h"
#include <iostream>
#include <fstream>
using namespace std;

void test()
{
	ifstream file1("test1.txt", ios::in);
	Tree *test1 = createTree();
	test1 = stringIntoTree(file1);
	file1.close();

	ifstream file2("test2.txt", ios::in);
	Tree *test2 = createTree();
	test2 = stringIntoTree(file2);
	file2.close();

	ifstream file3("test3.txt", ios::in);
	Tree *test3 = createTree();
	test3 = stringIntoTree(file3);
	file3.close();

	if ((treeCalculation(test1) == 16) && (treeCalculation(test2) == 18) && (treeCalculation(test3) == -50))
	{
		cout << "Тест пройден" << endl;
	}
	else
	{
		cout << "Тест провален" << endl;
	}

	deleteTree(test1);
	deleteTree(test2);
	deleteTree(test3);
}