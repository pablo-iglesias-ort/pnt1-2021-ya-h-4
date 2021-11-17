﻿// <auto-generated />
using System;
using MVC_Entity_Framework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC_Entity_Framework.Migrations
{
    [DbContext(typeof(MVC_Entity_FrameworkContext))]
    [Migration("20211115040359_nueva")]
    partial class nueva
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18");

            modelBuilder.Entity("MVC_Entity_Framework.Models.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Actvo")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("AutorForeignKey")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoriaPrincipalId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CuerpoForeignKey")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EncabezadoForeignKey")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("PalabrasClave")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AutorForeignKey");

                    b.HasIndex("CategoriaPrincipalId");

                    b.HasIndex("CuerpoForeignKey")
                        .IsUnique();

                    b.HasIndex("EncabezadoForeignKey")
                        .IsUnique();

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Activa")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Cuerpo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cuerpos");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Encabezado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Encabezados");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CuerpoForeignKey")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Orden")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subtitulo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Texto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CuerpoForeignKey");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Mensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaYHora")
                        .HasColumnType("TEXT");

                    b.Property<string>("Texto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Referencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArticuloPrincipal")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArticuloReferencial")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.ToTable("Referencias");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(80);

                    b.Property<byte[]>("Contraseña")
                        .HasColumnType("BLOB");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(80);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("User")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Admin", b =>
                {
                    b.HasBaseType("MVC_Entity_Framework.Models.Usuario");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Autor", b =>
                {
                    b.HasBaseType("MVC_Entity_Framework.Models.Usuario");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Autor");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.User", b =>
                {
                    b.HasBaseType("MVC_Entity_Framework.Models.Usuario");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Articulo", b =>
                {
                    b.HasOne("MVC_Entity_Framework.Models.Autor", "Autor")
                        .WithMany("Articulos")
                        .HasForeignKey("AutorForeignKey");

                    b.HasOne("MVC_Entity_Framework.Models.Categoria", "CategoriaPrincipal")
                        .WithMany()
                        .HasForeignKey("CategoriaPrincipalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Entity_Framework.Models.Cuerpo", "Cuerpo")
                        .WithOne("Articulo")
                        .HasForeignKey("MVC_Entity_Framework.Models.Articulo", "CuerpoForeignKey");

                    b.HasOne("MVC_Entity_Framework.Models.Encabezado", "Encabezado")
                        .WithOne("Articulo")
                        .HasForeignKey("MVC_Entity_Framework.Models.Articulo", "EncabezadoForeignKey");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Categoria", b =>
                {
                    b.HasOne("MVC_Entity_Framework.Models.Articulo", null)
                        .WithMany("CategoriasSecundaria")
                        .HasForeignKey("ArticuloId");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Entrada", b =>
                {
                    b.HasOne("MVC_Entity_Framework.Models.Cuerpo", "Cuerpo")
                        .WithMany("Entradas")
                        .HasForeignKey("CuerpoForeignKey");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Mensaje", b =>
                {
                    b.HasOne("MVC_Entity_Framework.Models.Articulo", "Articulo")
                        .WithMany("Mensajes")
                        .HasForeignKey("ArticuloId");
                });

            modelBuilder.Entity("MVC_Entity_Framework.Models.Referencia", b =>
                {
                    b.HasOne("MVC_Entity_Framework.Models.Articulo", null)
                        .WithMany("Referencias")
                        .HasForeignKey("ArticuloId");
                });
#pragma warning restore 612, 618
        }
    }
}