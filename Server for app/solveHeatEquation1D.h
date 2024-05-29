#ifndef HEAT_EQUATION_SOLVER_H
#define HEAT_EQUATION_SOLVER_H

#include <omp.h>
#include <vector>

// Function to solve the 1D heat equation
std::vector<double> solveHeatEquation1D(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature, int numSteps, int nx);

#endif // HEAT_EQUATION_SOLVER_H
