using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems
{
    class P010950
    {
        public static void Main(string[] args)
        {
            int numOfCase = GetValue<int>(Console.ReadLine(), 1).FirstOrDefault();

            var cases = new List<IEnumerable<int>>();
            for (int i = 0; i < numOfCase; i++)
            {
                cases.Add(GetValue<int>(Console.ReadLine(), 2));
            }

            cases.ForEach(x => Console.WriteLine(x.Sum()));
        }

        static IEnumerable<T> GetValue<T>(string str, int count)
        {
            var values = str.Split();

            if (values.Count() < count)
                throw new ArgumentException();
            
            for (int i = 0; i < count; i++)
            {
                yield return (T)Convert.ChangeType(values[i], typeof(T));
            }            
        }
    }
}