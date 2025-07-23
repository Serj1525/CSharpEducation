namespace Bookkeping_with_exceptions;
/// <summary>
/// Управление списком сотрудников: добавление, удаление сотрудника;
/// редактирование данных сотрудника, вывод списка со всеми сотрудниками.
/// </summary>
internal class EmployeeManager
{
    internal List<Employee> Employees { get; } = new List<Employee>();

    /// <summary>
    /// Добавление сотрудника в список
    /// </summary>
    /// <param name="positionManager">Управление списком должностей.</param>
    /// <exception cref="ApplicationException">Исключение при сбое работы метода.</exception>
    /// <exception cref="FormatException">Исключение при обработке неверного формата.</exception>
    internal void AddEmployee(PositionManager positionManager)
    {
        Console.Clear();
        Console.Write("Введите имя сотрудника: ");
        string firstName = Console.ReadLine();
        Console.Write("Введите фамилию сотрудника: ");
        string lastName = Console.ReadLine();
        positionManager.DisplayPositions();
        Console.Write("Введите ID должности: ");
        if (int.TryParse(Console.ReadLine(), out int positionId))
        {
            var position = positionManager.GetPositionById(positionId);
            if (position != null)
            {
                Employees.Add(new Employee(firstName, lastName, position));
                Console.WriteLine("Сотрудник добавлен.");
            }
            else
            {
                throw new ApplicationException("Должность не найдена.");
            }
        }
        else
        {
            throw new FormatException("Некорректное значение ID.");
        }
    }
    
    /// <summary>
    /// Удаление сотрудника из списка.
    /// </summary>
    /// <exception cref="ApplicationException">Исключение при сбое работы метода.</exception>
    /// <exception cref="FormatException">Исключение при обработке неверного формата.</exception>
    internal void RemoveEmployee()
    {
        Console.Clear();
        Console.Write("Введите ID сотрудника для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var employee = Employees.Find(e => e.Id == id);
            if (employee != null)
            {
                Employees.Remove(employee);
                Console.WriteLine("Сотрудник удален.");
            }
            else
            {
                throw new ApplicationException("Сотрудник не найден.");
            }
        }
        else
        {
            throw new FormatException("Некорректное значение ID.");
        }
    }
    
    /// <summary>
    /// Редактирование данных сотрудника (имя, фамилия, должность).
    /// </summary>
    /// <param name="positionManager">Управление списком должностей.</param>
    /// <exception cref="ApplicationException">Исключение при сбое работы метода.</exception>
    /// <exception cref="FormatException">Исключение при обработке неверного формата.</exception>
    internal void EditEmployee(PositionManager positionManager)
    {
        Console.Clear();
        Console.Write("Введите ID сотрудника для редактирования: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var employee = Employees.Find(e => e.Id == id);
            if (employee != null)
            {
                Console.Write("Введите новое имя: ");
                employee.FirstName = Console.ReadLine();
                Console.Write("Введите новую фамилию: ");
                employee.LastName = Console.ReadLine();
                positionManager.DisplayPositions();
                Console.Write("Введите новый ID должности: ");
                if (int.TryParse(Console.ReadLine(), out int positionId))
                {
                    var position = positionManager.GetPositionById(positionId);
                    if (position != null)
                    {
                        employee.Position = position;
                        Console.WriteLine("Данные сотрудника обновлены.");
                    }
                    else
                    {
                        throw new ApplicationException("Должность не найдена.");
                    }
                }
                else
                {
                    throw new FormatException("Некорректное значение для ID должности.");
                }
            }
            else
            {
                throw new ApplicationException("Сотрудник не найден.");
            }
        }
        else
        {
            throw new FormatException("Некорректное значение ID.");
        }
    }
    
    /// <summary>
    /// Вывод списка добавленных сотрудников.
    /// </summary>
    internal void DisplayEmployees()
    {
        Console.Clear();
        Console.WriteLine("Список сотрудников:");
        foreach (var employee in Employees)
        {
            Console.WriteLine(employee);
        }
    }
}