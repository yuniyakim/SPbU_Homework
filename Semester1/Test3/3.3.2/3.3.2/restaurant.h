#pragma once
#include <fstream>

// reads data from file and returns an hour with the largest amount of visitors
int readAndSummarize(std::ifstream &file);