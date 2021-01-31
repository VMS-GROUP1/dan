using System;
using System.Reflection;

namespace acmicpc.net
{
    class Program
    {
        const string MethodName = "Main";
        const string FolderName = "Problems";
        const string StopCommand = "stop";

        static void Main(string[] args)
        {
            string problem = "P010992";

            Assembly assembly = Assembly.GetExecutingAssembly();
            var nameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;

            while (true)
            {
                Console.Write("Input Class Name (null: in source code, 'stop': Stop Program): ");
                string input = Console.ReadLine();
                if (input == StopCommand)
                    break;

                string className = string.IsNullOrEmpty(input) ? problem : input;

                try
                {
                    Type type = assembly.GetType($"{nameSpace}.{FolderName}.{className}");
                    var method =type.GetMethod(MethodName, BindingFlags.Public | BindingFlags.Static);
                    Console.WriteLine($"Run '{type.FullName}'");
                    method.Invoke(null, new string[1]);
                    break;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    System.Console.WriteLine("Retry.");
                }
            }
        }
    }
}
