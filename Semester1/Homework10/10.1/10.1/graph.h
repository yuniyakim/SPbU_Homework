#pragma once

// creates a graph
int **createGraph(int size);

// deletes a graph
void deleteGraph(int **graph, int size);

// creates an array
int *createArray(int size);

// allocates cities to countries
void citiesRoadsCountries(int **graph, int amountOfCities, int *cityToCountry, int amountOfCapitals, int *capitals);

// prints
void printCountriesCities(int *cityToCountry, int amountOfCities, int *capitals, int amountOfCapitals);