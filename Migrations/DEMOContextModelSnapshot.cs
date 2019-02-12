﻿// <auto-generated />
using System;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatingApp.API.Migrations
{
    [DbContext(typeof(DEMOContext))]
    partial class DEMOContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatingApp.API.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Age")
                        .IsUnique()
                        .HasFilter("[Age] IS NOT NULL");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DatingApp.API.Models.ExaltUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("User_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Created")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<DateTime>("DateOfBirth")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Interests");

                    b.Property<string>("Introduction");

                    b.Property<string>("KnownAs")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("LastActive")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("LookingFor");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("UserId")
                        .HasName("PK__ExaltUse__206A9DF813C34DB9");

                    b.ToTable("ExaltUser");
                });

            modelBuilder.Entity("DatingApp.API.Models.Like", b =>
                {
                    b.Property<int>("LikerId");

                    b.Property<int>("LikeeId");

                    b.HasKey("LikerId", "LikeeId");

                    b.HasIndex("LikeeId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("DatingApp.API.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Photo_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateAdded")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<bool>("IsMain")
                        .HasColumnName("isMain");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasMaxLength(1000);

                    b.Property<int?>("UserId")
                        .HasColumnName("User_id");

                    b.HasKey("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("DatingApp.API.Models.TblUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Tbl_User");
                });

            modelBuilder.Entity("DatingApp.API.Models.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(1000);

                    b.Property<string>("PasswordSalt")
                        .HasMaxLength(1000);

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DatingApp.API.Models.Like", b =>
                {
                    b.HasOne("DatingApp.API.Models.ExaltUser", "Likee")
                        .WithMany("Likers")
                        .HasForeignKey("LikeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatingApp.API.Models.ExaltUser", "Liker")
                        .WithMany("Likees")
                        .HasForeignKey("LikerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatingApp.API.Models.Photo", b =>
                {
                    b.HasOne("DatingApp.API.Models.ExaltUser", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Photo__User_id__49C3F6B7");
                });
#pragma warning restore 612, 618
        }
    }
}