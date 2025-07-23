namespace Bookkeping_with_exceptions;

using System;

class Program
{
    /// <summary>
    /// Запуск меню с проверкой ошибок.
    /// </summary>
    static void Main()
    {
        EmployeeManager employeeManager = new EmployeeManager();
        PositionManager positionManager = new PositionManager();
        SalaryCalculator salaryCalculator = new SalaryCalculator();

        while (true)
        {
            try
            {
                Console.WriteLine("\n"+"Выберите действие:"+"\n"+
                                  "1. Добавить нового сотрудника"+"\n"+
                                  "2. Удалить сотрудника"+"\n"+
                                  "3. Редактировать данные сотрудника"+"\n"+
                                  "4. Добавить новую должность"+"\n"+
                                  "5. Удалить должность"+"\n"+
                                  "6. Редактировать должность"+"\n"+
                                  "7. Редактировать параметры премии"+"\n"+ 
                                  "8. Вывести список сотрудников"+"\n"+
                                  "9. Вывести список должностей"+"\n"+
                                  "0. Выход");

                var choice = Console.ReadLine();
                ExecuteAction(choice, employeeManager, positionManager, salaryCalculator);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Выбор пункта меню с запуском функции.
    /// </summary>
    /// <param name="choice">Пункт меню.</param>
    /// <param name="employeeManager">Класс для управления сотрудниками.</param>
    /// <param name="positionManager">Класс для управления должностями.</param>
    /// <param name="salaryCalculator">Класс для расчета зарплаты сотрудников.</param>
    /// <exception cref="ApplicationException">Исключение при сбое работы метода.</exception>
    static void ExecuteAction(string choice, EmployeeManager employeeManager, PositionManager positionManager, SalaryCalculator salaryCalculator)
    {
        switch (choice)
        {
            case "1":
                employeeManager.AddEmployee(positionManager);
                break;
            case "2":
                employeeManager.RemoveEmployee();
                break;
            case "3":
                employeeManager.EditEmployee(positionManager);
                break;
            case "4":
                positionManager.AddPosition();
                break;
            case "5":
                positionManager.RemovePosition(employeeManager);
                break;
            case "6":
                positionManager.EditPosition(employeeManager);
                break;
            case "7":
                salaryCalculator.EditBonusPercentage(employeeManager);
                break;
            case "8":
                employeeManager.DisplayEmployees();
                break;
            case "9":
                positionManager.DisplayPositions();
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                throw new ApplicationException("Некорректный выбор. Попробуйте снова.");
        }
    }
}