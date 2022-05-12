using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repunsitory.Shared.Models;

namespace Repunsitory.Server.Data
{
    public class RepunsitoryContext : DbContext
    {
        public RepunsitoryContext (DbContextOptions<RepunsitoryContext> options)
            : base(options)
        {
        }

        public DbSet<Repunsitory.Shared.Models.Pun>? Pun { get; set; }
    }
}
