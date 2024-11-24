using System;
using Test;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Выберите режим: тест функциональности сервера (1) или тест времени обработки (2):");
        int choice = UserInput.GetValidatedInput(1, 2);

        if (choice == 1)
        {
            Console.WriteLine("Выберите тип расчета: в одномерном пространстве (1) или в двухмерном пространстве (2):");
            int solveEquation = UserInput.GetValidatedInput(1, 2);

            if (solveEquation == 1)
            {
                var stream = ServerHelper.StartServer();
                FunctionalityTest.OneDimensionalCalculation(stream);
            }
            else if (solveEquation == 2)
            {
                var stream = ServerHelper.StartServer();
                FunctionalityTest.TwoDimensionalCalculation(stream);
            }
        }
        else if (choice == 2)
        {
            Console.WriteLine("Выберите тип расчета: в одномерном пространстве (1) или в двухмерном пространстве (2):");
            int solveEquation = UserInput.GetValidatedInput(1, 2);

            if (solveEquation == 1)
            {
                var stream = ServerHelper.StartServer();
                ProcessingTimeTest.OneDimensionalCalculation(stream);
            }
            else if (solveEquation == 2)
            {
                var stream = ServerHelper.StartServer();
                ProcessingTimeTest.TwoDimensionalCalculation(stream);
            }
        }
    }
}
