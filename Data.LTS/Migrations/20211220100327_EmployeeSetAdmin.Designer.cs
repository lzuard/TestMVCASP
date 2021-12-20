﻿// <auto-generated />
using System;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.LTS.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211220100327_EmployeeSetAdmin")]
    partial class EmployeeSetAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Contracts.Contracts.Address.AddressDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Building")
                        .HasColumnType("text");

                    b.Property<string>("House")
                        .HasColumnType("text");

                    b.Property<string>("Housing")
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Room")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Contracts.Contracts.Agent.AgentDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("CheckingAccount")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("IndividualTaxpayerNumber")
                        .HasColumnType("text");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int?>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("TypeId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Contracts.Contracts.AgentType.AgentTypeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AgentTypes");
                });

            modelBuilder.Entity("Contracts.Contracts.Category.CategoryDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Contracts.Contracts.Employee.EmployeeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsFired")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.Property<string>("ThirdName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Contracts.Contracts.Order.OrderDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Extra")
                        .HasColumnType("text");

                    b.Property<bool>("IsAcceptClient")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAcceptTransportCompany")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentDocument")
                        .HasColumnType("text");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("TransportCompanyId")
                        .HasColumnType("integer");

                    b.Property<int?>("TtnId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TransportCompanyId");

                    b.HasIndex("TtnId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Contracts.Contracts.Product.ProductDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Art")
                        .HasColumnType("integer");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<bool>("IsDiscount")
                        .HasColumnType("boolean");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("Manufacture")
                        .HasColumnType("text");

                    b.Property<int>("MinimalOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PackageNumber")
                        .HasColumnType("integer");

                    b.Property<int>("PackageType")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Contracts.Contracts.ProductOrder.ProductOrderDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("Contracts.Contracts.ProductSupply.ProductSupplyDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("SupplyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplyId");

                    b.ToTable("ProductSupplies");
                });

            modelBuilder.Entity("Contracts.Contracts.ProductUtil.ProductUtilDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<int?>("UtilizationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UtilizationId");

                    b.ToTable("ProductUtils");
                });

            modelBuilder.Entity("Contracts.Contracts.Return.ReturnDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("ReturnAct")
                        .HasColumnType("text");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TtnId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderId");

                    b.HasIndex("TtnId");

                    b.ToTable("Returns");
                });

            modelBuilder.Entity("Contracts.Contracts.Supply.SupplyDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Extra")
                        .HasColumnType("text");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<string>("PaymentDocument")
                        .HasColumnType("text");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SupplyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TransportCompanyId")
                        .HasColumnType("integer");

                    b.Property<int?>("TtnId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("TransportCompanyId");

                    b.HasIndex("TtnId");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("Contracts.Contracts.Ttn.TtnDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Form")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Ttns");
                });

            modelBuilder.Entity("Contracts.Contracts.Utilization.UtilizationDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TtnId")
                        .HasColumnType("integer");

                    b.Property<string>("UtilizationAct")
                        .HasColumnType("text");

                    b.Property<int?>("UtilizerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TtnId");

                    b.HasIndex("UtilizerId");

                    b.ToTable("Utilizations");
                });

            modelBuilder.Entity("Contracts.Contracts.Agent.AgentDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Address.AddressDto", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Contracts.Contracts.AgentType.AgentTypeDto", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Address");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Contracts.Contracts.Category.CategoryDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Category.CategoryDto", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Contracts.Contracts.Order.OrderDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Address.AddressDto", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Contracts.Contracts.Agent.AgentDto", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Contracts.Contracts.Employee.EmployeeDto", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Contracts.Contracts.Agent.AgentDto", "TransportCompany")
                        .WithMany()
                        .HasForeignKey("TransportCompanyId");

                    b.HasOne("Contracts.Contracts.Ttn.TtnDto", "Ttn")
                        .WithMany()
                        .HasForeignKey("TtnId");

                    b.Navigation("Address");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("TransportCompany");

                    b.Navigation("Ttn");
                });

            modelBuilder.Entity("Contracts.Contracts.Product.ProductDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Category.CategoryDto", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Contracts.Contracts.ProductOrder.ProductOrderDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Order.OrderDto", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("Contracts.Contracts.Product.ProductDto", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Contracts.Contracts.ProductSupply.ProductSupplyDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Product.ProductDto", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Contracts.Contracts.Supply.SupplyDto", "Supply")
                        .WithMany()
                        .HasForeignKey("SupplyId");

                    b.Navigation("Product");

                    b.Navigation("Supply");
                });

            modelBuilder.Entity("Contracts.Contracts.ProductUtil.ProductUtilDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Employee.EmployeeDto", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Contracts.Contracts.Product.ProductDto", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Contracts.Contracts.Utilization.UtilizationDto", "Utilization")
                        .WithMany()
                        .HasForeignKey("UtilizationId");

                    b.Navigation("Employee");

                    b.Navigation("Product");

                    b.Navigation("Utilization");
                });

            modelBuilder.Entity("Contracts.Contracts.Return.ReturnDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Employee.EmployeeDto", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Contracts.Contracts.Order.OrderDto", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("Contracts.Contracts.Ttn.TtnDto", "Ttn")
                        .WithMany()
                        .HasForeignKey("TtnId");

                    b.Navigation("Employee");

                    b.Navigation("Order");

                    b.Navigation("Ttn");
                });

            modelBuilder.Entity("Contracts.Contracts.Supply.SupplyDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Employee.EmployeeDto", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Contracts.Contracts.Agent.AgentDto", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.HasOne("Contracts.Contracts.Agent.AgentDto", "TransportCompany")
                        .WithMany()
                        .HasForeignKey("TransportCompanyId");

                    b.HasOne("Contracts.Contracts.Ttn.TtnDto", "Ttn")
                        .WithMany()
                        .HasForeignKey("TtnId");

                    b.Navigation("Employee");

                    b.Navigation("Supplier");

                    b.Navigation("TransportCompany");

                    b.Navigation("Ttn");
                });

            modelBuilder.Entity("Contracts.Contracts.Utilization.UtilizationDto", b =>
                {
                    b.HasOne("Contracts.Contracts.Employee.EmployeeDto", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Contracts.Contracts.Ttn.TtnDto", "Ttn")
                        .WithMany()
                        .HasForeignKey("TtnId");

                    b.HasOne("Contracts.Contracts.Agent.AgentDto", "Utilizer")
                        .WithMany()
                        .HasForeignKey("UtilizerId");

                    b.Navigation("Employee");

                    b.Navigation("Ttn");

                    b.Navigation("Utilizer");
                });
#pragma warning restore 612, 618
        }
    }
}
