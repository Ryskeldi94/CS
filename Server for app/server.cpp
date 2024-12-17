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
//g++ -o server.exe server.cpp solveHeatEquation1D.cpp solveHeatEquation2D.cpp -lws2_32 -fopenmp

void logError(const std::string& errorMessage) {
    std::ofstream errorFile("C:/My projects/Server for app/error_log.txt", std::ios::app);
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
    std::ofstream progressFile("C:/My projects/Server for app/progress_log.txt", std::ios::app);
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
    std::ofstream progressFile("C:/My projects/Server for app/progress_log.txt");
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

    logProgress("WSAStartup successfully initialized.");

    SOCKET ListenSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (ListenSocket == INVALID_SOCKET) {
        logError("Error at socket(): " + std::to_string(WSAGetLastError()));
        logProgress("Error at socket()");
        WSACleanup();
        return 1;
    }

    logProgress("Socket successfully created.");

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

    logProgress("Socket successfully bound to port 54000.");

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

    logProgress("Client connected.");

    while (1) {
        logProgress("Waiting for calculation type from client...");

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
            logProgress("Incomplete data received for calculation type.");
            closesocket(ClientSocket);
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }

        logProgress("Received calculation type: " + std::to_string(calculationType));

        std::vector<double> result;

        if (calculationType == 1) {

            logProgress("Starting 1D heat equation calculation.");

            double density, specificHeat, alpha, dt, dx;
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

            logProgress("Received density: " + std::to_string(density));

            recvResult = recv(ClientSocket, (char*)&specificHeat, sizeof(specificHeat), 0);
            if (recvResult != sizeof(specificHeat)) {
                logError("Error receiving specificHeat.");
                logProgress("Error receiving specificHeat.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received specificHeat: " + std::to_string(specificHeat));

            recvResult = recv(ClientSocket, (char*)&alpha, sizeof(alpha), 0);
            if (recvResult != sizeof(alpha)) {
                logError("Error receiving alpha.");
                logProgress("Error receiving alpha.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received alpha: " + std::to_string(alpha));

            recvResult = recv(ClientSocket, (char*)&highTempLocation, sizeof(highTempLocation), 0);
            if (recvResult != sizeof(highTempLocation)) {
                logError("Error receiving highTempLocation.");
                logProgress("Error receiving highTempLocation.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received highTempLocation: " + std::to_string(highTempLocation));

            recvResult = recv(ClientSocket, (char*)&initialTemperature, sizeof(initialTemperature), 0);
            if (recvResult != sizeof(initialTemperature)) {
                logError("Error receiving initialTemperature.");
                logProgress("Error receiving initialTemperature.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received initialTemperature: " + std::to_string(initialTemperature));

            recvResult = recv(ClientSocket, (char*)&ambientTemperature, sizeof(ambientTemperature), 0);
            if (recvResult != sizeof(ambientTemperature)) {
                logError("Error receiving ambientTemperature.");
                logProgress("Error receiving ambientTemperature.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received ambientTemperature: " + std::to_string(ambientTemperature));

            recvResult = recv(ClientSocket, (char*)&numSteps, sizeof(numSteps), 0);
            if (recvResult != sizeof(numSteps)) {
                logError("Error receiving numSteps.");
                logProgress("Error receiving numSteps.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received numSteps: " + std::to_string(numSteps));

            recvResult = recv(ClientSocket, (char*)&nx, sizeof(nx), 0);
            if (recvResult != sizeof(nx)) {
                logError("Error receiving nx.");
                logProgress("Error receiving nx.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received nx: " + std::to_string(nx));

            recvResult = recv(ClientSocket, (char*)&dt, sizeof(dt), 0);
            if (recvResult != sizeof(dt)) {
                logError("Error receiving dt.");
                logProgress("Error receiving dt.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received dt: " + std::to_string(dt));

            recvResult = recv(ClientSocket, (char*)&dx, sizeof(dx), 0);
            if (recvResult != sizeof(dx)) {
                logError("Error receiving dx.");
                logProgress("Error receiving dx.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received dx: " + std::to_string(dx));

            result = solveHeatEquation1D(density, specificHeat, alpha, highTempLocation, initialTemperature, ambientTemperature, numSteps, nx, dt, dx);

            logProgress("1D calculation completed, sending result to client.");

            int sendResult = send(ClientSocket, reinterpret_cast<char*>(result.data()), result.size() * sizeof(double), 0);

            if (sendResult == SOCKET_ERROR) {
                logError("send failed: " + std::to_string(WSAGetLastError()));
                logProgress("send failed");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Result sent to client.");
        }
        else if (calculationType == 2) {

            logProgress("Starting 2D heat equation calculation.");

            double density, specificHeat, alpha, dt, dx, dy;
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

            logProgress("Received density: " + std::to_string(density));

            recvResult = recv(ClientSocket, (char*)&specificHeat, sizeof(specificHeat), 0);
            if (recvResult != sizeof(specificHeat)) {
                logError("Error receiving specificHeat.");
                logProgress("Error receiving specificHeat.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received specificHeat: " + std::to_string(specificHeat));

            recvResult = recv(ClientSocket, (char*)&alpha, sizeof(alpha), 0);
            if (recvResult != sizeof(alpha)) {
                logError("Error receiving alpha.");
                logProgress("Error receiving alpha.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received alpha: " + std::to_string(alpha));

            recvResult = recv(ClientSocket, (char*)&highTempX, sizeof(highTempX), 0);
            if (recvResult != sizeof(highTempX)) {
                logError("Error receiving highTempX.");
                logProgress("Error receiving highTempX.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received highTempX: " + std::to_string(highTempX));

            recvResult = recv(ClientSocket, (char*)&highTempY, sizeof(highTempY), 0);
            if (recvResult != sizeof(highTempY)) {
                logError("Error receiving highTempY.");
                logProgress("Error receiving highTempY.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received highTempY: " + std::to_string(highTempY));

            recvResult = recv(ClientSocket, (char*)&initialTemperature, sizeof(initialTemperature), 0);
            if (recvResult != sizeof(initialTemperature)) {
                logError("Error receiving initialTemperature.");
                logProgress("Error receiving initialTemperature.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received initialTemperature: " + std::to_string(initialTemperature));

            recvResult = recv(ClientSocket, (char*)&ambientTemperature, sizeof(ambientTemperature), 0);
            if (recvResult != sizeof(ambientTemperature)) {
                logError("Error receiving ambientTemperature.");
                logProgress("Error receiving ambientTemperature.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received ambientTemperature: " + std::to_string(ambientTemperature));

            recvResult = recv(ClientSocket, (char*)&numSteps, sizeof(numSteps), 0);
            if (recvResult != sizeof(numSteps)) {
                logError("Error receiving numSteps.");
                logProgress("Error receiving numSteps.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received numSteps: " + std::to_string(numSteps));

            recvResult = recv(ClientSocket, (char*)&nx, sizeof(nx), 0);
            if (recvResult != sizeof(nx)) {
                logError("Error receiving nx.");
                logProgress("Error receiving nx.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received nx: " + std::to_string(nx));

            recvResult = recv(ClientSocket, (char*)&ny, sizeof(ny), 0);
            if (recvResult != sizeof(ny)) {
                logError("Error receiving ny.");
                logProgress("Error receiving ny.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received ny: " + std::to_string(ny));

            recvResult = recv(ClientSocket, (char*)&dt, sizeof(dt), 0);
            if (recvResult != sizeof(dt)) {
                logError("Error receiving dt.");
                logProgress("Error receiving dt.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            logProgress("Received dt: " + std::to_string(dt));

            recvResult = recv(ClientSocket, (char*)&dx, sizeof(dx), 0);
            if (recvResult != sizeof(dx)) {
                logError("Error receiving dx.");
                logProgress("Error receiving dx.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&dy, sizeof(dy), 0);
            if (recvResult != sizeof(dy)) {
                logError("Error receiving dy.");
                logProgress("Error receiving dy.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            result = solveHeatEquation2D(density, specificHeat, alpha, highTempX, highTempY, initialTemperature, ambientTemperature, numSteps, nx, ny , dt, dx, dy);

            logProgress("2D calculation completed, sending result to client.");

            int sendResult = send(ClientSocket, reinterpret_cast<char*>(result.data()), result.size() * sizeof(double), 0);
            if (sendResult == SOCKET_ERROR) {
                logError("Error sending result: " + std::to_string(WSAGetLastError()));
                logProgress("Error sending result.");
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }
            logProgress("Result sent to client.");

        }
    }

    logProgress("Shutting down server.");

    closesocket(ClientSocket);
    closesocket(ListenSocket);
    WSACleanup();
    return 0;
}
