#include "pch.h"
#include <iostream>
#include <fstream>
#include "restaurant.h"
#include "test.h"
using namespace std;

int main()
{
	test();

	ifstream file("3.3.2.txt", ios::in);
	if (!file.is_open())
	{
		cout << "File not found" << endl;
		return 1;
	}

	int maxHour = readAndSummarize(file);
	if (maxHour == -2)
	{
		cout << "Invalid data" << endl;
	}
	else if (maxHour == -1)
	{
		cout << "No visitors" << endl;
	}
	else
	{
		cout << "An hour with the largest amount of visitors is " << maxHour << endl;
	}

	file.close();
	return 0;
}

// В ресторане в течение рабочего дня для всех посетителей регистрируется время прихода и ухода в виде пары моментов времени. 
// На входе файл, описывающий статистику посещений за день в виде строк следующего формата:

// hourStart minuteStart hourFinish minuteFinish

// Требуется вычислить, в течение какого из часовых отрезков в сутках в ресторане находилось одновременно наибольшее количество посетителей.