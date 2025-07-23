namespace Bookkeping_with_exceptions;

/// <summary>
/// Класс для хранения данных о сотруднике (ID, имя, фамилия, должность, зарплата).
/// </summary>
internal class Employee
{
    internal int Id { get; }
    internal string FirstName { get; set; }
    internal string LastName { get; set; }
    internal Position Position { get; set; }
    internal double Salary => SalaryCalculator.CalculateSalary(Position.BaseSalary, Position.BonusPercentage);

    private static int _counter = 1;

    /// <summary>
    /// Данные сотрудника с должностью, со своим ID.
    /// </summary>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="position">ID должности</param>
    internal Employee(string firstName, string lastName, Position position)
    {
        Id = _counter++;
        FirstName = firstName;
        LastName = lastName;
        Position = position;
    }

    /// <summary>
    /// Вывод данных сотрудника в виде строки
    /// </summary>
    /// <returns> Возвращает строку</returns>
    public override string ToString()
    {
        return $"ID: {Id}, Имя: {FirstName}, Фамилия: {LastName}, Должность: {Position.Name}, Зарплата: {Salary:F2} руб.";
    }
}