using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lab_10;

namespace lab11
{
    public class TestCollections
    {
        public List<Tovar> tovarList;
        public List<string> strList;
        static string[] NameOfProduckts = { "potato", "apple", "carrot", "tomato", "onion" };

        public SortedDictionary<Tovar, Produckt> tovarSortedDict;
        public SortedDictionary<string, Produckt> strSortedDict;

        public List<Tovar> TovarList
        {
            get => tovarList;
        }

        public List<string> StrList
        {
            get => strList;
        }

        public SortedDictionary<Tovar, Produckt> TovarSortedDict
        {
            get => tovarSortedDict;
        }

        public SortedDictionary<string, Produckt> StrSortedDict
        {
            get => strSortedDict;
        }

        public int Count
        {
            get => tovarList.Count;
        }

        public TestCollections() => CreateCollections();

        public TestCollections(int len)
        {
            bool f;

            Console.WriteLine("Введите 1, если желаете ввести данные вручную, иначе заполнится рандомными данными");

            if (Console.ReadLine() == "1") f = true; else f = false;

            CreateCollections();

            InitCollections(len, f);
        }

        void CreateCollections()
        {
            tovarList = new List<Tovar>();
            strList = new List<string>();

            tovarSortedDict = new SortedDictionary<Tovar, Produckt>();
            strSortedDict = new SortedDictionary<string, Produckt>();
        }

        void InitCollections(int len, bool f)
        {
            if (f) InitCollectionsManually(len);
            else InitCollectionsRandom(len);
        }

        void InitCollectionsRandom(int count)
        {
            Random rnd = new Random();
            for (int i = 1; i <= count; i++)
            {
                int code = rnd.Next(10, 10000);
                int price = 0;
                string name = NameOfProduckts[rnd.Next(5)];

                Produckt prod = new Produckt(0, price, name);
                Tovar tov = new Tovar(code, 0);

                AddToCollectons(prod, tov);
            }
        }

        void InitCollectionsManually(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"Введите код продукта - ");
                int code = enter_int('c');
                
                int price = 0;
                Console.WriteLine($"Введите наименование продукта - ");
                string name = Console.ReadLine();

                

                Produckt prod = new Produckt(0, price, name);
                Tovar tov = new Tovar(code, prod.GetPrice());

                AddToCollectons(prod, tov);
            }
        }

        public bool AddToCollectons(Produckt prod, Tovar tov)
        {
            string strName = tov.Code.ToString();
            bool f;

            if (tovarList.Contains(tov))
            {
               

                f = false;
            }
            else
            {
                tovarList.Add(tov);
                strList.Add(strName);
                tovarSortedDict.Add(tov, prod);
                strSortedDict.Add(strName, prod);

                f = true;
            }

            return f;
        }

        public bool RemoveFromCollectins(Tovar key)
        {
            if (tovarList.Contains(key))
            {
                tovarList.Remove(key);
                strList.Remove(key.ToString());

                tovarSortedDict.Remove(key);
                strSortedDict.Remove(key.ToString());
                return true;
            }
            return false;
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
