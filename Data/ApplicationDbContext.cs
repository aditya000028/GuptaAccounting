using System;
using System.Collections.Generic;
using System.Text;
using GuptaAccounting.Model;
using GuptaAccounting.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuptaAccounting.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }

        public DbSet<SMTP> SMTP { get; set; }
    }
}
