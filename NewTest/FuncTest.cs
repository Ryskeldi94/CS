using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace Test
{
    public static class FunctionalityTest
    {

        public static void OneDimensionalCalculation(NetworkStream stream)
        {
            Console.WriteLine("Введите количество шагов:");
            int numSteps = UserInput.GetPositiveInteger("Количество шагов:");

            SendData1D(stream, numSteps);
            ReceiveAndDisplayResults1D(stream, numSteps);
        }

        public static void TwoDimensionalCalculation(NetworkStream stream)
        {
            Console.WriteLine("Введите количество шагов:");
            int numSteps = UserInput.GetPositiveInteger("Количество шагов:");

            SendData2D(stream, numSteps);
            ReceiveAndDisplayResults2D(stream, numSteps);
        }

        private static void SendData1D(NetworkStream stream, int numSteps)
        {
            double density = 7.78, specificHeat = 0.449, alpha = 80.2, dt = 1, dx = 0.1;
            int highTempLocation = 5, nx = 10;
            float initialTemperature = 100.0f, ambientTemperature = 20.0f;

            stream.Write(BitConverter.GetBytes(1), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(highTempLocation), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(dt), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(dx), 0, sizeof(double));
        }

        private static void ReceiveAndDisplayResults1D(NetworkStream stream, int numSteps)
        {
            int nx = 10;
            byte[] buffer = new byte[sizeof(double) * nx * numSteps];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            if (bytesRead == buffer.Length)
            {
                double[] result = new double[nx * numSteps];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                }

                Console.WriteLine("Результаты:");
                for (int step = 0; step < numSteps; step++)
                {
                    Console.Write($"Шаг {step + 1}: ");
                    for (int x = 0; x < nx; x++)
                    {
                        Console.Write($"{result[step * nx + x]:F3} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void SendData2D(NetworkStream stream, int numSteps)
        {
            double density = 7.78, specificHeat = 0.449, alpha = 80.2, dt = 1, dx = 0.1, dy = 0.1;
            int highTempX = 5, highTempY = 5, nx = 10, ny = 10;
            float initialTemperature = 100.0f, ambientTemperature = 20.0f;

            stream.Write(BitConverter.GetBytes(2), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(highTempX), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(highTempY), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(ny), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(dt), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(dx), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(dy), 0, sizeof(double));
        }

        private static void ReceiveAndDisplayResults2D(NetworkStream stream, int numSteps)
        {
            int nx = 10, ny = 10;
            byte[] buffer = new byte[sizeof(double) * nx * ny * numSteps];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            if (bytesRead == buffer.Length)
            {
                double[] result = new double[nx * ny * numSteps];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                }

                Console.WriteLine("Результаты:");
                for (int step = 0; step < numSteps; step++)
                {
                    Console.WriteLine($"Шаг {step + 1}:");
                    for (int row = 0; row < nx; row++)
                    {
                        for (int col = 0; col < ny; col++)
                        {
                            Console.Write($"{result[step * nx * ny + row * ny + col]:F3} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
