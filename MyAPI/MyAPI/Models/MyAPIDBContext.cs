﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyAPI.Models;

namespace MyAPI.Models
{
    public class FirstAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public FirstAPIDBContext(DbContextOptions<FirstAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            try
            {

                var connectionString = Configuration.GetConnectionString("CustomerDataService");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }

            catch (Exception)
            {
                Console.Write("bad string");
            }
        }

        public DbSet<Card> Cards { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
    }
}
