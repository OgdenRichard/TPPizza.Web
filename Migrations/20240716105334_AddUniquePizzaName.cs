using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPPizza.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddUniquePizzaName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaName",
                table: "Pizzas",
                column: "PizzaName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pizzas_PizzaName",
                table: "Pizzas");
        }
    }
}
