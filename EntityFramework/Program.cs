using EntityFramework.Controllers;
using EntityFramework.Models;
using System;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //var majorclasses = _context.MajorClasses.ToList();
            //var classes = _context.Classes.ToList();

            Major major = null;
            var majorsCtrl = new MajorsController();

            //var NewMajor = new Major()
            //{
            //    Id = 0, Code = "MUSX", Description = "Music", MinSat = 1595
            //};
            //try
            //{
            //    var rcl = majorsCtrl.Create(NewMajor);
            //    if (!rcl)
            //    {
            //        Console.WriteLine("Create failed!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Exception occurred: {ex.Message}");
            //}

            //NewMajor.Description = "Classical Music";
            //majorsCtrl.Change(NewMajor.Id, NewMajor);

            var NewMajor2 = majorsCtrl.GetbyPk(17);
            var rc = majorsCtrl.Remove(NewMajor2.Id);
            if (!rc)
            {
                Console.WriteLine("Remove failed!");
            }

            major = majorsCtrl.GetbyCode("GENB");
            Console.WriteLine(major);
            
            major = majorsCtrl.GetbyPk(2);
            Console.WriteLine($"{major.Description}");

            major = majorsCtrl.GetbyPk(999);
            if (major == null)
            {
                Console.WriteLine("Not found!");
            }

            var majors = majorsCtrl.GetAll();
            foreach (var m in majors)
            {
                Console.WriteLine($"{m.Id} | {m.Code} | {m.Description} | {m.MinSat}");
            }
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
                //var students = _context.Students.ToList();
            //var gpasort = from stud in students
            //              orderby stud.Gpa descending
            //              select stud;
            //var gpasort = students.OrderByDescending(s => s.Gpa)
            //                      .ThenByDescending(s => s.Sat);
            //foreach(var g in gpasort)
            //{
            //    Console.WriteLine($"{g.Firstname} {g.Lastname} | {g.Sat} | {g.Gpa}");
            //}
            //Console.WriteLine("");
            //var satavg = students.Average(s => s.Sat);
            //Console.WriteLine($"The average of the student's SAT scores is {satavg}.");
        }
    }
}
