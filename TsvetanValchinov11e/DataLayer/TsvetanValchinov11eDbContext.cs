using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer
    {
    public class TsvetanValchinov11eDbContext : DbContext
        {
        public TsvetanValchinov11eDbContext() 
            {
                
            }

        public TsvetanValchinov11eDbContext(DbContextOptions options) :base(options)
            {

            }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            if (!optionsBuilder.IsConfigured)
                {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-ADCBR92\SQLEXPRESS;Database=TsvetanValchinov11ePT4;Trusted_Connection=True");
                }
            }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }

        }
    }
