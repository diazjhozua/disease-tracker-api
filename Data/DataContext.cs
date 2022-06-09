using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Models;
using Microsoft.EntityFrameworkCore;

namespace disease_tracker_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

          public DbSet<Disease> Diseases { get; set; }
    }
}