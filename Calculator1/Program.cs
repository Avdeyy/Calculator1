using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{

    internal class Program
    {
        static double CalculateExpression(string input)
        {
            char[] operators = { '+', '-', '/', '*', '^', '%' };
            char chosenOperator = ' ';
            string[] parts;

            foreach (char op in operators)
            {
                if (input.Contains(op))
                {
                    chosenOperator = op;
                    parts = input.Split(op);
                    double operand1 = double.Parse(parts[0]);
                    double operand2 = double.Parse(parts[1]);

                    switch (op)
                    {
                        case '+':
                            return operand1 + operand2;
                        case '-':
                            return operand1 - operand2;
                        case '/':
                        case ':':
                            if (operand2 == 0)
                            {
                                throw new DivideByZeroException("Деление на ноль.");
                            }
                            return operand1 / operand2;
                        case '*':
                            return operand1 * operand2;
                        case '^':
                            return Math.Pow(operand1, operand2);
                        case '%':
                            return (operand1 * operand2) / 100;
                    }
                }
            }

            throw new ArgumentException("Неверный формат выражения.");
        }
        static void Main(string[] args)
        {

            string input;
            while (true)
            {
                Console.WriteLine("Введите выражение: ");
                input = Console.ReadLine();

                // Удаление лишних пробелов
                input = input.Replace(" ", "").Replace("\t", "");

                try
                {
                    double result = CalculateExpression(input);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }

            
        }
    }
}
