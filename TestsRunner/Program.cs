using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var testClassType = typeof(CalculatorTests.EvaluateTests);
            var testClassInstance = Activator.CreateInstance(testClassType);
            var testMethods = testClassType.GetMethods();

            foreach (var method in testMethods)
            {
                if (Attribute.GetCustomAttribute(method, typeof(TestMethodAttribute)) != null)
                {
                    try
                    {
                        Console.WriteLine($"Запуск теста: {method.Name}");
                        method.Invoke(testClassInstance, null);
                        Console.WriteLine($"Тест {method.Name} успешно выполнен");
                    }
                    catch (TargetInvocationException e)
                    {
                        Console.WriteLine($"Ошибка в тесте {method.Name}: {e.InnerException.Message}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Неожиданная ошибка в тесте {method.Name}: {e.Message}");
                    }
                }
            }

            Console.WriteLine("Запуск тестов завершен");
        }
    }
}