using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    public class Tovar : IExecutable, ICloneable, IComparable 
    {
        protected int code;
        protected int price;
        protected string[] n = new string[1] {"ard" };

        public void ShowS()
        {
            Console.WriteLine($"Код товара = {code}, его цена = {price}, строка = {n[0]}");
        }

        public void SetS(string s)
        {
            n[0] = s;
        }

        public override string ToString()
        {
            return $"" +
                $"Код товара = {code}, его цена = {price}";
        }

        public Tovar(int Code, int Price)
        {
            code = Code;
            price = Price;
        }

        public int Code
        {
            get => code;
            set
            {
                code = value;
            }
        }

        public int Price
        {
            get => price;
            set
            {
                price = value;
            }
        }

        public virtual void Print()
        {
            Console.WriteLine($"Код товара = {code}, его цена = {price}");
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public object Clone()
        {
            return new Tovar(Code, Price);
        }

        public int CompareTo(object obj)
        {
            Tovar temp = (Tovar)obj;
            return String.Compare(temp.code.ToString(), this.code.ToString());
        }

        public static bool operator >(Tovar left, Tovar right)
        {
            return string.Compare(left.code.ToString(), right.code.ToString()) == 1;
        }

        public static bool operator <(Tovar left, Tovar right)
        {
            return string.Compare(left.code.ToString(), right.code.ToString()) == -1;
        }

        public static bool operator ==(Tovar left, Tovar right)
        {
            return string.Compare(left.code.ToString(), right.code.ToString()) == 0;
        }

        public static bool operator !=(Tovar left, Tovar right)
        {
            return string.Compare(left.code.ToString(), right.code.ToString()) != 0;
        }

        public Tovar()
        {
            code = -1;
            price = 0;
        }


        public int GetCode()
        {
            return code;
        }

        public int GetPrice()
        {
            return price;
        }

        public void SetCode(int Code)
        {
            code = Code;
        }

        public void SetPrice(int Price)
        {
            price = Price;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Код товара = {code}, его цена = {price}");
        }

        public void ShowT()
        {
            Console.WriteLine($"Код товара = {code}, его цена = {price}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Tovar tovar = (Tovar)obj;
            return this.Code == tovar.Code;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
