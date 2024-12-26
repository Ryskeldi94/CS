using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerTests
{

    [TestClass]
    public class ServerConnectionTests
    {
        private const string ServerPath = @"C:\My projects\Server for app\server.exe";
        private const string ServerAddress = "127.0.0.1";
        private const int ServerPort = 54000;

        [TestMethod]
        public void TestRunServer()
        {
            // Arrange
            NetworkStream stream = null;

            try
            {
                // Act: Запуск сервера
                stream = ServerHelper.StartServer();

                // Assert: Проверяем, что поток не null
                Assert.IsNotNull(stream, "Не удалось запустить сервер.");
                Console.WriteLine("Сервер успешно запущен и поток создан.");
            }
            catch (Exception ex)
            {
                // Если возникло исключение, логируем его
                Console.WriteLine($"Ошибка при запуске сервера: {ex.Message}");
                Assert.Fail("Исключение при запуске сервера.");
            }
            finally
            {
                // Закрываем поток, если он был создан
                stream?.Close();
                Console.WriteLine("Поток успешно закрыт.");
            }
        }

        [TestMethod]
        public void TestServerConnection()
        {
            // Arrange
            bool isConnected = false;
            NetworkStream stream = null;
            int maxAttempts = 5;
            int attempt = 1;
            bool serverWasRunningInitially = ServerHelper.IsServerRunning();

            try
            {
                // Act: Запуск сервера, если он не работает
                if (!serverWasRunningInitially)
                {
                    stream = ServerHelper.StartServer();
                }

                // Попытки подключения к серверу с небольшой задержкой
                while (attempt <= maxAttempts)
                {
                    try
                    {
                        using (TcpClient client = new TcpClient())
                        {
                            client.Connect("127.0.0.1", 54000);
                            isConnected = client.Connected;
                            if (isConnected) break;
                        }
                    }
                    catch
                    {
                        // Подключение не удалось, увеличиваем счетчик попыток
                        attempt++;
                        Thread.Sleep(1000); // Подождать 1 секунду перед следующей попыткой
                    }
                }
            }
            catch (Exception ex)
            {
                // Логируем исключение для диагностики
                Console.WriteLine($"Ошибка при подключении к серверу: {ex.Message}");
                isConnected = false;
            }
            finally
            {
                // Останавливаем сервер, только если он был запущен тестом
                if (!serverWasRunningInitially)
                {
                    ServerHelper.StopServer();
                }
            }

            // Вывод информации для отладки
            Console.WriteLine($"Количество попыток: {attempt}");
            Console.WriteLine($"Подключение к серверу: {(isConnected ? "успешно" : "не удалось")}");

            // Assert: Проверка успешного подключения
            Assert.IsTrue(isConnected, $"Не удалось подключиться к серверу после {maxAttempts} попыток.");
        }


        [TestMethod]
        public void TestTimeServer()
        {

            var stream = ServerHelper.StartServer();

            int numSteps = JustHerpel.IminInput(100, 45000);
            bool solve = JustHerpel.IminInput(1,3)==1;

            double density = 7.78, specificHeat = 0.449, alpha = 80.2, dt = 0.1, dx = 0.1, dy = 0.1;
            int highTempX = 5, highTempY = 5, nx = 10, ny = 10;
            float initialTemperature = 100.0f, ambientTemperature = 20.0f;


            // Стартуем секундомер
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (solve)
            {
                // Отправка данных на сервер
                stream.Write(BitConverter.GetBytes(1), 0, sizeof(int));
                stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
                stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
                stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
                stream.Write(BitConverter.GetBytes(highTempX), 0, sizeof(int));
                stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
                stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
                stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
                stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));
                stream.Write(BitConverter.GetBytes(dt), 0, sizeof(double));
                stream.Write(BitConverter.GetBytes(dx), 0, sizeof(double));

                // Буфер для чтения данных
                byte[] buffer = new byte[sizeof(double) * nx * numSteps];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
            } 
            else
            {
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

                byte[] buffer = new byte[sizeof(double) * nx * ny * numSteps];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
            }
                
            stopwatch.Stop();

            Console.WriteLine(solve ? "В одномерном пространстве" : "В двухмерном пространстве");
            Console.WriteLine($"Количество шагов: {numSteps}");
            Console.WriteLine($"Время выполнения: {stopwatch.Elapsed.TotalSeconds} секунд");

            double expectedTimePerStep = 0.01; // ожидаемое время в секундах на шаг
            double actualTimePerStep = stopwatch.Elapsed.TotalSeconds / numSteps;

            Assert.IsTrue(actualTimePerStep < expectedTimePerStep,
                $"Время на шаг ({actualTimePerStep:F4} сек) превышает допустимое ({expectedTimePerStep} сек)");
        }

    }
}
