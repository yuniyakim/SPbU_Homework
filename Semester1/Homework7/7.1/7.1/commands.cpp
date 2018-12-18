#include "pch.h"
#include "commands.h"
#include "binaryTree.h"
#include <iostream>
using namespace std;

void printCommands()
{
	cout << "0 Ц выйти" << endl;
	cout << "1 Ц добавить значение во множество" << endl;
	cout << "2 Ц удалить значение из множества" << endl;
	cout << "3 Ц проверить, принадлежит ли значение множеству" << endl;
	cout << "4 Ц распечатать текущие элементы множества в возрастающем пор€дке" << endl;
	cout << "5 Ц распечатать текущие элементы множества в убывающем пор€дке" << endl;
}

void command1(BinaryTree *tree)
{
	int data = 0;
	cout << "¬ведите добавл€емое значение" << endl;
	cin >> data;
	if (!add(tree, data))
	{
		cout << "ƒобавл€емое значение уже содержитс€ во множестве." << endl;
	}
	cout << "\n";
}

void command2(BinaryTree *tree)
{
	int data = 0;
	cout << "¬ведите удал€емое значение" << endl;
	cin >> data;
	if (!remove(tree, data))
	{
		cout << "”дал€емое значение не содержитс€ во множестве." << endl;
	}
	cout << "\n";
}

void command3(BinaryTree *tree)
{
	int data = 0;
	cout << "¬ведите провер€емое значение" << endl;
	cin >> data;
	if (exists(tree, data))
	{
		cout << "«начение содержитс€ во множестве." << endl;
	}
	else
	{
		cout << "«начение не содержитс€ во множестве." << endl;
	}
	cout << "\n";
}

void command4(BinaryTree *tree)
{
	printBinaryTreeAscendingOrder(tree);
	cout << "\n";
	cout << "\n";
}

void command5(BinaryTree *tree)
{
	printBinaryTreeDescendingOrder(tree);
	cout << "\n";
	cout << "\n";
}

void commands()
{
	BinaryTree *tree = createTree();

	int input = 0;
	printCommands();
	cin >> input;
	while (input != 0)
	{
		switch (input)
		{
		case 1:
		{
			command1(tree);
			break;
		}
		case 2:
		{
			command2(tree);
			break;
		}
		case 3:
		{
			command3(tree);
			break;
		}
		case 4:
		{
			command4(tree);
			break;
		}
		case 5:
		{
			command5(tree);
			break;
		}
		default:
		{
			cout << "¬ведена неверна€ команда.\n" << endl;
			break;
		}
		};
		printCommands();
		cin >> input;
	}

	deleteBinaryTree(tree);
}