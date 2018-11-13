using System;
using System.Collections.Generic;

namespace BrickRoad
{
    class Program
    {
        /// <summary>
        /// Number of bricks
        /// </summary>
        static int count;
        /// <summary>
        /// Array representing the numbers on eavh brick
        /// </summary>
        static int[] arr;

        private static int MinMove(int current, int total, IList<int> path)
        {
            if (current + 1 == count)
                return total;

            path.Add(current);

            var result = count;
            for (int i = 0; i < count; i++)
            {
                if (!path.Contains(i) && (i == current - 1 || i == current + 1 || arr[current] == arr[i]))
                {
                    var _temp = MinMove(i, total + 1, new List<int>(path));
                    result = _temp < result ? _temp : result;
                }
            }

            return result;
        }

        private static void GetInputs()
        {
            Console.Write("Count of bricks -> ");
            count = Convert.ToInt32(Console.ReadLine());

            arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{i + 1}. bricks -> ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void Main(string[] args)
        {
            GetInputs();
            Console.WriteLine(MinMove(0, 0, new List<int>()));
            Console.Read();
        }
    }
}
