using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace PhoneBook
{

    class Record
    {
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public Record(string name, string phoneNum)
        {
            Name = name;
            PhoneNum = phoneNum;
        }
        public override string ToString()
        {
            return $"\tName: {Name}\t\tPhone: {PhoneNum}";
        }
    }


    class PhoneBook
    {
        Dictionary<string,string> pairs = new Dictionary<string, string>();

        public PhoneBook(){}
        public PhoneBook(params Record[] records) {
            foreach (var item in records)
            {
                pairs.Add(item.Name, item.PhoneNum);
            }
        }

        public void AddRecord(string name, string phoneNum)
        {
            pairs.Add(name, phoneNum);
        }
        public void AddRecord(Record record)
        {
            pairs.Add(record.Name, record.PhoneNum);
        }
        public void RemoveRecord(string name) {  pairs.Remove(name); }

        public string SearchRecord(string name)
        {
            return pairs.TryGetValue(name, out string? phone) ? new Record(name, phone).ToString() : $"{name} not found";
        }
        public void EditName(string name, string newname)
        {
            string tmp = pairs[name];
            pairs.Remove(name);
            pairs[newname] = tmp;
        }
        public void EditPhone(string name, string newPhone)
        {
            pairs[name] = newPhone;
        }

        public void print()
        {

            foreach (var item in pairs)
            {
                Console.WriteLine(new Record(item.Key, item.Value).ToString());
                Console.WriteLine();
            }
        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            
            PhoneBook records = new PhoneBook();

            records.AddRecord(new Record("John Doe", "+1234567890"));
            records.AddRecord(new Record("Jane Smith", "+9876543210"));
            records.AddRecord(new Record("Bob Johnson", "+1122334455"));
            records.AddRecord(new Record("Alice Williams", "+9988776655"));

            records.print();
            records.RemoveRecord("John Doe");
            Console.WriteLine();
            records.print();
            Console.WriteLine();
            Console.WriteLine(records.SearchRecord("Alice Williams"));

            records.EditName("Bob Johnson", "Rob Gekson");
            Console.WriteLine();
            records.print();
        }
    }
}