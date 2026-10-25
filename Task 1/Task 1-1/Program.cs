using System;

namespace Task_1_1
{
    internal static class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Список формальных параметров. </param>
        static void Main(string[] args)
        {
            const double a = 2;
            const double b = 1;
            const double c = 3;

            double x = GetNumber("Введите x = ");

            double y = GetResult(a, b, c, x);

            Console.WriteLine($"x = {x}; y = {y}");
        }

        /// <summary>
        /// Получает число.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Число, введённое с клавиатуры. </returns>
        static double GetNumber(string message = "")
        {
            Console.Write(message);
            string input = Console.ReadLine();

            return double.Parse(input);
        }

        /// <summary>
        /// Вычисляет y = (a * |x^3| + 5/2 * b * sqrt(x^2 + 1)) / (c + sin(x) * cos(x)).
        /// </summary>
        /// <param name="a"> Константа a. </param>
        /// <param name="b"> Константа b. </param>
        /// <param name="c"> Константа c. </param>
        /// <param name="x"> Переменная x. </param>
        /// <returns> Значение функции. </returns>
        static double GetResult(double a, double b, double c, double x)
        {
            return (a * Math.Abs(x * x * x) + 5.0 / 2.0 * b * Math.Sqrt(x * x + 1)) /
                (c + Math.Sin(x) * Math.Cos(x));
        }
    }
}
