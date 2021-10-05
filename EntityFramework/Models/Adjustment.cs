using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.Models
{
    public partial class Adjustment
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Gpadelta { get; set; }
        public bool Completed { get; set; }
    }
}
