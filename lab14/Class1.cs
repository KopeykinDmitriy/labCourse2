using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_10;
using lab_12;

namespace lab_14
{
    public static class Class1//Методы расширения класса
    {
        public static IEnumerable<Produckt> Selection(this MyCollection<Produckt> collection, Func<Produckt, bool> predicate)
        {
            var query = collection.Where(predicate);

            return query;
        }

        public static int Summary(this MyCollection<Produckt> collection, Func<Produckt, bool> predicate)
        {
            var query = collection.Where(predicate);

            int sum = 0;

            foreach (var item in query) sum += item.GetPrice();

            return sum;
        }

        public static IEnumerable<Tovar> Sorting(this MyCollection<Tovar> collection, Func<Tovar, int> predicate)
        {
            var query = collection.OrderBy(predicate);

            return query;
        }
    }
}
