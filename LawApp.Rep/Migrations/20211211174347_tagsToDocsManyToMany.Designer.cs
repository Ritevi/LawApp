﻿// <auto-generated />
using System;
using LawApp.Rep.SqlContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using AppContext = LawApp.Rep.SqlContext.AppContext;

namespace LawApp.Rep.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211211174347_tagsToDocsManyToMany")]
    partial class tagsToDocsManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DocTag", b =>
                {
                    b.Property<Guid>("DocsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uuid");

                    b.HasKey("DocsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("DocTag");
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Doc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Docs");
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CategoryNumber")
                        .HasColumnType("integer");

                    b.Property<Guid?>("PreviousAnswerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PreviousAnswerId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AnswerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DocTag", b =>
                {
                    b.HasOne("LawApp.Common.Models.Domain.Doc", null)
                        .WithMany()
                        .HasForeignKey("DocsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawApp.Common.Models.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Answer", b =>
                {
                    b.HasOne("LawApp.Common.Models.Domain.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Question", b =>
                {
                    b.HasOne("LawApp.Common.Models.Domain.Answer", "PreviousAnswer")
                        .WithMany("NextQuestions")
                        .HasForeignKey("PreviousAnswerId");

                    b.Navigation("PreviousAnswer");
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Tag", b =>
                {
                    b.HasOne("LawApp.Common.Models.Domain.Answer", null)
                        .WithMany("Tags")
                        .HasForeignKey("AnswerId");

                    b.HasOne("LawApp.Common.Models.Domain.Question", null)
                        .WithMany("Tags")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Answer", b =>
                {
                    b.Navigation("NextQuestions");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("LawApp.Common.Models.Domain.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
