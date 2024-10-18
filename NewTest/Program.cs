using System;
using System.Diagnostics;
using System.Net.Sockets;
using Test;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Please choose: server test or processing time test?  1 or 2");
        int pro;
        while (!int.TryParse(Console.ReadLine(), out pro) || (pro != 1 && pro != 2))
        {
            Console.WriteLine("Please enter a valid option: 1 for server test, 2 for processing time test.");
        }

        if (pro == 1)
        {
            try
            {
                ProcessStartInfo serverStartInfo = new ProcessStartInfo();
                serverStartInfo.FileName = @"C:\My projects\Server for app\server.exe"; 
                serverStartInfo.UseShellExecute = false;
                serverStartInfo.CreateNoWindow = true; 
                serverStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                Process? serverProcess = Process.Start(serverStartInfo);
                if (serverProcess == null)
                {
                    Console.WriteLine("Failed to start server process.");
                    return; 
                }
                Console.WriteLine("Server is running.");

                TcpClient client = new TcpClient("127.0.0.1", 54000); 
                Console.WriteLine("Connected to server.");

                NetworkStream stream = client.GetStream();


                double density = 7.78, specificHeat = 0.449, alpha = 80.2;
                int highTempLocation = 5, highTempY = 5, highTempX = 5, numSteps = 100, nx = 10, ny = 10;
                float initialTemperature = 100.0f, ambientTemperature = 20.0f;

                while (true)
                {
                    Console.WriteLine("\nPlease enter the calculation type. 1 for 1D test, 2 for 2D test:");
                    int calculationType;
                    while (!int.TryParse(Console.ReadLine(), out calculationType) || (calculationType != 1 && calculationType != 2))
                    {
                        Console.WriteLine("Invalid input. Enter 1 for 1D or 2 for 2D calculation:");
                    }

                    if (calculationType == 1)
                    {
                        stream.Write(BitConverter.GetBytes(calculationType), 0, sizeof(int));
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

                        if (bytesRead == sizeof(double) * nx * numSteps)
                        {
                            double[] result = new double[nx * numSteps];
                            for (int i = 0; i < nx * numSteps; i++)
                            {
                                result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                            }

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

                        byte[] buffer = new byte[sizeof(double) * nx * ny * numSteps];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);

                        if (bytesRead == sizeof(double) * nx * ny * numSteps)
                        {
                            double[] result = new double[nx * ny * numSteps];
                            for (int i = 0; i < nx * ny * numSteps; i++)
                            {
                                result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                            }

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
                                    Console.WriteLine(); 
                                }
                                Console.WriteLine(); 
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

            int method;
            while (!int.TryParse(Console.ReadLine(), out method) || (method != 1 && method != 2)) 
            {
                Console.WriteLine("Invalid input. Enter 1 for 1D or 2 for 2D calculation:");
            }

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
