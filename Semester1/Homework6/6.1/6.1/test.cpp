#include "pch.h"
#include "test.h"
#include "postfix.h"
#include <iostream>
using namespace std;

void test()
{
	setlocale(LC_ALL, "Russian");

	char test1[20] = "9 6 - 1 2 + *"; // (9 - 6) * (1 + 2) = 9
	char test2[20] = "8 4 + 6 2 - /"; // (8 + 4) / (6 - 2) = 3
	char test3[20] = "5 6 9 7 - / 6 * +"; // 5 + (6 / (9 - 7)) * 6 = 23
	char test4[45] = "8 9 4 5 + 3 * 8 - 4 1 7 + 6 * 4 / + - / +"; // 8 + (9 / ((4 + 5) * 3 - 8) - (4 + (1 + 7) * 6 / 4)) = 11
	if ((postfix(test1) == 9) && (postfix(test2) == 3) && (postfix(test3) == 23) && (postfix(test4) == 11))
	{
		cout << "Тест пройден.\n" << endl;
	}
	else
	{
		cout << "Тест провален.\n" << endl;
	}
}
