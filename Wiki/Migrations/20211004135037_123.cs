using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Entity_Framework.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    FechaAlta = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Activa = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuerpos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuerpos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encabezados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encabezados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Orden = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Subtitulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    CuerpoForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entradas_Cuerpos_CuerpoForeignKey",
                        column: x => x.CuerpoForeignKey,
                        principalTable: "Cuerpos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Actvo = table.Column<bool>(nullable: false),
                    CategoriaPrincipalForeignKey = table.Column<int>(nullable: true),
                    CategoriasSecundariaForeignKey = table.Column<int>(nullable: true),
                    AutorForeignKey = table.Column<int>(nullable: true),
                    EncabezadoForeignKey = table.Column<int>(nullable: true),
                    CuerpoForeignKey = table.Column<int>(nullable: true),
                    PalabrasClave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articulos_Autores_AutorForeignKey",
                        column: x => x.AutorForeignKey,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Categorias_CategoriaPrincipalForeignKey",
                        column: x => x.CategoriaPrincipalForeignKey,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Categorias_CategoriasSecundariaForeignKey",
                        column: x => x.CategoriasSecundariaForeignKey,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Cuerpos_CuerpoForeignKey",
                        column: x => x.CuerpoForeignKey,
                        principalTable: "Cuerpos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Encabezados_EncabezadoForeignKey",
                        column: x => x.EncabezadoForeignKey,
                        principalTable: "Encabezados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreRol = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaYHora = table.Column<DateTime>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensajes_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticuloPrincipal = table.Column<string>(nullable: true),
                    ArticuloReferencial = table.Column<string>(nullable: true),
                    ArticuloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencias_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_AutorForeignKey",
                table: "Articulos",
                column: "AutorForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CategoriaPrincipalForeignKey",
                table: "Articulos",
                column: "CategoriaPrincipalForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CategoriasSecundariaForeignKey",
                table: "Articulos",
                column: "CategoriasSecundariaForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CuerpoForeignKey",
                table: "Articulos",
                column: "CuerpoForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_EncabezadoForeignKey",
                table: "Articulos",
                column: "EncabezadoForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_CuerpoForeignKey",
                table: "Entradas",
                column: "CuerpoForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_ArticuloId",
                table: "Mensajes",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencias_ArticuloId",
                table: "Referencias",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_UsuarioId",
                table: "Rol",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Referencias");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Cuerpos");

            migrationBuilder.DropTable(
                name: "Encabezados");
        }
    }
}
