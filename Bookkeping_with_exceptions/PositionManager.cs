namespace Bookkeping_with_exceptions;
/// <summary>
/// Класс для управления списком должностей: добавление, удаление должности,
/// редактирование данных должности, поиск должности по ID, вывод списка должностей.
/// </summary>
internal class PositionManager
{
    internal List<Position> Positions { get; } = new List<Position>();

    /// <summary>
    /// Добавление должности в список
    /// </summary>
    /// <exception cref="FormatException">Исключение при обработке неверного формата.</exception>
    internal void AddPosition()
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
            throw new FormatException("Некорректное значение для оклада.");
        }
    }

    /// <summary>
    /// Удаление должности из списка.
    /// </summary>
    /// <param name="employeeManager">Класс для управления сотрудниками.</param>
    /// <exception cref="ApplicationException">Исключение при сбое работы метода</exception>
    /// <exception cref="FormatException">Исключение при обработке неверного формата</exception>
    internal void RemovePosition(EmployeeManager employeeManager)
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
                    throw new ApplicationException("Нельзя удалить должность, пока есть сотрудники с этой должностью.");
                }
                else
                {
                    Positions.Remove(position);
                    Console.WriteLine("Должность удалена.");
                }
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

    /// <summary>
    /// Редактирование данных должности (название, оклад).
    /// Обновляет зарплату сотрудников с конкретной должностью при изменении оклада.
    /// </summary>
    /// <param name="employeeManager"></param>
    /// <exception cref="ApplicationException">Исключение при сбое работы метода.</exception>
    /// <exception cref="FormatException">Исключение при обработке неверного формата.</exception>
    internal void EditPosition(EmployeeManager employeeManager)
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
                    throw new FormatException("Некорректное значение для оклада.");
                }
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

    /// <summary>
    /// Вывод данных должности по ID.
    /// </summary>
    /// <param name="id">Значение ID должности.</param>
    /// <returns> Возвращает данные должности в найденой позиции по ID.</returns>
    internal Position GetPositionById(int id)
    {
        return Positions.Find(p => p.Id == id);
    }

    /// <summary>
    /// Вывод списка должностей.
    /// </summary>
    internal void DisplayPositions()
    {
        Console.Clear();
        Console.WriteLine("Список должностей:");
        foreach (var position in Positions)
        {
            Console.WriteLine(position);
        }
    }
}