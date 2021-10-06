using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    public class StudentController
    {
        private readonly EdDbContext _context;

        public StudentController()
        {
            _context = new EdDbContext();
        }
        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        public Student GetbyPk(int Id)
        {
            return _context.Students.Find(Id);
        }
        public bool Create(Student student)
        {
            if(student.Id != 0)
            {
                throw new Exception("You must enter 0 for Id!");
            }
            _context.Students.Add(student);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Create failed!");
            }
            return true;
        }
        public bool Change(int Id, Student student)
        {
            if(Id != student.Id)
            {
                throw new Exception("Id's don't match!");
            }
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Update failed!");
            }
            return true;
        }
        public bool Remove(int Id)
        {
            var student = _context.Students.Find(Id);
            if(student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }


    }
}
