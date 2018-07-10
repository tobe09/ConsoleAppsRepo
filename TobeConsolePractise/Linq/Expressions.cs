using System;
using System.Linq.Expressions;

namespace TobeConsolePractise.Linq
{
    class Expressions
    {
        public static void Run()
        {
            Expression<Func<TestClass, bool>> where = c => c.Name.StartsWith("P");

            //same as above
            // The parameter, c
            var parm = Expression.Parameter(typeof(TestClass), "c");
            // c.Name
            var propName = Expression.Property(parm, "Name");
            // The constant, "P"
            var constP = Expression.Constant("P");
            // c.Name.StartsWith("P")
            var nameStartsWith = Expression.Call(
                propName,
                typeof(string).GetMethod("StartsWith", new[] { typeof(string) }),
                constP);
            Expression<Func<TestClass, bool>> where2 = Expression.Lambda<Func<TestClass, bool>>(nameStartsWith, parm);

            //interface segregation (e.g. System.Data.Entity.DbSet<T> IQueryable and IEnumerable implementation)
            var valA = new TestClass().AsTestA().TestMethod(() => true);   //As ITestA func
            var valB = new TestClass().TestMethod(() => true);   //As ITestB expr
        }


        interface ITestA
        {
            bool TestMethod(Func<bool> func);
        }

        interface ITestB : ITestA
        {
            bool TestMethod(Expression<Func<bool>> expr);
        }

        class TestClass : ITestB
        {
            public string Name { get; set; } = "Tobe";

            bool ITestA.TestMethod(Func<bool> func)
            {
                return func();
            }

            public bool TestMethod(Expression<Func<bool>> expr)
            {
                Func<bool> func = expr.Compile();
                return func();
            }

            public ITestA AsTestA()
            {
                return this;
            }
        }
    }
}
