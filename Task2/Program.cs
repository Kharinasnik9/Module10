using System;

namespace Task2
{
    public interface ISum
    {
        decimal Add(decimal a, decimal b);
    }

    public class Calculator : ISum
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public decimal Add(decimal a, decimal b)
        {
            _logger.LogInfo($"Начато сложение: {a} + {b}");
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger(); 
            Calculator calculator = new Calculator(logger);
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
                logger.LogError("Ошибка: введено некорректное значение. Пожалуйста, введите числовое значение.");
            }
            catch (OverflowException Ex)
            {
                logger.LogError("Ошибка: введённое число слишком большое или слишком маленькое.");
            }
            finally
            {
                if (!isValid)
                {
                    logger.LogInfo("Пожалуйста, попробуйте снова.");
                }
            }

            Console.ReadKey();
        }
    }
}
