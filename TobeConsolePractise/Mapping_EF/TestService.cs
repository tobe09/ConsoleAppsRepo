using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TobeConsolePractise.Mapping_EF
{
    [TestFixture]
    class TestService
    {
        [Test]
        public void UpdateStudent_Did_Update()
        {
            var fakeStudents = GetFakeStudents();

            Mock<DbSet<Student>> mockStudents = new Mock<DbSet<Student>>();
            Mock<StubContext> mockContext = new Mock<StubContext>();

            mockStudents.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(fakeStudents.Expression);
            mockStudents.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(fakeStudents.ElementType);
            mockStudents.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(fakeStudents.GetEnumerator());
            mockStudents.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(fakeStudents.Provider);
            mockStudents.Setup(s => s.Find(It.IsAny<int>())).Returns((object[] i) =>
            {
                return fakeStudents.FirstOrDefault(s => s.Id == (int)i[0]);
            });

            mockContext.Setup(c => c.Students).Returns(mockStudents.Object);

            int id = 2;
            string newName = "Testname";

            var context = mockContext.Object;
            context.Dispose();                                  //dispose automatically mocked
            new StubContext().Dispose();                        //dispose manually mocked

            var students = context.Students.ToList();           //count is 3
            var students2 = context.Students.ToList();          //enumerator at end, list count is 0
            var oldStudent = context.Students.FirstOrDefault(s => s.Id == id);      //iterates using enumerator

            //var practiseService = new PractiseService();
            //practiseService.UpdateStudent(context, id, newName, true);      //difficult to mock entry

            var oldStudent2 = context.Students.Find(id);
            oldStudent2.Name = newName;
            int value = context.SaveChanges();          //unnecessary, value is 0, changes/update occur in memory

            var allStudents = context.Students.ToList();         //enumerator at end, list count is still 0
            var updStudent = context.Students.FirstOrDefault(s => s.Id == id);

            mockStudents.Verify(s => s.Find(It.IsAny<int>()), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        IQueryable<Student> GetFakeStudents()
        {
            return new List<Student>()
            {
                new Student {Id=1,Name="Cindy",AdministratorId=0,CreatedDate=DateTime.Now },
                new Student {Id=2,Name="Wisdom",AdministratorId=0,CreatedDate=DateTime.Now },
                new Student {Id=3,Name="Vincent",AdministratorId=0,CreatedDate=DateTime.Now }
            }.AsQueryable();
        }
    }

    public class StubContext : MyContext
    {
        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
        }
    }
}
