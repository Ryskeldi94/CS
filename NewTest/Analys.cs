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
                serverStartInfo.FileName = @"C:\My projects\Server for app\server.exe"; 
                serverStartInfo.UseShellExecute = false;

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

                double density = 7.78;
                double specificHeat = 0.449;
                double alpha = 80.2;
                int highTempLocation = 5;
                float initialTemperature = 100.0f;
                float ambientTemperature = 20.0f;
                int nx = 10;
                int calculationType = 1;

                while (true)
                {
                    int numSteps;
                    Console.WriteLine("Enter the number of steps:");
                    while (!int.TryParse(Console.ReadLine(), out numSteps) && (numSteps > 10)) 
                    {
                        Console.WriteLine("Enter the number of steps:");
                    }
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

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

                    stopwatch.Stop();

                    if (bytesRead == sizeof(double) * nx * numSteps)
                    {
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
                serverStartInfo.FileName = @"C:\My projects\Server for app\server.exe"; 
                serverStartInfo.UseShellExecute = false;

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
                    int numSteps;

                    while(!int.TryParse(Console.ReadLine(), out numSteps))
                    {
                        Console.WriteLine("enter the number of steps:");
                    }

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    int calculationType = 2; 
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
                    }
                    stopwatch.Stop();
                    Console.WriteLine($"Time elapsed for numSteps={numSteps}: {stopwatch.Elapsed}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
