using System;
using System.Globalization;
using ContractPerHour.Entities;
using ContractPerHour.Entities.Enums;


namespace ContractPerHour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Nivel: (Junior/MidLevel/Senior)");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salario Base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker?: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) //for do valor digitado pelo usuario para saber quantas passagens pelo for contrato ira ocorrer
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY) ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Durations (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);

                //Adicionando os contratos paa o trabalhador

                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + " : " + worker.Income(year, month));

        }
    }
}
