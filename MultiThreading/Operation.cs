using Payroll_Service_ADO_database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Operation
    {
        EmployeeOperation operations = new EmployeeOperation();

        //UC1
        public void UsingWithoutThread(List<Employee> list)
        {
            DateTime start = DateTime.Now;
            foreach (var data in list)
            {
                operations.AddEmployee(data);
            }
            DateTime end = DateTime.Now;
            
            Console.WriteLine("Duration without Thread " + (end - start));
        }
        //UC2
        public void UsingWithThread(List<Employee> list)
        {
            DateTime start = DateTime.Now;
            foreach (var data in list)
            {
                Task threadss = new Task(() =>
                {
                    Console.WriteLine("Being Added" + data.Name);
                    operations.AddEmployee(data);
                    Console.WriteLine("Added" + data.Name);
                });
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("Duration with Thread " + (end - start));
        }
    }
}
