using System;

namespace Lab_1
{
    class Program
    {
        static int check_int(string enter_number)
        {
            int number;
            while (!int.TryParse(enter_number, out number))
            {
                Console.Write("Ошибка. Неверный ввод. Попробуйте ещё раз: ");
                enter_number = Console.ReadLine();
            }
            number = Convert.ToInt32(enter_number);
            return number;
        }
        static void quest_one()
        {
            Console.WriteLine("Введите m и n");
            string enter;
            Console.Write("m = ");
            enter = Console.ReadLine();
            int m = check_int(enter);
            Console.Write("n = ");
            enter = Console.ReadLine();
            int n = check_int(enter);
            Console.WriteLine("{0} {1}", n, m);
        }
        static void Main(string[] args)
        {
            quest_one();
        }
    }
}
