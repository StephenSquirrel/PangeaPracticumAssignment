using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsumeRabbit
{
    public partial class PangeaPracticumContext : DbContext
    {
        public virtual DbSet<PangeaRecords> PangeaRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D4VPA1R;Database=PangeaPracticum;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PangeaRecords>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JsonData).HasColumnName("jsonData");

                entity.Property(e => e.XmlData).HasColumnName("xmlData");
            });
        }
    }
}