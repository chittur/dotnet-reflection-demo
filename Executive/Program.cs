/******************************************************************************
 * Filename    = Program.cs
 *
 * Author      = Ramaswamy Krishnan-Chittur
 *
 * Product     = ReflectionDemo
 * 
 * Project     = Executive
 *
 * Description = Demonstrates .NET reflection.
 *****************************************************************************/

using System.Reflection;

namespace Executive
{
    /// <summary>
    /// Class to demonstrate .NET reflection.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Prints the types and their methods in the given assembly.
        /// </summary>
        /// <param name="path">Path to the .NET assembly.</param>
        static void PrintTypes(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            Console.WriteLine($"Assembly: {assembly.FullName}");
            Console.WriteLine("=========================");
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine(type.FullName);
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"\t{method.Name}");
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (ParameterInfo parameter in parameters)
                    {
                        Console.WriteLine($"\t\tParameter={parameter.Name?.ToString()}");
                        Console.WriteLine($"\t\t\tType={parameter.ParameterType.ToString()}");
                        Console.WriteLine($"\t\t\tPosition={parameter.Position.ToString()}");
                        Console.WriteLine($"\t\t\tOptional={parameter.IsOptional.ToString()}");
                    }
                }
            }
        }

        /// <summary>
        /// The executive function.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    Console.WriteLine("Usage: Executive.exe <path of .NET binary>");
                    return;
                }

                PrintTypes(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}