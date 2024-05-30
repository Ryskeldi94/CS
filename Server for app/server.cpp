#include <iostream>
#include <vector>
#include <winsock2.h>
#include <omp.h>
#include <fstream>
#include <algorithm>
#include <ctime> 
#include <string> 
#include "solveHeatEquation1D.h"
#include "solveHeatEquation2D.h"

#pragma comment(lib, "ws2_32.lib")

void logError(const std::string& errorMessage) {
    std::ofstream errorFile("C:\\Users\\Ryskeldi\\Documents\\CS\\Server for app\\error_log.txt", std::ios::app);
    if (errorFile.is_open()) {
        time_t now = time(0);
        tm* localTime = localtime(&now);
        char timeBuffer[80];
        strftime(timeBuffer, 80, "[%Y-%m-%d %H:%M:%S] ", localTime);
        errorFile << timeBuffer << errorMessage << std::endl;
    }
    else {
        std::cerr << "Error opening error_log.txt for writing." << std::endl;
    }
}

void logProgress(const std::string& logMessage) {
    std::ofstream progressFile("C:\\Users\\Ryskeldi\\Documents\\CS\\Server for app\\progress_log.txt", std::ios::app);
    if (progressFile.is_open()) {
        time_t now = time(0);
        tm* localTime = localtime(&now);
        char timeBuffer[80];
        strftime(timeBuffer, 80, "[%Y-%m-%d %H:%M:%S] ", localTime);
        progressFile << timeBuffer << logMessage << std::endl;
    }
    else {
        std::cerr << "Error opening progress_log.txt for writing." << std::endl;
    }
}

void initializeProgressLog() {
    std::ofstream progressFile("C:\\Users\\Ryskeldi\\Documents\\CS\\Server for app\\progress_log.txt");
    if (!progressFile.is_open()) {
        std::cerr << "Error opening progress_log.txt for writing." << std::endl;
    }
}

