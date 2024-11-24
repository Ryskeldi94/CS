using System;
using System.Diagnostics;

namespace Test
{
    public static class UserInput
    {
        public static int GetValidatedInput(int minValue, int maxValue)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == -1)
                    {
                        Environment.Exit(0);
                    }

                    if (input >= minValue && input <= maxValue)
                    {
                        return input; 
                    }
                }
                Console.WriteLine($"Введите число от {minValue} до {maxValue}:");
            }
        }


        public static int GetPositiveInteger(string message)
        {
            Console.WriteLine(message);
            while (true) 
            {
                if (int.TryParse(Console.ReadLine(),out int input))
                {
                    if (input == -1)
                    {
                        Environment.Exit(0);
                    }

                    if(input > 0)
                    {
                        return input;
                    }
                }
                Console.WriteLine("Введите положительное число:");
            }
        }
    }
}
