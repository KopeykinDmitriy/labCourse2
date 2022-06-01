using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_10;

namespace lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<Tovar> stack = new MyCollection<Tovar>();
            int choice;
            Console.WriteLine("Добро пожаловать в лабораторную работу 12");
            Console.WriteLine("");
            

            bool f = true;
            while (f)
            {
                Console.WriteLine("1. Создать коллекцию или добавить элементы в существующую");
                Console.WriteLine("2. Количество элементов в коллекции");
                Console.WriteLine("3. Удалить элемент из коллекции");
                Console.WriteLine("4. Поиск элемента по значению в коллекции");
                Console.WriteLine("5. Клонирование коллекции");
                Console.WriteLine("6. Поверхностное копирование коллекции");
                Console.WriteLine("7. Вывести коллекцию в консоль");
                Console.WriteLine("8. Удалить коллекцию из памяти");
                Console.WriteLine("9. Завершение работы");
                choice = enter_int();
                bool clear = true;
                switch (choice)
                {
                    case 1:
                        CreateElementsAndAddToStack(stack);
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Количество элементов в стеке = " + stack.Count);
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 3:
                        PopElementFromStack(stack);
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 4:
                        SearchInStack(stack);
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 5:
                        CloneCopy(stack);
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 6:
                        PoverhCopy(stack);
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 7:
                        PrintStack(stack);
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 8:
                        ClearStack(stack);
                        Console.WriteLine("Коллекция удалена из памяти");
                        Console.WriteLine("Нажмите enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case 9:
                        clear = false;
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

        static void SearchInStack(MyCollection<Tovar> stack)
        {
            if (stack == null) Console.WriteLine("Стек не создан\n");
            else if (stack.Contains(CreateElement())) Console.WriteLine("Этот элемент есть в стеке\n");
            else Console.WriteLine("Элемента в стеке нет\n");
        }


        static void ClearStack(MyCollection<Tovar> stack) => stack.Clear();

        static void PopElementFromStack(MyCollection<Tovar> stack)
        {
            if (stack.Count == 0) Console.WriteLine("Стек пуст");
            else
            {
                Tovar element = CreateElement();
                if (stack.Remove(element)) Console.WriteLine("Элемент удалён");
                else Console.WriteLine("Такого элемента нет в коллекции");
            }
        }

        static void PrintStack(MyCollection<Tovar> stack)
        {
            int n = 0;
            if (stack.Count == 0) Console.WriteLine("Стек пуст\n");
            else
                foreach (Tovar elem in stack)
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

        static void PoverhCopy(MyCollection<Tovar> stack)
        {
            MyCollection<Tovar> tmp = new MyCollection<Tovar>();
            foreach(Tovar elem in stack)
            {
                tmp.Add(elem);
            }
            Console.WriteLine("Копированный стек:");
            PrintStack(tmp);
        }

        static void CloneCopy(MyCollection<Tovar> stack)
        {
            MyCollection<Tovar> tmp = new MyCollection<Tovar>();
            foreach (Tovar elem in stack)
            {
                Tovar temp = new Tovar();
                if (elem is MolochnyProduckt) temp = (MolochnyProduckt)(elem as MolochnyProduckt).CloneM();
                else
                    if (elem is Igrushka) temp = (Igrushka)(elem as Igrushka).CloneI();
                else
                    if (elem is Produckt) temp = (Produckt)(elem as Produckt).CloneP();
                else
                    if (elem is Tovar) temp = (Tovar)elem.Clone();
                tmp.Add(temp);
            }
            Console.WriteLine("Клонированный стек:");
            PrintStack(tmp);
        }

        
        static void CreateElementsAndAddToStack(MyCollection<Tovar> stack)
        {
            Tovar[] elements = CreateElementsArray();

            stack.Add(elements);
        }

        static Tovar[] CreateElementsArray()
        {
            Console.WriteLine("Введите количество добавляемых элементов: ");
            int count = enter_int('n');
            Tovar[] elements = new Tovar[count];
            int elemNum = 0;
            while (elemNum != count)
            {
                elements[elemNum] = CreateElement();
                if (elements[elemNum++] is null) elemNum--;
            }

            return elements;
        }

       
      

        static Tovar CreateElement()
        {
           
                Console.WriteLine("Введите тип элемента: Tovar, Produckt, Igrushka или MolochnyProduckt: ");
                string elementType = Console.ReadLine();
                if (elementType == "Tovar") return MakeTovar();
                else if (elementType == "Produckt") return MakeProduckt();
                else if (elementType == "Igrushka") return MakeIgrushka();
                else if (elementType == "MolochnyProduckt") return MakeMolochnyProduckt();
                else Console.WriteLine("Неизвестный тип элемента!\n");
                return CreateElement();
                
            
        }

        static Tovar MakeTovar()
        {
            int code; int price;
            Console.WriteLine("Введите код товара = ");
            code = enter_int();
            Console.WriteLine("Введите цену товара = ");
            price = enter_int('p');
            return new Tovar(code, price);
        }

        static Produckt MakeProduckt()
        {
            int code; int price;
            Console.WriteLine("Введите код продукта = ");
            code = enter_int();
            Console.WriteLine("Введите цену продукта = ");
            price = enter_int('p');
            string name;
            Console.WriteLine("Введите наименование продукта = ");
            name = Console.ReadLine();

            return new Produckt(code, price, name);
        }

        static Igrushka MakeIgrushka()
        {
            int code; int price;
            Console.WriteLine("Введите код игрушки = ");
            code = enter_int();
            Console.WriteLine("Введите цену игрушки = ");
            price = enter_int('p');
            string name;
            Console.WriteLine("Введите наименование игрушки = ");
            name = Console.ReadLine();

            return new Igrushka(code, price, name);
        }

        static MolochnyProduckt MakeMolochnyProduckt()
        {
            int code; int price;
            Console.WriteLine("Введите код молочного продукта = ");
            code = enter_int();
            Console.WriteLine("Введите цену молочного продукта = ");
            price = enter_int('p');
            string name;
            Console.WriteLine("Введите наименование молочного продукта = ");
            name = Console.ReadLine();
            int zhirnost;
            Console.WriteLine("Введите жирность молочного продукта = ");
            zhirnost = enter_int('z');


            return new MolochnyProduckt(code, price, name, zhirnost);
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
                    Console.WriteLine("Ошибка. Количество элементов должно быть больше нуля. Попробуйте ещё раз:");
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
