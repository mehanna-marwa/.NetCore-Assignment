using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CateogryID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CateogryID",
                        column: x => x.CateogryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Category 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "category 2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CateogryID", "ImgURL", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "", "product 1", 10.5, 15 },
                    { 2, 1, "", "product 2", 15.0, 35 },
                    { 4, 1, "", "product 4", 300.39999999999998, 30 },
                    { 3, 2, "", "product 3", 150.0, 1 },
                    { 5, 2, "", "product 5", 1000.0, 300 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CateogryID",
                table: "Products",
                column: "CateogryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
