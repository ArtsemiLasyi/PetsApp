using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtsemiLasyi.PetsApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetBreeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetBreeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetBreeds_PetTypes_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeightInGrams = table.Column<float>(type: "real", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PetBreedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_PetBreeds_PetBreedId",
                        column: x => x.PetBreedId,
                        principalTable: "PetBreeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), "Cat" },
                    { new Guid("0f9fad5b-d9cb-469f-a165-70867728950e"), "Dog" },
                    { new Guid("0fafad5b-d9cb-469f-a165-70867728950e"), "Parrot" }
                });

            migrationBuilder.InsertData(
                table: "PetBreeds",
                columns: new[] { "Id", "Name", "PetTypeId" },
                values: new object[,]
                {
                    { new Guid("0faaad5b-d9cb-469f-a165-70867728950e"), "British Shrthair", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e") },
                    { new Guid("0fabad5b-d9cb-469f-a165-70867728950e"), "Alaskan Malamute", new Guid("0f9fad5b-d9cb-469f-a165-70867728950e") },
                    { new Guid("0facad5b-d9cb-469f-a165-70867728950e"), "Komondor", new Guid("0f9fad5b-d9cb-469f-a165-70867728950e") },
                    { new Guid("0fadad5b-d9cb-469f-a165-70867728950e"), "Drever", new Guid("0f9fad5b-d9cb-469f-a165-70867728950e") },
                    { new Guid("0fbfad5b-d9cb-469f-a165-70867728950e"), "Macaw", new Guid("0fafad5b-d9cb-469f-a165-70867728950e") },
                    { new Guid("0fcfad5b-d9cb-469f-a165-70867728950e"), "Cockatoo", new Guid("0fafad5b-d9cb-469f-a165-70867728950e") },
                    { new Guid("0fdfad5b-d9cb-469f-a165-70867728950e"), "Caique", new Guid("0fafad5b-d9cb-469f-a165-70867728950e") },
                    { new Guid("0fefad5b-d9cb-469f-a165-70867728950e"), "Abyssinian", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e") },
                    { new Guid("0fffad5b-d9cb-469f-a165-70867728950e"), "Bengal", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetBreeds_PetTypeId",
                table: "PetBreeds",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetBreedId",
                table: "Pets",
                column: "PetBreedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "PetBreeds");

            migrationBuilder.DropTable(
                name: "PetTypes");
        }
    }
}
