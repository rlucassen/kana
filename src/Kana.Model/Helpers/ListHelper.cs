using System;
using System.Collections.Generic;

namespace Kana.Model.Helpers
{
    public static class ListHelper
    {
        private static Random random = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static IList<T> RandomItems<T>(this IList<T> list, int count)
        {
            if (list.Count == 0)
            {
                return new List<T>();
            }
            var lastIndex = 0;
            var randomList = new List<T>();
            for (var i = 1; i <= count; i++)
            {
                var index = random.Next(list.Count);
                while (index == lastIndex)
                {
                    index = random.Next(list.Count);
                }
                lastIndex = index;
                randomList.Add(list[index]);
            }
            return randomList;
        }
    }
}