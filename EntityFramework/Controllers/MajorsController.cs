using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    public class MajorsController
    {
        //readonly can only be set in a constructor
        private readonly EdDbContext _context;

        public MajorsController()
        {
            //with this everytime an instance of MajorsController is created it also creates an instance of the Context
            _context = new EdDbContext();
        }

        public List<Major> GetAll()
        {
            //have to identify which collection we are working with (i.e. Majors here)
            return _context.Majors.ToList();
        }
        public Major GetbyPk(int Id)
        {
            return _context.Majors.Find(Id);
        }
        public Major GetbyCode(string Code)
        {
            return _context.Majors.SingleOrDefault(m => m.Code == Code);
        }
        public bool Create(Major major)
        {
            major.Id = 0;
            _context.Majors.Add(major);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Create failed");
            }
            return true;
        }
        public bool Change(int Id, Major major)
        {
            if(Id != major.Id)
            {
                throw new Exception("Id's don't match!");
            }
            //major.Updated = DateTime.Now;
            _context.Entry(major).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected != 1)
            {
                throw new Exception("Update failed");
            }
            return true;
        }
        public bool Remove(int Id)
        {
            var major = _context.Majors.Find(Id);
            if(major == null)
            {
                return false;
            }
            _context.Majors.Remove(major);
            _context.SaveChanges();
            return true;
        }
    }
}
