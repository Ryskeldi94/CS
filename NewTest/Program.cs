using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using Test;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Please choose: server test or processing time test?  1 or 2");
        int pro = int.Parse(Console.ReadLine());

        if (pro == 1)
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
                int calculationType = 1; // 1D calculation
                double density = 7.78;
                double specificHeat = 0.449;
                double alpha = 80.2;
                int highTempLocation = 5;
                int highTempY = 5;
                int highTempX = 5;
                float initialTemperature = 100.0f;
                float ambientTemperature = 20.0f;
                int numSteps = 100;
                int nx = 10;
                int ny = 10;

                while (true)
                {
                    Console.WriteLine("\nPlease enter the calculation type:");
                    calculationType = int.Parse(Console.ReadLine());

                    if (calculationType == 1)
                    {
                        // Send calculation type and parameters to server
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

                        // Process result (e.g., display, save to file)
                        if (bytesRead == sizeof(double) * nx * numSteps)
                        {
                            // Interpret received bytes as double values
                            double[] result = new double[nx * numSteps];
                            for (int i = 0; i < nx * numSteps; i++)
                            {
                                result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                            }

                            // Display each step's result on a new line with three decimal places
                            Console.WriteLine("Received result from server:");
                            for (int i = 0; i < numSteps; i++)
                            {
                                Console.Write("Step " + (i + 1) + ": ");
                                for (int j = 0; j < nx; j++)
                                {
                                    Console.Write($"{result[i * nx + j]:F3} ");
                                }
                                Console.WriteLine();
                            }

                        }
                    }
                    else if (calculationType == 2)
                    {
                        //exsample for 2d
                        // Send calculation type and parameters to server
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

                            // Display each step's result on a new line with three decimal places
                            Console.WriteLine("Received result from server:");
                            for (int i = 0; i < numSteps; i++)
                            {
                                Console.WriteLine($"Step {i + 1}:");
                                for (int row = 0; row < nx; row++)
                                {
                                    for (int col = 0; col < ny; col++)
                                    {
                                        Console.Write($"{result[i * nx * ny + row * ny + col]:F3} ");
                                    }
                                    Console.WriteLine(); // Move to the next line after printing each row
                                }
                                Console.WriteLine(); // Separate each step with an empty line
                            }

                        }
                    }
                    else
                    {
                        calculationType = 0;
                        stream.Write(BitConverter.GetBytes(calculationType), 0, sizeof(int));
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
        else
        {
            Console.WriteLine("Please choose: (1 - s1d, 2 - s2d):");
            int method = int.Parse(Console.ReadLine());

            if (method == 1)
            {
                Analys.s1d();
            }
            else if (method == 2)
            {
                Analys.s2d();
            }
            else
            {
                Console.WriteLine("Неверный выбор метода.");
            }

        }
    }
}
