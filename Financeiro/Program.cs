using System;
using System.Globalization;
using Financeiro.Entities;
using Financeiro.Entities.Enums;

namespace Financeiro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Emter the department's name: ");
            var deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data");
            Console.Write("Name: ");
            var nameWorker = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());//Converting the string to the int in the enum

            Console.Write("Base salary: ");
            var baseSal = double.Parse(Console.ReadLine());

            Department dept = new Department(deptName);
            Worker worker = new Worker(nameWorker, level, baseSal, dept);

            Console.Write("How many contracts to this worker? ");
            var numbContract = int.Parse(Console.ReadLine()); 

            for(var i= 1; i <= numbContract; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null); //DateTime here is the type of variable like int, double, sting etc
                Console.Write("Value per hour: ");
                var valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                var hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);//Instanciando o contrato
                worker.AddContract(contract);//Add the contract to the worker
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            var monthAndYear = Console.ReadLine();

            //To separate the month from the year and transform to int
            var month = int.Parse(monthAndYear.Substring(0, 2));
            var year = int.Parse(monthAndYear.Substring(3));


            Console.WriteLine("Name: "+ worker.Name );
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year,month).ToString("F2"));



        }
    }
}
