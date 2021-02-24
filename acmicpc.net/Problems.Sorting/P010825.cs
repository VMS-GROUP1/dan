using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace acmicpc.net.Problems.Sorting
{
    public class P010825
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> members = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Student member = new Student(input[0], int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]));
                members.Add(member);
            }

            members.Sort();
            StringBuilder sb = new StringBuilder(100000);
            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                    sb.AppendLine();

                sb.Append(members[i].Name);
            }

            Console.WriteLine(sb.ToString());
        }

        public class Student : IComparable<Student>
        {
            public string Name;
            public int Korean;
            public int English;
            public int Math;

            public Student(string name, int korean, int english, int math)
            {
                Name =name;
                Korean = korean;
                English = english;
                Math = math;
            }

            public int CompareTo(Student other)
            {
                int cmp = this.Korean.CompareTo(other.Korean) * -1;
                if (cmp != 0)
                    return cmp;

                cmp = this.English.CompareTo(other.English);
                if (cmp != 0)
                    return cmp;

                cmp = this.Math.CompareTo(other.Math) * -1;
                if (cmp != 0)
                    return cmp;
                
                return this.Name.CompareTo(other.Name);
            }
        }
    }
}