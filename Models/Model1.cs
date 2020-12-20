using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab7WebApi.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Equipments> Equipments { get; set; }
        public virtual DbSet<Naprav> Naprav { get; set; }
        public virtual DbSet<Pacients> Pacients { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
