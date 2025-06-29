namespace Bookkeping;

public class SalaryCalculator
{
    public static double CalculateSalary(double baseSalary, double bonusPercentage)
    {
        return baseSalary + (baseSalary * bonusPercentage / 100);
    }

    public void EditBonusPercentage(EmployeeManager employeeManager)
    {
        Console.Write("Введите новый процент (%) премии: ");
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
            Console.WriteLine("Некорректное значение!");
        }
    }
}