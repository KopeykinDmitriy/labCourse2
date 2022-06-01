using lab_10;
using lab_12;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_14
{
    class Program
    {

        static void Main(string[] args)
        {
            Queue<Dictionary<int, Produckt>> queue = new Queue<Dictionary<int, Produckt>>();

            for (int i = 0; i < 3; i++) //Заполнение очереди
            {
                Dictionary<int, Produckt> dictionary = new Dictionary<int, Produckt>();
                FillDictionary(dictionary);
                queue.Enqueue(dictionary);
            }
            //Пять запросов(двумя способами)
            QueryFirst(queue);

            QuerySecond(queue);

            QueryThird(queue);

            QueryFourth(queue);

            QueryFifth(queue);
            //Использование методов расширения класса
            Methods();

        }

        static void FillDictionary(Dictionary<int, Produckt> dict) //Заполнение словаря
        {
            for (int i = 1; i <= 10; i++)
            {
                Produckt item = new Produckt();
                item.RandomFill();
                dict.Add(item.GetHashCode(), item);
            }
        }

        static void QueryFirst(Queue<Dictionary<int, Produckt>> queue)
        {
            Console.WriteLine("Запрос на выборку\n");



            Console.WriteLine("LINQ запрос:\n");

            var QueryLINQ = from item in queue.Peek().Values
                            orderby item.GetName()
                            select item.GetName();

            QueryLINQ = QueryLINQ.Distinct();

            Console.Write("Наименования товаров в первом отделе: ");

            foreach (string s in QueryLINQ) Console.Write("{0} ", s);



            Console.WriteLine("\n\nЗапрос с использованием метода расширения:\n");

            var QueryMethod = queue.Peek().Values.OrderBy(item => item.GetName()).Select(item => item.GetName()).Distinct();

            Console.Write("Наименования товаров в первом отделе: ");

            foreach (string s in QueryMethod) Console.Write("{0} ", s);
        }

        static void QuerySecond(Queue<Dictionary<int, Produckt>> queue)
        {
            Console.WriteLine("\n\n\nЗапрос на получение счётчика\n");



            Console.WriteLine("LINQ запрос:\n");

            int QueryLINQ = (from dictionary in queue
                            from item in dictionary.Values
                            where item.GetName() == "potato"
                            select item).Count();

            Console.Write("Количество товара potato: {0}", QueryLINQ);



            Console.WriteLine("\n\nЗапрос с использованием метода расширения:\n");

            int QueryMethod = queue.SelectMany(dictionary => dictionary.Values).Where(item => item.GetName() == "potato").Select(item => item).Count();

            Console.Write("Количество товара potato: {0}", QueryMethod);
        }

        static void QueryThird(Queue<Dictionary<int, Produckt>> queue)
        {
            Console.WriteLine("\n\n\nОперации над множествами\n");

            Queue<Dictionary<int, Produckt>> queueLINQ = new(queue);

            Queue<Dictionary<int, Produckt>> queueMethod = new(queue);


            Console.WriteLine("LINQ запрос:\n");

            var QueryLINQ = (from item in queueLINQ.Dequeue().Values
                            orderby item.GetName()
                            select item.GetName()).Intersect(
                            from item in queueLINQ.Dequeue().Values
                            orderby item.GetName()
                            select item.GetName());

            Console.Write("Наименования товаров, которые есть в первом и втором отделе: ");

            foreach (string s in QueryLINQ) Console.Write("{0} ", s);



            Console.WriteLine("\n\nЗапрос с использованием метода расширения:\n");

            var QueryMethod = (queueMethod.Dequeue().Values.OrderBy(item => item.GetName()).Select(item => item.GetName()))
                              .Intersect(queueMethod.Dequeue().Values.OrderBy(item => item.GetName()).Select(item => item.GetName()));

            Console.Write("Наименования товаров, которые есть в первом и втором отделе: ");

            foreach (string s in QueryMethod) Console.Write("{0} ", s);
        }

        static void QueryFourth(Queue<Dictionary<int, Produckt>> queue)
        {
            Console.WriteLine("\n\n\nЗапрос на агрегирование данных\n");



            Console.WriteLine("LINQ запрос:\n");

            int QueryLINQ = (from dictionary in queue
                             from item in dictionary.Values
                             where item.GetName() == "potato"
                             select item.GetPrice()).Sum();

            Console.Write("Суммарная стоимость товара potato: {0} рублей", QueryLINQ);



            Console.WriteLine("\n\nЗапрос с использованием метода расширения:\n");

            int QueryMethod = queue.SelectMany(dictionary => dictionary.Values).Where(item => item.GetName() == "potato").Select(item => item.GetPrice()).Sum();

            Console.Write("Суммарная стоимость товара potato: {0} рублей", QueryMethod);
        }

        static void QueryFifth(Queue<Dictionary<int, Produckt>> queue)
        {
            Console.WriteLine("Запрос на группировку\n");



            Console.WriteLine("LINQ запрос:\n");

            var QueryLINQ = from dictionary in queue
                            from item in dictionary.Values
                            group item by item.GetName();

            Console.WriteLine("Группировка кодов и цен по наименованию продукта: ");

            foreach (var name in QueryLINQ)
            {
                Console.WriteLine(name.Key);

                foreach (var info in name) Console.WriteLine("{0}   {1}",info.GetCode(), info.GetPrice());

                Console.WriteLine();
            }



            Console.WriteLine("\n\nЗапрос с использованием метода расширения:\n");

            var QueryMethod = queue.SelectMany(dictionary => dictionary.Values).GroupBy(item => item.GetName());

            Console.WriteLine("Группировка кодов и цен по наименованию продукта: ");

            foreach (var name in QueryMethod)
            {
                Console.WriteLine(name.Key);

                foreach (var info in name) Console.WriteLine("{0}   {1}", info.GetCode(), info.GetPrice());

                Console.WriteLine();
            }
        }

        static void Methods()
        {
            MyCollection<Produckt> tovars = new MyCollection<Produckt>();

            for (int i=1; i<=30; i++)
            {
                Produckt item = new Produckt();

                item.RandomFill();

                tovars.Add(item);
            }

            Console.WriteLine("Запрос на выборку\n");

            var queryOne = tovars.Selection(item => item.GetName() == "potato");

            foreach (Produckt item in queryOne) Console.WriteLine("{0} {1} {2}", item.GetCode(), item.GetPrice(), item.GetName());

            Console.WriteLine("\nЗапрос на агрегацию\n");

            int queryTwo = tovars.Summary(item => item.GetName() == "apple");

            Console.WriteLine("{0}",queryTwo);

            Console.WriteLine("\nЗапрос на сортировку\n");

            MyCollection<Tovar> tovars1 = new MyCollection<Tovar>();

            for (int i = 1; i <= 30; i++)
            {
                Tovar item = new Tovar();

                Random rnd = new Random();

                item.SetCode(rnd.Next(10, 100000));
                item.SetPrice(rnd.Next(10000));

                tovars1.Add(item);
            }

            var queryThree = tovars1.Sorting(item => item.GetPrice());

            foreach (Tovar item in queryThree) Console.WriteLine("{0} {1}", item.GetCode(), item.GetPrice());

        }
    }
}
