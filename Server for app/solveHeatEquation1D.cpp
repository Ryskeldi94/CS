#include "solveHeatEquation1D.h"

std::vector<double> solveHeatEquation1D(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature, int numSteps, int nx, double dt, double dx) {

    // Convert density and specific heat to standard units
    density *= 1000;         // g/cm^3 -> kg/m^3
    specificHeat *= 1000;    // kJ/(kg*K) -> J/(kg*K)

    // Initialize the temperature array with ambient temperature
    std::vector<double> temperature(nx, ambientTemperature);
    if (highTempLocation >= 0 && highTempLocation < nx) {
        temperature[highTempLocation] = initialTemperature;
    }

    // Allocate space to store all results
    std::vector<double> allResults(nx * numSteps);

    // Time-stepping loop
    for (int step = 0; step < numSteps; ++step) {
        std::vector<double> newTemperature(nx, ambientTemperature);

        // Compute the new temperature for internal points
#pragma omp parallel for
        for (int i = 1; i < nx - 1; ++i) {
            newTemperature[i] = temperature[i] + alpha * dt / (dx * dx) *
                (temperature[i - 1] - 2 * temperature[i] + temperature[i + 1]) /
                (density * specificHeat);
        }
        temperature = newTemperature;

        // Save the temperature distribution at each step
        std::copy(temperature.begin(), temperature.end(), allResults.begin() + step * nx);
    }

    return allResults;
}
