using Mvc4PhoneCatalog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc4PhoneCatalog.Data
{
    public class PhoneDbContext: DbContext
    {
        public PhoneDbContext()
        {

        }
        
        public DbSet<Phone> Phone { get; set; }

    }
}
