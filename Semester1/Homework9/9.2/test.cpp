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
	if (isBrackets(test1) && !isBrackets(test2) && isBrackets(test3) && isBrackets(test4) && !isBrackets(test5) && !isBrackets(test6) && !isBrackets(test7))
	{
		cout << "Тест пройден.\n" << endl;
	}
	else
	{
		cout << "Тест провален.\n" << endl;
	}
}