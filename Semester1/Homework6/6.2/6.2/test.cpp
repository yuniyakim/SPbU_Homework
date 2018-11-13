#include "pch.h"
#include "brackets.h"
#include "test.h"
#include <iostream>
using namespace std;

void test()
{
	setlocale(LC_ALL, "Russian");

	char test1[20] = "{[([])]}"; 
	char test2[10] = "([]}"; 
	char test3[20] = "([[{[]}]])";
	char test4[30] = "[{[(([{{{()}}}]))]}]";
	char test5[20] = "([])}]";
	char test6[20] = "{[()]";
	char test7[10] = "([";
	if (brackets(test1) && !brackets(test2) && brackets(test3) && brackets(test4) && !brackets(test5) && !brackets(test6) && !brackets(test7))
	{
		cout << "Тест пройден.\n" << endl;
	}
	else
	{
		cout << "Тест провален.\n" << endl;
	}
}