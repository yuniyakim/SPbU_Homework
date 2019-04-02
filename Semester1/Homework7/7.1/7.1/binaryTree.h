#pragma once

// structure of a binary tree
struct BinaryTree;

// creates a binary tree
BinaryTree *createTree();

// deletes the binary tree
void deleteBinaryTree(BinaryTree *tree);

// adds a node with given data to the binary tree
bool add(BinaryTree *tree, int const data);

// removes a node with a given data from the binary tree
bool remove(BinaryTree *tree, int const data);

// checks if a node with given data exists
bool exists(BinaryTree *tree, int const data);

// checks if the tree is empty
bool isEmpty(BinaryTree *tree);

// prints a binary tree in a descending order
void printBinaryTreeDescendingOrder(BinaryTree *tree);

// prints a binary tree in a ascending order
void printBinaryTreeAscendingOrder(BinaryTree *tree);