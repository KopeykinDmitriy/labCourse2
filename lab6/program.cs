using System;

namespace laba_6
{
    class Program
    {
        static int enter_int(char what = '0') // Ввод целого числа
        {
            string enter;
            bool f = true;
            enter = Console.ReadLine();
            int number;
            while (!int.TryParse(enter, out number))
            {
                Console.WriteLine("Ошибка. Неверный ввод. Попробуйте ещё раз: ");
                enter = Console.ReadLine();
            }
            if (what == 'n')
                if (Convert.ToInt32(enter) < 0)
                {
                    Console.WriteLine("Ошибка. Длина массива не может быть отрицательной. Попробуйте ещё раз:");
                    f = false;
                }
            if (f)
                number = Convert.ToInt32(enter);
            else number = enter_int();
            return number;
        }


        static char enter_char() // Ввод символа
        {
            string enter;
            enter = Console.ReadLine();
            char output;
            while (!char.TryParse(enter, out output))
            {
                Console.WriteLine("Ошибка. Неверный ввод. Попробуйте ещё раз: ");
                enter = Console.ReadLine();
            }
            output = Convert.ToChar(enter);
            return output;
        }


        static void vivod_mass(char[,] mass, int strings, int columns) // Вывод двумерного массива
        {

            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(mass[i, j] + " ");
                }
            }
        }


        static void vvod_mass(char[,] mass, int strings, int columns) // Заполнение двумерного массива
        {
            Console.WriteLine("Способ заполнения массива:");
            Console.WriteLine("");
            Console.WriteLine("1) Рандомные символы");
            Console.WriteLine("2) Ручной ввод");
            bool f = false;
            int choice;
            while (!f)
            {
                choice = enter_int();
                if (choice == 1)
                {
                    rand_vvod(mass, strings, columns);
                    f = true;
                }
                else
                if (choice == 2)
                {
                    hand_vvod(mass, strings, columns);
                    f = true;
                }
                else
                    Console.WriteLine("Неверный ввод, попробуйте ещё раз");
            }
        }


        static string zagotov_string()
        {
            Console.WriteLine("Заготовки:");
            Console.WriteLine("");
            Console.WriteLine("1) Hello. My name is Dima and I am glad to see you! How are you?");
            Console.WriteLine("2) Hi, my name is Dima!");
            Console.WriteLine("3) Hi.");
            bool f = false;
            int choice;
            string s = "";
            while (!f)
            {
                choice = enter_int();
                if (choice == 1)
                {
                    s = "Hello. My name is Dima and I am glad to see you! How are you?";
                    f = true;
                }
                else
                if (choice == 2)
                {
                    s = "Hi, my name is Dima!";
                    f = true;
                }
                if (choice == 3)
                {
                    s = "Hi.";
                    f = true;
                }
                else
                    Console.WriteLine("Неверный ввод, попробуйте ещё раз");
            }
            return s;
        }


        static string vvod_string() // Ввод строки
        {
            
            bool f = false;
            
            int choice;
            string s = "";
            while (!f)
            {
                Console.WriteLine("Способ ввода строки:");
                Console.WriteLine("");
                Console.WriteLine("1) Заготовленная строка");
                Console.WriteLine("2) Ручной ввод");
                bool r = true;
                choice = enter_int();
                if (choice == 1)
                {
                    s = zagotov_string();
                    f = true;
                }
                else
                if (choice == 2)
                {
                    Console.WriteLine("Вводите свою строку:");
                    s = Console.ReadLine();
                    for (int i = 1; i < s.Length && r; i++)
                    {
                        if ((s[i-1] == '.' && s[i] == '.') || (s[i - 1] == '!' && s[i] == '!') || (s[i - 1] == '?' && s[i] == '?'))
                        {
                            Console.WriteLine("Неверный ввод");
                            r = false;
                        }
                    }
                    if (r) f = true;
                }
                else
                    Console.WriteLine("Неверный ввод, попробуйте ещё раз");
            }
            return s;
        }


        static void rand_vvod(char[,] mass, int strings, int columns) // Заполнение двумерного массива рандомными числами
        {
            Random rnd = new Random();
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < columns; j++)
                {
                    int random = rnd.Next(0, 73);
                    mass[i, j] = chars[random];
                }
            }
        }


        static void hand_vvod(char[,] mass, int strings, int columns) // Ручное заполнение двумерного массива
        {
            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine("Введите [{0}, {1}] символ", i + 1, j + 1);
                    mass[i, j] = enter_char();
                }
            }
        }


        static void find_digit(char[,] mass, int strings, int columns, bool g) // Поиск цифры
        {
            if (g)
            {
                char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                bool r = false;
                for (int i = 0; i < strings; i++)
                {

                    bool f = false;
                    for (int j = 0; j < columns && !f; j++)
                    {
                        int code = Convert.ToInt32(mass[i, j]);
                        if ((code <= 57) && (code >= 48)) f = true;
                    }

                    for (int j = 0; j < columns && f; j++)
                    {
                        Console.Write(mass[i, j] + " ");
                        r = true;
                    }

                    if (f) Console.WriteLine("");
                }
                if (!r) Console.WriteLine("Массив пуст");
            }
            else
            {
                bool f = false;
                for (int i = 0; i < strings; i++)
                {
                    Console.WriteLine("");
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(mass[i, j] + " ");
                        f = true;
                    }
                }
                if (!f) Console.WriteLine("Массив пуст");
            }
        }


        static string init_string(string s) // Работа со строкой(переворот предложений)
        {
            int first = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] == '.') || (s[i] == '?')) first = i + 1;

                if (s[i] == '!')
                {
                    string temp = s.Substring(first, i - first);
                    char[] arr = temp.ToCharArray();
                    Array.Reverse(arr);
                    string temp_2 = new string(arr);

                    string temp_3 = s.Substring(0, first) + temp_2 + s.Substring(i, s.Length - i);
                    s = temp_3;

                    first = i + 1;
                }
            }
            return s;
        }



        static void Main(string[] args)
        {
            inter_face();
        }


        static void inter_face() // интерфейс
        {
            int choice;
            Console.WriteLine("Добро пожаловать в лабораторную работу 6");
            Console.WriteLine("");


            bool f = true;
            while (f)
            {
                Console.WriteLine("1. Первое задание. Работа с массивом");
                Console.WriteLine("2. Второе задание. Работа со строкой");
                Console.WriteLine("3. Закончить работу программы");
                choice = enter_int();
                switch (choice)
                {
                    case 1:
                        quest_one();
                        break;
                    case 2:
                        quest_two();
                        break;
                    case 3:
                        Console.WriteLine("Программа завершена.");
                        f = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                        break;
                }
            }
        }


        static void quest_one() // Первое задание
        {
            Console.WriteLine("");
            Console.WriteLine("Инициализируем двумерный массив");

            Console.WriteLine("Введите количество строк");
            int strings = enter_int('n'); // количество строк 
            Console.WriteLine("Введите количество столбцов");
            int columns = enter_int('n'); // количество столбцов
            char[,] mass = new char[strings, columns]; // инициализация двумерного массива

            vvod_mass(mass, strings, columns);

            vivod_mass(mass, strings, columns);
            bool f = true;
            bool g = false;
            while (f)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. Вывести массив в консоль");
                Console.WriteLine("2. Ввести элементы массива ещё раз");
                Console.WriteLine("3. Выполнить задание: Удалить все строки, в которых нет цифр");
                Console.WriteLine("4. Назад");
                Console.WriteLine("");
                int choice = enter_int();
                Console.WriteLine("");
                
                switch (choice)
                {
                    case 1:
                        find_digit(mass, strings, columns, g);
                        break;
                    case 2:
                        vvod_mass(mass, strings, columns);
                        break;
                    case 3:
                       

                        Console.WriteLine("Результат: ");
                        g = true;
                        find_digit(mass, strings, columns, g);
                        Console.WriteLine("");
                        Console.WriteLine("Задание выполнено");
                        break;
                    case 4:
                        f = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                        break;
                }
            }
        }


        static void quest_two() // Второе задание
        {
            Console.WriteLine("");
            Console.WriteLine("Инициализируем строку");
            string s = vvod_string();
            Console.WriteLine(s);
            Console.WriteLine("");
            Console.WriteLine("Измененная строка:");
            s = init_string(s);
            Console.WriteLine(s);
        }
    }
}
