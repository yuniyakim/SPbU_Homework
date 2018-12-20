#include "pch.h"
#include <iostream>
#include "hash.h"
#include "test.h"
#include <fstream>
#include <string>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	test();

	ifstream file("9.1.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден." << endl;
		return 1;
	}

	const int buckets = 30;
	HashTable *table = createHashTable(buckets);
	double amount = 0;

	while (!file.eof())
	{
		string word = "";
		file >> word;
		file.ignore(1);
		addIntoHashTable(table, word);
		amount++;
	}
	file.close();

	printAll(table);

	cout << "\n";

	const double rate = amount / buckets;
	cout << "Коэффициент заполнения хеш-таблицы равен " << rate << endl;
	cout << "Максимальная длина списка в сегменте таблицы равна " << maximum(table) << endl;
	cout << "Средняя длина списка в сегменте таблицы равна " << average(table) << endl;

	deleteHashTable(table);

	return 0;
}

// Посчитать частоты встречаемости слов в тексте с помощью хеш - таблицы.
// На входе файл с текстом, вывести на консоль все слова, встречающиеся в этом тексте с количеством раз, которое встречается каждое слово.
// Словом считается последовательность символов, разделённая пробелами, разные словоформы считаются разными словами.
// Хеш - таблицу реализовать в отдельном модуле, использующем модуль "Список".
// Подсчитать и вывести также коэффициент заполнения хеш - таблицы, максимальную и среднюю длину списка в сегменте таблицы.