int main() {
    initializeProgressLog();
    logProgress("Server started.");

    WSADATA wsaData;
    int iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0) {
        logError("WSAStartup failed: " + std::to_string(iResult));
        logProgress("WSAStartup failed.");
        return 1;
    }

    SOCKET ListenSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (ListenSocket == INVALID_SOCKET) {
        logError("Error at socket(): " + std::to_string(WSAGetLastError()));
        logProgress("Error at socket()");
        WSACleanup();
        return 1;
    }

    sockaddr_in serverAddr;
    serverAddr.sin_family = AF_INET;
    serverAddr.sin_addr.s_addr = INADDR_ANY;
    serverAddr.sin_port = htons(54000);
    if (bind(ListenSocket, (sockaddr*)&serverAddr, sizeof(serverAddr)) == SOCKET_ERROR) {
        logError("bind failed: " + std::to_string(WSAGetLastError()));
        logProgress("bind failed");
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    if (listen(ListenSocket, SOMAXCONN) == SOCKET_ERROR) {
        logError("listen failed: " + std::to_string(WSAGetLastError()));
        logProgress("listen failed");
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    std::cout << "Server is listening on port 54000..." << std::endl;
    logProgress("Server is listening on port 54000...");

    SOCKET ClientSocket = INVALID_SOCKET;
    ClientSocket = accept(ListenSocket, NULL, NULL);
    if (ClientSocket == INVALID_SOCKET) {
        logError("accept failed: " + std::to_string(WSAGetLastError()));
        logProgress("accept failed");
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    std::cout << "Client connected." << std::endl;
    logProgress("Client connected.");

    while (1) {
        int calculationType;
        int recvResult = recv(ClientSocket, (char*)&calculationType, sizeof(calculationType), 0);
        if (recvResult == SOCKET_ERROR) {
            logError("recv failed: " + std::to_string(WSAGetLastError()));
            logProgress("recv failed");
            closesocket(ClientSocket);
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }
        if (recvResult != sizeof(calculationType)) {
            logError("Incomplete data received for calculation type.");
            logProgress("Incomplete data received for calculation type.");
            closesocket(ClientSocket);
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }

        logProgress("Received calculation type: " + std::to_string(calculationType));

        std::vector<double> result;

        if (calculationType == 1) {
            double density, specificHeat, alpha;
            int highTempLocation, numSteps, nx;
            float initialTemperature, ambientTemperature;

            recvResult = recv(ClientSocket, (char*)&density, sizeof(density), 0);
            if (recvResult != sizeof(density)) {
                logError("Error receiving density.");
                logProgress("Error receiving density.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&specificHeat, sizeof(specificHeat), 0);
            if (recvResult != sizeof(specificHeat)) {
                logError("Error receiving specificHeat.");
                logProgress("Error receiving specificHeat.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&alpha, sizeof(alpha), 0);
            if (recvResult != sizeof(alpha)) {
                logError("Error receiving alpha.");
                logProgress("Error receiving alpha.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&highTempLocation, sizeof(highTempLocation), 0);
            if (recvResult != sizeof(highTempLocation)) {
                logError("Error receiving highTempLocation.");
                logProgress("Error receiving highTempLocation.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&initialTemperature, sizeof(initialTemperature), 0);
            if (recvResult != sizeof(initialTemperature)) {
                logError("Error receiving initialTemperature.");
                logProgress("Error receiving initialTemperature.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&ambientTemperature, sizeof(ambientTemperature), 0);
            if (recvResult != sizeof(ambientTemperature)) {
                logError("Error receiving ambientTemperature.");
                logProgress("Error receiving ambientTemperature.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&numSteps, sizeof(numSteps), 0);
            if (recvResult != sizeof(numSteps)) {
                logError("Error receiving numSteps.");
                logProgress("Error receiving numSteps.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&nx, sizeof(nx), 0);
            if (recvResult != sizeof(nx)) {
                logError("Error receiving nx.");
                logProgress("Error receiving nx.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received 1D parameters: density=" + std::to_string(density) + ", specificHeat=" + std::to_string(specificHeat) +
                ", alpha=" + std::to_string(alpha) + ", highTempLocation=" + std::to_string(highTempLocation) +
                ", initialTemperature=" + std::to_string(initialTemperature) + ", ambientTemperature=" + std::to_string(ambientTemperature) +
                ", numSteps=" + std::to_string(numSteps) + ", nx=" + std::to_string(nx));

            result = solveHeatEquation1D(density, specificHeat, alpha, highTempLocation, initialTemperature, ambientTemperature, numSteps, nx);

            int sendResult = send(ClientSocket, reinterpret_cast<char*>(result.data()), result.size() * sizeof(double), 0);
            if (sendResult == SOCKET_ERROR) {
                logError("Error sending result: " + std::to_string(WSAGetLastError()));
                logProgress("Error sending result.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

        }
        else if (calculationType == 2) {
            double density, specificHeat, alpha;
            int highTempX, highTempY, numSteps, nx, ny;
            float initialTemperature, ambientTemperature;

            recvResult = recv(ClientSocket, (char*)&density, sizeof(density), 0);
            if (recvResult != sizeof(density)) {
                logError("Error receiving density.");
                logProgress("Error receiving density.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&specificHeat, sizeof(specificHeat), 0);
            if (recvResult != sizeof(specificHeat)) {
                logError("Error receiving specificHeat.");
                logProgress("Error receiving specificHeat.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&alpha, sizeof(alpha), 0);
            if (recvResult != sizeof(alpha)) {
                logError("Error receiving alpha.");
                logProgress("Error receiving alpha.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&highTempX, sizeof(highTempX), 0);
            if (recvResult != sizeof(highTempX)) {
                logError("Error receiving highTempX.");
                logProgress("Error receiving highTempX.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&highTempY, sizeof(highTempY), 0);
            if (recvResult != sizeof(highTempY)) {
                logError("Error receiving highTempY.");
                logProgress("Error receiving highTempY.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&initialTemperature, sizeof(initialTemperature), 0);
            if (recvResult != sizeof(initialTemperature)) {
                logError("Error receiving initialTemperature.");
                logProgress("Error receiving initialTemperature.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&ambientTemperature, sizeof(ambientTemperature), 0);
            if (recvResult != sizeof(ambientTemperature)) {
                logError("Error receiving ambientTemperature.");
                logProgress("Error receiving ambientTemperature.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&numSteps, sizeof(numSteps), 0);
            if (recvResult != sizeof(numSteps)) {
                logError("Error receiving numSteps.");
                logProgress("Error receiving numSteps.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&nx, sizeof(nx), 0);
            if (recvResult != sizeof(nx)) {
                logError("Error receiving nx.");
                logProgress("Error receiving nx.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&ny, sizeof(ny), 0);
            if (recvResult != sizeof(ny)) {
                logError("Error receiving ny.");
                logProgress("Error receiving ny.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received 2D parameters: density=" + std::to_string(density) + ", specificHeat=" + std::to_string(specificHeat) +
                ", alpha=" + std::to_string(alpha) + ", highTempX=" + std::to_string(highTempX) +
                ", highTempY=" + std::to_string(highTempY) + ", initialTemperature=" + std::to_string(initialTemperature) +
                ", ambientTemperature=" + std::to_string(ambientTemperature) + ", numSteps=" + std::to_string(numSteps) +
                ", nx=" + std::to_string(nx) + ", ny=" + std::to_string(ny));

            result = solveHeatEquation2D(density, specificHeat, alpha, highTempX, highTempY, initialTemperature, ambientTemperature, numSteps, nx, ny);

            int sendResult = send(ClientSocket, reinterpret_cast<char*>(result.data()), result.size() * sizeof(double), 0);
            if (sendResult == SOCKET_ERROR) {
                logError("Error sending result: " + std::to_string(WSAGetLastError()));
                logProgress("Error sending result.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }
        }
        else {
            logError("Invalid calculation type received: " + std::to_string(calculationType));
            closesocket(ClientSocket);
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }
    }

    closesocket(ClientSocket);
    closesocket(ListenSocket);
    WSACleanup();
    return 0;
}
