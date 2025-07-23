namespace Bookkeping_with_exceptions;

/// <summary>
/// Класс для хранения данных должности (ID, название, оклад, % премии)
/// </summary>
internal class Position
{
    internal int Id { get; }
    internal string Name { get; set; }
    internal double BaseSalary { get; set; }
    internal double BonusPercentage { get; set; }

    private static int _counter = 1;

    /// <summary>
    /// Данные о должности
    /// </summary>
    /// <param name="name">Название должности</param>
    /// <param name="baseSalary">Оклад</param>
    /// <param name="bonusPercentage">% премии</param>
    internal Position(string name, double baseSalary, double bonusPercentage)
    {
        Id = _counter++;
        Name = name;
        BaseSalary = baseSalary;
        BonusPercentage = bonusPercentage;
    }

    /// <summary>
    /// Вывод данных в 1 строку
    /// </summary>
    /// <returns> Возвращает строку</returns>
    public override string ToString()
    {
        return $"ID: {Id}, Должность: {Name}, Оклад: {BaseSalary:F2} руб.";
    }
}