namespace Bookkeping_with_exceptions;

public class Employee
{
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Position Position { get; set; }
    public double Salary => SalaryCalculator.CalculateSalary(Position.BaseSalary, Position.BonusPercentage);

    private static int _counter = 1;

    public Employee(string firstName, string lastName, Position position)
    {
        Id = _counter++;
        FirstName = firstName;
        LastName = lastName;
        Position = position;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Имя: {FirstName}, Фамилия: {LastName}, Должность: {Position.Name}, Зарплата: {Salary:F2} руб.";
    }
}