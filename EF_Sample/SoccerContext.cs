﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Sample
{
    class SoccerContext : DbContext
    {
        public SoccerContext()
            : base("DefaultConnection")
        { }

        public DbSet<Player> Players { get; set; }
    }

}
