#include "pch.h"
#include "binaryTree.h"
#include <iostream>
using namespace std;

struct Node
{
	int data;
	Node *leftChild;
	Node *rightChild;
};

struct BinaryTree
{
	Node *head;
};

BinaryTree *createTree()
{
	return new BinaryTree{ nullptr };
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

void deleteBinaryTree(BinaryTree *tree)
{
	if (tree != nullptr)
	{
		deleteNodes(tree->head);
		delete tree;
	}
}

void addNode(Node *node, int data)
{
	if (node->data > data && node->leftChild != nullptr)
	{
		addNode(node->leftChild, data);
	}
	else if (node->data < data && node->rightChild != nullptr)
	{
		addNode(node->rightChild, data);
	}
	else
	{
		if (node->data > data)
		{
			node->leftChild = new Node{ data, nullptr, nullptr };
		}
		else
		{
			node->rightChild = new Node{ data, nullptr, nullptr };
		}
	}
}

bool add(BinaryTree *tree, int const  data)
{
	if (isEmpty(tree))
	{
		tree->head = new Node{ data, nullptr, nullptr };
	}
	else
	{
		if (!exists(tree, data))
		{
			addNode(tree->head, data);
		}
		else
		{
			return false;
		}
	}
	return true;
}

int maximum(Node *tree)
{
	auto* temp = tree;
	temp = temp->leftChild;
	while (temp->rightChild != nullptr)
	{
		temp = temp->rightChild;
	}
	return temp->data;
}

void removeRecursion(Node *&tree, int data)
{
	if (tree->data > data)
	{
		removeRecursion(tree->leftChild, data);
	}
	else if (tree->data < data)
	{
		removeRecursion(tree->rightChild, data);
	}
	else
	{
		if (tree->leftChild == nullptr && tree->rightChild == nullptr)
		{
			auto* temp = tree;
			tree = nullptr;
			delete temp;
			return;
		}
		else if (tree->leftChild == nullptr && tree->rightChild != nullptr)
		{
			auto* temp = tree;
			tree = tree->rightChild;
			delete temp;
			return;
		}
		else if (tree->leftChild != nullptr && tree->rightChild == nullptr)
		{
			auto* temp = tree;
			tree = tree->leftChild;
			delete temp;
			return;
		}
		else
		{
			tree->data = maximum(tree);
			removeRecursion(tree->leftChild, tree->data);
		}
	}
}

bool remove(BinaryTree *tree, int const data)
{
	if (!exists(tree, data))
	{
		return false;
	}
	removeRecursion(tree->head, data);
	return true;
}

bool exists(BinaryTree *tree, int const data)
{
	if (isEmpty(tree))
	{
		return false;
	}
	auto* temp = tree->head;
	while (true)
	{
		if (temp->data > data)
		{
			if (temp->leftChild != nullptr)
			{
				temp = temp->leftChild;
			}
			else
			{
				return false;
			}
		}
		else if (temp->data < data)
		{
			if (temp->rightChild != nullptr)
			{
				temp = temp->rightChild;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return true;
		}
	}
}

bool isEmpty(BinaryTree *tree)
{
	return tree->head == nullptr;
}

void printAscendingOrder(Node *node)
{
	if (node != nullptr)
	{
		printAscendingOrder(node->leftChild);
		cout << node->data << " ";
		printAscendingOrder(node->rightChild);
	}
}

void printBinaryTreeAscendingOrder(BinaryTree *tree)
{
	if (isEmpty(tree))
	{
		cout << "Множество пусто.";
	}
	else
	{
		printAscendingOrder(tree->head->leftChild);
		cout << tree->head->data << " ";
		printAscendingOrder(tree->head->rightChild);
	}
}

void printDescendingOrder(Node *node)
{
	if (node != nullptr)
	{
		printDescendingOrder(node->rightChild);
		cout << node->data << " ";
		printDescendingOrder(node->leftChild);
	}
}

void printBinaryTreeDescendingOrder(BinaryTree *tree)
{
	if (isEmpty(tree))
	{
		cout << "Множество пусто.";
	}
	else
	{
		printDescendingOrder(tree->head->rightChild);
		cout << tree->head->data << " ";
		printDescendingOrder(tree->head->leftChild);
	}
}