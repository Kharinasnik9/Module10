using System;

namespace MiniCalculator
{
    public interface ISum
    {
        decimal Add(decimal a, decimal b);
    }

    public class Calculator : ISum
    {
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            decimal NumberX = 0;
            decimal NumberY = 0;
            bool isValid = false;

            try
            {
                // Получаем первое число
                Console.Write("Введите первое число: ");
                NumberX = Convert.ToDecimal(Console.ReadLine());

                // Получаем второе число
                Console.Write("Введите второе число: ");
                NumberY = Convert.ToDecimal(Console.ReadLine());

                // Если всё прошло успешно, делаем сложение
                decimal result = calculator.Add(NumberX, NumberY);
                Console.WriteLine($"Результат: {NumberX} + {NumberY} = {result}");
                isValid = true;
            }
            catch (FormatException Ex)
            {
                Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, введите числовое значение.");
            }
            catch (OverflowException Ex)
            {
                Console.WriteLine("Ошибка: введённое число слишком большое или слишком маленькое.");
            }
            finally
            {
                if (!isValid)
                {
                    Console.WriteLine("Пожалуйста, попробуйте снова.");
                }
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
