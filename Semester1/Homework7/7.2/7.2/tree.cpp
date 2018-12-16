#include "pch.h"
#include "tree.h"
#include <iostream>
#include <fstream>
using namespace std;

struct Node
{
	char data;
	Node *leftChild;
	Node *rightChild;
};

struct Tree
{
	Node *head;
};

Tree *createTree()
{
	return new Tree{ nullptr };
}

void ignoreSpaces(ifstream &file)
{
	while (file.peek() == ' ')
	{
		file.ignore(1);
	}
}

void ignoreBracket(ifstream &file)
{
	while (file.peek() == ')')
	{
		file.ignore(1);
	}
}

Node *stringIntoNodes(ifstream &file) // works only with single digits
{
	Node *head = new Node{ '\0', nullptr, nullptr };
	char symbol = file.get();
	if (symbol == '(')
	{
		head->data = file.get();
		ignoreSpaces(file);
		head->leftChild = stringIntoNodes(file);
		ignoreSpaces(file);
		head->rightChild = stringIntoNodes(file);
	}
	else if (isdigit(symbol) && file.peek() == ')')
	{
		head->data = symbol;
		ignoreBracket(file);
	}
	else if (isdigit(symbol))
	{
		head->data = symbol;
		ignoreSpaces(file);
	}

	return head;
}

Tree *stringIntoTree(ifstream &file)
{
	Tree *tree = createTree();
	tree->head = stringIntoNodes(file);
	return tree;
}

void deleteNodes(Node *&node)
{
	if (node != nullptr)
	{
		deleteNodes(node->leftChild);
		deleteNodes(node->rightChild);
		delete node;
	}
}

void deleteTree(Tree *tree)
{
	if (tree != nullptr)
	{
		deleteNodes(tree->head);
		delete tree;
	}
}

bool isEmpty(Tree *tree)
{
	return tree->head == nullptr;
}

int nodesCalculation(Node *node)
{
	if (node->data == '*')
	{
		return nodesCalculation(node->leftChild) * nodesCalculation(node->rightChild);
	}
	else if (node->data == '/')
	{
		return nodesCalculation(node->leftChild) / nodesCalculation(node->rightChild);
	}
	else if (node->data == '+')
	{
		return nodesCalculation(node->leftChild) + nodesCalculation(node->rightChild);
	}
	else if (node->data == '-')
	{
		return nodesCalculation(node->leftChild) - nodesCalculation(node->rightChild);
	}
	return node->data - '0';
}

int treeCalculation(Tree *tree)
{
	if (isEmpty(tree))
	{
		return 0;
	}
	else
	{
		return nodesCalculation(tree->head);
	}
}

void printNodes(Node *node)
{
	if (node != nullptr)
	{
		if (!isdigit(node->data))
		{
			cout << "(" << node->data << " ";
		}
		else
		{
			cout << node->data;
		}
		printNodes(node->leftChild);
		if (node->leftChild != nullptr)
		{
			cout << " ";
		}
		printNodes(node->rightChild);
		if (node->rightChild != nullptr)
		{
			cout << ")";
		}
	}
}

void printTree(Tree *tree)
{
	if (isEmpty(tree))
	{
		cout << "Дерево пусто";
	}
	else
	{
		cout << "(" << tree->head->data;
		printNodes(tree->head->leftChild);
		printNodes(tree->head->rightChild);
		cout << ")";
	}
}
