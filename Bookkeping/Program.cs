namespace Bookkeping;

using System;

class Program
{
    static void Main()
    {
        EmployeeManager employeeManager = new EmployeeManager();
        PositionManager positionManager = new PositionManager();
        SalaryCalculator salaryCalculator = new SalaryCalculator();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить нового сотрудника");
            Console.WriteLine("2. Удалить сотрудника");
            Console.WriteLine("3. Редактировать данные сотрудника");
            Console.WriteLine("4. Добавить новую должность");
            Console.WriteLine("5. Удалить должность");
            Console.WriteLine("6. Редактировать должность");
            Console.WriteLine("7. Редактировать параметры премии");
            Console.WriteLine("8. Вывести список сотрудников");
            Console.WriteLine("9. Вывести список должностей");
            Console.WriteLine("0. Выход");

            var choice = Console.ReadLine();

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
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}