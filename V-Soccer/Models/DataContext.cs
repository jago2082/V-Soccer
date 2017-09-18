using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace V_Soccer.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<Domain.City> Cities { get; set; }

        public System.Data.Entity.DbSet<Domain.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<Domain.Gener> Geners { get; set; }

        public System.Data.Entity.DbSet<Domain.Player> Players { get; set; }

        public System.Data.Entity.DbSet<Domain.Match> Matches { get; set; }

        public System.Data.Entity.DbSet<Domain.Status> Status { get; set; }

        public System.Data.Entity.DbSet<Domain.PlayerTeam> PlayerTeams { get; set; }

        public System.Data.Entity.DbSet<Domain.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<Domain.Department> Departments { get; set; }
    }
}