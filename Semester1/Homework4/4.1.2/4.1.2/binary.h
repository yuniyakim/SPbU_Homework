#pragma once

// converts a number from decimal into two's complement
void intoTwosComplement(int number, bool array[]);

// prints a binary number
void printBinary(bool number[]);

// adds two whole binary numbers
void sumOfTwosComplements(bool array1[], bool array2[], bool sum[]);

// adds two binary numbers in current digit places
void additionOfBinaries(bool array1[], bool array2[], bool sum[], bool &carry, int i);

// converts a number from  two's complement into decimal
int fromTwosComplements(bool array[]);