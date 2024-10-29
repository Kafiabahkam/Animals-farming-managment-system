using Animals_farming_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Animals_farming_managment_system.Data
{
    public class AnimalFarmingDbContext: DbContext
    {
        public AnimalFarmingDbContext(DbContextOptions<AnimalFarmingDbContext> options)
        : base(options)
        {
        }

       
        public DbSet<Animal> Animals { get; set; }
        public DbSet<FeedingSchedule> FeedingSchedules { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Barn> Barns { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // العلاقة بين Animal و FeedingSchedule (One-to-Many)
            modelBuilder.Entity<Animal>()
                .HasMany(a => a.FeedingSchedules)
                .WithOne(fs => fs.Animal)
                .HasForeignKey(fs => fs.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            // يحذف جداول التغذية المرتبطة عند حذف الحيوان

           

            // العلاقة بين Animal و HealthRecord (One-to-Many)
            modelBuilder.Entity<Animal>()
                .HasMany(a => a.HealthRecords)
                .WithOne(hr => hr.Animal)
                .HasForeignKey(hr => hr.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            // يحذف السجلات الصحية المرتبطة عند حذف الحيوان


            // العلاقة بين Barn و Animal (One-to-Many)
            modelBuilder.Entity<Animal>()
                .HasOne(b => b.Barn)
                .WithMany(a => a.Animals)
                .HasForeignKey(a => a.BarnId)
                .OnDelete(DeleteBehavior.Cascade);
            // يحذف الحيوانات المرتبطة عند حذف الحظيرة

         
        }   
    }
}

