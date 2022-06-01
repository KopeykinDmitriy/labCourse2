using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_9
{
    public class Money
    {
        int rubles;
        int kopeks;
        private static int counter = 0;

        public Money()
        {
            rubles = 0;
            kopeks = 0;
            counter++;
        }

        public Money(int rub, int kop)
        {
            rubles = rub;
            kopeks = kop;
            Checks();
            counter++;
        }

        public void set_rubles(int rub)
        {
            rubles = rub;
            Checks();
        }

        public void set_kopeks(int kop)
        {
            kopeks = kop;
            Checks();
        }

        public int get_rubles()
        {
            return rubles;
        }

        public int get_kopeks()
        {
            return kopeks;
        }

        public void show_money()
        {
            Console.WriteLine("Рубли {0}, Копейки {1}", rubles, kopeks);
        }

        private void Checks()
        {
            if (kopeks > 99)
            {
                rubles += kopeks / 100;
                kopeks = kopeks % 100;
            }
            if (kopeks < 0)
            {
                rubles -= Math.Abs(kopeks / 100);
                if (kopeks % 100 != 0)
                {
                    rubles--;
                    kopeks = 100 - Math.Abs(kopeks % 100);
                }
                else kopeks = 0;
            }
            if (rubles < 0)
            {
                rubles = 0;
                kopeks = 0;
            }
        }

        private static void Checks(Money x)
        {
            if (x.kopeks > 99)
            {
                x.rubles += x.kopeks / 100;
                x.kopeks = x.kopeks % 100;
            }
            if (x.kopeks < 0)
            {
                x.rubles -= Math.Abs(x.kopeks / 100);
                if (x.kopeks % 100 != 0)
                {
                    x.rubles--;
                    x.kopeks = 100 - Math.Abs(x.kopeks % 100);
                }
                else x.kopeks = 0;
            }
            if (x.rubles < 0)
            {
                x.rubles = 0;
                x.kopeks = 0;
            }
        }

        public static void Subtraction(Money x1, Money x2)
        {
            x1.rubles -= x2.rubles;
            x1.kopeks -= x2.kopeks;
            Checks(x1);
        }

        public void Subtraction(Money x)
        {
            rubles -= x.rubles;
            kopeks -= x.kopeks;
            Checks();
        }

        public static Money operator-- (Money x)
        {
            x.kopeks--;
            Checks(x);
            return x;
        }

        public static Money operator++ (Money x)
        {
            x.kopeks++;
            Checks(x);
            return x;
        }

        public static explicit operator double(Money x)
        {
            return (double)x.kopeks/100;
        }

        public static implicit operator int(Money x)
        {
            return x.rubles;
        }

        public static Money operator +(Money x, int p)
        {
            Money r;
            r = x;
            r.rubles += p;
            Checks(x);
            return x;
        }

        public static Money operator -(Money x, int p)
        {
            Money r;
            r = x;
            r.rubles -= p;
            Checks(x);
            return x;
        }

        public static Money operator +(int p, Money x)
        {
            Money r;
            r = x;
            r.rubles = p + x.rubles;
            Checks(x);
            return x;
        }

        public static Money operator -(int p, Money x)
        {
            Money r;
            r = x;
            r.rubles = p - x.rubles;
            Checks(x);
            return x;
        }

        public static Money operator +(Money x1, Money x2)
        {
            Money r = new Money();
            r.rubles = x1.rubles + x2.rubles;
            r.kopeks = x1.kopeks + x2.kopeks;
            Checks(r);
            return r;
        }
        public static Money operator -(Money x1, Money x2)
        {
            Money r = new Money();
            r.rubles = x1.rubles - x2.rubles;
            r.kopeks = x1.kopeks - x2.kopeks;
            Checks(r);
            return r;
        }

        public static int get_count()
        {
            return counter;
        }
    }
}
