using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PracticumPangea.Data;


namespace PracticumPangea.Models
{
    public class DbInitializer
    {
        public static void Initialize(PangeaContext context)
        {
            context.Database.EnsureCreated();
            //PangeaRecord
            //if (context.PangeaRecords.Any())
            //{
            //    return;   // DB has been seeded
            //}
            //var recordspan = new PangeaRecord[]
            //{
            //new PangeaRecord{jsonData = "testPracticumPangea"},
          
            //};
            //foreach (PangeaRecord s in recordspan)
            //{
            //    context.PangeaRecords.Add(s);
            //}
            //context.SaveChanges();

        }
    }
}