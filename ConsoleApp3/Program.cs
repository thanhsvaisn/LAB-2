using Phoneapp;

class Program
{
    static void Main()
    {
        Phone phoneBook = new PhoneBook();

        phoneBook.InsertPhone("John Doe", "123-456-7890");
        phoneBook.InsertPhone("Jane Smith", "987-654-3210");
        phoneBook.InsertPhone("John Doe", "111-222-3333"); // Existing entry, should add as a new number

        phoneBook.SearchPhone("John Doe");
        phoneBook.RemovePhone("Jane Smith");
        phoneBook.SearchPhone("Jane Smith"); // Should not be found

        phoneBook.Sort();
    }
}