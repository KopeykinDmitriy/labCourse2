using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    class Nasled
    {
        static Tovar[] arr;
        static int size;
        static string[] NameOfProduckts = { "potato", "apple", "carrot", "tomato", "onion"};
        static string[] NameOfIgrushki = { "car", "doll", "teddy", "cubes", "mosaic" };
        static string[] NameOfMolochnyProduckts = { "milk", "cheese", "kefir", "koumiss", "butter" };

        static void ShowArrayVirtual()
        {
            int n = 0;
            if (size == 0) Console.WriteLine("Массив пуст");
            else
            foreach (Tovar elem in arr)
                {
                    n++;
                    Console.Write($"{n})");
                    elem.Show();
                }
        }

        static void ShowArrayNonVirtual()
        {
            int n = 0;
            if (size == 0) Console.WriteLine("Массив пуст");
            else
                foreach (Tovar elem in arr)
                {
                    n++;
                    Console.Write($"{n})");
                    if (elem is MolochnyProduckt) (elem as MolochnyProduckt).ShowM();
                    else
                    if (elem is Igrushka) (elem as Igrushka).ShowI();
                    else
                    if (elem is Produckt) (elem as Produckt).ShowP();
                    else
                    if (elem is Tovar) elem.ShowT();
                }
        }

        static void InitArrTovar()
        {
            Console.WriteLine("Сколько элементов класса Tovar? - ");
            int sizeR;
            sizeR = enter_int('r');
            Tovar[] temp = new Tovar[sizeR];
            if (sizeR > 0)
            {
                Console.WriteLine("Введите 1, если желаете ввести данные вручную, иначе массив заполнится рандомными данными");
                if (Console.ReadLine() == "1")
                {
                    for (int i = 0; i < sizeR; i++)
                    {
                        Console.WriteLine($"Введите код {i + 1}-го товара - ");
                        int code = enter_int('c');
                        Console.WriteLine($"Введите цену {i + 1}-го товара - ");
                        int price = enter_int('p');
                        temp[i] = new Tovar(code, price);
                    }
                }
                else
                {
                    Random rnd = new Random();
                    for (int i = 0; i < sizeR; i++)
                    {
                        int code = rnd.Next(10,100);
                        int price = rnd.Next(10000);
                        temp[i] = new Tovar(code, price);
                    }
                }

                Tovar[] temp2 = new Tovar[size + sizeR];

                for (int i = 0; i < size + sizeR; i++)
                {
                    if (i < size) temp2[i] = arr[i];
                    else temp2[i] = temp[i - size];
                }

                arr = temp2;
                size += sizeR;
            }

        }

        static void InitArrProduckt()
        {
            Console.WriteLine("Сколько элементов класса Produckt? - ");
            int sizeR;
            sizeR = enter_int('r');
            Tovar[] temp = new Tovar[sizeR];
            if (sizeR > 0)
            {
                Console.WriteLine("Введите 1, если желаете ввести данные вручную, иначе массив заполнится рандомными данными");
                if (Console.ReadLine() == "1")
                {
                    for (int i = 0; i < sizeR; i++)
                    {
                        Console.WriteLine($"Введите код {i + 1}-го продукта - ");
                        int code = enter_int('c');
                        Console.WriteLine($"Введите цену {i + 1}-го продукта - ");
                        int price = enter_int('p');
                        Console.WriteLine($"Введите наименование {i + 1}-го продукта - ");
                        string name = Console.ReadLine();
                        temp[i] = new Produckt(code, price, name);
                    }
                }
                else
                {
                    Random rnd = new Random();
                    for (int i = 0; i < sizeR; i++)
                    {
                        int code = rnd.Next(10, 100);
                        int price = rnd.Next(10000);
                        string name = NameOfProduckts[rnd.Next(5)];
                        temp[i] = new Produckt(code, price, name);
                    }
                }

                Tovar[] temp2 = new Tovar[size + sizeR];

                for (int i = 0; i < size + sizeR; i++)
                {
                    if (i < size) temp2[i] = arr[i];
                    else temp2[i] = temp[i - size];
                }

                arr = temp2;
                size += sizeR;
            }


        }

        static void InitArrIgrushka()
        {
            Console.WriteLine("Сколько элементов класса Igrushka? - ");
            int sizeR;
            sizeR = enter_int('r');
            Tovar[] temp = new Tovar[sizeR];
            if (sizeR > 0)
            {
                Console.WriteLine("Введите 1, если желаете ввести данные вручную, иначе массив заполнится рандомными данными");
                if (Console.ReadLine() == "1")
                {
                    for (int i = 0; i < sizeR; i++)
                    {
                        Console.WriteLine($"Введите код {i + 1}-ой игрушки - ");
                        int code = enter_int('c');
                        Console.WriteLine($"Введите цену {i + 1}-ой игрушки - ");
                        int price = enter_int('p');
                        Console.WriteLine($"Введите наименование {i + 1}-ой игрушки - ");
                        string name = Console.ReadLine();
                        temp[i] = new Igrushka(code, price, name);
                    }
                }
                else
                {
                    Random rnd = new Random();
                    for (int i = 0; i < sizeR; i++)
                    {
                        int code = rnd.Next(10, 100);
                        int price = rnd.Next(10000);
                        string name = NameOfIgrushki[rnd.Next(5)];
                        temp[i] = new Igrushka(code, price, name);
                    }
                }

                Tovar[] temp2 = new Tovar[size + sizeR];

                for (int i = 0; i < size + sizeR; i++)
                {
                    if (i < size) temp2[i] = arr[i];
                    else temp2[i] = temp[i - size];
                }

                arr = temp2;
                size += sizeR;
            }


        }

        static void InitArrMolochnyProduckt()
        {
            Console.WriteLine("Сколько элементов класса MolochnyProduckt? - ");
            int sizeR;
            sizeR = enter_int('r');
            Tovar[] temp = new Tovar[sizeR];
            if (sizeR > 0)
            {
                Console.WriteLine("Введите 1, если желаете ввести данные вручную, иначе массив заполнится рандомными данными");
                if (Console.ReadLine() == "1")
                {
                    for (int i = 0; i < sizeR; i++)
                    {
                        Console.WriteLine($"Введите код {i + 1}-го молочного продукта - ");
                        int code = enter_int('c');
                        Console.WriteLine($"Введите цену {i + 1}-го молочного продукта - ");
                        int price = enter_int('p');
                        Console.WriteLine($"Введите наименование {i + 1}-го молочного продукта - ");
                        string name = Console.ReadLine();
                        Console.WriteLine($"Введите жирность {i + 1}-го молочного продукта - ");
                        int zhirnost = enter_int('z');
                        temp[i] = new MolochnyProduckt(code, price, name, zhirnost);
                    }
                }
                else
                {
                    Random rnd = new Random();
                    for (int i = 0; i < sizeR; i++)
                    {
                        int code = rnd.Next(10, 100);
                        int price = rnd.Next(10000);
                        string name = NameOfMolochnyProduckts[rnd.Next(5)];
                        int zhirnost = rnd.Next(101);
                        temp[i] = new MolochnyProduckt(code, price, name, zhirnost);
                    }
                }
            
                Tovar[] temp2 = new Tovar[size + sizeR];

                for (int i = 0; i < size + sizeR; i++)
                {
                    if (i < size) temp2[i] = arr[i];
                    else temp2[i] = temp[i - size];
                }

                arr = temp2;
                size += sizeR;
            }


        }

        static void InitArr()
        {
            arr = new Tovar[0];
            size = 0;
            InitArrTovar();
            InitArrIgrushka();
            InitArrProduckt();
            InitArrMolochnyProduckt();
        }

        public static void Start()
        {
            Console.WriteLine("Начало работы с наследованиями");
            Console.WriteLine("Инициализируем массив");
            
            InitArr();

            int choice;
            bool f = true;
            while (f)
            {
                Console.WriteLine("1. Просмотреть массив с помощью виртуальной функции");
                Console.WriteLine("2. Просмотреть массив с помощью невиртуальной функции");
                Console.WriteLine("3. Инициализировать массив заново");
                Console.WriteLine("4. Найти самую дорогую и самую дешевую игрушку в магазине");
                Console.WriteLine("5. Найти суммарную стоимость товара заданного наименования");
                Console.WriteLine("6. Найти количество товара заданного наименования");
                Console.WriteLine("7. Назад");
                choice = enter_int();
                bool clear = true;
                switch (choice)
                {
                    case 1:
                        ShowArrayVirtual();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 2:
                        ShowArrayNonVirtual();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 3:
                        InitArr();
                        break;
                    case 4:
                        FindMaxAndMinPriceIgrushka();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 5:
                        FindSumPriceOfName();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 6:
                        FindAmountOfName();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 7:
                        
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

        static void FindMaxAndMinPriceIgrushka()
        {
            if (size == 0) Console.WriteLine("Массив пуст");
            else
            {
                bool f = false;
                int min = -1;
                int max = -1;
                int minElem = -1, maxElem = -1;
                for (int i = 0; i < size; i++)
                {
                    if (arr[i] is Igrushka)
                    {
                        f = true;
                        if (min == -1 && max == -1)
                        {
                            min = (arr[i] as Igrushka).GetPrice();
                            max = (arr[i] as Igrushka).GetPrice();
                            minElem = i;
                            maxElem = i;
                        }
                        else
                            if ((arr[i] as Igrushka).GetPrice() < min)
                        {
                            min = (arr[i] as Igrushka).GetPrice();
                            minElem = i;
                        }
                        else
                            if ((arr[i] as Igrushka).GetPrice() > max)
                        {
                            max = (arr[i] as Igrushka).GetPrice();
                            maxElem = i;
                        }
                    }
                }

                if (!f) Console.WriteLine("В массиве нет элементов класса Igrushka");
                else
                {
                    Console.WriteLine($"Минимальный {minElem+1}-ый элемент:"); arr[minElem].Show();
                    Console.WriteLine($"Максимальный {maxElem + 1}-ый элемент:"); arr[maxElem].Show();
                }
            }
        }

        static void FindSumPriceOfName()
        {
            if (size == 0) Console.WriteLine("Массив пуст");
            else
            {
                long sum = 0;
                Console.Write("Введите наименование товара = ");
                string findName = Console.ReadLine();
                for (int i = 0; i < size; i++)
                {
                    if (arr[i] is Igrushka)
                    {
                        if ((arr[i] as Igrushka).GetName() == findName) sum += (arr[i] as Igrushka).GetPrice();
                    }
                    else
                    if (arr[i] is MolochnyProduckt)
                    {
                        if ((arr[i] as MolochnyProduckt).GetName() == findName) sum += (arr[i] as MolochnyProduckt).GetPrice();
                    }
                    else
                    if (arr[i] is Produckt)
                    {
                        if ((arr[i] as Produckt).GetName() == findName) sum += (arr[i] as Produckt).GetPrice();
                    }
                }
                if (sum == 0) Console.WriteLine("Товаров с заданным наименованием не найдено");
                else
                {
                    Console.WriteLine($"Сумма цен товаров с заданным наименованием равна = {sum}");
                }
            }
        }

        static void FindAmountOfName()
        {
            if (size == 0) Console.WriteLine("Массив пуст");
            else
            {
                long n = 0;
                Console.Write("Введите наименование товара = ");
                string findName = Console.ReadLine();
                for (int i = 0; i < size; i++)
                {
                    if (arr[i] is MolochnyProduckt)
                    {
                        if ((arr[i] as MolochnyProduckt).GetName() == findName) n += 1;
                    }
                    else
                    if (arr[i] is Igrushka)
                    {
                        if ((arr[i] as Igrushka).GetName() == findName) n += 1;
                    }
                    else
                    if (arr[i] is Produckt)
                    {
                        if ((arr[i] as Produckt).GetName() == findName) n += 1;
                    }
                }
                if (n == 0) Console.WriteLine("Товаров с заданным наименованием не найдено");
                else
                {
                    Console.WriteLine($"Количество товаров с заданным наименованием = {n}");
                }
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
            if (what == 'u')
                if (Convert.ToInt32(enter) < 10 || Convert.ToInt32(enter) > 100)
                {
                    Console.WriteLine("Ошибка. Код товара должен быть больше 9 и меньше 101. Попробуйте ещё раз:");
                    f = false;
                }
            if (f)
                number = Convert.ToInt32(enter);
            else number = enter_int();
            return number;
        }

    }
}
