using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Disquera.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Disquera.Modelos.Cancion> Canciones { get; set; } = default!;

        public DbSet<Disquera.Modelos.Autor>? Autores { get; set; }
    }
