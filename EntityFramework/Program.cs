using EntityFramework.Models;
using System;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var _context = new EdDbContext();
            var majors = _context.Majors.ToList();
            var majorclasses = _context.MajorClasses.ToList();
            var classes = _context.Classes.ToList();
            //foreach(var m in majors)
            //{
            //    Console.WriteLine($"{m.Id} | {m.Code} | {m.Description} | {m.MinSat}");
            //}
            //var majandclass = from m in majors
            //                  join mc in majorclasses
            //                    on m.Id equals mc.MajorId
            //                  join c in classes
            //                    on mc.ClassId equals c.Id
            //                  select new { Id = m.Id, Code = m.Code, Description = m.Description, MinSat = m.MinSat,
            //                      MajorId = mc.MajorId, ClassId = mc.ClassId, clCode = c.Code, Subject = c.Subject,
            //                      Section = c.Section};
            //foreach (var mc in majandclass)
            //{
            //    Console.WriteLine($"{mc.Id} | {mc.Code} | {mc.Description} | {mc.MinSat} " +
            //                        $" | {mc.clCode} | {mc.Subject} | {mc.Section}");
            //}
            var students = _context.Students.ToList();
            //var gpasort = from stud in students
            //              orderby stud.Gpa descending
            //              select stud;
            var gpasort = students.OrderByDescending(s => s.Gpa)
                                  .ThenByDescending(s => s.Sat);
            foreach(var g in gpasort)
            {
                Console.WriteLine($"{g.Firstname} {g.Lastname} | {g.Sat} | {g.Gpa}");
            }
            Console.WriteLine("");
            var satavg = students.Average(s => s.Sat);
            Console.WriteLine($"The average of the student's SAT scores is {satavg}.");
        }
    }
}
