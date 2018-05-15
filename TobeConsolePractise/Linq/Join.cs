using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            employees.Add(new Employee { EmployeeId = 11, EmployeeName = "Emp1", DepartmentId = 1 });
            employees.Add(new Employee { EmployeeId = 31, EmployeeName = "Emp3", DepartmentId = 3 });
            employees.Add(new Employee { EmployeeId = 41, EmployeeName = "Emp4", DepartmentId = 4 });

            var query = from dept in departments
                        join emp in employees on
                            dept.DepartmentId equals emp.DepartmentId
                        select new { dept.DepartmentName, EmpName = emp.EmployeeName};

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
