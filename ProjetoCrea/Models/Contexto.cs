using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetoCrea.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Empregado> Empregados { get; set; }
    }
}