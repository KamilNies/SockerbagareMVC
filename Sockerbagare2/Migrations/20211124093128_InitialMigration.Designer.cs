// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sockerbagare2.Context;

namespace Sockerbagare2.Migrations
{
    [DbContext(typeof(Sockerbagare2Context))]
    [Migration("20211124093128_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Sockerbagare2.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IngredientName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Sockerbagare2.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProviderName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Sockerbagare2.Models.RecievedOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BatchNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BestBeforeDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("DeliveryNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IngredientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ManufacturingDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProviderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("QuantityKg")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("RecievingDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ProviderId");

                    b.ToTable("RecievedOrders");
                });

            modelBuilder.Entity("Sockerbagare2.Models.RecievedOrder", b =>
                {
                    b.HasOne("Sockerbagare2.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sockerbagare2.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Provider");
                });
#pragma warning restore 612, 618
        }
    }
}
