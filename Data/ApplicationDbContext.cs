using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SammysAuto.Models;
using SammysAuto.Utility;

namespace SammysAuto.Data
{
    public class ApplicationDbContext : IdentityDbContext<SammysAutoUser, SammysAutoRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<SammysAutoRole> SammysAutoRoles { get; set; }
    }
}
