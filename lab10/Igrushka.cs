using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    public class Igrushka : Tovar
    {
        private string name;

        public Igrushka()
        {
            name = "noname";
        }

        public Igrushka(int Code, int Price, string Name) : base(Code, Price)
        {
            name = Name;
        }

        public override string ToString()
        {
            return $"" +
                $"Код игрушки = {code}, его цена = {price}, его имя = {name}";
        }

        public object CloneI()
        {
            return new Igrushka(Code, Price, name);
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
            Console.WriteLine($"Код товара = {code}, наименование игрушки = {name}, его цена = {price}");
        }

        public void ShowI()
        {
            Console.WriteLine($"Код товара = {code}, наименование игрушки = {name}, его цена = {price}");
        }

        public override void Print()
        {
            Console.WriteLine($"Код товара = {code}, наименование игрушки = {name}, его цена = {price}");
        }
    }
}
