using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Covid19Tracking
{
    class CovidDbContext : DbContext
    {
        public DbSet<Citizen> citizens { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Nation> nations { get; set; }
        public DbSet<TestCenter> testCenters { get; set; }
        public DbSet<TestCenterManagement> testCenterManagements { get; set; }
        public DbSet<Municipality> municipalities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source = Covid19.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primary keys

            modelBuilder.Entity<Citizen>()
                .HasKey(C => C.SSN);

            modelBuilder.Entity<Location>()
                .HasKey(L => L.Addr);

            modelBuilder.Entity<Municipality>()
                .HasKey(M => M.MunicipalityID);

            modelBuilder.Entity<Nation>()
                .HasKey(N => N.NationName);

            modelBuilder.Entity<TestCenter>()
                .HasKey(TC => TC.centerName);

            modelBuilder.Entity<TestCenterManagement>()
                .HasKey(TCM => TCM.phoneNum);

            //Municipality relations

            modelBuilder.Entity<Municipality>()
                .HasMany(M => M.citizens)
                .WithOne(C => C.municipality)
                .HasForeignKey(C => C.MunicipalityID);
            modelBuilder.Entity<Municipality>()
                .HasMany(M => M.locations)
                .WithOne(L => L.municipality)
                .HasForeignKey(L => L.MunicipalityID);
            modelBuilder.Entity<Municipality>()
                .HasMany(M => M.testCenters)
                .WithOne(T => T.municipality)
                .HasForeignKey(T => T.MunicipalityID);
            modelBuilder.Entity<Municipality>()
                .HasOne(M => M.nation)
                .WithMany(N => N.municipalities)
                .HasForeignKey(M => M.NationName);

            //TestCenterManagement relations

            modelBuilder.Entity<TestCenterManagement>()
                .HasOne(TCM => TCM.testCenter)
                .WithOne(TC => TC.testCenterManagement)
                .HasForeignKey<TestCenterManagement>(TestID => TestID.centerName);


            // CitizenLocation relations 

            modelBuilder.Entity<CitizenLocation>()
                .HasOne(L => L.location)
                .WithMany(CL => CL.citizenLocations)
                .HasForeignKey(L => L.Addr); 
            modelBuilder.Entity<CitizenLocation>()
                .HasOne(C => C.citizen)
                .WithMany(CCL => CCL.citizenLocations)
                .HasForeignKey(C => C.SSN);

            // Tested At relations

            modelBuilder.Entity<TestedAt>()
                .HasOne(C => C.citizen)
                .WithMany(TA => TA.testedAts)
                .HasForeignKey(C => C.SSN);
            modelBuilder.Entity<TestedAt>()
                .HasOne(TC => TC.testCenter)
                .WithMany(TA2 => TA2.testedAts)
                .HasForeignKey(TC => TC.centerName);
        }
    }
}
