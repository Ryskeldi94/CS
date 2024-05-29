#ifndef SOLVE_HEAT_EQUATION_2D_H
#define SOLVE_HEAT_EQUATION_2D_H

#include <vector>
#include <omp.h>
#include <algorithm>

std::vector<double> solveHeatEquation2D(double density, double specificHeat, double alpha, int highTempX, int highTempY, float initialTemperature, float ambientTemperature, int numSteps, int nx, int ny);

#endif // SOLVE_HEAT_EQUATION_2D_H
