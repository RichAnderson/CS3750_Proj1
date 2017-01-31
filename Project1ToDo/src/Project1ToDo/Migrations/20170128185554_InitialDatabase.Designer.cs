using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Project1ToDo.Models;

namespace Project1ToDo.Migrations
{
    [DbContext(typeof(ListContext))]
    [Migration("20170128185554_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project1ToDo.Models.Categorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("categoryID");

                    b.Property<int>("listID");

                    b.HasKey("Id");

                    b.HasIndex("categoryID");

                    b.HasIndex("listID");

                    b.ToTable("Categorization");
                });

            modelBuilder.Entity("Project1ToDo.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("categoryName");

                    b.Property<DateTime>("creationDate");

                    b.Property<bool>("deleted");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Project1ToDo.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ListId");

                    b.Property<bool>("completed");

                    b.Property<DateTime>("dateCompleted");

                    b.Property<DateTime>("dateCreated");

                    b.Property<bool>("deleted");

                    b.Property<string>("itemName");

                    b.Property<int>("order");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Project1ToDo.Models.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dateCreated");

                    b.Property<bool>("deleted");

                    b.Property<string>("listName");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("Project1ToDo.Models.Categorization", b =>
                {
                    b.HasOne("Project1ToDo.Models.Category", "Category")
                        .WithMany("Categorizations")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project1ToDo.Models.List", "List")
                        .WithMany("Categorizations")
                        .HasForeignKey("listID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project1ToDo.Models.Item", b =>
                {
                    b.HasOne("Project1ToDo.Models.List")
                        .WithMany("Items")
                        .HasForeignKey("ListId");
                });
        }
    }
}
