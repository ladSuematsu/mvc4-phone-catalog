using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc4PhoneCatalog.Models
{
    public class Phone
    {
        
        public int ID {get; set;}

        //[Required]
        public String Brand { get; set; }

        //[Required]
        public String ModelName { get; set; }
        
        public String ModelCode { get; set; }
        
        public Int16 LaunchYear { get; set; }

        public String OperatingSystem { get; set; }

        public decimal Price { get; set; }
    }

    public class PhoneDbContext : DbContext
    {
        public DbSet<Phone> Phone { get; set; }
    }
}
