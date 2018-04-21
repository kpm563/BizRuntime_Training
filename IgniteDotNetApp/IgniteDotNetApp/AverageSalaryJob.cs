using Apache.Ignite.Core.Compute;
using System;
using System.Collections;

namespace IgniteDotNetApp
{
    class AverageSalaryJob:ComputeJobAdapter<Tuple<long, int>>
    {
        private readonly ArrayList _employees = new ArrayList();

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public override Tuple<long, int> Execute()
        {
            //throw new NotImplementedException();
            long sum = 0;
            int count = 0;

            Console.WriteLine();
            Console.WriteLine(">>> Executing salary job :: "+_employees.Count + " employee(s).....");
            Console.WriteLine();

            foreach (Employee emp in _employees)
            {
                sum += emp.Salary;
                count++;
            }

            return new Tuple<long, int>(sum, count);
        }
    }
}
