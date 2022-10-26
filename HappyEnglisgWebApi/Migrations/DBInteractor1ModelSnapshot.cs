﻿// <auto-generated />
using HappyEnglisgWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HappyEnglisgWebApi.Migrations
{
    [DbContext(typeof(DBInteractor1))]
    partial class DBInteractor1ModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("HappyEnglisgWebApi.Model.Gamer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gamer");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Age = 321,
                            FirstName = "Anton1",
                            LastName = "Lukyantsev1"
                        });
                });

            modelBuilder.Entity("HappyEnglisgWebApi.Model.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Word");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Value = "Anton"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
