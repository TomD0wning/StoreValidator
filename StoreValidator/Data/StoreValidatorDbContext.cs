using StoreValidator.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StoreValidator.Data
{
    public class StoreValidatorDbContext : DbContext
    {
        public StoreValidatorDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Store> Stores { get; set; }


    }
}