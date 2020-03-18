using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManager.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    cartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    totalPrice = table.Column<decimal>(nullable: false),
                    userID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.cartID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(nullable: false),
                    userPassword = table.Column<string>(nullable: false),
                    userImage = table.Column<string>(nullable: true),
                    userAddress = table.Column<string>(nullable: true),
                    eMail = table.Column<string>(nullable: false),
                    UserKind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    productName = table.Column<string>(nullable: false),
                    productImage1 = table.Column<string>(nullable: true),
                    productImage2 = table.Column<string>(nullable: true),
                    productDescription = table.Column<string>(nullable: false),
                    productPrice = table.Column<decimal>(nullable: false),
                    productQuantity = table.Column<int>(nullable: false),
                    cartID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productID);
                    table.ForeignKey(
                        name: "FK_Products_Carts_cartID",
                        column: x => x.cartID,
                        principalTable: "Carts",
                        principalColumn: "cartID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_cartID",
                table: "Products",
                column: "cartID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
