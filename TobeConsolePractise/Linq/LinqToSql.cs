using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TobeConsolePractise.Linq;

namespace TobeConsolePractise
{
    class LinqToSql
    {
        /// <summary>
        /// Only obtainable for MS SQL server. Preferable to use Entity framework
        /// </summary>
        public static void Run()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConsolePractiseDbConnectionString"].ToString();
            string connStrClone = connStr;// TobeConsolePractise.Properties.Settings.Default.ConsolePractiseDbConnectionString;
            bool isSame = connStr.Equals(connStrClone);  //true

            using (LinqToSqlDataContext dbContext = new LinqToSqlDataContext(connStr))
            {
                DisplayAllEmployees(dbContext);

                //CREATE/INSERT
                Employee emp = new Employee();      //any property not set will be assigned a default value
                emp.Name = "Employee1";
                emp.DepartmentId = "Dept1";
                emp.EmployeeId = 1;

                dbContext.Employees.InsertOnSubmit(emp);
                dbContext.SubmitChanges();

                //SELECT: get inserted employee
                Employee insertedEmp = dbContext.Employees.FirstOrDefault(e => e.Name.Equals("Employee1"));
                Console.WriteLine("Inserted Employee Details: {0}, {1}, {2}", insertedEmp.Name, insertedEmp.EmployeeId, insertedEmp.DepartmentId);

                DisplayAllEmployees(dbContext);

                //UPDATE
                emp.Name = "Employee1 Updated";     //affects updatedEmp since they point to the same object
                insertedEmp.DepartmentId = "Dept1 Upd";   //length of field should not be exceeded

                dbContext.SubmitChanges();

                DisplayAllEmployees(dbContext);

                //get updated employee
                Employee updatedEmp = dbContext.Employees.FirstOrDefault(e => e.Name == "Employee1 Updated");
                Employee testEmp = dbContext.Employees.FirstOrDefault(e => e.Name == "Employee1"); //null
                Console.WriteLine("Updated Employee Details: {0}, {1}, {2}", updatedEmp.Name, updatedEmp.EmployeeId, updatedEmp.DepartmentId);

                //DELETE
                Employee deleteEmp = dbContext.Employees.FirstOrDefault(e => e.DepartmentId.Equals("Dept11"));

                Console.WriteLine("Deleted Employee Details: {0}, {1}, {2}", deleteEmp.Name, deleteEmp.EmployeeId, deleteEmp.DepartmentId);

                dbContext.Employees.DeleteOnSubmit(deleteEmp);
                dbContext.SubmitChanges();

                DisplayAllEmployees(dbContext, "Departments");

                //testing linq join
                IEnumerable<Employee> empList = dbContext.Employees;
                IEnumerable<Department> deptList = dbContext.Departments;
                var query1 = empList.Join(deptList, e => e.Name.ToUpper(), dept => "Employee1 Updated".ToUpper(), (e, dept) => new { e.Name, dept.DepartmentId })
                .Select(newObj => new { newObj.Name, newObj.DepartmentId }); //redundant
                var query2 = from e in empList join dept in deptList on e.Name equals "Employee1 Updated" select new { e.Name, dept.DepartmentId };

                //plurality is done automatically for db table name property in the DataContext class
            }

            Console.ReadKey();
        }

        public static void DisplayAllEmployees(DataClasses1DataContext dbContext, string tableName = "Employees")
        {
            Type t = dbContext.GetType();
            var objsProp = t.GetProperty(tableName);
            var objs = (IEnumerable<object>)objsProp.GetValue(dbContext);

            int count = 1;
            foreach (object obj in objs)
            {
                t = obj.GetType();
                var objProp = t.GetProperties();

                Console.WriteLine("\nAll " + tableName + " " + count);
                foreach (var prop in objProp)
                    Console.Write(prop.Name + ": " + prop.GetValue(obj) + ", ");

                count++;
            }

            Console.WriteLine();

            //IEnumerable<Employee> empList = dbContext.Employees;
            //Console.WriteLine("\nAll employees currently available");

            //foreach (Employee empl in empList)
            //    Console.WriteLine("Employee Details: {0}, {1}, {2}\n", empl.Name, empl.EmployeeId, empl.DepartmentId);
        }
    }

    class LinqToSqlDataContext : DataClasses1DataContext
    {
        public LinqToSqlDataContext(string connStr)
            : base(connStr)
        {
        }
    }
}
