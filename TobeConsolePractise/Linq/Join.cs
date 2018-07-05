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

            var empinDept = from emp in employees
                            join dept in departments
                            on emp.DepartmentId equals dept.DepartmentId
                            select new { emp.EmployeeName, dept.DepartmentName };

            var empinDept2 = employees.Join(departments,
                e => e.DepartmentId,
                d => d.DepartmentId,
                (e, d) => new { e.EmployeeName, d.DepartmentName}
                );

            var query = from dept in departments
                        join emp in employees on
                          new { dept.DepartmentId, key2 = dept.DepartmentId } equals new { emp.DepartmentId, key2 = emp.EmployeeId }
                        select new { dept.DepartmentName, EmpName = emp.EmployeeName };

            var newQuery = departments.GroupJoin(
                employees,
                d => new { Prop1 = d.DepartmentId, Prop2 = d.DepartmentId },
                e =>
                {
                    return new { Prop1 = e.DepartmentId, Prop2 = e.EmployeeId };
                },
                (d, emps) => new { d.DepartmentName, emps })
                .SelectMany(
                x => x.emps.DefaultIfEmpty(),
                (x, y) => new { x.DepartmentName, EmployeeName = y == null ? null : y.EmployeeName }      //new Department { DepartmentName = x.DepartmentName }
                )
                .Join(
                departments,
                a => a.DepartmentName,
                b => b.DepartmentName,
                (a, b) => new { a.EmployeeName, b.DepartmentName, and = 2 }
                )
                .DefaultIfEmpty()
                .OrderBy(a => a.DepartmentName)
                .OrderByDescending(a => a.DepartmentName)
                .ThenByDescending(a => a.EmployeeName)
                .Select(val => val)
                //.GroupBy(s => s.EmployeeName)             //group by name and values under it
                .DefaultIfEmpty();
            
            var q = departments.SelectMany(d => new List<int> { });

            var query2 = from dept in departments
                         join emp in employees on
                             dept.DepartmentId equals emp.DepartmentId into query3
                         from emp in query3.DefaultIfEmpty()
                         select new
                         {
                             DepartmentId = emp == null ? 0 : emp.DepartmentId,
                             DepartmentName = dept == null ? null : dept.DepartmentName,
                             EmployeeId = emp == null ? 0 : emp.EmployeeId,
                             EmployeeName = emp == null ? null : emp.EmployeeName
                         };

            foreach (var e in query)
                Console.WriteLine("Employee Name: {0}, Department Name: {1}", e.DepartmentName, e.EmpName);

            foreach (var emp in query2)
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
