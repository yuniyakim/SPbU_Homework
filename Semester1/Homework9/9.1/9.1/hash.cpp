#include "pch.h"
#include "hash.h"
#include "list.h"
#include <string>
#include <iostream>
using namespace std;

struct HashTable
{
	int size;
	List **buckets;
};

unsigned int hashFunction(string input)
{
	int parameter = 25;
	int result = 0;
	for (int i = 0; i < input.size(); ++i)
	{
		result = (result + int(input[i])) % parameter;
	}
	return result;
}

HashTable *createHashTable(const int size)
{
	HashTable *table = new HashTable;
	table->buckets = new List *[size];
	for (int i = 0; i < size; i++)
	{
		table->buckets[i] = createList();
	}
	table->size = size;
	return table;
}

void deleteHashTable(HashTable *table)
{
	for (int i = 0; i < table->size; i++)
	{
		deleteList(table->buckets[i]);
	}
	delete[] table->buckets;
	delete table;
}

bool isContained(HashTable *table, const string &key)
{
	List *temp = table->buckets[hashFunction(key) % table->size];
	while (temp != nullptr)
	{
		if (keyOfElement(temp) == key)
		{
			return true;
		}
		temp = nextOfList(temp);
	}
	return false;
}

void increaseAmountOfKey(HashTable *table, const string &key)
{
	List *temp = table->buckets[hashFunction(key) % table->size];
	while (keyOfElement(temp) != key)
	{
		temp = nextOfList(temp);
	}
	increaseAmount(temp);
}

void addIntoHashTable(HashTable *table, const string &key)
{
	if (!isContained(table, key))
	{
		const int hash = hashFunction(key) % table->size;
		table->buckets[hash] = addIntoList(table->buckets[hash], key);
	}
	else
	{
		increaseAmountOfKey(table, key);
	}
}

int amountOfKey(HashTable *table, const string &key)
{
	List *temp = table->buckets[hashFunction(key) % table->size];
	while (keyOfElement(temp) != key)
	{
		temp = nextOfList(temp);
	}
	return amountOfList(temp);
}

void printAll(HashTable *table)
{
	for (int i = 0; i < table->size; i++)
	{
		if (!isEmpty(table->buckets[i]))
		{
			List *temp = table->buckets[i];
			while (temp != nullptr)
			{
				cout << keyOfElement(temp) << " " << amountOfList(temp) << endl;
				temp = nextOfList(temp);
			}
		}
	}
}

int maximum(HashTable *table)
{
	int maximum = 0;
	for (int i = 0; i < table->size; i++)
	{
		if (!isEmpty(table->buckets[i]))
		{
			int amount = 0;
			List *temp = table->buckets[i];
			while (temp != nullptr)
			{
				temp = nextOfList(temp);
				amount++;
			}
			if (amount > maximum)
			{
				maximum = amount;
			}
		}
	}
	return maximum;
}

double average(HashTable *table)
{
	double amountOfElements = 0;
	double amountOfNonEmptyBuckets = 0;
	for (int i = 0; i < table->size; i++)
	{
		if (!isEmpty(table->buckets[i]))
		{
			List *temp = table->buckets[i];
			while (temp != nullptr)
			{
				temp = nextOfList(temp);
				amountOfElements++;
			}
			amountOfNonEmptyBuckets++;
		}
	}
	double average = amountOfElements / amountOfNonEmptyBuckets;
	return average;
}