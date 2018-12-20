#include "pch.h"
#include <iostream>
#include <string>
#include <vector>
#include "kmp.h"
using namespace std;

vector<int> prefixFunction(const string &input) 
{
	int length = input.size();
	vector<int> pi(length);
	for (int i = 1; i < length; i++) 
	{
		int help = pi[i - 1];
		while ((help > 0) && (input[i] != input[help]))
		{
			help = pi[help - 1];
		}
		if (input[i] == input[help])
		{
			++help;
		}
		pi[i] = help;
	}
	return pi;
}

int kmp(const string &str, const string &key)
{
	int length = key.size();
	vector<int> pi(length);
	pi = prefixFunction(key);
	int k = 0;
	for (int i = 0; i <= str.size(); i++)
	{
		while ((str[i] != key[k]) && (k > 0))
		{
			k = pi[k - 1];
		}
		if (str[i] == key[k])
		{
			k++;
		}
		if (k == length)
		{
			return i - length + 1;
		}
	}
	return -1;
}