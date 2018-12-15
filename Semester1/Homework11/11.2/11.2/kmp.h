#pragma once
#include <string>
#include <vector>

// prefix function
std::vector<int> prefixFunction(std::string input);

//Knuth–Morris–Pratt algorithm which returns an index of the first match
int kmp(std::string S, std::string T);