//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PangeaWebApplication.Data
//{
//    public class PangeaContext
//    {
//    }
//}
using PracticumPangea.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticumPangea.Data
{
    public class PangeaContext : DbContext
    {
        public PangeaContext(DbContextOptions<PangeaContext> options) : base(options)
        {
        }

        public DbSet<PangeaRecord> PangeaRecords { get; set; }

    }
}