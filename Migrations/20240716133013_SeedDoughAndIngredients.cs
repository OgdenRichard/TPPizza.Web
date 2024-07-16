using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TPPizza.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoughAndIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doughs",
                columns: new[] { "DoughId", "DoughName" },
                values: new object[,]
                {
                    { 1L, "Neapolitan" },
                    { 2L, "New York Style" },
                    { 3L, "Chicago Deep Dish" },
                    { 4L, "Sicilian" },
                    { 5L, "Whole Wheat" },
                    { 6L, "Gluten-Free" },
                    { 7L, "Sourdough" },
                    { 8L, "Cauliflower" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "IngredientName" },
                values: new object[,]
                {
                    { 1L, "Tomato Sauce" },
                    { 2L, "Mozzarella Cheese" },
                    { 3L, "Pepperoni" },
                    { 4L, "Mushrooms" },
                    { 5L, "Bell Peppers" },
                    { 6L, "Onions" },
                    { 7L, "Olives" },
                    { 8L, "Sausage" },
                    { 9L, "Ham" },
                    { 10L, "Pineapple" },
                    { 11L, "Bacon" },
                    { 12L, "Spinach" },
                    { 13L, "Garlic" },
                    { 14L, "Basil" },
                    { 15L, "Ricotta Cheese" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "DoughId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "DoughId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "DoughId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "DoughId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "DoughId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "DoughId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "DoughId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "DoughId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15L);
        }
    }
}
