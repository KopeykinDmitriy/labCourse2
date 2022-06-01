using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_9
{
    public class MoneyArray
    {
        Money[] array;
        int size;

        public MoneyArray()
        {
            array = new Money[0];
            size = 0;
        }

        public MoneyArray(int n, string a)
        {
            size = n;
            array = new Money[n];

            if (a == "random")
            {
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = new Money();
                    array[i].set_rubles(rnd.Next(0, 100));
                    array[i].set_kopeks(rnd.Next(0, 100));
                }
            }

            if (a == "manually")
            {
                for (int i = 0; i < size; i++)
                {
                    array[i] = new Money();
                    Console.WriteLine("Введите количество рублей для {0} объекта:", i + 1);
                    array[i].set_rubles(enter_int());
                    Console.WriteLine("\nВведите количество копеек для {0} объекта:", i + 1);
                    array[i].set_kopeks(enter_int());
                }
            }
            show_array();
        }

        public void show_array()
        {
            if (size == 0) Console.WriteLine("Массив пуст");
            else
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(i + 1 + ") Рубли = " + array[i].get_rubles() + " Копейки = " + array[i].get_kopeks());
            }
        }

        public Money this[int index]
        {
            get
            {
                if (index < 0) { Console.WriteLine("Индекс не может быть отрицательным, будет возвращен первый элемент массива");
                    return array[0];
                }
                else return array[index];
            }

            set
            {
                if (index < 0) Console.WriteLine("Индекс не может быть отрицательным");
                else array[index] = value;
            }
        }

        public void max_element()
        {
            double max = 0;
            int max_element = 0;

            for (int i = 0; i < size; i++)
            {
                double x = array[i].get_rubles() + (double)(array[i].get_kopeks() / 100);

                if (x > max)
                {
                    max = x;
                    max_element = i + 1;
                }
            }

            Console.WriteLine("Максимальный элемент под номером " + max_element + " Рубли = " + array[max_element - 1].get_rubles() + " Копейки = " + array[max_element - 1].get_kopeks());
        }

        private static int enter_int() // Ввод целого числа
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
            if (Convert.ToInt32(enter) < 0)
            {
                Console.WriteLine("Ошибка. Рубли или копейки не могут быть отрицательными. Попробуйте ещё раз:");
                f = false;
            }
            if (f) number = Convert.ToInt32(enter);
            else number = enter_int();
            return number;
        }

    }
}
