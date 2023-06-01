using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MotorbikeApp.Models;

namespace MotorbikeApp.Data
{
    public class MotorbikeAppContext : DbContext
    {
        public MotorbikeAppContext (DbContextOptions<MotorbikeAppContext> options)
            : base(options)
        {
        }

        public DbSet<MotorbikeApp.Models.Motorbike> Motorbike { get; set; } = default!;
    }
}
