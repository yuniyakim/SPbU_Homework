#include "pch.h"
#include <iostream>
#include <string>
#include <vector>
#include "kmp.h"
#include "test.h"
using namespace std;

void test()
{
	string S1 = "abcabeabcabd";
	string T1 = "abcabd";
	string S2 = "ABC ABCDAB ABCDABCDABDE";
	string T2 = "ABCDABD";
	string S3 = "abcabcdeabcdef";
	string T3 = "abcdeabcde";
	string S4 = "exaaaaams";
	string T4 = "help";
	if ((kmp(S1, T1) == 6) && (kmp(S2, T2) == 15) && (kmp(S3, T3) == 3) && (kmp(S4, T4) == -1))
	{
		cout << "Тест пройден" << endl;
	}
	else
	{
		cout << "Тест провален" << endl;
	}
}