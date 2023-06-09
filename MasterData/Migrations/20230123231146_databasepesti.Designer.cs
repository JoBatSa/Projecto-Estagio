﻿// <auto-generated />
using System;
using DDDSample1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DDDNetCore.Migrations
{
    [DbContext(typeof(DDDSample1DbContext))]
    [Migration("20230123231146_databasepesti")]
    partial class databasepesti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DDDSample1.Domain.Administrators.Administrator", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("DDDSample1.Domain.Customers.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nif")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DDDSample1.Domain.Employees.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkAuthorizationId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkAuthorizationId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DDDSample1.Domain.Logins.Login", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("DDDSample1.Domain.Reports.Report", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NokParts")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OkParts")
                        .HasColumnType("int");

                    b.Property<string>("PartNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkOrder")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("DDDSample1.Domain.VisualAids.VisualAid", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkOrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VisualAids");
                });

            modelBuilder.Entity("DDDSample1.Domain.WorkAuthorizations.WorkAuthorization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BeginWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("VisualAidNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkOrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkAuthorizations");
                });

            modelBuilder.Entity("DDDSample1.Domain.WorkOrders.WorkOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BeginWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndWork")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("DDDSample1.Domain.Administrators.Administrator", b =>
                {
                    b.OwnsOne("MasterData.Domain.ValueObjects.Job_PositionType", "AdminP", b1 =>
                        {
                            b1.Property<string>("AdministratorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("job_Position")
                                .HasColumnType("int");

                            b1.HasKey("AdministratorId");

                            b1.ToTable("Administrators");

                            b1.WithOwner()
                                .HasForeignKey("AdministratorId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.Password", "password", b1 =>
                        {
                            b1.Property<string>("AdministratorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("texto")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AdministratorId");

                            b1.ToTable("Administrators");

                            b1.WithOwner()
                                .HasForeignKey("AdministratorId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.User", "user", b1 =>
                        {
                            b1.Property<string>("AdministratorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("user")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AdministratorId");

                            b1.ToTable("Administrators");

                            b1.WithOwner()
                                .HasForeignKey("AdministratorId");
                        });

                    b.Navigation("AdminP");

                    b.Navigation("password");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DDDSample1.Domain.Customers.Customer", b =>
                {
                    b.OwnsOne("MasterData.Domain.ValueObjects.EmailType", "CustomerEmail", b1 =>
                        {
                            b1.Property<string>("CustomerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("CustomerId");

                            b1.HasIndex("Email")
                                .IsUnique()
                                .HasFilter("[CustomerEmail_Email] IS NOT NULL");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.Job_PositionType", "CustPosition", b1 =>
                        {
                            b1.Property<string>("CustomerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("job_Position")
                                .HasColumnType("int");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.PhoneNumberType", "CustomerPhoneNumber", b1 =>
                        {
                            b1.Property<string>("CustomerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("CustomerEmail");

                    b.Navigation("CustomerPhoneNumber");

                    b.Navigation("CustPosition");
                });

            modelBuilder.Entity("DDDSample1.Domain.Employees.Employee", b =>
                {
                    b.HasOne("DDDSample1.Domain.WorkAuthorizations.WorkAuthorization", null)
                        .WithMany("EmployeeId")
                        .HasForeignKey("WorkAuthorizationId");

                    b.OwnsOne("MasterData.Domain.ValueObjects.EmailType", "UserEmail", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("EmployeeId");

                            b1.HasIndex("Email")
                                .IsUnique()
                                .HasFilter("[UserEmail_Email] IS NOT NULL");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.Job_PositionType", "Job_Position", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("job_Position")
                                .HasColumnType("int");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.PhoneNumberType", "UserPhoneNumber", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Job_Position");

                    b.Navigation("UserEmail");

                    b.Navigation("UserPhoneNumber");
                });

            modelBuilder.Entity("DDDSample1.Domain.Logins.Login", b =>
                {
                    b.OwnsOne("MasterData.Domain.ValueObjects.Data", "Date", b1 =>
                        {
                            b1.Property<string>("LoginId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("data")
                                .HasColumnType("datetime2");

                            b1.HasKey("LoginId");

                            b1.ToTable("Logins");

                            b1.WithOwner()
                                .HasForeignKey("LoginId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.Job_PositionType", "tipo", b1 =>
                        {
                            b1.Property<string>("LoginId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("job_Position")
                                .HasColumnType("int");

                            b1.HasKey("LoginId");

                            b1.ToTable("Logins");

                            b1.WithOwner()
                                .HasForeignKey("LoginId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.Text", "Name", b1 =>
                        {
                            b1.Property<string>("LoginId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("text")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LoginId");

                            b1.ToTable("Logins");

                            b1.WithOwner()
                                .HasForeignKey("LoginId");
                        });

                    b.OwnsOne("MasterData.Domain.ValueObjects.User", "User", b1 =>
                        {
                            b1.Property<string>("LoginId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("user")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LoginId");

                            b1.ToTable("Logins");

                            b1.WithOwner()
                                .HasForeignKey("LoginId");
                        });

                    b.Navigation("Date");

                    b.Navigation("Name");

                    b.Navigation("tipo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DDDSample1.Domain.WorkAuthorizations.WorkAuthorization", b =>
                {
                    b.OwnsMany("MasterData.Domain.ValueObjects.ListOfString", "EmployeeNumber", b1 =>
                        {
                            b1.Property<string>("WorkAuthorizationId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("frase")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WorkAuthorizationId", "Id");

                            b1.ToTable("ListOfString");

                            b1.WithOwner()
                                .HasForeignKey("WorkAuthorizationId");
                        });

                    b.Navigation("EmployeeNumber");
                });

            modelBuilder.Entity("DDDSample1.Domain.WorkAuthorizations.WorkAuthorization", b =>
                {
                    b.Navigation("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
