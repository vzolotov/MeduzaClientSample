using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MeduzaClient.Database;

namespace MeduzaClient.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("MeduzaClient.Models.Entity.DocumentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("document_type");

                    b.Property<bool>("full");

                    b.Property<int>("modified_at");

                    b.Property<string>("pub_date");

                    b.Property<int>("published_at");

                    b.Property<string>("url");

                    b.Property<int>("version");

                    b.HasKey("Id");

                    b.ToTable("DocumentEntity");
                });
        }
    }
}
