using System;

namespace Task_1_3
{
    internal static class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Список формальных параметров. </param>
        static void Main(string[] args)
        {
            double m = GetNumber("Введите массу жидкости m (кг) = ");
            double l = GetNumber("Введите удельную теплоту парообразования L (Дж/кг) = ");

            double q = GetHeat(m, l);

            Console.WriteLine($"m = {m} кг; L = {l} Дж/кг");
            Console.WriteLine($"Необходимое количество теплоты Q = {q} Дж");
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
        /// Вычисляет количество теплоты для превращения жидкости в пар при температуре кипения Q = L * m.
        /// </summary>
        /// <param name="m"> Масса жидкости, кг. </param>
        /// <param name="l"> Удельная теплота парообразования, Дж/кг. </param>
        /// <returns> Количество теплоты, Дж. </returns>
        static double GetHeat(double m, double l)
        {
            return l * m;
        }
    }
}
