using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace Test
{
    internal class Analys
    {
        public static void s1d()
        {
            try
            {
                ProcessStartInfo serverStartInfo = new ProcessStartInfo();
                serverStartInfo.FileName = @"C:\My projects\Server for app\server.exe"; // Путь к исполняемому файлу сервера
                serverStartInfo.UseShellExecute = false;

                // Создаем новый процесс для сервера
                Process serverProcess = Process.Start(serverStartInfo);

                // Ждем, пока сервер не завершит запуск
                Console.WriteLine("Server is running.");

                TcpClient client = new TcpClient("127.0.0.1", 54000); // Connect to server
                Console.WriteLine("Connected to server.");

                NetworkStream stream = client.GetStream();

                // Example 1D heat equation calculation
                double density = 7.78;
                double specificHeat = 0.449;
                double alpha = 80.2;
                int highTempLocation = 5;
                float initialTemperature = 100.0f;
                float ambientTemperature = 20.0f;
                int nx = 10;
                int calculationType = 1;
                // Временные шаги для анализа

                while (true)
                {
                    Console.WriteLine("Enter the number of steps:");
                    int numSteps = int.Parse(Console.ReadLine());
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    //начало время

                    stream.Write(BitConverter.GetBytes(calculationType), 0, sizeof(int));
                    stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
                    stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
                    stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
                    stream.Write(BitConverter.GetBytes(highTempLocation), 0, sizeof(int));
                    stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
                    stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
                    stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
                    stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));

                    // Receive result from server
                    byte[] buffer = new byte[sizeof(double) * nx * numSteps];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    //конеч посчета времени и ввыд на экран вряме оброботки
                    stopwatch.Stop();

                    // Process result (e.g., display, save to file)
                    if (bytesRead == sizeof(double) * nx * numSteps)
                    {
                        // Interpret received bytes as double values
                        double[] result = new double[nx * numSteps];
                        for (int i = 0; i < nx * numSteps; i++)
                        {
                            result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                        }
                    }

                    Console.WriteLine($"Time elapsed for numSteps={numSteps}: {stopwatch.Elapsed}");

                    if (numSteps < 0)
                    {
                        break;
                    }
                }

                // Close the stream and client when done
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void s2d()
        {
            try
            {
                ProcessStartInfo serverStartInfo = new ProcessStartInfo();
                serverStartInfo.FileName = @"C:\My projects\Server for app\server.exe"; // Путь к исполняемому файлу сервера
                serverStartInfo.UseShellExecute = false;

                // Создаем новый процесс для сервера
                Process serverProcess = Process.Start(serverStartInfo);

                // Ждем, пока сервер не завершит запуск
                Console.WriteLine("Server is running.");

                TcpClient client = new TcpClient("127.0.0.1", 54000); // Connect to server
                Console.WriteLine("Connected to server.");

                NetworkStream stream = client.GetStream();

                // Example 2D heat equation calculation
                double density = 7.78;
                double specificHeat = 0.449;
                double alpha = 80.2;
                int highTempX = 5;
                int highTempY = 5;
                float initialTemperature = 100.0f;
                float ambientTemperature = 20.0f;
                int nx = 10;
                int ny = 10;

                while (true)
                {
                    Console.WriteLine("Enter the number of steps:");
                    int numSteps = int.Parse(Console.ReadLine());


                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();


                    // Send calculation type and parameters to server
                    int calculationType = 2; // 2D calculation
                    stream.Write(BitConverter.GetBytes(calculationType), 0, sizeof(int));
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

                    // Receive result from server
                    byte[] buffer = new byte[sizeof(double) * nx * ny * numSteps];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    // Process result (e.g., display, save to file)
                    if (bytesRead == sizeof(double) * nx * ny * numSteps)
                    {
                        // Interpret received bytes as double values
                        double[] result = new double[nx * ny * numSteps];
                        for (int i = 0; i < nx * ny * numSteps; i++)
                        {
                            result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                        }
                    }
                    stopwatch.Stop();
                    Console.WriteLine($"Time elapsed for numSteps={numSteps}: {stopwatch.Elapsed}");

                }

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
