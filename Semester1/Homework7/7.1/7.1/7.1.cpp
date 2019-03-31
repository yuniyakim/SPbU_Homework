#include "pch.h"
#include "binaryTree.h"
#include "commands.h"
#include "test.h"
#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	test();

	commands();
	
	return 0;
}

// Реализовать АТД "множество" на основе двоичного дерева поиска. 
// Программа должна позволять в интерактивном режиме добавлять значения целого типа в множество, удалять значения, 
// проверять, принадлежит ли значение множеству, печатать текущие элементы множества в возрастающем и убывающем порядках.