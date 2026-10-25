using System;
using System.Globalization;

namespace Task_2_2
{
    internal static class Program
    {
        private const double Epsilon = 1e-9;

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Список формальных параметров. </param>
        static void Main(string[] args)
        {
            double a = ReadDouble("Введите a = ");
            double b = ReadDouble("Введите b = ");
            double c = ReadDouble("Введите c = ");

            if (IsArithmeticProgression(a, b, c))
            {
                Console.WriteLine($"Числа образуют арифметическую прогрессию, разность d = {b - a}.");
            }
            else
            {
                Console.WriteLine("Числа не образуют арифметическую прогрессию.");
            }
        }

        /// <summary>
        /// Проверяет, образуют ли числа арифметическую прогрессию: b - a = c - b.
        /// Сравнение выполняется с точностью Epsilon из-за погрешности вещественных чисел.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <param name="c"> Третье число. </param>
        /// <returns> true, если разность соседних элементов постоянна. </returns>
        static bool IsArithmeticProgression(double a, double b, double c)
        {
            return Math.Abs((b - a) - (c - b)) < Epsilon;
        }

        /// <summary>
        /// Запрашивает вещественное число, пока не будет введено корректное значение.
        /// Допускается ввод с точкой или запятой.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Введённое число. </returns>
        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = (Console.ReadLine() ?? string.Empty).Replace(',', '.');

                if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
                    && !double.IsNaN(value) && !double.IsInfinity(value))
                {
                    return value;
                }

                Console.WriteLine("Ошибка: введите число.");
            }
        }
    }
}
