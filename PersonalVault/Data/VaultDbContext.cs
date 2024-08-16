using Microsoft.EntityFrameworkCore;
using PersonalVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalVault.Data
{
    public class VaultDbContext :DbContext
    {
        public DbSet<Credential> Credentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HV7D9HD;Initial Catalog=VaultData;Integrated Security=True;Trust Server Certificate=True");
        }
    }

}
