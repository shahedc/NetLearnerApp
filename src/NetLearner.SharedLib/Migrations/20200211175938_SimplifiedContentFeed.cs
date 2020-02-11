using Microsoft.EntityFrameworkCore.Migrations;

namespace NetLearner.SharedLib.Migrations
{
    public partial class SimplifiedContentFeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContentFeeds_LearningResourceId",
                table: "ContentFeeds");

            migrationBuilder.AddColumn<string>(
                name: "ContentFeedUrl",
                table: "LearningResources",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentFeeds_LearningResourceId",
                table: "ContentFeeds",
                column: "LearningResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContentFeeds_LearningResourceId",
                table: "ContentFeeds");

            migrationBuilder.DropColumn(
                name: "ContentFeedUrl",
                table: "LearningResources");

            migrationBuilder.CreateIndex(
                name: "IX_ContentFeeds_LearningResourceId",
                table: "ContentFeeds",
                column: "LearningResourceId",
                unique: true);
        }
    }
}
