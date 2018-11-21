#pragma once

// converts an expression from infix into postfix form
void fromInfixIntoPostfix(char input[], char output[]);

// defines if an incoming symbol is '*' or '/'
bool isMultiplicationOrDivision(char symbol);

// defines if an incoming symbol is '+' or '-'
bool isAdditionOrSubtraction(char symbol);

// defines if an incoming symbol is '(' 
bool isAnOpeningBracket(char symbol);

// defines if an incoming symbol is ')'
bool isAClosingBracket(char symbol);