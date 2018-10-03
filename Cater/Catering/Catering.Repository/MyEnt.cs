using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Domain;

namespace Catering.Repository
{
    public class MyEnt : DbContext
    {
        public MyEnt()
           : base("CateringContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            InsertListener();
            UpdateListener();
            DeleteListener();
            return base.SaveChanges();
        }

        private void InsertListener()
        {
            foreach (var entity in ChangeTracker.Entries<BaseDomain>().Where(x => x.State == EntityState.Added).ToList())
            {
                entity.Entity.CreateDate = DateTime.Now;
                entity.Entity.UpdateDate = DateTime.Now;
                entity.Entity.IsActive = true;
                entity.Entity.IsDeleted = false;
            }
        }

        private void UpdateListener()
        {
            foreach (
                var entity in ChangeTracker.Entries<BaseDomain>().Where(x => x.State == EntityState.Modified).ToList())
            {
                entity.Entity.UpdateDate = DateTime.Now;
            }
        }

        private void DeleteListener()
        {
            foreach (
                var entity in ChangeTracker.Entries<BaseDomain>().Where(x => x.State == EntityState.Deleted).ToList())
            {
                entity.Entity.IsDeleted = true;
                entity.Entity.UpdateDate = DateTime.Now;
                entity.State = EntityState.Modified;
            }
        }

       
        public DbSet<Iletisim> Iletisim{ get; set; }
        public DbSet<Biletler> Biletler { get; set; }
        public DbSet<Gallery> Galeri{ get; set; }
    }
}
