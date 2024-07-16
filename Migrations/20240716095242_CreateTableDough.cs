using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPPizza.Web.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableDough : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DoughId",
                table: "Pizzas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Doughs",
                columns: table => new
                {
                    DoughId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoughName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doughs", x => x.DoughId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_DoughId",
                table: "Pizzas",
                column: "DoughId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Doughs_DoughId",
                table: "Pizzas",
                column: "DoughId",
                principalTable: "Doughs",
                principalColumn: "DoughId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Doughs_DoughId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Doughs");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_DoughId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "DoughId",
                table: "Pizzas");
        }
    }
}
