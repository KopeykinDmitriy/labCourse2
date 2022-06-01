using System;

namespace lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("Добро пожаловать в лабораторную работу 10");
            Console.WriteLine("");


            bool f = true;
            while (f)
            {
                Console.WriteLine("1. Работа с наследованиями");
                Console.WriteLine("2. Работа с интерфейсами");
                Console.WriteLine("3. Завершение работы");
                choice = enter_int();
                bool clear = true;
                switch (choice)
                {
                    case 1:
                        Nasled.Start();
                        break;
                    case 2:
                        Interfaces.Start();
                        break;
                    case 3:
                        Console.WriteLine("Программа завершена.");
                        f = false;
                        break;
                    default:
                        clear = false;
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                        break;
                }
                if (clear) Console.Clear();
            }
        }

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
            if (what == 'r')
                if (Convert.ToInt32(enter) < 0)
                {
                    Console.WriteLine("Ошибка. Количество элементов не может быть отрицательным. Попробуйте ещё раз:");
                    f = false;
                }
            if (what == 'p')
                if (Convert.ToInt32(enter) < 0)
                {
                    Console.WriteLine("Ошибка. Цена не может быть отрицательной. Попробуйте ещё раз:");
                    f = false;
                }
            if (what == 'c')
                if (Convert.ToInt32(enter) < 0)
                {
                    Console.WriteLine("Ошибка. Количество элементов не может быть отрицательным. Попробуйте ещё раз:");
                    f = false;
                }
            if (what == 'z')
                if (Convert.ToInt32(enter) < 0 || Convert.ToInt32(enter) > 100)
                {
                    Console.WriteLine("Ошибка. Жирность может быть только от 0 до 100 %. Попробуйте ещё раз:");
                    f = false;
                }
            if (f)
                number = Convert.ToInt32(enter);
            else number = enter_int();
            return number;
        }
    }
}
