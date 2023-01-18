using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CollectionHomework2
{
    class Program
    {

        static void Main(string[] args)
        {
            Func<double, double, double> lambda2 = (arg1, arg2) => arg1 + arg2;
            Console.WriteLine("Вызов лямбды, сохраненной в переменную-Func: " + lambda2(5, 7));
            Console.WriteLine("---");
            Console.WriteLine();

            Action<double, double> lambda3 = (arg1, arg2) => Console.WriteLine(arg1 + arg2);
            Console.Write("Вызов лямбды, сохраненной в переменную-Action: ");
            lambda3(5, 7);
            Console.WriteLine("---");
            Console.WriteLine();

            // Как работает каждая функиця по отдельности 
            // Можно закомментировать 



            //WriteDemo.Demo();
            //ReadDemo.Demo();
            //  ColorDemo.Demo();
            //Demo();

        }

        /// <summary>
        /// Опции меню
        /// </summary>
        private static string[] options = new[]{
            "Добавить книгу",
            "Вывести список непрочитанного",
            "Выйти"
        };

        /// <summary>
        /// На одну строку вниз
        /// </summary>
        private static void SetDown()
        {
            if (selectedValue < options.Length)
            {
                selectedValue++;
            }
        }

        /// <summary>
        /// На одну строку вверх
        /// </summary>
        private static void SetUp()
        {
            if (selectedValue > 1)
            {

                selectedValue--;
            }
        }

        /// <summary>
        /// Вывести меню
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("Для выхода нажмие Escape");
            for (var i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{((i + 1) == selectedValue ? '>' : ' ')}{i + 1}. {options[i]}");
            }
        }

        /// <summary>
        /// Исходное положение стрелки меню
        /// </summary>
        private static int selectedValue = 0;

        private static void WriteCursor(int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.Write(">");
            Console.SetCursorPosition(0, pos);
        }

        private static void ClearCursor(int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.Write(" ");
            Console.SetCursorPosition(0, pos);
        }

        /// <summary>
        /// Запуск меню
        /// </summary>
        private static void Start()
        {
            ConsoleKeyInfo ki;

            selectedValue = 1;

            do
            {
                PrintMenu();
                ki = Console.ReadKey();

                switch (ki.Key)
                {
                    case ConsoleKey.UpArrow:
                        SetUp();
                        break;
                    case ConsoleKey.DownArrow:
                        SetDown();
                        break;
                    default:
                        //WriteCursor(selectedValue);
                        break;
                }
                Console.Clear();
            } while (ki.Key != ConsoleKey.Escape);

        }

        public static void Demo()
        {
            //Krutilca();
            //Clear();
            //Start();
        }

        private static void Clear()
        {
            var i = 0;
            while (i < 10)
            {
                Console.WriteLine($"Строка под номером {i++}");
            }

            Console.Write("Сейчас все очищу, нажмите любую клавищу");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Все чисто");
        }


        /// <summary>
        /// Крутилка в консоли (демонстрация CursorPosition)
        /// </summary>
        private static void Krutilca()
        {
            var a = new char[] { '\\', '|', '/', '-' };

            Console.Write("\\ Начинаем крутится");
            var i = 0;

            do
            {
                //Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                Console.Write(a[(i++) % 4]);
                Thread.Sleep(300);
                // Прокручиваем 12 раз
            } while (i < 48);
        }
    }
}
