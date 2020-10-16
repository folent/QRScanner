using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QRcodeGenerate.Models
{
    public class TasksContext : DbContext
    {
        
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TechnologyModel> Technologys { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<UnderLocationModel> UnderLocations { get; set; }
        public DbSet<MachineModel> Machine { get; set; }
        public DbSet<OperationModel> Operations { get; set; }
        public DbSet<GeneralOperationModel> GeneralOperations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TasksContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}