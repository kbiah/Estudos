using lagrimas.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace lagrimas.Data
{
    public class IESContext: DbContext
    {
            public DbSet<Departamento> Departamentos { get; set; }
            public DbSet<Instituicao> Instituicoes { get; set; }

            public IESContext(DbContextOptions<IESContext> options) : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            object value = modelBuilder.Entity<Departamento>().ToTable("Departamento");
        }

        // ---> Só usar isso se nao for usar local db <---
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //      optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IESCasaDoCodigo;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
    }
 }
