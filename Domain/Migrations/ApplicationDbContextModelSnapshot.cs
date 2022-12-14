﻿// <auto-generated />
using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Abu Dhabi"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Dubai"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Sharjah"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 1,
                            Name = "Ras Al Khaimah"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 1,
                            Name = "Ajman"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 1,
                            Name = "Umm Al Quwain"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 1,
                            Name = "Fujairah"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CoachClass", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AvailableSpaces")
                        .HasColumnType("int");

                    b.Property<DateTime>("ClassFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ClassTo")
                        .HasColumnType("datetime2");

                    b.Property<long>("CoachId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("CoachClasses");
                });

            modelBuilder.Entity("Domain.Entities.CoachMember", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CoachId")
                        .HasColumnType("bigint");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("MemberId");

                    b.ToTable("CoachMember");
                });

            modelBuilder.Entity("Domain.Entities.CoachType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CoachTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gym Instructor"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bootcamp Instructor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Crossfit Instructor"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Group Exercise Instructor"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mobile Personal Trainer"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Physique Trainer"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Performance Personal Trainer"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Lifestyle Personal Trainer"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sports Trainer"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Health Coach"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Cardio Trainer"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CoachesTypes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CoachId")
                        .HasColumnType("bigint");

                    b.Property<int>("CoachTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("CoachTypeId");

                    b.ToTable("CoachesTypes");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "United Arab Emirates"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("CityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenderId");

                    b.HasIndex("Email", "UserTypeId")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<int>("UserTypeId");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Coach", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Domain.Entities.Member", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.CoachClass", b =>
                {
                    b.HasOne("Domain.Entities.Coach", "Coach")
                        .WithMany("CoachClasses")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Domain.Entities.CoachMember", b =>
                {
                    b.HasOne("Domain.Entities.Coach", "Coach")
                        .WithMany("CoachMember")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Member", "Member")
                        .WithMany("CoachMember")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Domain.Entities.CoachesTypes", b =>
                {
                    b.HasOne("Domain.Entities.Coach", "Coach")
                        .WithMany("CoachesTypes")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CoachType", "CoachType")
                        .WithMany("CoachesTypes")
                        .HasForeignKey("CoachTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("CoachType");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Domain.Entities.CoachType", b =>
                {
                    b.Navigation("CoachesTypes");
                });

            modelBuilder.Entity("Domain.Entities.Coach", b =>
                {
                    b.Navigation("CoachClasses");

                    b.Navigation("CoachMember");

                    b.Navigation("CoachesTypes");
                });

            modelBuilder.Entity("Domain.Entities.Member", b =>
                {
                    b.Navigation("CoachMember");
                });
#pragma warning restore 612, 618
        }
    }
}
