using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace ServerTests
{
    public static class ServerHelper
    {
        private static Process _serverProcess;

        public const string ServerPath = @"C:\My projects\Server for app\server.exe";
        public const string ServerAddress = "127.0.0.1";
        public const int ServerPort = 54000;

        /// <summary>
        /// Запускает сервер и возвращает поток для взаимодействия.
        /// </summary>
        public static NetworkStream StartServer()
        {
            try
            {
                // Проверка, если сервер уже запущен
                if (_serverProcess != null && !_serverProcess.HasExited)
                    throw new InvalidOperationException("Сервер уже запущен!");

                // Запуск процесса сервера
                ProcessStartInfo serverStartInfo = new ProcessStartInfo
                {
                    FileName = ServerPath,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                _serverProcess = Process.Start(serverStartInfo);
                if (_serverProcess == null || _serverProcess.HasExited)
                    throw new Exception("Не удалось запустить сервер.");

                // Установка подключения
                TcpClient client = new TcpClient(ServerAddress, ServerPort);
                return client.GetStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка запуска сервера: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Завершает работу сервера, если он запущен.
        /// </summary>
        public static void StopServer()
        {
            try
            {
                if (_serverProcess != null && !_serverProcess.HasExited)
                {
                    _serverProcess.Kill();
                    _serverProcess.WaitForExit();
                    _serverProcess.Dispose();
                    _serverProcess = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при завершении работы сервера: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Проверяет, доступен ли сервер.
        /// </summary>
        public static bool IsServerRunning()
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(ServerAddress, ServerPort);
                    return client.Connected;
                }
            }
            catch
            {
                return false;
            }
        }

        
    }

    public class JustHerpel
    {
        private static readonly Random _random = new Random();

        public static int IminInput(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

    }
}
