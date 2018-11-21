#pragma once

// converts an expression from infix into postfix form
void fromInfixIntoPostfix(char input[], char output[]);

// defines if an incoming symbol is '*' or '/'
bool isMultiplicationOrDivision(char symbol);

// defines if an incoming symbol is '+' or '-'
bool isAdditionOrSubtraction(char symbol);

<<<<<<< HEAD
=======
// returns the length of a string
int lengthOfLine(char string[]);

>>>>>>> 4cdc42aecbcc09b17a1336d6df2cd0155eb09127
// defines if an incoming symbol is '(' 
bool isAnOpeningBracket(char symbol);

// defines if an incoming symbol is ')'
bool isAClosingBracket(char symbol);