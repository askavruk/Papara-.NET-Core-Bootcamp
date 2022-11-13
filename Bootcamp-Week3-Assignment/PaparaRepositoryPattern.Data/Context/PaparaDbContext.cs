using Microsoft.EntityFrameworkCore;
using PaparaRepositoryPattern.Data.Configurations;
using PaparaRepositoryPattern.Domain.Entities;
using PaparaRepositoryPattern.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Data.Context
{
    public class PaparaDbContext : DbContext
    {
        public PaparaDbContext(DbContextOptions<PaparaDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfigurations());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
             .HasData(
              new Company { Id = 1, Name = "Papara", Adress = "Uskudar", City = "Istanbul", Email = "papara@papara.com", TaxNumber = "123", CreationDate = DateTime.Now, Status= Status.Active },
              new Company { Id = 2, Name = "Patika", Adress = "Beyoglu", City = "Istanbul", Email = "patika@patika.com", TaxNumber="123", CreationDate = DateTime.Now, Status = Status.Active },
              new Company { Id = 3, Name = "Company", Adress = "Beylikduzu", City = "Istanbul", Email = "company@company.com", TaxNumber = "123", CreationDate = DateTime.Now, Status = Status.Active });

        }
        public DbSet<Company> Companies { get; set; }
    }
}
