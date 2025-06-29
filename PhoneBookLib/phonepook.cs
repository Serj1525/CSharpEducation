namespace PhoneBookLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class Abonent
{
    public string PhoneNumber { get; set; }
    public string Name { get; set; }

    public Abonent(string phoneNumber, string name)
    {
        PhoneNumber = phoneNumber;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name}: {PhoneNumber}";
    }
}

public class Phonebook
{
    private static Phonebook _instance;
    private List<Abonent> _abonents;
    private const string FilePath = "phonebook.txt";

    private Phonebook()
    {
        _abonents = new List<Abonent>();
        LoadFromFile();
    }

    public static Phonebook Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Phonebook();
            }
            return _instance;
        }
    }

    public void AddAbonent(string phoneNumber, string name)
    {
        if (_abonents.Any(a => a.PhoneNumber == phoneNumber))
        {
            Console.WriteLine("Абонент с таким номером уже существует.");
            return;
        }

        var abonent = new Abonent(phoneNumber, name);
        _abonents.Add(abonent);
        SaveToFile();
        Console.WriteLine("Абонент добавлен.");
    }

    public void DeleteAbonent(string phoneNumber)
    {
        var abonent = _abonents.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
        if (abonent != null)
        {
            _abonents.Remove(abonent);
            SaveToFile();
            Console.WriteLine("Абонент удалён.");
        }
        else
        {
            Console.WriteLine("Абонент не найден.");
        }
    }

    public Abonent FindAbonentByPhoneNumber(string phoneNumber)
    {
        return _abonents.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
    }

    public string GetPhoneNumberByName(string name)
    {
        var abonent = _abonents.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return abonent?.PhoneNumber;
    }

    public void DisplayAllAbonents()
    {
        if (_abonents.Count == 0)
        {
            Console.WriteLine("Справочник пуст.");
            return;
        }

        foreach (var abonent in _abonents)
        {
            Console.WriteLine(abonent);
        }
    }

    private void LoadFromFile()
    {
        if (File.Exists(FilePath))
        {
            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 2)
                {
                    _abonents.Add(new Abonent(parts[0], parts[1]));
                }
            }
        }
    }

    private void SaveToFile()
    {
        var lines = _abonents.Select(a => $"{a.PhoneNumber};{a.Name}");
        File.WriteAllLines(FilePath, lines);
    }
}

