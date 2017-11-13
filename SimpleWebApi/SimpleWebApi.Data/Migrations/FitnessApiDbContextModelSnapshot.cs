﻿// <auto-generated />
namespace SimpleWebApi.Data.Migrations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using SimpleWebApi.Data;

    [DbContext(typeof(FitnessApiDbContext))]
    partial class FitnessApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleWebApi.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Fats");

                    b.Property<double>("FatsContent");

                    b.Property<string>("Name");

                    b.Property<double>("ProteinContent");

                    b.Property<double>("SugarContent");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}