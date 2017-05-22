using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TodoList.DataModel.Context;

namespace TodoList.DataModel.Migrations
{
    [DbContext(typeof(TodoListContext))]
    [Migration("20170514135524_TodoList_InitialMigration")]
    partial class TodoList_InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodoList.DataModel.Models.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Message");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });
        }
    }
}
