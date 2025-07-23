namespace Bookkeping_with_exceptions;
/// <summary>
/// Класс для расчета зарплаты сотрудника (оклад + премия).
/// </summary>
internal class SalaryCalculator
{
    internal static double CalculateSalary(double baseSalary, double bonusPercentage)
    {
        return baseSalary + (baseSalary * bonusPercentage / 100);
    }

    /// <summary>
    /// Редактирование % премии и запись в список сотрудников для расчета зарплаты.
    /// </summary>
    /// <param name="employeeManager">Класс для управления сотрудников.</param>
    /// <exception cref="FormatException">Исключение при обработке неверного формата.</exception>
    internal void EditBonusPercentage(EmployeeManager employeeManager)
    {
        Console.Write("Введите новый процент премии: ");
        if (double.TryParse(Console.ReadLine(), out double newBonus))
        {
            foreach (var employee in employeeManager.Employees)
            {
                employee.Position.BonusPercentage = newBonus;
            }
            Console.WriteLine("Процент премии обновлен для всех сотрудников.");
        }
        else
        {
            throw new FormatException("Некорректное значение для процента премии.");
        }
    }
}