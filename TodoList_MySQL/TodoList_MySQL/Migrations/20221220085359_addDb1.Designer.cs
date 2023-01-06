﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList_MySQL.Data;

#nullable disable

namespace TodoList_MySQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221220085359_addDb1")]
    partial class addDb1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TodoList_MySQL.Model.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("TodoList_MySQL.Model.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("TodoList_MySQL.Model.TodoGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("TodoGroups");
                });

            modelBuilder.Entity("TodoTodoGroup", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("TodosId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "TodosId");

                    b.HasIndex("TodosId");

                    b.ToTable("TodoTodoGroup");
                });

            modelBuilder.Entity("TodoList_MySQL.Model.Todo", b =>
                {
                    b.HasOne("TodoList_MySQL.Model.Member", "Member")
                        .WithMany("Todos")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TodoList_MySQL.Model.TodoGroup", b =>
                {
                    b.HasOne("TodoList_MySQL.Model.Member", "Member")
                        .WithMany("Groups")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TodoTodoGroup", b =>
                {
                    b.HasOne("TodoList_MySQL.Model.TodoGroup", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoList_MySQL.Model.Todo", null)
                        .WithMany()
                        .HasForeignKey("TodosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TodoList_MySQL.Model.Member", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}