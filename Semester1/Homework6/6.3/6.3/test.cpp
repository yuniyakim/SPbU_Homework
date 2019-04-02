#include "pch.h"
#include "test.h"
#include "fromInfixIntoPostfix.h"
#include <iostream>
using namespace std;

void test()
{
	setlocale(LC_ALL, "Russian");

	char test1[25] = "(19 - 6) * (1 + 72)";
	char test2[25] = "(8 + 40) / (6 - 2)";
	char test3[30] = "5 + (36 / (9 - 7)) * 91";
	char test4[30] = "8 * (509 / (94 - 8)) - 91";

	char test11[20]{};
	char test22[20]{};
	char test33[30]{};
	char test44[30]{};

	fromInfixIntoPostfix(test1, test11);
	fromInfixIntoPostfix(test2, test22);
	fromInfixIntoPostfix(test3, test33);
	fromInfixIntoPostfix(test4, test44);

	if (!strcmp(test11, "19 6 - 1 72 + * ") && !strcmp(test22, "8 40 + 6 2 - / ") && !strcmp(test33, "5 36 9 7 - / 91 * + ") && !strcmp(test44, "8 509 94 8 - / * 91 - "))
	{
		cout << "Тест пройден.\n" << endl;
	}
	else
	{
		cout << "Тест провален.\n" << endl;
	}
}
