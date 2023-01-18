using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Librarian
{
    class Program
    {
        public static Dictionary<string, int> ConcurrentDictionary = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            var menuOption = Menu.Demo();

            switch (menuOption)
            {
                case 1:
                    AddBook();
                    menuOption = Menu.Demo();
                    break;
                case 2:
                    GetListBook();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        private static void GetListBook()
        {
            throw new NotImplementedException();
        }

        private static void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Введите название книги:");
            ConcurrentDictionary.Add(Console.ReadLine(), 0);
            Console.WriteLine("Книга упешно добавлена");
            Console.WriteLine("Для выхода в меню нажмите любую клавишу");
            Console.ReadKey();
        }

        public class Menu
        {
            /// <summary>
            /// Опции меню
            /// </summary>
            private static string[] options = new[]
            {
            "Добавить книгу",
            "Вывести список",
            "Выйти"
            };

            /// <summary>
            /// Исходное положение стрелки меню
            /// </summary>
            private static int selectedValue = 0;

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
                Console.WriteLine("Выберите опцию стрелками \"Вверх\" \"Вниз\":");
                for (var i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{((i + 1) == selectedValue ? '>' : ' ')}{i + 1}. {options[i]}");
                }
            }

            

            //private static void WriteCursor(int pos)
            //{
            //    Console.SetCursorPosition(0, pos);
            //    Console.Write(">");
            //    Console.SetCursorPosition(0, pos);
            //}

            //private static void ClearCursor(int pos)
            //{
            //    Console.SetCursorPosition(0, pos);
            //    Console.Write(" ");
            //    Console.SetCursorPosition(0, pos);
            //}

            /// <summary>
            /// Запуск меню
            /// </summary>
            private static void Start()
            {
                Console.Clear();
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
                } while (ki.Key != ConsoleKey.Enter);

            }
            
            public static int Demo()
            {
                Start();
                return selectedValue;
            }

        }
    }
}
