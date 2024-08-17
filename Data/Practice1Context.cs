using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice1.Models;

namespace Practice1.Data
{
    public class Practice1Context : DbContext
    {
        public Practice1Context (DbContextOptions<Practice1Context> options)
            : base(options)
        {
        }

        public DbSet<Practice1.Models.Randoms> Randoms { get; set; } = default!;
    }
}
