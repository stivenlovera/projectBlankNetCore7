using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comisionesapi.Models;
using Microsoft.EntityFrameworkCore;

namespace comisionesapi.Context
{
    public class DbMysqlServerContext : DbContext
    {
        public DbMysqlServerContext(DbContextOptions<DbMysqlServerContext> options) : base(options)
        {

        }
         public virtual DbSet<AdministracionRed> AdministracionRed { get; set; }
    }
}