using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lab_12;

namespace lab_13
{
    public class JournalEntry : ICloneable, IComparable
    {

        public string CollectionName { get; private set; } = "";

        public string EventType { get; } = "";

        public string ChangedObjectInformation { get; private set; } = "";

        public JournalEntry(string collectionName, object changedObject)
        {
            CollectionName = collectionName;
            EventType = "Событие";
            ChangedObjectInformation = changedObject.ToString();
        }

        public JournalEntry(string collectionName, string eventType, object changedObject)
        {
            CollectionName = collectionName;
            EventType = eventType;
            ChangedObjectInformation = changedObject.ToString();
        }

        public override string ToString()
        {
            return $"" +
                $"Коллекция: {CollectionName}\n" +
                $"Событие: {EventType}\n" +
                $"Изменённый объект:\n" +
                $"{ChangedObjectInformation}" +
                $"\n";
        }

        public object Clone() => new JournalEntry(CollectionName, EventType, ChangedObjectInformation);

        public int CompareTo(object obj)
        {
            JournalEntry temp = (JournalEntry)obj;

            if (CollectionName != temp.CollectionName) return CollectionName.CompareTo(temp.CollectionName);
            if (EventType != temp.EventType) return CollectionName.CompareTo(temp.CollectionName);
            return ChangedObjectInformation.CompareTo(temp.ChangedObjectInformation);
        }

        public virtual void Show() => Console.WriteLine(ToString());
    }

    public class ChangedObjectJournalEntity : JournalEntry
    {
        public ChangedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "Изменён объект по индексу", changedObject) { }

        public override void Show() => Console.WriteLine(ToString());
    }

    public class RemovedObjectJournalEntity : JournalEntry
    {
        public RemovedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "Из коллекции удалён объект", changedObject) { }

        public override void Show() => Console.WriteLine(ToString());
    }

    public class AddedObjectJournalEntity : JournalEntry
    {
        public AddedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "В коллекцию добавлен элемент", changedObject) { }
        public override void Show() => Console.WriteLine(ToString());
    }

    public class Journal : MyCollection<JournalEntry>
    {
        public string Name { get; set; } = "";

        public Journal(string name) => Name = name;

        public void Add(string collectionName, string eventType, object changedObject) => Add(new JournalEntry(collectionName, eventType, changedObject));
        public void AddChanged(string collectionName, object changedObject) => Add(new ChangedObjectJournalEntity(collectionName, changedObject));
        public void AddRemoved(string collectionName, object changedObject) => Add(new RemovedObjectJournalEntity(collectionName, changedObject));
        public void AddAdded(string collectionName, object changedObject) => Add(new AddedObjectJournalEntity(collectionName, changedObject));
        public override void Show()
        {
            if (First != null)
            {
                Console.WriteLine($"______\n\n" + Name + $"\n______");
                CollectionPoint<JournalEntry> cursor = First;
                while (cursor != null)
                {
                    cursor.Value.Show();
                    cursor = cursor.Next;
                }
            }
        }

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (args.EventType == "remove") AddRemoved(args.CollectionName, args.ChangedObject);
            else if (args.EventType == "add") AddAdded(args.CollectionName, args.ChangedObject);
            else Add(args.CollectionName, args.EventType, args.ChangedObject);
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (args.EventType == "changed") AddChanged(args.CollectionName, args.ChangedObject);
            else Add(args.CollectionName, args.EventType, args.ChangedObject);
        }
    }
}
