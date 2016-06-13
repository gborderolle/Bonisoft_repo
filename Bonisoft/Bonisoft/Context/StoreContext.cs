using Bonisoft.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bonisoft.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
    }
}