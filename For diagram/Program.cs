using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

class Program
{
    static async Task Main(string[] args)
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

        TcpClient client = new TcpClient("127.0.0.1", 54000);

        NetworkStream stream = client.GetStream();

        double density = 7.78, specificHeat = 0.449, alpha = 80.2, dt = 1, dx = 0.1, dy = 0.1;
        int highTempX = 5, highTempY = 5, nx = 10, ny = 10;
        float initialTemperature = 100.0f, ambientTemperature = 20.0f;

        //for (int numsteps = 100; numsteps<45000; numsteps+=100)
        //{
        //    stopwatch stopwatch = new stopwatch();
        //    stopwatch.start();

        //    stream.write(bitconverter.getbytes(1), 0, sizeof(int));
        //    stream.write(bitconverter.getbytes(density), 0, sizeof(double));
        //    stream.write(bitconverter.getbytes(specificheat), 0, sizeof(double));
        //    stream.write(bitconverter.getbytes(alpha), 0, sizeof(double));
        //    stream.write(bitconverter.getbytes(hightempx), 0, sizeof(int));
        //    stream.write(bitconverter.getbytes(initialtemperature), 0, sizeof(float));
        //    stream.write(bitconverter.getbytes(ambienttemperature), 0, sizeof(float));
        //    stream.write(bitconverter.getbytes(numsteps), 0, sizeof(int));
        //    stream.write(bitconverter.getbytes(nx), 0, sizeof(int));
        //    stream.write(bitconverter.getbytes(dt), 0, sizeof(double));
        //    stream.write(bitconverter.getbytes(dx), 0, sizeof(double));

        //    byte[] buffer = new byte[sizeof(double) * nx * numsteps];
        //    int bytesread = stream.read(buffer, 0, buffer.length);

        //    stopwatch.stop();
            
        //    using (filestream fstream = new filestream(@"c:\my projects\for diagram\1d.txt", filemode.append))
        //    {
        //        string text = $"{numsteps}: {stopwatch.elapsed}\r\n";
        //        // преобразуем строку в байты
        //        byte[] buffer1 = encoding.default.getbytes(text);
        //        // запись массива байтов в файл
        //        await fstream.writeasync(buffer1, 0, buffer1.length);
        //    }
        //    console.writeline($"1: {numsteps}");
        //    thread.sleep(500);
        //}

        for (int numSteps = 100; numSteps < 80000; numSteps += 100)
        {
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
            stream.Write(BitConverter.GetBytes(dt), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(dx), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(dy), 0, sizeof(double));

            byte[] buffer = new byte[sizeof(double) * nx * numSteps];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            stopwatch.Stop();

            using (FileStream fstream = new FileStream(@"C:\My projects\For diagram\2D.txt", FileMode.Append))
            {
                string text = $"{numSteps}: {stopwatch.Elapsed}\r\n";
                // преобразуем строку в байты
                byte[] buffer1 = Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                await fstream.WriteAsync(buffer1, 0, buffer1.Length);
            }
            Console.WriteLine($"2: {numSteps}");
            Thread.Sleep(500);
        }
    }
}