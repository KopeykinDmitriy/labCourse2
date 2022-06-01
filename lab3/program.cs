using System;

namespace laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в лабораторную работу 3");
            Console.WriteLine("");
            double x = 0.1; // начальное значение x
            for (int i = 0; i <= 10; i++)
            {
                double y = x * Math.Sin(Math.PI / 4) / (1 - 2* x * Math.Cos(Math.PI / 4) + x*x); // функция y
                double SN = SumN(x); // значение суммы для заданного n
                double SE = SumE(x); // значение суммы для заданной точности 
                Console.WriteLine("x = {0:0.00}     SN = {1:0.000}     SE = {2:0.000}     y = {3:0.000}", x, SN, SE, y); // вывод результатов
                Console.WriteLine("");
                x += (0.8 - 0.1) / 10; // шаг изменения x
            }
        }

        static double SumN(double x) // функция вычисления значения суммы для заданного n
        {
            double prev = 1; // служит для вычисления функции x в степени n
            double curr = 0; // хранит текущее значение суммы
            for (int i = 1; i<=40; i++)
            {
                prev *= x; // вычисление функции x  в степени n
                curr += prev * Math.Sin(i * Math.PI / 4); // прибавление нового элемента суммы
            }
            return curr; // возвращаем значение суммы
        }

        static double SumE(double x) // функция вычисления значения суммы для заданной точности
        {
            double prev_a = 0; // предыдущее значение элемента суммы
            double a = 1; // текущее значение элемента суммы
            double prev = 1; // служит для вычисления функции x в степени n
            double curr = 0; // хранит текущее значение суммы
            for (int i = 1; Math.Abs(a-prev_a) >= 0.0001; i++) // вычисляем до тех пор, пока разница между предыдущим и текущем элементом не будет меньше 0.0001
            {
                prev *= x; // вычисление функции x  в степени n
                curr += prev * Math.Sin(i * Math.PI / 4); // прибавление нового элемента суммы
                prev_a = a; // сохранение предыдущего значения элемента суммы
                a = prev * Math.Sin(i * Math.PI / 4); // сохранение текущего значения элемента суммы
            }
            return curr; // возвращаем значение суммы
        }
    }
}
