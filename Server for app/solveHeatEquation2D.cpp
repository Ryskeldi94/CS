﻿#include "solveHeatEquation2D.h"

std::vector<double> solveHeatEquation2D(double density, double specificHeat, double alpha, int highTempX, int highTempY, float initialTemperature, float ambientTemperature, int numSteps, int nx, int ny) {

    // Adjust density to kg/m^3 and specific heat to J/(kg*K)
    density *= 1000;
    specificHeat *= 1000;

    if (highTempX < 1 || highTempX > nx) {
        highTempX = nx / 2; // Или любое другое значение по умолчанию, которое соответствует вашим требованиям
    }
    else {
        highTempX--; // Преобразование координаты X пользователя в индекс массива
    }

    if (highTempY < 1 || highTempY > ny) {
        highTempY = ny / 2; // Или любое другое значение по умолчанию, которое соответствует вашим требованиям
    }
    else {
        highTempY--; // Преобразование координаты Y пользователя в индекс массива
    }

    // Spatial steps
    const double dx = 0.1;
    const double dy = 0.1;

    // Time step
    const double dt = 0.1;

    // Initial temperature distribution
    std::vector<double> temperature(nx * ny, ambientTemperature);
    temperature[highTempY * nx + highTempX] = initialTemperature;

    std::vector<double> allResults(nx * ny * numSteps);

    for (int step = 0; step < numSteps; ++step) {
        std::vector<double> newTemperature(nx * ny, 0.0);

#pragma omp parallel for collapse(2)
        for (int i = 1; i < nx - 1; ++i) {
            for (int j = 1; j < ny - 1; ++j) {
                int index = j * nx + i;
                newTemperature[index] = temperature[index] + alpha * dt / (dx * dx) *
                    (temperature[index - 1] - 2 * temperature[index] + temperature[index + 1]) / (density * specificHeat)
                    + alpha * dt / (dy * dy) * (temperature[index - nx] - 2 * temperature[index] + temperature[index + nx]) / (density * specificHeat);
            }
        }
        temperature = newTemperature;

        // Save the temperature distribution at each step
        std::copy(temperature.begin(), temperature.end(), allResults.begin() + step * nx * ny);
    }

    return allResults; // Returning the final temperature distribution for all steps
}
