using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolRental.DataAccess.Migrations
{
    public partial class rentalitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ToolCategoryId = table.Column<int>(nullable: false),
                    JobTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalItem_JobType_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalItem_Category_ToolCategoryId",
                        column: x => x.ToolCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalItem_JobTypeId",
                table: "RentalItem",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalItem_ToolCategoryId",
                table: "RentalItem",
                column: "ToolCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalItem");
        }
    }
}
