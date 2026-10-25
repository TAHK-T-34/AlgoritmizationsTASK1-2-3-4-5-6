using System;
using System.Globalization;

namespace Task_2_3
{
    /// <summary>
    /// Область координатной плоскости.
    /// </summary>
    internal enum Region
    {
        /// <summary> I четверть. </summary>
        QuadrantI,

        /// <summary> II четверть. </summary>
        QuadrantII,

        /// <summary> III четверть. </summary>
        QuadrantIII,

        /// <summary> IV четверть. </summary>
        QuadrantIV,

        /// <summary> Положительная полуось X. </summary>
        PositiveXAxis,

        /// <summary> Отрицательная полуось X. </summary>
        NegativeXAxis,

        /// <summary> Положительная полуось Y. </summary>
        PositiveYAxis,

        /// <summary> Отрицательная полуось Y. </summary>
        NegativeYAxis,

        /// <summary> Начало координат. </summary>
        Origin
    }

    internal static class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Список формальных параметров. </param>
        static void Main(string[] args)
        {
            double x = ReadDouble("Введите x = ");
            double y = ReadDouble("Введите y = ");

            Region region = GetRegion(x, y);

            Console.WriteLine($"Точка ({x}; {y}) находится: {GetRegionName(region)}.");
        }

        /// <summary>
        /// Определяет, в какой из 9 областей координатной плоскости лежит точка.
        /// </summary>
        /// <param name="x"> Координата x. </param>
        /// <param name="y"> Координата y. </param>
        /// <returns> Область, которой принадлежит точка. </returns>
        static Region GetRegion(double x, double y)
        {
            if (x == 0)
            {
                if (y == 0)
                {
                    return Region.Origin;
                }

                return y > 0 ? Region.PositiveYAxis : Region.NegativeYAxis;
            }

            if (y == 0)
            {
                return x > 0 ? Region.PositiveXAxis : Region.NegativeXAxis;
            }

            if (x > 0)
            {
                return y > 0 ? Region.QuadrantI : Region.QuadrantIV;
            }

            return y > 0 ? Region.QuadrantII : Region.QuadrantIII;
        }

        /// <summary>
        /// Возвращает текстовое описание области.
        /// </summary>
        /// <param name="region"> Область координатной плоскости. </param>
        /// <returns> Описание области. </returns>
        static string GetRegionName(Region region)
        {
            switch (region)
            {
                case Region.QuadrantI: return "в I четверти";
                case Region.QuadrantII: return "во II четверти";
                case Region.QuadrantIII: return "в III четверти";
                case Region.QuadrantIV: return "в IV четверти";
                case Region.PositiveXAxis: return "на положительной полуоси X";
                case Region.NegativeXAxis: return "на отрицательной полуоси X";
                case Region.PositiveYAxis: return "на положительной полуоси Y";
                case Region.NegativeYAxis: return "на отрицательной полуоси Y";
                case Region.Origin: return "в начале координат";
                default: throw new ArgumentOutOfRangeException(nameof(region));
            }
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
