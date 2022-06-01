using System;
using System.Linq;
using System.Diagnostics;

using lab_10;

namespace lab11
{
    class Program
    {
        static Stopwatch timer = new Stopwatch();

        static TestCollections collections = null;

        struct SearchResult
        {
            public bool isFounded;
            public long ticks;
        }

        static void Main(string[] args)
        {
            int action;

            do
            {
                PrintInterface();
                Console.WriteLine("Введите команду: ");
                action = enter_int();

                if (action != 0) DoAction(action);
            } while (action != 0);
        }

        static void PrintInterface()
        {
            if (collections == null) Console.WriteLine("Колекции не созданы\n\n");
            else Console.WriteLine($"Элементов в коллекциях: {collections.Count}\n\n");

            Console.WriteLine(
                "1. Создать коллекции\n" +
                "2. Добавить элемент в коллекции\n" +
                "3. Удалить элемент из коллекции\n" +
                "4. Измерить время нахождения первого элемента\n" +
                "5. Измерить время нахождения среднего элемента\n" +
                "6. Измерить время нахождения последнего элемента\n" +
                "7. Измерить время нахождения элемента по ключу с клавиатуры\n" +
                "8. Измерить время нахождения значения в словарях\n" +
                "9. Измерить время нахождения значения в словарях по value\n\n" +
                "0. Выход\n\n");
        }

        static void CreateCollections()
        {
            Console.WriteLine("Введите количество элементов коллекций: ");
            int len = enter_int('n');

            collections = new TestCollections(len); //Создание коллекций
        }

        static void DoAction(int actionNum)
        {
            bool clear = true;
            switch (actionNum)
            {
                case 1:
                    CreateCollections();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;
                case 2:
                    AddElement();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;
                case 3:
                    RemoveElement();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;
                case 4:
                    FindFirstElement();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;
                case 5:
                    FindMiddleElement();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;
                case 6:
                    FindLastElement();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;
                case 7:
                    FindAnotherElement();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;
                case 8:
                    FindValueByNum();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;
                case 9:
                    FindAnotherValue();
                    Console.WriteLine("Нажмите enter, чтобы продолжить");
                    Console.ReadLine();
                    break;


                default:
                    Console.WriteLine("Неизвестная команда\n");
                    clear = false;
                    break;
            }
            if (clear) Console.Clear();
        }
        
