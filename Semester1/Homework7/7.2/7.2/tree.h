#pragma once
#include <fstream>

// structure of a binary tree
struct Tree;

// creates a binary tree
Tree *createTree();

// deletes the binary tree
void deleteTree(Tree *tree);

// converts an input string into a tree
Tree *stringIntoTree(std::ifstream &file);

// checks if the tree is empty
bool isEmpty(Tree *tree);

// calculates the result of the expression in a tree
int treeCalculation(Tree *tree);

// prints a tree
void printTree(Tree *tree);