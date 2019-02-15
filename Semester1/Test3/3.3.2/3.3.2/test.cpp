#include "pch.h"
#include <iostream>
#include <fstream>
#include "restaurant.h"
using namespace std;

void test()
{
	ifstream test1("test1.txt", ios::in);
	ifstream test2("test2.txt", ios::in);
	ifstream test3("test3.txt", ios::in);
	if (readAndSummarize(test1) == 14 && readAndSummarize(test2) == 21 && readAndSummarize(test3) == -2)
	{
		cout << "Test passed" << endl;
	}
	else
	{
		cout << "Test failed" << endl;
	}

	test1.close();
	test2.close();
	test3.close();
}