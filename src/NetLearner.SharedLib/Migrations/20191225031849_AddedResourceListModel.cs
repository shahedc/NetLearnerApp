using Microsoft.EntityFrameworkCore.Migrations;

namespace NetLearner.SharedLib.Migrations
{
    public partial class AddedResourceListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResourceListId",
                table: "LearningResources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResourceLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningResources_ResourceListId",
                table: "LearningResources",
                column: "ResourceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningResources_ResourceLists_ResourceListId",
                table: "LearningResources",
                column: "ResourceListId",
                principalTable: "ResourceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningResources_ResourceLists_ResourceListId",
                table: "LearningResources");

            migrationBuilder.DropTable(
                name: "ResourceLists");

            migrationBuilder.DropIndex(
                name: "IX_LearningResources_ResourceListId",
                table: "LearningResources");

            migrationBuilder.DropColumn(
                name: "ResourceListId",
                table: "LearningResources");
        }
    }
}