        static void FindFirstElement()
        {
            if (collections == null || collections.Count == 0) Console.WriteLine("Коллекции пусты!\n");
            else
            {

                Tovar first = new Tovar(collections.tovarList.First().Code, 0); //Запоминаем первый элемент

                Console.WriteLine($"Поиск первого элемента:\n");

                FindElementInCollections(first, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

                PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
            }
        }

        static void FindMiddleElement()
        {
            if (collections == null || collections.Count == 0) Console.WriteLine("Коллекции пусты!\n");
            else
            {
                int index = collections.tovarList.Count / 2;

                Tovar middle = new Tovar(collections.tovarList.ElementAt(index).Code, collections.tovarList.ElementAt(index).Price);

                Console.WriteLine($"Поиск среднего элемента:\n");

                FindElementInCollections(middle, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

                PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
            }
        }

        static void FindLastElement()
        {
            if (collections == null || collections.Count == 0) Console.WriteLine("Коллекции пусты!\n");
            else
            {
                Tovar last = new Tovar(collections.tovarList.Last().Code, collections.tovarList.Last().Price);

                Console.WriteLine($"Поиск последнего элемента:\n");

                FindElementInCollections(last, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

                PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
            }
        }

        static void FindAnotherElement()
        {
            if (collections == null || collections.Count == 0) Console.WriteLine("Коллекции пусты!\n");
            else
            {
                Console.WriteLine("Введите code для поиска в коллекции: ");
                int code = enter_int('u');
                Tovar tov = new Tovar(code, 0);

                Console.WriteLine($"Поиск элемента, которого нет в коллекции:\n");

                FindElementInCollections(tov, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

                PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
            }
        }

        static void FindValueByNum()
        {
            if (collections == null || collections.Count == 0) Console.WriteLine("Коллекции пусты!\n");
            else
            {
                Console.WriteLine("Введите номер искомого элемента: ");
                int num = enter_int();
                if (num < 1 || num > collections.Count) Console.WriteLine("Такого элемента нет");
                else
                {
                    Tovar key = collections.tovarList.ElementAt(num - 1);
                    Produckt value = collections.tovarSortedDict[key];

                    Produckt region = new Produckt(value.GetCode(), value.GetPrice(), value.GetName());

                    Console.WriteLine($"Искомое значение:\n" +
                        $"code = {region.GetCode()}\n");

                    if (FindValueInDict(region, out long ticks)) Console.WriteLine($"Элемент найден за {ticks} тиков\n");
                    else Console.WriteLine($"Элемент не найден за {ticks} тиков\n");
                }
            }
        }

        static void FindAnotherValue()
        {
            if (collections == null || collections.Count == 0) Console.WriteLine("Коллекции пусты!\n");
            else
            {
                Console.WriteLine("Введите name искомого товара: ");
                string name = Console.ReadLine();
                int code = 0;

                Produckt region = new Produckt(code, 0, name);

                if (FindValueInDict(region, out long ticks)) Console.WriteLine($"Элемент найден за {ticks} тиков\n");
                else Console.WriteLine($"Элемент не найден за {ticks} тиков\n");
            }
        }

        static void FindElementInCollections(Tovar element, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict)
        {
            inClsLL = new SearchResult(); inStrLL = new SearchResult(); inClsDict = new SearchResult(); inStrDict = new SearchResult();

            inClsLL.isFounded = FindElementInLinkedList(element, out inClsLL.ticks);
            inStrLL.isFounded = FindElementInLinkedList(element.Code.ToString(), out inStrLL.ticks);
            inClsDict.isFounded = FindElementInDict(element, out inClsDict.ticks);
            inStrDict.isFounded = FindElementInDict(element.Code.ToString(), out inStrDict.ticks);
        }

        static bool FindElementInLinkedList(Tovar keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.tovarList.Contains(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInLinkedList(string keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.StrList.Contains(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInDict(Tovar keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.tovarSortedDict.ContainsKey(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInDict(string keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.StrSortedDict.ContainsKey(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindValueInDict(Produckt value, out long ticks)
        {
            timer.Restart();
            bool result = collections.tovarSortedDict.ContainsValue(value);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }
        

        static void PrintResults(SearchResult inClsLL, SearchResult inStrLL, SearchResult inClsDict, SearchResult inStrDict)
        {
            if (inClsLL.isFounded) Console.WriteLine($"List, тип ключа - класс : Элемент найден за {inClsLL.ticks} тиков\n");
            else Console.WriteLine($"List, тип ключа - класс : Элемент не найден за {inClsLL.ticks} тиков\n");

            if (inStrLL.isFounded) Console.WriteLine($"List, тип ключа - строка: Элемент найден за {inStrLL.ticks} тиков\n");
            else Console.WriteLine($"List, тип ключа - строка: Элемент не найден за {inStrLL.ticks} тиков\n");

            if (inClsDict.isFounded) Console.WriteLine($"SortedDictionary, тип ключа - класс : Элемент найден за {inClsDict.ticks} тиков\n");
            else Console.WriteLine($"SortedDictionary, тип ключа - класс : Элемент не найден за {inClsDict.ticks} тиков\n");

            if (inStrDict.isFounded) Console.WriteLine($"SortedDictionary, тип ключа - строка: Элемент найден за {inStrDict.ticks} тиков\n");
            else Console.WriteLine($"SortedDictionary, тип ключа - строка: Элемент не найден за {inStrDict.ticks} тиков\n");
        }

        static void AddElement()
        {
            if (collections == null) collections = new TestCollections();

            Console.WriteLine("Введите code: ");
            int code = enter_int('u');
            Console.WriteLine("Введите name: ");
            string name = Console.ReadLine();

            Produckt prod = new Produckt(code, 0, name);
            Tovar tov = new Tovar(prod.GetCode(), 0);

            bool added = collections.AddToCollectons(prod, tov);

            if (!added) Console.WriteLine("Элемент с таким ключом уже есть в коллекциях, значение в словарях было перезаписано\n");
            else Console.WriteLine("Элемент добавлен\n");
        }

        static void RemoveElement()
        {
            if (collections == null || collections.Count == 0) Console.WriteLine("Коллекции пусты!\n");
            else
            {
                Console.WriteLine("Введите code: ");
                int code = enter_int('u');

                Tovar key = new Tovar(code, 0);

                bool removed = collections.RemoveFromCollectins(key);

                if (removed) Console.WriteLine("Элемент удалён\n");
                else Console.WriteLine("Такого элемента в коллекциях нет\n");
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
                if (Convert.ToInt32(enter) < 1)
                {
                    Console.WriteLine("Ошибка. Длина коллекции должна быть больше 0. Попробуйте ещё раз:");
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
                if (Convert.ToInt32(enter) < 10 || Convert.ToInt32(enter) > 10000)
                {
                    Console.WriteLine("Ошибка. Код товара должен быть больше 9 и меньше 10001. Попробуйте ещё раз:");
                    f = false;
                }
            if (f)
                number = Convert.ToInt32(enter);
            else number = enter_int(what);
            return number;
        }
    }
}
