using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TobeConsolePractise.Mapping_EF
{
    public class PractiseEf
    {
        public static void Run()
        {
            var practiseService = new PractiseService();
            //practiseService.PerformActions(new MyContext());
            //practiseService.UpdateStudent(new MyContext(), new { Id = 2, Name = "Rash", CreatedDate = DateTime.Now, AdministratorId = 0 });
        }
    }

    public class PractiseService   //more like a data provider though.
    {
        private MyContext testContext;

        public PractiseService() { }

        public PractiseService(MyContext context)
        {
            testContext = context;
        }

        public void PerformActions(MyContext context)
        {
            using (context)
            {
                if (context.Students.ToList().Count == 0)
                {
                    AddAdministrators(context);
                    AddStudents(context);
                    AddSubjects(context);
                    AddEnrollments(context);
                    context.SaveChanges();
                }

                var admins = context.Administrators.ToList();
                var students = context.Students.ToList();
                var subjects = context.Subjects.ToList();
                var enrollments = context.Enrollments.ToList();

                var studentsDoingMaths = (from enrollment in context.Enrollments
                                          join subject in context.Subjects
                                          on new { enrollment.SubjectId, Name = "Maths" } equals new { SubjectId = subject.Id, subject.Name }
                                          join student in context.Students
                                          on enrollment.StudentId equals student.Id
                                          select new
                                          {
                                              StudentName = student.Name,
                                              SubjectName = subject.Name,
                                              EnrollmentId = enrollment.Id,
                                              AdministratorId = student.AdministratorId,
                                              CreatingAdmin = student.CreatingAdmin
                                          }).ToList();

                //same as above
                var studentsDoingMaths2= (from enrollment in context.Enrollments
                                          join subject in context.Subjects
                                          on new { enrollment.SubjectId, Name = "Maths" } equals new { SubjectId = subject.Id, subject.Name }
                                          select new
                                          {
                                              StudentName = enrollment.Student.Name,
                                              SubjectName = subject.Name,
                                              EnrollmentId = enrollment.Id,
                                              AdministratorId = enrollment.Student.AdministratorId,
                                              CreatingAdmin = enrollment.Student.CreatingAdmin
                                          }).ToList();

                //same as above
                var studentsDoingMaths3 = context.Enrollments.Where(e => e.Subject.Name == "Maths")
                    .Select(enrollment => new
                    {
                        StudentName = enrollment.Student.Name,
                        SubjectName = enrollment.Subject.Name,
                        EnrollmentId = enrollment.Id,
                        AdministratorId = enrollment.Student.AdministratorId,
                        CreatingAdmin = enrollment.Student.CreatingAdmin
                    }).ToList();


                var studentsDoingMathsAndEnglish = context.Enrollments.Where(e => e.Subject.Name == "Maths")
                    .Join(
                    context.Enrollments.Where(e => e.Subject.Name == "English").Select(e => e.StudentId),
                    eInner => eInner.StudentId,
                    studentId => studentId,
                    (eInner, studentId) => new
                    {
                        Studentid = studentId,
                        StudentName = eInner.Student.Name,
                        SubjectName = eInner.Subject.Name,
                        EnrollmentId = eInner.Id,
                        AdministratorId = eInner.Student.AdministratorId,
                        CreatingAdmin = eInner.Student.CreatingAdmin
                    }).ToList();

                //same as above
                var studentsDoingMathsAndEnglish2 = (from eInner in context.Enrollments
                                                     where eInner.Subject.Name == "Maths"
                                                     join outerStudentId in (from outerEnrollment in context.Enrollments
                                                                             where outerEnrollment.Subject.Name == "English"
                                                                             select outerEnrollment.StudentId)
                                                     on eInner.Student.Id equals outerStudentId
                                                     select new
                                                     {
                                                         StudentName = eInner.Student.Name,
                                                         SubjectName = eInner.Subject.Name,
                                                         EnrollmentId = eInner.Id,
                                                         AdministratorId = eInner.Student.AdministratorId,
                                                         CreatingAdmin = eInner.Student.CreatingAdmin
                                                     }).ToList();
                                                  


                Console.ReadKey();
            }
        }

        public void UpdateStudent(MyContext context, dynamic updatedEntityProps, bool isTest = false)
        {
            if (isTest)
                using (context) { }         //to test whether dispose method has been mocked

            using (context)
            {
                Student student = context.Students.Find(updatedEntityProps.Id);
                context.Entry(student).CurrentValues.SetValues(updatedEntityProps);
                context.Entry(student).State = EntityState.Modified;
                int status = context.SaveChanges();
            }
        }
        
        void AddAdministrators(MyContext myContext)
        {
            var admin = new Administrator { Id = 0, Name = "Chineke Tobenna" };
            myContext.Administrators.Add(admin);
        }

        void AddStudents(MyContext myContext)
        {
            var students = new List<Student>()
            {
                new Student {Id=1,Name="Cindy",AdministratorId=0,CreatedDate=DateTime.Now },
                new Student {Id=2,Name="Wisdom",AdministratorId=0,CreatedDate=DateTime.Now },
                new Student {Id=3,Name="Vincent",AdministratorId=0,CreatedDate=DateTime.Now }
            };
            myContext.Students.AddRange(students);
        }

        void AddSubjects(MyContext myContext)
        {
            var subjects = new List<Subject>()
            {
                new Subject {Id=1, Name="Maths", Description="Calculation" },
                new Subject {Id=2, Name="English", Description="Grammar" }
            };
            foreach (var subject in subjects) myContext.Subjects.Add(subject);
        }

        void AddEnrollments(MyContext myContext)
        {
            var enrollments = new List<EnrollMent>()
            {
                new EnrollMent {Id=1, StudentId=1,SubjectId=1 },
                new EnrollMent {Id=2, StudentId=1,SubjectId=2 },
                new EnrollMent {Id=3, StudentId=2,SubjectId=1 },
                new EnrollMent {Id=4, StudentId=3,SubjectId=2 }
            };
            foreach (var enrollment in enrollments) myContext.Enrollments.Add(enrollment);
        }
    }
}
