namespace Bookkeping;

public class PositionManager
{
    public List<Position> Positions { get; } = new List<Position>();

    public void AddPosition()
    {
        Console.Clear();
        Console.Write("Введите название должности: ");
        string name = Console.ReadLine();
        Console.Write("Введите оклад: ");
        if (double.TryParse(Console.ReadLine(), out double baseSalary))
        {
            Positions.Add(new Position(name, baseSalary, 10)); // Начальный процент премии 10%
            Console.WriteLine("Должность добавлена.");
        }
        else
        {
            Console.WriteLine("Некорректное значение!");
        }
    }

    public void RemovePosition(EmployeeManager employeeManager)
    {
        Console.Clear();
        Console.Write("Введите ID должности для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var position = GetPositionById(id);
            if (position != null)
            {
                if (employeeManager.Employees.Exists(e => e.Position == position))
                {
                    Console.WriteLine("Нельзя удалить должность, пока есть сотрудники с этой должностью.");
                }
                else
                {
                    Positions.Remove(position);
                    Console.WriteLine("Должность удалена.");
                }
            }
            else
            {
                Console.WriteLine("Должность не найдена.");
            }
        }
    }

    public void EditPosition(EmployeeManager employeeManager)
    {
        Console.Clear();
        Console.Write("Введите ID должности для редактирования: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var position = GetPositionById(id);
            if (position != null)
            {
                Console.Write("Введите новое название должности: ");
                position.Name = Console.ReadLine();
                Console.Write("Введите новый оклад: ");
                if (double.TryParse(Console.ReadLine(), out double newBaseSalary))
                {
                    position.BaseSalary = newBaseSalary;

                    // Автоматически обновляем зарплаты сотрудников
                    foreach (var employee in employeeManager.Employees)
                    {
                        if (employee.Position == position)
                        {
                            employee.Position.BonusPercentage = position.BonusPercentage; // сохраняем процент при смене оклада
                        }
                    }
                    Console.WriteLine("Должность обновлена.");
                }
                else
                {
                    Console.WriteLine("Некорректное значение для оклада!");
                }
            }
            else
            {
                Console.WriteLine("Должность не найдена.");
            }
        }
    }

    public Position GetPositionById(int id)
    {
        return Positions.Find(p => p.Id == id);
    }

    public void DisplayPositions()
    {
        Console.Clear();
        Console.WriteLine("Список должностей:");
        foreach (var position in Positions)
        {
            Console.WriteLine(position);
        }
    }
}