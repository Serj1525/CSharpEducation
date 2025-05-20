using PhoneBookLib;
using System;

namespace PhoneBookApp;

class Program
{
    static void Main()
    {
        var phonebook = Phonebook.Instance;

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить абонента");
            Console.WriteLine("2. Удалить абонента");
            Console.WriteLine("3. Получить абонента по номеру телефона");
            Console.WriteLine("4. Получить номер телефона по имени");
            Console.WriteLine("5. Показать всех абонентов");
            Console.WriteLine("6. Выход");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите номер телефона: ");
                    var phoneNumber = Console.ReadLine();
                    Console.Write("Введите имя абонента: ");
                    var name = Console.ReadLine();
                    phonebook.AddAbonent(phoneNumber, name);
                    break;

                case "2":
                    Console.Write("Введите номер телефона для удаления: ");
                    phoneNumber = Console.ReadLine();
                    phonebook.DeleteAbonent(phoneNumber);
                    break;

                case "3":
                    Console.Write("Введите номер телефона: ");
                    phoneNumber = Console.ReadLine();
                    var abonentByNumber = phonebook.FindAbonentByPhoneNumber(phoneNumber);
                    Console.WriteLine(abonentByNumber != null ? abonentByNumber.ToString() : "Абонент не найден.");
                    break;

                case "4":
                    Console.Write("Введите имя абонента: ");
                    name = Console.ReadLine();
                    var numberByName = phonebook.GetPhoneNumberByName(name);
                    Console.WriteLine(numberByName != null ? numberByName : "Абонент не найден.");
                    break;

                case "5":
                    phonebook.DisplayAllAbonents();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    break;
            }
        }
    }
}