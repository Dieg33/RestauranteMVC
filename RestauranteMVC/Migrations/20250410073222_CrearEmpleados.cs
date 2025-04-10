using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteMVC.Migrations
{
    /// <inheritdoc />
    public partial class CrearEmpleados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    ComboID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImagenURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.ComboID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    MesaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroMesa = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.MesaID);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagos",
                columns: table => new
                {
                    MetodoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagos", x => x.MetodoID);
                });

            migrationBuilder.CreateTable(
                name: "Promociones",
                columns: table => new
                {
                    PromocionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promociones", x => x.PromocionID);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Platos",
                columns: table => new
                {
                    PlatoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagenURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platos", x => x.PlatoID);
                    table.ForeignKey(
                        name: "FK_Platos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaID");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlFotoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleados_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "Menu_Items",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    PlatoID = table.Column<int>(type: "int", nullable: true),
                    ComboID = table.Column<int>(type: "int", nullable: true),
                    PromocionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Items", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_Menu_Items_Combos_ComboID",
                        column: x => x.ComboID,
                        principalTable: "Combos",
                        principalColumn: "ComboID");
                    table.ForeignKey(
                        name: "FK_Menu_Items_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_Items_Platos_PlatoID",
                        column: x => x.PlatoID,
                        principalTable: "Platos",
                        principalColumn: "PlatoID");
                    table.ForeignKey(
                        name: "FK_Menu_Items_Promociones_PromocionID",
                        column: x => x.PromocionID,
                        principalTable: "Promociones",
                        principalColumn: "PromocionID");
                });

            migrationBuilder.CreateTable(
                name: "PlatosCombos",
                columns: table => new
                {
                    ComboID = table.Column<int>(type: "int", nullable: false),
                    PlatoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatosCombos", x => new { x.ComboID, x.PlatoID });
                    table.ForeignKey(
                        name: "FK_PlatosCombos_Combos_ComboID",
                        column: x => x.ComboID,
                        principalTable: "Combos",
                        principalColumn: "ComboID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatosCombos_Platos_PlatoID",
                        column: x => x.PlatoID,
                        principalTable: "Platos",
                        principalColumn: "PlatoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promociones_Items",
                columns: table => new
                {
                    PromocionItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromocionID = table.Column<int>(type: "int", nullable: true),
                    PlatoID = table.Column<int>(type: "int", nullable: true),
                    ComboID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promociones_Items", x => x.PromocionItemId);
                    table.ForeignKey(
                        name: "FK_Promociones_Items_Combos_ComboID",
                        column: x => x.ComboID,
                        principalTable: "Combos",
                        principalColumn: "ComboID");
                    table.ForeignKey(
                        name: "FK_Promociones_Items_Platos_PlatoID",
                        column: x => x.PlatoID,
                        principalTable: "Platos",
                        principalColumn: "PlatoID");
                    table.ForeignKey(
                        name: "FK_Promociones_Items_Promociones_PromocionID",
                        column: x => x.PromocionID,
                        principalTable: "Promociones",
                        principalColumn: "PromocionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolID",
                table: "Empleados",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Items_ComboID",
                table: "Menu_Items",
                column: "ComboID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Items_MenuID",
                table: "Menu_Items",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Items_PlatoID",
                table: "Menu_Items",
                column: "PlatoID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Items_PromocionID",
                table: "Menu_Items",
                column: "PromocionID");

            migrationBuilder.CreateIndex(
                name: "IX_Platos_CategoriaID",
                table: "Platos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatosCombos_PlatoID",
                table: "PlatosCombos",
                column: "PlatoID");

            migrationBuilder.CreateIndex(
                name: "IX_Promociones_Items_ComboID",
                table: "Promociones_Items",
                column: "ComboID");

            migrationBuilder.CreateIndex(
                name: "IX_Promociones_Items_PlatoID",
                table: "Promociones_Items",
                column: "PlatoID");

            migrationBuilder.CreateIndex(
                name: "IX_Promociones_Items_PromocionID",
                table: "Promociones_Items",
                column: "PromocionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Menu_Items");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "MetodoPagos");

            migrationBuilder.DropTable(
                name: "PlatosCombos");

            migrationBuilder.DropTable(
                name: "Promociones_Items");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Platos");

            migrationBuilder.DropTable(
                name: "Promociones");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
