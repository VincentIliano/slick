using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Slick.Models.Contact;
using Slick.Models.Contracts;
using Slick.Models.People;
using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        //static LoggerFactory object
        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
        //      new ConsoleLoggerProvider((_, __) => true, true)
        //});

        //static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
              new DebugLoggerProvider()
        });

        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<ConsultantSpecialisation> ConsultantSpecialisations { get; set; }
        public DbSet<SpecialisationLevel> SpecialisationLevels { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Contract> Contracts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
            .EnableSensitiveDataLogging()
            .UseSqlServer(@"Data Source=ELMOS-KG4STNS\SQLELMOS;Initial Catalog=slick;Integrated Security=True");
            
        }
    }
}
