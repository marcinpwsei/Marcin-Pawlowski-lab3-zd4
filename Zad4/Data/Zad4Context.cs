using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zad4.Models;

namespace Zad4.Data
{
    public class Zad4Context : DbContext
    {
        public Zad4Context (DbContextOptions<Zad4Context> options)
            : base(options)
        {
        }

        public DbSet<Zad4.Models.StorageList> StorageList { get; set; }
    }
}
