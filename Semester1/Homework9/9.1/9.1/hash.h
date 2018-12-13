#pragma once
#include <string>

// a hash table
struct HashTable;

// hash function
int hashFunction(std::string input);

// creates a new hash table
HashTable *createHashTable(int size);

// deletes a hash table and all its' elements
void deleteHashTable(HashTable *table);

// checks if a key is contained
bool isContained(HashTable *table, std::string key);

// increases amount of a key
void increaseAmountOfKey(HashTable *table, std::string key);

// adds a new element into the hash table
void addIntoHashTable(HashTable *table, std::string key);

// returns amount of a key in the hash table
int amountOfKey(HashTable *table, std::string key);

// prints all the elements and its' amount in the hash table
void printAll(HashTable *table);

// returns the maximum amount of elements in a bucket
int maximum(HashTable *table);

// returns the average amount of elements in a bucket
double average(HashTable *table);