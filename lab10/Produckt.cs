using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    public class Produckt : Tovar
    {
        protected string name;

        public Produckt()
        {
            name = "noname";
        }

        public Produckt(int Code, int Price, string Name) : base(Code, Price)
        {
            name = Name;
        }

        public override string ToString()
        {
            return $"" +
                $"Код продукта = {code}, его цена = {price}, его имя = {name}";
        }

        public void RandomFill()
        {
            string[] NameOfProduckts = { "potato", "apple", "carrot", "tomato", "onion" };
            Random rnd = new Random();

            code = rnd.Next(10, 100000);
            price = rnd.Next(10000);
            name = NameOfProduckts[rnd.Next(5)];
        }

        public object CloneP()
        {
            return new Produckt(Code, Price, name);
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string Name)
        {
            name = Name;
        }

        public override void Show()
        {
            Console.WriteLine($"Код товара = {code}, наименование продукта = {name}, его цена = {price}");
        }

        public void ShowP()
        {
            Console.WriteLine($"Код товара = {code}, наименование продукта = {name}, его цена = {price}");
        }

        public override void Print()
        {
            Console.WriteLine($"Код товара = {code}, наименование продукта = {name}, его цена = {price}");
        }

        public Tovar BaseTovar

        {

            get

            {

                return new Tovar(code, price);//возвращает объект базового класса

            }

        }
    }
}
