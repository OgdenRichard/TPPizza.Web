using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPPizza.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOnDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredients_Ingredients_IngredientId",
                table: "PizzaIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredients_Pizzas_PizzaId",
                table: "PizzaIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredients_Ingredients_IngredientId",
                table: "PizzaIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredients_Pizzas_PizzaId",
                table: "PizzaIngredients",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "PizzaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredients_Ingredients_IngredientId",
                table: "PizzaIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredients_Pizzas_PizzaId",
                table: "PizzaIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredients_Ingredients_IngredientId",
                table: "PizzaIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredients_Pizzas_PizzaId",
                table: "PizzaIngredients",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "PizzaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
