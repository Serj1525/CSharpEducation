namespace Bookkeping_with_exceptions;

public class Position
{
    public int Id { get; }
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public double BonusPercentage { get; set; }

    private static int _counter = 1;

    public Position(string name, double baseSalary, double bonusPercentage)
    {
        Id = _counter++;
        Name = name;
        BaseSalary = baseSalary;
        BonusPercentage = bonusPercentage;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Должность: {Name}, Оклад: {BaseSalary:F2} руб.";
    }
}