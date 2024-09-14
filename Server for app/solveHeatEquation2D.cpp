#include "solveHeatEquation2D.h"

std::vector<double> solveHeatEquation2D(double density, double specificHeat, double alpha, int highTempX, int highTempY, float initialTemperature, float ambientTemperature, int numSteps, int nx, int ny) {

    // Adjust density to kg/m^3 and specific heat to J/(kg*K)
    density *= 1000;
    specificHeat *= 1000;

    // Spatial steps
    const double dx = 0.1;
    const double dy = 0.1;

    // Time step
    const double dt = 0.1;

    if (highTempX < 1 || highTempX > nx) {
        highTempX = nx / 2; 
    }
    else {
        highTempX--; 
    }

    if (highTempY < 1 || highTempY > ny) {
        highTempY = ny / 2; 
    }
    else {
        highTempY--; 
    }

    // Initial temperature distribution
    std::vector<double> temperature(nx * ny, ambientTemperature);
    temperature[highTempY * nx + highTempX] = initialTemperature;

    std::vector<double> allResults(nx * ny * numSteps);

    // Precompute coefficients
    double coeffX = alpha * dt / (dx * dx) / (density * specificHeat);
    double coeffY = alpha * dt / (dy * dy) / (density * specificHeat);

    for (int step = 0; step < numSteps; ++step) {
        std::vector<double> newTemperature(nx * ny, 0.0);

#pragma omp parallel for collapse(2)
        for (int i = 1; i < nx - 1; ++i) {
            for (int j = 1; j < ny - 1; ++j) {
                int index = j * nx + i;
                newTemperature[index] = temperature[index]
                    + coeffX * (temperature[index - 1] - 2 * temperature[index] + temperature[index + 1])
                    + coeffY * (temperature[index - nx] - 2 * temperature[index] + temperature[index + nx]);
            }
        }

        // Handle boundary conditions (example: isolated boundaries)
        for (int i = 0; i < nx; ++i) {
            newTemperature[i] = temperature[i]; // Top boundary
            newTemperature[(ny - 1) * nx + i] = temperature[(ny - 1) * nx + i]; // Bottom boundary
        }
        for (int j = 0; j < ny; ++j) {
            newTemperature[j * nx] = temperature[j * nx]; // Left boundary
            newTemperature[j * nx + (nx - 1)] = temperature[j * nx + (nx - 1)]; // Right boundary
        }

        // Swap temperatures for the next step
        std::swap(temperature, newTemperature);

        // Save the temperature distribution at each step
        std::copy(temperature.begin(), temperature.end(), allResults.begin() + step * nx * ny);
    }

    return allResults; // Returning the final temperature distribution for all steps
}
