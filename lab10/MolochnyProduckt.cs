using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    public class MolochnyProduckt : Produckt
    {
        private double zhirnost;

        public MolochnyProduckt()
        {
            zhirnost = 0;
        }

        public override string ToString()
        {
            return $"" +
                $"Код молочного продукта = {code}, его цена = {price}, его имя = {name}, его жирность = {zhirnost}";
        }

        public MolochnyProduckt(int Code, int Price, string Name, double Zhirnost) : base(Code, Price, Name)
        {
            zhirnost = Zhirnost;
        }

        public object CloneM()
        {
            return new MolochnyProduckt(Code, Price, name, zhirnost);
        }

        public double GetZhirnost()
        {
            return zhirnost;
        }

        public void SetZhirnost(double Zhirnost)
        {
            zhirnost = Zhirnost;
        }

        public override void Show()
        {
            Console.WriteLine($"Код товара = {code}, наименование молочного продукта = {name}, его цена = {price}, его жирность = {zhirnost}%");
        }

        public void ShowM()
        {
            Console.WriteLine($"Код товара = {code}, наименование молочного продукта = {name}, его цена = {price}, его жирность = {zhirnost}%");
        }

        public override void Print()
        {
            Console.WriteLine($"Код товара = {code}, наименование молочного продукта = {name}, его цена = {price}, его жирность = {zhirnost}%");
        }
    }
}
