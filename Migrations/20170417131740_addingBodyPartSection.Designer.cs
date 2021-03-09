using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Defult.Models;

namespace Defult.Migrations
{
    [DbContext(typeof(Data))]
    [Migration("20170417131740_addingBodyPartSection")]
    partial class addingBodyPartSection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Defult.Models.BodyPartSection", b =>
                {
                    b.Property<int>("BPartId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BPartName");

                    b.HasKey("BPartId");

                    b.ToTable("BodyPartSection");
                });

            modelBuilder.Entity("Defult.Models.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiseaseName");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("Defult.Models.Excercise", b =>
                {
                    b.Property<int>("ExId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExBodyPart");

                    b.Property<string>("ExDesc");

                    b.Property<string>("ExDuration");

                    b.Property<string>("ExEquip");

                    b.Property<string>("ExName");

                    b.Property<string>("ExSkill");

                    b.Property<string>("ExStepOne");

                    b.Property<string>("ExStepTwo");

                    b.Property<string>("ExType");

                    b.Property<string>("ExVideo");

                    b.HasKey("ExId");

                    b.ToTable("Excercises");
                });

            modelBuilder.Entity("Defult.Models.ExcerciseBPart", b =>
                {
                    b.Property<int>("ExcerBodyPart")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EBP_BPartId");

                    b.Property<int>("EBP_ExId");

                    b.HasKey("ExcerBodyPart");

                    b.ToTable("ExcerciseBPart");
                });

            modelBuilder.Entity("Defult.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Fcalore");

                    b.Property<double>("Fcarb");

                    b.Property<double>("Ffat");

                    b.Property<string>("Foodname");

                    b.Property<double>("Fproten");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Defult.Models.Program_Workouts", b =>
                {
                    b.Property<int>("PW_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PW_PId");

                    b.Property<int>("PW_WId");

                    b.Property<int>("P_Day");

                    b.HasKey("PW_Id");

                    b.ToTable("Program_Workout");
                });

            modelBuilder.Entity("Defult.Models.Programs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("P_Area");

                    b.Property<string>("P_Level");

                    b.Property<string>("P_Type");

                    b.Property<string>("P_name");

                    b.HasKey("Id");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Defult.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("Calories");

                    b.Property<int>("Carb");

                    b.Property<int>("DiseaseId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Fat");

                    b.Property<bool>("Gender");

                    b.Property<int>("GoalWieght");

                    b.Property<float>("Height");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Password");

                    b.Property<int>("ProgramsId");

                    b.Property<int>("Protin");

                    b.Property<int>("Repassword");

                    b.Property<DateTime>("Startdate");

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.HasIndex("ProgramsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Defult.Models.Workout", b =>
                {
                    b.Property<int>("Wid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("WArea");

                    b.Property<string>("WLevel");

                    b.Property<string>("WName");

                    b.Property<string>("WType");

                    b.HasKey("Wid");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("Defult.Models.Workout_Excercises", b =>
                {
                    b.Property<int>("WE_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("WE_ExId");

                    b.Property<int>("WE_WId");

                    b.HasKey("WE_id");

                    b.ToTable("Workout_Excercise");
                });

            modelBuilder.Entity("Defult.Models.User", b =>
                {
                    b.HasOne("Defult.Models.Disease", "Disease")
                        .WithMany()
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Defult.Models.Programs", "Programs")
                        .WithMany()
                        .HasForeignKey("ProgramsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
