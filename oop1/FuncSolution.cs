using System;
using System.Collections.Generic;
using System.Text;

namespace oop1
{
    class FuncSolution
    {
        ///Оголошення та iнiцiалiзацiя змiнних
        private double _valueOfA = 0, _valueOfC = 0, _valueOfD = 0;
        public double result = 0;
        
        //Метод для перевiрки та обробки, керування можливостями класу
        public void Start()
        {
            Console.WriteLine("Формула виразу:");
            Console.WriteLine("      2*c-lg(d/4)");
            Console.WriteLine("y = ----------------");
            Console.WriteLine("        a*a-1\n\n");
            do
            {
                if (InputData())
                {
                    ShowExpression();
                    GetResult();
                }
                else
                {
                    Console.WriteLine("Перевiрте вхiднi данi!");
                }
                Console.WriteLine("Натиснiть ентер щоб вийти!\nАбо iнший символ щоб продовжити!");
            }
            while (Console.ReadKey().Key != ConsoleKey.Enter);
        }

    

        //Введення даних
        public bool InputData()
        {
            Console.Write("Введiть значення а=");
            if (!Double.TryParse(Console.ReadLine(), out _valueOfA))
            {
                return false;
            }
            Console.Write("Введiть значення c=");
            if (!Double.TryParse(Console.ReadLine(), out _valueOfC))
            {
                return false;
            }
            Console.Write("Введiть значення d=");
            if (!Double.TryParse(Console.ReadLine(), out _valueOfD))
            {
                return false;
            }
            
                return true;
            
        }
        //Вивiд на дисплей вхiдних даних
        public void ShowExpression()
        {
            Console.WriteLine("Значення змiнних:\nа={0};\nc={1};\nd={2}.", _valueOfA, _valueOfD, _valueOfD);
            Console.WriteLine("      2*{0}-lg({1}/4)", _valueOfC, _valueOfD);
            Console.WriteLine("y = ----------------");
            Console.WriteLine("        {0}*{0}-1", _valueOfA);

        }
        //Метод для обробки виразу
        public void GetResult()
        {
            //Обробка та перевiрка виключень пiд час обчислення виразу
            try
            {
               
                ///Перевiрка на логарифм вiд'ємного числа
                if (Double.IsNaN(Math.Log(_valueOfD / 4)))
                {
                    Console.WriteLine("Помилка в чисельнику: lg({0}/4)", _valueOfD);
                     throw new ArithmeticException("Логарифм вiд'ємного числа!!!");
                }
                //Перевiрка на логарифм нуля
                else if (_valueOfD / 4 == 0)
                {
                    Console.WriteLine("Помилка в чисельнику: lg({0}/4)", _valueOfD);
                    throw new ArithmeticException("Логарифм нуля!!!");
                }
                //Перевiрка дiлення на нуль
                else if (_valueOfA * _valueOfA - 1 == 0)
                {
                    Console.WriteLine("Помилка у знаменнику: {0}*{0}-1={1}", _valueOfA, _valueOfA * _valueOfA - 1);
                    throw new ArithmeticException("Дiлення на нуль!");
                }

                else
                {
                    result = (2 * _valueOfC - Math.Log(_valueOfD / 4)) / (_valueOfA * _valueOfA - 1);
                    Console.WriteLine("Результат виразу:\n y={0}",result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка обробки даних: {0}", e.Message);
            }
        }
    }
}
