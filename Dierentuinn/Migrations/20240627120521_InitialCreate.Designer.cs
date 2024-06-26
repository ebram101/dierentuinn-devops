﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dierentuinn.Data;

#nullable disable

namespace dierentuinn.Migrations
{
    [DbContext(typeof(DierentuinDbContext))]
    [Migration("20240627120521_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("dierentuinn.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("dierentuinn.Models.CustomSize", b =>
                {
                    b.Property<int>("CustomSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomSizeId");

                    b.ToTable("CustomSizes");
                });

            modelBuilder.Entity("dierentuinn.Models.Dieren", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActivityPattern")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DietaryClass")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnclosureId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SecurityRequirement")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SizeCustomSizeId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("SpaceRequirement")
                        .HasColumnType("REAL");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EnclosureId");

                    b.HasIndex("SizeCustomSizeId");

                    b.ToTable("Dierens");
                });

            modelBuilder.Entity("dierentuinn.Models.Enclosure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HabitatType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Size")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Enclosures");
                });

            modelBuilder.Entity("dierentuinn.Models.Dieren", b =>
                {
                    b.HasOne("dierentuinn.Models.Category", "Category")
                        .WithMany("Dierens")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dierentuinn.Models.Enclosure", "Enclosure")
                        .WithMany("Dierens")
                        .HasForeignKey("EnclosureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dierentuinn.Models.CustomSize", "Size")
                        .WithMany()
                        .HasForeignKey("SizeCustomSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Enclosure");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("dierentuinn.Models.Category", b =>
                {
                    b.Navigation("Dierens");
                });

            modelBuilder.Entity("dierentuinn.Models.Enclosure", b =>
                {
                    b.Navigation("Dierens");
                });
#pragma warning restore 612, 618
        }
    }
}
