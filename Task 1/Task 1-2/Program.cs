using System;

namespace Task_1_2
{
    internal static class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Список формальных параметров. </param>
        static void Main(string[] args)
        {
            double r = GetNumber("Введите радиус основания R = ");
            double h = GetNumber("Введите высоту h = ");

            double area = GetLateralArea(r, h);

            Console.WriteLine($"R = {r}; h = {h}");
            Console.WriteLine($"Площадь боковой поверхности цилиндра S = {area}");
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
        /// Вычисляет площадь боковой поверхности цилиндра S = 2 * pi * R * h.
        /// </summary>
        /// <param name="r"> Радиус основания. </param>
        /// <param name="h"> Высота цилиндра. </param>
        /// <returns> Площадь боковой поверхности. </returns>
        static double GetLateralArea(double r, double h)
        {
            return 2 * Math.PI * r * h;
        }
    }
}
