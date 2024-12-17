#include "solveHeatEquation2D.h"

std::vector<double> solveHeatEquation2D(double density, double specificHeat, double alpha, int highTempX, int highTempY, float initialTemperature, float ambientTemperature, int numSteps, int nx, int ny, double dt, double dx, double dy) {

    density *= 1000;
    specificHeat *= 1000;

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

    std::vector<double> temperature(nx * ny, ambientTemperature);
    temperature[highTempY * nx + highTempX] = initialTemperature;

    std::vector<double> allResults(nx * ny * numSteps);

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

        for (int i = 0; i < nx; ++i) {
            newTemperature[i] = temperature[i]; 
            newTemperature[(ny - 1) * nx + i] = temperature[(ny - 1) * nx + i]; 
        }
        for (int j = 0; j < ny; ++j) {
            newTemperature[j * nx] = temperature[j * nx]; 
            newTemperature[j * nx + (nx - 1)] = temperature[j * nx + (nx - 1)]; 
        }

        std::swap(temperature, newTemperature);

        std::copy(temperature.begin(), temperature.end(), allResults.begin() + step * nx * ny);
    }

    return allResults; 
}
