using System;

namespace laba_9
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
            if (what == 'r')
                if (Convert.ToInt32(enter) < 0)
                {
                    Console.WriteLine("Ошибка. Рубли или копейки не могут быть отрицательными. Попробуйте ещё раз:");
                    f = false;
                }
            if (f)
                number = Convert.ToInt32(enter);
            else number = enter_int();
            return number;
        }

        static void Main(string[] args)
        {
            inter_face();
        }

        static void inter_face() // интерфейс
        {
            int choice;
            Console.WriteLine("Добро пожаловать в лабораторную работу 9");
            Console.WriteLine("");


            bool f = true;
            while (f)
            {
                Console.WriteLine("1. Работа с функциями");
                Console.WriteLine("2. Работа с перегруженными операциями");
                Console.WriteLine("3. Работа с массивом");
                Console.WriteLine("4. Количество созданных экземпляров класса");
                Console.WriteLine("5. Завершение работы");
                choice = enter_int();
                bool clear = true;
                switch (choice)
                {
                    case 1:
                        quest_one();
                        break;
                    case 2:
                        quest_two();
                        break;
                    case 3:
                        quest_three();
                        break;
                    case 4:
                        Console.WriteLine("Количество созданных экземпляров класса равно = " + Money.get_count());
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 5:
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


        static void quest_one()
        {
            int choice;
            Console.WriteLine("Работа с функциями");
            Console.WriteLine("");


            bool f = true;
            bool clear = true;
            while (f)
            {
                
                if (clear) Console.Clear();
                Console.WriteLine("1. Использовать метод класса");
                Console.WriteLine("2. Использовать статический метод");
                Console.WriteLine("3. Назад");
                choice = enter_int();
                clear = true;
                switch (choice)
                {
                    case 1:
                        Money a;
                        Money b;
                        Console.WriteLine("Введите 1, если желаете вручную задать параметры класса, иначе будут использоваться заготовленные объекты класса");
                        if (Console.ReadLine() == "1")
                        {
                            int x;
                            int y;
                            Console.Write("Количество рублей первого объекта = ");
                            x = enter_int('r');
                            Console.Write("Количество копеек первого объекта = ");
                            y = enter_int('r');
                            a = new Money(x, y);
                            Console.WriteLine("Первый объект создан");
                            Console.Write("Количество рублей второго объекта = ");
                            x = enter_int('r');
                            Console.Write("Количество копеек второго объекта = ");
                            y = enter_int('r');
                            b = new Money(x, y);
                            Console.WriteLine("Второй объект создан");
                        }
                        else
                        {
                            a = new Money(47, 23);
                            b = new Money(29, 58);
                        }
                        Console.WriteLine("\nДанные объектов класса:");
                        a.show_money();
                        b.show_money();
                        Console.WriteLine("\nРезультат операции a - b:");
                        a.Subtraction(b);
                        a.show_money();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 2:
                        Money c;
                        Money d;
                        Console.WriteLine("Введите 1, если желаете вручную задать параметры класса, иначе будут использоваться заготовленные объекты класса");
                        if (Console.ReadLine() == "1")
                        {
                            int x;
                            int y;
                            Console.Write("Количество рублей первого объекта = ");
                            x = enter_int('r');
                            Console.Write("Количество копеек первого объекта = ");
                            y = enter_int('r');
                            c = new Money(x, y);
                            Console.WriteLine("Первый объект создан");
                            Console.Write("Количество рублей второго объекта = ");
                            x = enter_int('r');
                            Console.Write("Количество копеек второго объекта = ");
                            y = enter_int('r');
                            d = new Money(x, y);
                            Console.WriteLine("Второй объект создан");
                        }
                        else
                        {
                            c = new Money(63, 39);
                            d = new Money(32, 54);
                        }
                        Console.WriteLine("\nДанные объектов класса:");
                        c.show_money();
                        d.show_money();
                        Console.WriteLine("\nРезультат операции a - b:");
                        Money.Subtraction(c, d);
                        c.show_money();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 3:
                        
                        f = false;
                        break;
                    default:
                        clear = false;
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                        break;
                }
            }
        }

        static void quest_two()
        {
            int choice;
            Console.WriteLine("Работа с перегруженными операциями");
            Console.WriteLine("");


            bool f = true;
            bool clear = true;
            while (f)
            {
                
                if (clear) Console.Clear();
                Console.WriteLine("1. Работа с унарными операциями");
                Console.WriteLine("2. Работа с операциями приведения типа");
                Console.WriteLine("3. Работа с бинарными операциями");
                Console.WriteLine("4. Назад");
                choice = enter_int();
                clear = true;
                switch (choice)
                {
                    case 1:
                        Money a;
                        Console.WriteLine("Введите 1, если желаете вручную задать параметры класса, иначе будут использоваться заготовленные объекты класса");
                        if (Console.ReadLine() == "1")
                        {
                            int x;
                            int y;
                            Console.Write("Количество рублей первого объекта = ");
                            x = enter_int('r');
                            Console.Write("Количество копеек первого объекта = ");
                            y = enter_int('r');
                            a = new Money(x, y);
                            Console.WriteLine("Объект создан");
                        }
                        else
                        {
                            a = new Money(47, 23);
                        }
                        Console.WriteLine("\nДанные объекта класса:");
                        a.show_money();
                        Console.WriteLine("\nРезультат операции a++:");
                        Money b = new Money(a.get_rubles(), a.get_kopeks());
                        b++;
                        b.show_money();
                        Console.WriteLine("\nРезультат операции a--:");
                        a--;
                        a.show_money();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 2:
                        Money c;
                        Console.WriteLine("Введите 1, если желаете вручную задать параметры класса, иначе будут использоваться заготовленные объекты класса");
                        if (Console.ReadLine() == "1")
                        {
                            int x;
                            int y;
                            Console.Write("Количество рублей первого объекта = ");
                            x = enter_int('r');
                            Console.Write("Количество копеек первого объекта = ");
                            y = enter_int('r');
                            c = new Money(x, y);
                            Console.WriteLine("Объект создан");
                        }
                        else
                        {
                            c = new Money(12, 7);
                        }
                        Console.WriteLine("\nДанные объекта класса:");
                        c.show_money();
                        Console.WriteLine("\nРезультат операции неявного приведения к int:");
                        int r = c;
                        Console.WriteLine(r);
                        Console.WriteLine("\nРезультат операции явного приведения к double:");
                        double e = (double)c;
                        Console.WriteLine(e);
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 3:
                        Money w;
                        Money t;
                        int q;
                        Console.WriteLine("Введите 1, если желаете вручную задать параметры класса, иначе будут использоваться заготовленные объекты класса");
                        if (Console.ReadLine() == "1")
                        {
                            int x;
                            int y;
                            Console.Write("Количество рублей первого объекта = ");
                            x = enter_int('r');
                            Console.Write("Количество копеек первого объекта = ");
                            y = enter_int('r');
                            w = new Money(x, y);
                            Console.WriteLine("Первый объект создан");
                            Console.Write("Количество рублей второго объекта = ");
                            x = enter_int('r');
                            Console.Write("Количество копеек второго объекта = ");
                            y = enter_int('r');
                            t = new Money(x, y);
                            Console.WriteLine("Второй объект создан");
                            Console.Write("Введите целое число: ");
                            q = enter_int();
                        }
                        else
                        {
                            w = new Money(47, 23);
                            t = new Money(29, 58);
                            q = 24;
                        }
                        Console.WriteLine("\nДанные объектов класса и целое число:");
                        w.show_money();
                        t.show_money();
                        Console.WriteLine(q);
                        Console.WriteLine("\nРезультат операции Money - int:");
                        Money u = new Money(w.get_rubles(), w.get_kopeks());
                        u = u - q;
                        u.show_money();
                        Console.WriteLine("\nРезультат операции int - Money:");
                        Money o = new Money(w.get_rubles(), w.get_kopeks());
                        o = q - o;
                        o.show_money();
                        Console.WriteLine("\nРезультат операции Money - Money:");
                        Money er = new Money(w.get_rubles(), w.get_kopeks());
                        er = er - t;
                        er.show_money();
                        Console.WriteLine("\nРезультат операции Money + int:");
                        Money ur = new Money(w.get_rubles(), w.get_kopeks());
                        ur = ur + q;
                        ur.show_money();
                        Console.WriteLine("\nРезультат операции int + Money:");
                        Money or = new Money(w.get_rubles(), w.get_kopeks());
                        or = q + or;
                        or.show_money();
                        Console.WriteLine("\nРезультат операции Money + Money:");
                        Money eru = new Money(w.get_rubles(), w.get_kopeks());
                        eru = eru + t;
                        eru.show_money();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 4:
                        
                        f = false;
                        break;
                    default:
                        clear = false;
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                        break;
                }
            }
        }

        static void quest_three()
        {
            Console.Clear();
            Console.WriteLine("Работа с массивом");
            Console.WriteLine("");
            Console.WriteLine("Инициализируем массив");
            Console.Write("\nВведите количество элементов: ");
            int size = enter_int('n');
            MoneyArray array;
            Console.WriteLine("Введите 1, если желаете вручную заполнить массив, иначе он заполнится случайными данными");
            if (Console.ReadLine() == "1") array = new MoneyArray(size, "manually");
            else array = new MoneyArray(size, "random");
            Console.WriteLine("Нажмите enter, чтобы начать работу с массивом");
            Console.ReadLine();

            int choice;
            bool f = true;
            bool clear = true;
            while (f)
            {
                
                if (clear) Console.Clear();
                Console.WriteLine("1. Вывести массив");
                Console.WriteLine("2. Заполнить массив новыми данными");
                Console.WriteLine("3. Заново инициализировать массив");
                Console.WriteLine("4. Вывести максимальный элемент массива");
                Console.WriteLine("5. Работа с индексаторами");
                Console.WriteLine("6. Назад");
                choice = enter_int();
                clear = true;
                switch (choice)
                {
                    case 1:
                        array.show_array();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите 1, если желаете вручную заполнить массив, иначе он заполнится случайными данными");
                        if (Console.ReadLine() == "1") array = new MoneyArray(size, "manually");
                        else array = new MoneyArray(size, "random");
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("\nВведите количество элементов: ");
                        size = enter_int('n');
                        Console.WriteLine("Введите 1, если желаете вручную заполнить массив, иначе он заполнится случайными данными");
                        if (Console.ReadLine() == "1") array = new MoneyArray(size, "manually");
                        else array = new MoneyArray(size, "random");
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 4:
                        array.show_array();
                        array.max_element();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Введите индекс элемента, который вы желаете вывести в консоль? - ");
                        int i = enter_int();
                        if (i>size-1 || i < 0)
                        {
                            Console.WriteLine("Элемента с таким индексом нет в массиве");
                        }
                        else
                        {
                            array[i].show_money();
                        }
                        Console.WriteLine("Введите данные нового объекта");
                        int x;
                        int y;
                        Console.Write("Количество рублей объекта = ");
                        x = enter_int('r');
                        Console.Write("Количество копеек объекта = ");
                        y = enter_int('r');
                        Money w = new Money(x, y);
                        Console.Write("Введите индекс элемента, в который Вы хотите ввести эти данные - ");
                        int ir = enter_int();
                        if (ir > size - 1 || ir < 0)
                        {
                            Console.WriteLine("Элемента с таким индексом нет в массиве");
                        }
                        else
                        {
                            array[ir] = w;
                        }
                        array.show_array();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                        break;
                    case 6:
                        
                        f = false;
                        break;
                    default:
                        clear = false;
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                        break;
                }
            }

        }
    }
}
