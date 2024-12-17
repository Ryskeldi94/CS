using System;
using System.Diagnostics;
using System.Net.Sockets;

public static class ServerHelper
{
    public static NetworkStream StartServer()
    {
        try
        {
            ProcessStartInfo serverStartInfo = new ProcessStartInfo
            {
                FileName = @"C:\My projects\Server for app\server.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process? serverProcess = Process.Start(serverStartInfo);
            if (serverProcess == null)
            {
                throw new Exception("Не удалось запустить сервер.");
            }

            Console.WriteLine("Сервер запущен.");
            TcpClient client = new TcpClient("127.0.0.1", 54000);
            Console.WriteLine("Соединение с сервером установлено.");

            return client.GetStream();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при запуске сервера: {ex.Message}");
            throw;
        }
    }
}


