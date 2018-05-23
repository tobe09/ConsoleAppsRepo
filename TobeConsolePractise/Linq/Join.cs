using System;
using System.Collections.Generic;
using System.Linq;

namespace TobeConsolePractise
{
    class Join
    {
        /// <summary>
        /// Join
        /// GroupJoin
        /// </summary>
        public static void Run()
        {
            List<Department> departments = new List<Department>();
            departments.Add(new Department { DepartmentId = 1, DepartmentName = "Dept1" });
            departments.Add(new Department { DepartmentId = 2, DepartmentName = "Dept2" });
            departments.Add(new Department { DepartmentId = 3, DepartmentName = "Dept3" });

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { EmployeeId = 1, EmployeeName = "Emp1", DepartmentId = 1 });
            employees.Add(new Employee { EmployeeId = 3, EmployeeName = "Emp3", DepartmentId = 3 });
            employees.Add(new Employee { EmployeeId = 4, EmployeeName = "Emp4", DepartmentId = 4 });

            var query = from dept in departments
                        join emp in employees on
                          new { dept.DepartmentId, key2 = dept.DepartmentId } equals new { emp.DepartmentId, key2 = emp.EmployeeId }
                        select new { dept.DepartmentName, EmpName = emp.EmployeeName };

            var newQuery = departments.Join(
                employees,
                d => new { Prop1 = d.DepartmentId, Prop2 = d.DepartmentId },
                e =>
                {
                    return new { Prop1 = e.DepartmentId, Prop2 = e.EmployeeId };
                },
                (d, e) => new { d.DepartmentName, e.EmployeeName })
                .Join(
                departments,
                a => a.DepartmentName,
                b => b.DepartmentName,
                (a, b) => new { a.EmployeeName, b.DepartmentName }
                )
                .OrderBy(a => a.DepartmentName)
                .OrderByDescending(a => a.DepartmentName)
                .ThenByDescending(a => a.EmployeeName)
                .Select(val => val)
                .GroupBy(s => s.EmployeeName)
                .DefaultIfEmpty();

            var q = departments.SelectMany(d => new List<int> { });

            var query2 = from dept in departments
                         join emp in employees on
                             dept.DepartmentId equals emp.DepartmentId into query3
                         select query3;

            foreach (var e in query)
                Console.WriteLine("Employee Name: {0}, Department Name: {1}", e.DepartmentName, e.EmpName);

            foreach (var e in query2)
                foreach (var emp in e)
                    Console.WriteLine(emp.DepartmentId + ", " + emp.EmployeeId + ", " + emp.EmployeeName + ", ");

            Console.ReadKey();
        }

        class Department
        {
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }
        }

        class Employee
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public int DepartmentId { get; set; }
        }
    }
}
