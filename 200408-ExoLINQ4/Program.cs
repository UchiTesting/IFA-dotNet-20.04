using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExoLINQ4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Employee> employees = new List<Employee>();
            List<PaySlip> paySlips = new List<PaySlip>();
            int desiredNbEmpoyees = 13;
            int desiredNbPayslip = desiredNbEmpoyees * 12;
             int nbelem = Enum.GetValues(typeof(SeniorityEnum)).Length;
            
            employees.AddRange(CreateEmployees(desiredNbEmpoyees));
            paySlips.AddRange(CreatePaySlips(desiredNbPayslip,desiredNbEmpoyees));

            Employee selectedEmployee = employees[new Random().Next(0,employees.Count)];

            Console.WriteLine("Mean salary");
            MeanSalary(paySlips);
            Console.WriteLine("Payslips of a specific employee");
            PaySlipsOfSpecificEmployee(selectedEmployee,paySlips);
            Console.WriteLine("Employees with no extra hours");
            EmployeesWithNoExtraHours(employees,paySlips);
            Console.WriteLine("Average Seniority");
            AverageSeniority(employees);
            Console.WriteLine("Employees ordered by seniority");
            EmployeesOrderedBySeniority(employees);
            Console.WriteLine("Mean salary per post");
            MeanSalaryPerPost(employees,paySlips);
            Console.WriteLine("");
        }

        public static void MeanSalary(IEnumerable<PaySlip> p)
        {
            var paySlips = p as PaySlip[] ?? p.ToArray();
            int sum = paySlips.Sum(ps => ps.Salary);
            Console.WriteLine($"Mean Salary is {sum/paySlips.ToList().Count}");
        }
        public static void PaySlipsOfSpecificEmployee(Employee e, List<PaySlip> p){
            p.ForEach(ps => {
                if (ps.EmployeeID == e.Id)
                {
                    Console.WriteLine(ps);
                }
            });
        }

        public static void EmployeesWithNoExtraHours(List<Employee> e, List<PaySlip> p)
        {
            IEnumerable query = from pay in p
                join emp in e on pay.EmployeeID equals emp.Id
                where (pay.NbExtraHours == 0)
                select emp;

            foreach (var o in query)
            {
                Console.WriteLine(o.ToString());
            }
        }

        public static void AverageSeniority(List<Employee> e)
        {
            int avg = ((int)e.Average(emp => ((int) emp.Seniority)));
            Console.WriteLine($"Average Seniority is {((SeniorityEnum)avg)}");
        }

        public static void EmployeesOrderedBySeniority(List<Employee> e)
        {
            IEnumerable<Employee> query = from emp in e
                orderby emp.Seniority
                select emp;

            foreach (var employee in query)
            {
                Console.WriteLine(employee);
            }
        }

        public static void MeanSalaryPerPost(List<Employee> e, List<PaySlip> p)
        {
            // TODO finish this query
            // IEnumerable query = from pay in p
            //     join emp in e on pay.EmployeeID equals emp.Id
            //     where 
        }

        public static List<Employee> CreateEmployees(int nbEmployees)
        {
            List<Employee> temp = new List<Employee>();
            Random random = new Random();
            List<string> posts = new List<string>{"Dev", "Tester", "DevOps"};

            for (int i = 0; i < nbEmployees; i++)
            {
                temp.Add(
                    new Employee(
                        i,
                        $"Employee {i}",
                        posts[random.Next(0,posts.Count)],
                        ((SeniorityEnum)random.Next(0,3)))
                    );
            }

            return temp;
        }

        public static List<PaySlip> CreatePaySlips(int nbPaySlips, int nbEmployees = 10)
        {
            List<PaySlip> temp = new List<PaySlip>();
            Random random = new Random();
        
            for (int i = 0; i < nbPaySlips; i++)
            {
                temp.Add(
                    new PaySlip(i,
                    random.Next(0,nbEmployees+1),
                    $"Payslip {i}",
                    random.Next(0,200),
                    random.Next(0,20),
                    random.Next(15000,50000)
                    )
                );
            }

            return temp;
        }
    }
}