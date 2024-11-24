using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test
{
    internal class ProcessingTimeTest
    {
        public static void OneDimensionalCalculation(NetworkStream stream)
        {
            Console.WriteLine("Введите количество шагов:");
            int numSteps = UserInput.GetPositiveInteger("Количество шагов:");

            TimeResult1D(stream, numSteps);
        }

        public static void TwoDimensionalCalculation(NetworkStream stream)
        {
            Console.WriteLine("Введите количество шагов:");
            int numSteps = UserInput.GetPositiveInteger("Количество шагов:");

            TimeResult2D(stream, numSteps);
        }

        private static void TimeResult1D(NetworkStream stream, int numSteps)
        {
            double density = 7.78, specificHeat = 0.449, alpha = 80.2;
            int highTempLocation = 5, nx = 10;
            float initialTemperature = 100.0f, ambientTemperature = 20.0f;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            stream.Write(BitConverter.GetBytes(1), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(highTempLocation), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));

            byte[] buffer = new byte[sizeof(double) * nx * numSteps];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            stopwatch.Stop();
            Console.WriteLine($"Время, затраченное на количество шагов = {numSteps}: {stopwatch.Elapsed}");
        }

        private static void TimeResult2D(NetworkStream stream, int numSteps)
        {
            double density = 7.78, specificHeat = 0.449, alpha = 80.2;
            int highTempX = 5, highTempY = 5, nx = 10, ny = 10;
            float initialTemperature = 100.0f, ambientTemperature = 20.0f;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

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

            byte[] buffer = new byte[sizeof(double) * nx * ny * numSteps];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            stopwatch.Stop();
            Console.WriteLine($"Время, затраченное на количество шагов = {numSteps}: {stopwatch.Elapsed}");
        }
    }
}
