﻿// <auto-generated />
using JeuDontOnEstLeHeros.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JeuDontOnEstLeHeros.Core.Data.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20210106125823_EstInitialParagrapheV2")]
    partial class EstInitialParagrapheV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("JeuDontOnEstLeHeros.Core.Data.Models.Aventure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aventure");
                });

            modelBuilder.Entity("JeuDontOnEstLeHeros.Core.Data.Models.Paragraphe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstInitial")
                        .HasColumnType("bit");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paragraphe");
                });

            modelBuilder.Entity("JeuDontOnEstLeHeros.Core.Data.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ParagrapheId")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParagrapheId")
                        .IsUnique();

                    b.ToTable("Question");
                });

            modelBuilder.Entity("JeuDontOnEstLeHeros.Core.Data.Models.Reponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParagrapheId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParagrapheId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Proposition");
                });

            modelBuilder.Entity("JeuDontOnEstLeHeros.Core.Data.Models.Question", b =>
                {
                    b.HasOne("JeuDontOnEstLeHeros.Core.Data.Models.Paragraphe", null)
                        .WithOne("MaQuestion")
                        .HasForeignKey("JeuDontOnEstLeHeros.Core.Data.Models.Question", "ParagrapheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JeuDontOnEstLeHeros.Core.Data.Models.Reponse", b =>
                {
                    b.HasOne("JeuDontOnEstLeHeros.Core.Data.Models.Paragraphe", null)
                        .WithMany("Reponses")
                        .HasForeignKey("ParagrapheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JeuDontOnEstLeHeros.Core.Data.Models.Question", null)
                        .WithMany("MesReponses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JeuDontOnEstLeHeros.Core.Data.Models.Paragraphe", b =>
                {
                    b.Navigation("MaQuestion");

                    b.Navigation("Reponses");
                });

            modelBuilder.Entity("JeuDontOnEstLeHeros.Core.Data.Models.Question", b =>
                {
                    b.Navigation("MesReponses");
                });
#pragma warning restore 612, 618
        }
    }
}
