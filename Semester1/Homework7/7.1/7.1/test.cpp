#include "pch.h"
#include "commands.h"
#include "binaryTree.h"
#include <iostream>
using namespace std;

void test()
{
	BinaryTree *test = createTree();

	add(test, 4);
	add(test, 15);
	add(test, 11);
	add(test, 8);
	add(test, 26);
	add(test, 7);

	if (!add(test, 11) && exists(test, 26) && exists(test, 4) && !exists(test, 5) && !exists(test, 13) && remove(test, 7) && remove(test, 15) && !remove(test, 28) &&
		!exists(test, 7) && !exists (test, 15) && add(test, 14) && add(test, 15))
	{
		cout << "Тест пройден." << endl;
	}
	else
	{
		cout << "Тест провален." << endl;
	}

	deleteBinaryTree(test);
}