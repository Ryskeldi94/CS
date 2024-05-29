#include <iostream>
#include <vector>
#include <winsock2.h>
#include <omp.h>
#include <algorithm>
#include "solveHeatEquation1D.h"
#include "solveHeatEquation2D.h"

#pragma comment(lib, "ws2_32.lib")

int main() {
    // Initialize Winsock
    WSADATA wsaData;
    int iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0) {
        std::cerr << "WSAStartup failed: " << iResult << std::endl;
        return 1;
    }

    // Create a socket
    SOCKET ListenSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (ListenSocket == INVALID_SOCKET) {
        std::cerr << "Error at socket(): " << WSAGetLastError() << std::endl;
        WSACleanup();
        return 1;
    }

    // Bind the socket
    sockaddr_in serverAddr;
    serverAddr.sin_family = AF_INET;
    serverAddr.sin_addr.s_addr = INADDR_ANY;
    serverAddr.sin_port = htons(54000);
    if (bind(ListenSocket, (sockaddr*)&serverAddr, sizeof(serverAddr)) == SOCKET_ERROR) {
        std::cerr << "bind failed: " << WSAGetLastError() << std::endl;
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    // Listen for incoming connections
    if (listen(ListenSocket, SOMAXCONN) == SOCKET_ERROR) {
        std::cerr << "listen failed: " << WSAGetLastError() << std::endl;
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    std::cout << "Server is listening on port 54000..." << std::endl;

    // Accept incoming connections
    SOCKET ClientSocket = INVALID_SOCKET;
    ClientSocket = accept(ListenSocket, NULL, NULL);
    if (ClientSocket == INVALID_SOCKET) {
        std::cerr << "accept failed: " << WSAGetLastError() << std::endl;
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    std::cout << "Client connected." << std::endl;
    while (1) {
        // Receive parameters and determine the type of calculation
        int calculationType;
        int recvResult = recv(ClientSocket, (char*)&calculationType, sizeof(calculationType), 0);
        if (recvResult == SOCKET_ERROR) {
            std::cerr << "recv failed: " << WSAGetLastError() << std::endl;
            closesocket(ClientSocket);
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }
        if (recvResult != sizeof(calculationType)) {
            std::cerr << "Incomplete data received for calculation type." << std::endl;
            closesocket(ClientSocket);
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }

        std::vector<double> result;

        if (calculationType == 1) { // 1D calculation
            double density, specificHeat, alpha;
            int highTempLocation, numSteps, nx;
            float initialTemperature, ambientTemperature;

            // Receive 1D parameters from the client
            recvResult = recv(ClientSocket, (char*)&density, sizeof(density), 0);
            if (recvResult != sizeof(density)) {
                std::cerr << "Error receiving density." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&specificHeat, sizeof(specificHeat), 0);
            if (recvResult != sizeof(specificHeat)) {
                std::cerr << "Error receiving specificHeat." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&alpha, sizeof(alpha), 0);
            if (recvResult != sizeof(alpha)) {
                std::cerr << "Error receiving alpha." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&highTempLocation, sizeof(highTempLocation), 0);
            if (recvResult != sizeof(highTempLocation)) {
                std::cerr << "Error receiving highTempLocation." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&initialTemperature, sizeof(initialTemperature), 0);
            if (recvResult != sizeof(initialTemperature)) {
                std::cerr << "Error receiving initialTemperature." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&ambientTemperature, sizeof(ambientTemperature), 0);
            if (recvResult != sizeof(ambientTemperature)) {
                std::cerr << "Error receiving ambientTemperature." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&numSteps, sizeof(numSteps), 0);
            if (recvResult != sizeof(numSteps)) {
                std::cerr << "Error receiving numSteps." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&nx, sizeof(nx), 0);
            if (recvResult != sizeof(nx)) {
                std::cerr << "Error receiving nx." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            // Call the 1D solver function
            result = solveHeatEquation1D(density, specificHeat, alpha, highTempLocation, initialTemperature, ambientTemperature, numSteps, nx);

            // Send result back to client
            int sendResult = send(ClientSocket, reinterpret_cast<char*>(result.data()), result.size() * sizeof(double), 0);
            if (sendResult == SOCKET_ERROR) {
                std::cerr << "Error sending result: " << WSAGetLastError() << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

        }
        else if (calculationType == 2) { // 2D calculation
            double density, specificHeat, alpha;
            int highTempX, highTempY, numSteps, nx, ny;
            float initialTemperature, ambientTemperature;

            recvResult = recv(ClientSocket, (char*)&density, sizeof(density), 0);
            if (recvResult != sizeof(density)) {
                std::cerr << "Error receiving density." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&specificHeat, sizeof(specificHeat), 0);
            if (recvResult != sizeof(specificHeat)) {
                std::cerr << "Error receiving specificHeat." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&alpha, sizeof(alpha), 0);
            if (recvResult != sizeof(alpha)) {
                std::cerr << "Error receiving alpha." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&highTempX, sizeof(highTempX), 0);
            if (recvResult != sizeof(highTempX)) {
                std::cerr << "Error receiving highTempLocation." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&highTempY, sizeof(highTempY), 0);
            if (recvResult != sizeof(highTempY)) {
                std::cerr << "Error receiving highTempLocation." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&initialTemperature, sizeof(initialTemperature), 0);
            if (recvResult != sizeof(initialTemperature)) {
                std::cerr << "Error receiving initialTemperature." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&ambientTemperature, sizeof(ambientTemperature), 0);
            if (recvResult != sizeof(ambientTemperature)) {
                std::cerr << "Error receiving ambientTemperature." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&numSteps, sizeof(numSteps), 0);
            if (recvResult != sizeof(numSteps)) {
                std::cerr << "Error receiving numSteps." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&nx, sizeof(nx), 0);
            if (recvResult != sizeof(nx)) {
                std::cerr << "Error receiving nx." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            recvResult = recv(ClientSocket, (char*)&ny, sizeof(ny), 0);
            if (recvResult != sizeof(ny)) {
                std::cerr << "Error receiving nx." << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }

            // Call the 2D solver function
            result = solveHeatEquation2D(density, specificHeat, alpha, highTempX, highTempY, initialTemperature, ambientTemperature, numSteps, nx, ny);

            // Send result back to client
            int sendResult = send(ClientSocket, reinterpret_cast<char*>(result.data()), result.size() * sizeof(double), 0);
            if (sendResult == SOCKET_ERROR) {
                std::cerr << "Error sending result: " << WSAGetLastError() << std::endl;
                closesocket(ClientSocket);
                closesocket(ListenSocket);
                WSACleanup();
                return 1;
            }
        }
        else {
            std::cerr << "Invalid calculation type received: " << calculationType << std::endl;
            closesocket(ClientSocket);
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }
    }

    // Cleanup
    closesocket(ClientSocket);
    closesocket(ListenSocket);
    WSACleanup();
    return 0;
}
