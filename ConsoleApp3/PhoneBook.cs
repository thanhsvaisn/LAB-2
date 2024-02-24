using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Phoneapp
{
    internal class PhoneBook : Phone
    {
        private List<(string Name, string PhoneNumber)> PhoneList = new List<(string, string)>();

        public override void InsertPhone(string name, string phone)
        {
            var existingEntry = PhoneList.FirstOrDefault(entry => entry.Name == name);

            if (existingEntry == default)
            {
                PhoneList.Add((name, phone));
                Console.WriteLine($"Added {name}'s phone number: {phone}");
            }
            else
            {
                if (existingEntry.PhoneNumber != phone)
                {
                    // If the phone number is different, add it as a new entry
                    PhoneList.Add((name, phone));
                    Console.WriteLine($"Added additional phone number {phone} for {name}");
                }
                else
                {
                    Console.WriteLine($"{name}'s phone number already exists in the phone book.");
                }
            }
        }

        public override void RemovePhone(string name)
        {
            PhoneList.RemoveAll(entry => entry.Name == name);
            Console.WriteLine($"Removed all phone numbers for {name} from the phone book.");
        }

        public override void UpdatePhone(string name, string newPhone)
        {
            var existingEntry = PhoneList.FirstOrDefault(entry => entry.Name == name);

            if (existingEntry != default)
            {
                PhoneList[PhoneList.IndexOf(existingEntry)] = (name, newPhone);
                Console.WriteLine($"Updated {name}'s phone number to: {newPhone}");
            }
            else
            {
                Console.WriteLine($"{name}'s phone number not found in the phone book.");
            }
        }

        public override void SearchPhone(string name)
        {
            var matchingEntries = PhoneList.Where(entry => entry.Name == name).ToList();

            if (matchingEntries.Any())
            {
                Console.WriteLine($"Phone numbers for {name}:");
                foreach (var entry in matchingEntries)
                {
                    Console.WriteLine($"{entry.Name}: {entry.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine($"{name}'s phone number not found in the phone book.");
            }
        }

        public override void Sort()
        {
            PhoneList = PhoneList.OrderBy(entry => entry.Name).ToList();
            Console.WriteLine("Phone book sorted by name.");
        }
    }
}