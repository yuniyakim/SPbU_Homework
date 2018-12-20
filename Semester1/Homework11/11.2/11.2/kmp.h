#pragma once
#include <string>
#include <vector>

// prefix function
std::vector<int> prefixFunction(const std::string &input);

//Knuth–Morris–Pratt algorithm which returns an index of the first match
int kmp(const std::string &str, const std::string &key);