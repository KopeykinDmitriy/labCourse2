using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lab_12;
using lab_10;

namespace lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            NewCollection<Tovar> exampleOne = new NewCollection<Tovar>("Первая коллекция");
            NewCollection<Tovar> exampleTwo = new NewCollection<Tovar>("Вторая коллекция");
            Journal journalOne = new Journal("Журнал номер 1");
            Journal journalTwo = new Journal("Журнал номер 2");

            exampleOne.CollectionCountChanged += new CollectionHandler(journalOne.CollectionCountChanged);
            exampleOne.CollectionReferenceChanged += new CollectionHandler(journalOne.CollectionReferenceChanged);
            exampleOne.CollectionReferenceChanged += new CollectionHandler(journalTwo.CollectionReferenceChanged);
            exampleTwo.CollectionReferenceChanged += new CollectionHandler(journalTwo.CollectionReferenceChanged);

            exampleOne.Add(new Tovar());
            exampleOne.Add(new Produckt());
            exampleOne.Add(new Igrushka());
            exampleOne.Add(new MolochnyProduckt());

            exampleTwo.Add(new Tovar());
            exampleTwo.Add(new Produckt());
            exampleTwo.Add(new Igrushka());
            exampleTwo.Add(new MolochnyProduckt());

            exampleTwo[1] = new MolochnyProduckt();
            exampleOne[1] = new MolochnyProduckt();
            exampleTwo[0] = new Produckt();

            exampleOne.Remove(new Tovar());
            exampleTwo.Remove(new Produckt());

            journalOne.Show();
            journalTwo.Show();
        }
    }
}
