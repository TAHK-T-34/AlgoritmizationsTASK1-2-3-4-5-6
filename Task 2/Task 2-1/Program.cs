using System;
using System.Globalization;

namespace Task_2_1
{
    /// <summary>
    /// Вариант вычисления для правильного многоугольника.
    /// </summary>
    internal enum Calculation
    {
        /// <summary> Периметр по длине стороны и числу сторон. </summary>
        Perimeter = 1,

        /// <summary> Радиус вписанной окружности по длине стороны и числу сторон. </summary>
        InscribedRadius = 2
    }

    internal static class Program
    {
        private const int MinSides = 3;

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Список формальных параметров. </param>
        static void Main(string[] args)
        {
            Console.WriteLine("Правильный многоугольник");

            Calculation choice = ReadCalculation();
            double a = ReadPositiveDouble("Введите длину стороны a = ");
            int n = ReadSides();

            switch (choice)
            {
                case Calculation.Perimeter:
                    Console.WriteLine($"Периметр P = {GetPerimeter(a, n)}");
                    break;

                case Calculation.InscribedRadius:
                    Console.WriteLine($"Радиус вписанной окружности r = {GetInscribedRadius(a, n)}");
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(choice));
            }
        }

        /// <summary>
        /// Вычисляет периметр правильного многоугольника P = n * a.
        /// </summary>
        /// <param name="a"> Длина стороны. </param>
        /// <param name="n"> Число сторон. </param>
        /// <returns> Периметр. </returns>
        static double GetPerimeter(double a, int n)
        {
            return n * a;
        }

        /// <summary>
        /// Вычисляет радиус вписанной окружности r = a / (2 * tg(180° / n)).
        /// </summary>
        /// <param name="a"> Длина стороны. </param>
        /// <param name="n"> Число сторон. </param>
        /// <returns> Радиус вписанной окружности. </returns>
        static double GetInscribedRadius(double a, int n)
        {
            return a / (2 * Math.Tan(Math.PI / n));
        }

        /// <summary>
        /// Запрашивает у пользователя вариант вычисления, пока не будет введено корректное значение.
        /// </summary>
        /// <returns> Выбранный вариант вычисления. </returns>
        static Calculation ReadCalculation()
        {
            while (true)
            {
                Console.WriteLine("Что вычислить?");
                Console.WriteLine("  1 - периметр");
                Console.WriteLine("  2 - радиус вписанной окружности");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int value)
                    && Enum.IsDefined(typeof(Calculation), value))
                {
                    return (Calculation)value;
                }

                Console.WriteLine("Ошибка: введите 1 или 2.");
            }
        }

        /// <summary>
        /// Запрашивает число сторон (целое, не менее 3).
        /// </summary>
        /// <returns> Число сторон. </returns>
        static int ReadSides()
        {
            while (true)
            {
                Console.Write($"Введите число сторон n (целое, не менее {MinSides}): ");

                if (int.TryParse(Console.ReadLine(), out int n) && n >= MinSides)
                {
                    return n;
                }

                Console.WriteLine($"Ошибка: нужно целое число не меньше {MinSides}.");
            }
        }

        /// <summary>
        /// Запрашивает положительное вещественное число (допускается точка или запятая).
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Положительное число. </returns>
        static double ReadPositiveDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = (Console.ReadLine() ?? string.Empty).Replace(',', '.');

                if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
                    && value > 0 && !double.IsInfinity(value))
                {
                    return value;
                }

                Console.WriteLine("Ошибка: нужно положительное число.");
            }
        }
    }
}
