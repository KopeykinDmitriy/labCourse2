using System;

namespace laba_5
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
            if (what == 'k')
                if (Convert.ToInt32(enter) < 0)
                {
                    Console.WriteLine("Ошибка. Нельзя увеличить количество столбцов на отрицательное число. Попробуйте ещё раз:");
                    f = false;
                }
            if (f)
                number = Convert.ToInt32(enter);
            else number = enter_int();
            return number;
        }


        static void vivod_mass(int[] mass) // Вывод одномерного массива
        {
            Console.WriteLine("Ваш массив:");
            foreach (int x in mass) Console.Write(x + " ");
        }


        static void vivod_mass(int[,] mass, int strings, int columns) // Вывод двумерного массива
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


        static void vivod_mass(int[][] mass, int strings, int k = -1) // Вывод рваного массива
        {
            bool f = false;
            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < mass[i].Length && i != k; j++)
                {
                    if (mass[i][0] != -1)
                    {
                        Console.Write(mass[i][j] + " ");
                        f = true;
                    }
                }
            }
            if (!f) Console.WriteLine("Массив пуст");
        }


        static void vvod_mass(int[] mass, int n) // Заполнение одномерного массива
        {
            Console.WriteLine("Способ заполнения массива:");
            Console.WriteLine("");
            Console.WriteLine("1) Рандомные числа");
            Console.WriteLine("2) Ручной ввод");
            bool f = false;
            int choice;
            while (!f)
            {
                choice = enter_int();
                if (choice == 1)
                {
                    rand_vvod(mass, n);
                    f = true;
                }
                else
                if (choice == 2)
                {
                    hand_vvod(mass, n);
                    f = true;
                }
                else
                    Console.WriteLine("Неверный ввод, попробуйте ещё раз");
            }
        }


        static void vvod_mass(int[,] mass, int strings, int columns) // Заполнение двумерного массива
        {
            Console.WriteLine("Способ заполнения массива:");
            Console.WriteLine("");
            Console.WriteLine("1) Рандомные числа");
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


        static void vvod_mass(int[][] mass, int strings) // Заполнение рваного массива
        {
            Console.WriteLine("Способ заполнения массива:");
            Console.WriteLine("");
            Console.WriteLine("1) Рандомные числа");
            Console.WriteLine("2) Ручной ввод");
            bool f = false;
            int choice;
            while (!f)
            {
                choice = enter_int();
                if (choice == 1)
                {
                    rand_vvod(mass, strings);
                    f = true;
                }
                else
                if (choice == 2)
                {
                    hand_vvod(mass, strings);
                    f = true;
                }
                else
                    Console.WriteLine("Неверный ввод, попробуйте ещё раз");
            }
        }


        static void rand_vvod(int[] mass, int n) // Заполнение одномерного массива рандомными числами
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++) mass[i] = rnd.Next(1, 100);
        }


        static void rand_vvod(int[][] mass, int strings) // Заполнение рваного массива рандомными числами
        {
            Random rnd = new Random();
            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < mass[i].Length; j++)
                    mass[i][j] = rnd.Next(1, 100);
            }
        }


        static void rand_vvod(int[,] mass, int strings, int columns) // Заполнение двумерного массива рандомными числами
        {
            Random rnd = new Random();
            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < columns; j++)
                    mass[i, j] = rnd.Next(1, 100);
            }
        }


        static void hand_vvod(int[] mass, int n) // Ручное заполнение одномерного массива
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите {0} число", i + 1);
                mass[i] = enter_int();
            }
        }


        static void hand_vvod(int[,] mass, int strings, int columns) // Ручное заполнение двумерного массива
        {
            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine("Введите [{0}, {1}] число", i + 1, j + 1);
                    mass[i, j] = enter_int();
                }
            }
        }


        static void hand_vvod(int[][] mass, int strings) // Ручное заполнение рваного массива
        {
            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < mass[i].Length; j++)
                {
                    Console.WriteLine("Введите [{0}, {1}] число", i + 1, j + 1);
                    mass[i][j] = enter_int();
                }
            }
        }


        static int find_k(int[][] mass, int strings, int k)
        {
            bool f = true;
            int k_string = -1;
            for (int i = 0; i < strings && f; i++)
                for (int j = 0; j < mass[i].Length && f; j++)
                    if (mass[i][j] == k && mass[i][0] != -1)
                    {
                        f = false;
                        mass[i][0] = -1;
                    }
            Console.WriteLine("");
            if (f) Console.WriteLine("k не найдено в массиве");
            Console.WriteLine("");
            return k_string;
        } // Поиск строки, в которой есть число k


        static void Main(string[] args)
        {
            inter_face();
        }


        static void inter_face() // интерфейс
        {
            int choice;
            Console.WriteLine("Добро пожаловать в лабораторную работу 5");
            Console.WriteLine("");
            
            
            bool f = true;
            while (f)
            {
                Console.WriteLine("1. Начать работу с одномерным массивом");
                Console.WriteLine("2. Начать работу с двумерным массивом");
                Console.WriteLine("3. Начать работу с рваным массивом");
                Console.WriteLine("4. Закончить работу программы");
                choice = enter_int();
                switch (choice)
                {
                    case 1:
                        quest_odnomer_mass();
                        break;
                    case 2:
                        quest_dvumer_mass();
                        break;
                    case 3:
                        quest_rvan_mass();
                        break;
                    case 4:
                        Console.WriteLine("Программа завершена.");
                        f = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                        break;
                }
            }
        }  


        static void quest_odnomer_mass() // задание с одномерным массивом
        {
            Console.WriteLine("");
            Console.WriteLine("Инициализируем одномерный массив");

            Console.WriteLine("Введите количество элеметов");
            int n = enter_int('n'); // Количество элементов одномерного массива
            int[] mass = new int[n]; // Объявление одномерного массива
            vvod_mass(mass, n);
            Console.WriteLine("");
            Console.WriteLine("Массив сформирован");



            bool f = true;
            while (f)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. Вывести массив в консоль");
                Console.WriteLine("2. Ввести элементы массива ещё раз");
                Console.WriteLine("3. Выполнить задание: Удалить все элементы с четными индексами");
                Console.WriteLine("4. Назад");
                Console.WriteLine("");
                int choice = enter_int();
                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        if (n != 0) vivod_mass(mass);
                        else Console.WriteLine("Массив пуст");
                        break;
                    case 2:
                        vvod_mass(mass, n);
                        break;
                    case 3:
                        int j = 0;
                        int[] res_mass;
                        if (n % 2 == 0) res_mass = new int[n / 2];
                        else res_mass = new int[n / 2 + 1];
                        for (int i = 0; i < n; i += 2)
                        {
                            res_mass[j] = mass[i];
                            j++;
                        }
                        n = j;

                        mass = res_mass;

                        Console.Write("Результат: ");
                        vivod_mass(mass);
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


        static void quest_dvumer_mass() // задание с двумерным массивом
        {
            Console.WriteLine("");
            Console.WriteLine("Инициализируем двумерный массив");

            Console.WriteLine("Введите количество строк");
            int strings = enter_int('n'); // количество строк 
            Console.WriteLine("Введите количество столбцов");
            int columns = enter_int('n'); // количество столбцов
            int[,] mass = new int[strings, columns]; // инициализация двумерного массива

            vvod_mass(mass, strings, columns);

            Console.WriteLine("");
            Console.WriteLine("Массив сформирован");

            bool f = true;
            while (f)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. Вывести массив в консоль");
                Console.WriteLine("2. Ввести элементы массива ещё раз");
                Console.WriteLine("3. Выполнить задание: Добавить k столбцов в конец матрицы");
                Console.WriteLine("4. Назад");
                Console.WriteLine("");
                int choice = enter_int();
                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        if (strings != 0 && columns != 0) vivod_mass(mass, strings, columns);
                        else Console.WriteLine("Массив пуст");
                        break;
                    case 2:
                        vvod_mass(mass, strings, columns);
                        break;
                    case 3:
                        Console.WriteLine("Введите k");
                        int k = enter_int('k');

                        Console.WriteLine("Введите новые элементы:");
                        int[,] mass_temp = new int[strings, k];
                        vvod_mass(mass_temp, strings, k);

                        Console.WriteLine("\nРезультат:\n");
                        int[,] mass_res = new int[strings, columns + k];
                        for (int i = 0; i < strings; i++)
                            for (int j = 0; j < columns; j++)
                                mass_res[i, j] = mass[i, j];

                        for (int i = 0; i < strings; i++)
                            for (int j = columns; j < columns + k; j++)
                                mass_res[i, j] = mass_temp[i, j - columns];

                        mass = mass_res;
                        columns = columns + k;

                        if (strings != 0 && columns != 0) vivod_mass(mass, strings, columns);
                        else Console.WriteLine("Массив пуст");
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


        static void quest_rvan_mass() // задание с рваным массивом
        {
            Console.WriteLine("");
            Console.WriteLine("Инициализируем рваный массив");

            Console.WriteLine("Введите количество строк");
            int strings = enter_int('n'); // количество строк
            Console.WriteLine("Введите количество столбцов для каждой строки");
            int[][] mass = new int[strings][]; // инициализация рваного массива
            bool empty = true;
            for (int i = 0; i < strings; i++)
            {
                Console.WriteLine("Количество стобцов {0} строки", i + 1);
                int columns = enter_int('n'); // количество столбцов отдельной строки
                mass[i] = new int[columns];
                if (columns > 0) empty = false;
            }
            vvod_mass(mass, strings);
            Console.WriteLine("");
            Console.WriteLine("Массив сформирован");

            bool f = true;
            while (f)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. Вывести массив в консоль");
                Console.WriteLine("2. Ввести элементы массива ещё раз");
                Console.WriteLine("3. Выполнить задание: Удалить первую строку, в которой встречается заданное число k");
                Console.WriteLine("4. Назад");
                Console.WriteLine("");
                int choice = enter_int();
                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        if (strings != 0 && !empty) vivod_mass(mass, strings);
                        else Console.WriteLine("Массив пуст");
                        break;
                    case 2:
                        vvod_mass(mass, strings);
                        break;
                    case 3:
                        Console.WriteLine("Введите число k");
                        int k = enter_int();
                        k = find_k(mass, strings, k);
                        Console.WriteLine("Результат:");
                        if (strings != 0 && !empty) vivod_mass(mass, strings, k);
                        else Console.WriteLine("Массив пуст");

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
    }
}
