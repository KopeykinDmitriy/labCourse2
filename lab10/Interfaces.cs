using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    class Interfaces
    {
        static IExecutable[] arr;
        static int size;

        static string[] NameOfProduckts = { "potato", "apple", "carrot", "tomato", "onion" };
        static string[] NameOfIgrushki = { "car", "doll", "teddy", "cubes", "mosaic" };
        static string[] NameOfMolochnyProduckts = { "milk", "cheese", "kefir", "koumiss", "butter" };

        static void ShowArray()
        {
            int n = 0;
            if (size == 0) Console.WriteLine("Массив пуст");
            else
                foreach (IExecutable elem in arr)
                {
                    n++;
                    Console.Write($"{n})");
                    elem.Print();
                }
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
                Console.WriteLine("1. Просмотреть массив");
                Console.WriteLine("2. Инициализировать массив заново");
                Console.WriteLine("3. Сортировка массива с помощью IComparable");
                Console.WriteLine("4. Сортировка и поиск в массиве с помощью ICompare");
                Console.WriteLine("5. Клонировать элемент с помощью IClonable");
                Console.WriteLine("6. Назад");
                choice = enter_int();
                bool clear = true;
                switch (choice)
                {
                    case 1:
                        ShowArray();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 2:
                        InitArr();
                        break;
                    case 3:
                        SortArray();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 4:
                        SortAndSearch();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 5:
                        CloneElement();
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 6:
                        
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

        static void InitArr()
        {
            arr = new IExecutable[0];
            size = 0;
            InitArrTovar();
            InitArrIgrushka();
            InitArrProduckt();
            InitArrMolochnyProduckt();
        }

        static void InitArrTovar()
        {
            Console.WriteLine("Сколько элементов класса Tovar? - ");
            int sizeR;
            sizeR = enter_int('r');
            IExecutable[] temp = new IExecutable[sizeR];
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
                        int code = rnd.Next(10, 100);
                        int price = rnd.Next(10000);
                        temp[i] = new Tovar(code, price);
                    }
                }

                IExecutable[] temp2 = new IExecutable[size + sizeR];

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
            IExecutable[] temp = new IExecutable[sizeR];
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

                IExecutable[] temp2 = new IExecutable[size + sizeR];

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
            IExecutable[] temp = new IExecutable[sizeR];
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

                IExecutable[] temp2 = new IExecutable[size + sizeR];

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
            IExecutable[] temp = new IExecutable[sizeR];
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

                IExecutable[] temp2 = new IExecutable[size + sizeR];

                for (int i = 0; i < size + sizeR; i++)
                {
                    if (i < size) temp2[i] = arr[i];
                    else temp2[i] = temp[i - size];
                }

                arr = temp2;
                size += sizeR;
            }


        }

        static void SortArray()
        {
            if (size == 0) Console.WriteLine("\nМассив пуст\n");
            else
            {
                Sort();
                Console.WriteLine("Массив был отсортирован по убыванию code");
                ShowArray();
            }
        }

        static void Sort() => Array.Sort(arr);

        static void SortAndSearch()
        {
            if (size == 0) Console.WriteLine("\nМассив пуст\n");
            else
            {
                SearchInArray();
                SortArrayIComparer();
                Console.WriteLine("Массив был отсортирован по возрастанию code");
                ShowArray();
            }
        }

        static void SearchInArray()
        {
            Console.WriteLine("Введите code товара, которое необходимо найти");
            int code = enter_int();

            int num = 0;
            bool f = false;

            foreach (IExecutable elem in arr)
            {
                num++;
                if (elem.Code == code)
                {
                    f = true;
                    Console.WriteLine($"Найдено совпадение, номер {num}");
                }
            }

            if (!f) Console.WriteLine($"Товаров с кодом {code} не найдено");
        }

        static void SortArrayIComparer() => Array.Sort(arr, new SortByCode());

        static void CloneElement()
        {
            Console.WriteLine("Создадим экземпляр класса Tovar");
            Tovar p1 = new Tovar(15, 6490);
            p1.ShowS();
            Console.WriteLine("Создадим 3 новых экземпляра класса Tovar без параметров, и будем в них копировать предыдущий экземпляр");
            Tovar r1 = new Tovar();
            Tovar r2 = new Tovar();
            Tovar r3 = new Tovar();
            r1 = p1;
            Console.Write($"1) Копирование адреса -> результат: ");
            r1.ShowS();
            r2 = (Tovar)p1.ShallowCopy();
            Console.Write($"2) Поверхностное копирование -> результат: ");
            r2.ShowS();
            r3 = (Tovar)p1.Clone();
            Console.Write($"3) Клонирование -> результат: ");
            r3.ShowS();
            Console.WriteLine($"\nА теперь изменим данные в основном экземпляре, и посмотрим на изменения:");
            p1.SetCode(65);
            p1.SetPrice(6565);
            p1.SetS("hello");
            Console.Write($"Наш основной экземпляр: "); p1.ShowS();
            Console.Write($"1) Копирование адреса -> результат: ");
            r1.ShowS();
            Console.Write($"2) Поверхностное копирование -> результат: ");
            r2.ShowS();
            Console.Write($"3) Клонирование -> результат: ");
            r3.ShowS();
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
                if (Convert.ToInt32(enter) < 10 || Convert.ToInt32(enter) > 99)
                {
                    Console.WriteLine("Ошибка. Код товара должен быть больше 9 и меньше 100. Попробуйте ещё раз:");
                    f = false;
                }
            if (f)
                number = Convert.ToInt32(enter);
            else number = enter_int();
            return number;
        }
    }

    public class SortByCode : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            IExecutable temp1 = (IExecutable)x;
            IExecutable temp2 = (IExecutable)y;

            return String.Compare(temp1.Code.ToString(), temp2.Code.ToString());
        }
    }
}
