using System;
using ConsoleApp3;

namespace ConsoleAppRunner
{
    public class Run
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Введите выражение (введите 'end' для завершения):");

                string input;
                while ((input = Console.ReadLine()) != "end")
                {
                    string expressionWithoutSemicolon = input.TrimEnd(';');
                    
                    if (expressionWithoutSemicolon.Contains("=") && !expressionWithoutSemicolon.Contains("+"))
                    {
                        Console.WriteLine($"{expressionWithoutSemicolon};");
                        Calculator.Evaluate(input);
                    }
                    else
                    {
                        Console.WriteLine($"{expressionWithoutSemicolon} = {Calculator.Evaluate(input)};");
                    }
                }
            }
        }
    }
}