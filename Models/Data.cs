using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Defult.Models
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { set; get; }
        public DbSet<Programs> Programs { set; get; }
        public DbSet<Food> Foods { set; get; }
        public DbSet<Excercise> Excercises { set; get; }
        public DbSet<Program_Workouts> Program_Workout { set; get; }
        public DbSet<Workout> Workout { set; get; }
        public DbSet<Workout_Excercises> Workout_Excercise { set; get; }
        public DbSet<BodyPartSection> BodyPartSection { set; get; }
        public DbSet<Completed_Workouts> Completed_Workouts { set; get; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Programs>().ToTable("Programs");
            modelBuilder.Entity<Food>().ToTable("Foods");
            modelBuilder.Entity<Excercise>().ToTable("Excercises");
            modelBuilder.Entity<Program_Workouts>().ToTable("Program_Workout");
            modelBuilder.Entity<Workout>().ToTable("Workout");
            modelBuilder.Entity<Workout_Excercises>().ToTable("Workout_Excercise");
            modelBuilder.Entity<BodyPartSection>().ToTable("BodyPartSection");
            modelBuilder.Entity<Completed_Workouts>().ToTable("Completed_Workouts");
     
        }
    }
}