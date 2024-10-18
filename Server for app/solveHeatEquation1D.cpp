#include "solveHeatEquation1D.h"

const double dt = 0.1;  
const double dx = 0.1;  

std::vector<double> solveHeatEquation1D(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature, int numSteps, int nx) {

    density *= 1000;
    specificHeat *= 1000;

    std::vector<double> temperature(nx, ambientTemperature);
    temperature[highTempLocation] = initialTemperature;

    std::vector<double> allResults(nx * numSteps);

    double coefficient = alpha * dt / (dx * dx) / (density * specificHeat);

    for (int step = 0; step < numSteps; ++step) {
        std::vector<double> newTemperature(nx, 0.0);

#pragma omp parallel for
        for (int i = 1; i < nx - 1; ++i) {
            newTemperature[i] = temperature[i] + coefficient * (temperature[i - 1] - 2 * temperature[i] + temperature[i + 1]);
        }

        newTemperature[0] = temperature[0]; 
        newTemperature[nx - 1] = temperature[nx - 1];

        std::swap(temperature, newTemperature);

        std::copy(temperature.begin(), temperature.end(), allResults.begin() + step * nx);
    }

    return allResults;
}
