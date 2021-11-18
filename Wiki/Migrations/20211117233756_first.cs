using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Entity_Framework.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Id = table.Column<Guid>(nullable: false),
                    User = table.Column<string>(maxLength: 20, nullable: true),
                    Contraseña = table.Column<byte[]>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    Apellido = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FechaAlta = table.Column<DateTime>(nullable: true)
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
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Activa = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    ArticuloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Actvo = table.Column<bool>(nullable: false),
                    CategoriaPrincipalId = table.Column<Guid>(nullable: false),
                    AutorForeignKey = table.Column<Guid>(nullable: true),
                    EncabezadoForeignKey = table.Column<int>(nullable: true),
                    CuerpoForeignKey = table.Column<int>(nullable: true),
                    PalabrasClave = table.Column<string>(nullable: true),
                    AutorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articulos_Usuarios_AutorForeignKey",
                        column: x => x.AutorForeignKey,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Usuarios_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Categorias_CategoriaPrincipalId",
                        column: x => x.CategoriaPrincipalId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Articulos_AutorId",
                table: "Articulos",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CategoriaPrincipalId",
                table: "Articulos",
                column: "CategoriaPrincipalId");

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
                name: "IX_Categorias_ArticuloId",
                table: "Categorias",
                column: "ArticuloId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Articulos_ArticuloId",
                table: "Categorias",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Usuarios_AutorForeignKey",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Usuarios_AutorId",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Categorias_CategoriaPrincipalId",
                table: "Articulos");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Referencias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Cuerpos");

            migrationBuilder.DropTable(
                name: "Encabezados");
        }
    }
}
