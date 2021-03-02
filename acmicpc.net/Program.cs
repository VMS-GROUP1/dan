using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace acmicpc.net
{
    class Program
    {
        const string MethodName = "Main";
        const string FolderName = "Problems.Queue";
        const string StopCommand = "stop";
        const string RecentLogName = "recent.log";

        static void Main(string[] args)
        {
            string problem = "P010992";

            Assembly assembly = Assembly.GetExecutingAssembly();

            var nameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
            //var filePath = $@"{Directory.GetCurrentDirectory()}\{RecentLogName}";
            var tempPath = $@"{Path.GetTempPath()}{assembly.GetName().Name}";
            var recentLogPath = $@"{tempPath}\{RecentLogName}";
            new DirectoryInfo(tempPath).Create();

            while (true)
            {
                var lastName = GetLines(recentLogPath, 1).FirstOrDefault()?.Trim();
                var recentMenu = string.IsNullOrEmpty(lastName) ? string.Empty : $"'1': Recent '{lastName}', ";
                Console.Write($"Input Class Name (null: in source code, {recentMenu}'stop': Stop Program): ");
                string input = Console.ReadLine();
                if (input == StopCommand)
                    break;

                try
                {
                    string className = input;
                    if (string.IsNullOrEmpty(input))
                        className = problem;
                    else if (input == "1" && string.IsNullOrEmpty(lastName) is false)
                        className = lastName;

                    var method = GetProblem(assembly, $"{nameSpace}.{FolderName}.{className}");
                    Console.WriteLine($"Run '{method.DeclaringType.FullName}'");
                    WriteRecentLog(recentLogPath, className);
                    method.Invoke(null, new string[1]);
                    //break;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    System.Console.WriteLine("Retry.");
                }
            }
        }

        static MethodInfo GetProblem(Assembly assembly, string name)
        {
            try
            {
                Type type = assembly.GetType(name);
                if (type is null)
                    throw new Exception("Not found class.");

                var method = type.GetMethod(MethodName, BindingFlags.Public | BindingFlags.Static);
                return method;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static IEnumerable<string> GetLines(string path, int count)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    for (int i = 0; i < count; i++)
                    {
                        lines.Add(streamReader.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return lines;
            }
            catch (Exception)
            {
                throw;
            }

            return lines;
        }

        static void WriteRecentLog(string path, string name)
        {
            try
            {
                using (var recentLogFile = File.CreateText(path))
                    recentLogFile.WriteLine(name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
