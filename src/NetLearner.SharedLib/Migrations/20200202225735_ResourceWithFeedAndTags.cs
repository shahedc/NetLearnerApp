using Microsoft.EntityFrameworkCore.Migrations;

namespace NetLearner.SharedLib.Migrations
{
    public partial class ResourceWithFeedAndTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentFeed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedUrl = table.Column<string>(nullable: true),
                    LearningResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentFeed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentFeed_LearningResources_LearningResourceId",
                        column: x => x.LearningResourceId,
                        principalTable: "LearningResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LearningResourceTopicTag",
                columns: table => new
                {
                    LearningResourceId = table.Column<int>(nullable: false),
                    TopicTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningResourceTopicTag", x => new { x.LearningResourceId, x.TopicTagId });
                    table.ForeignKey(
                        name: "FK_LearningResourceTopicTag_LearningResources_LearningResourceId",
                        column: x => x.LearningResourceId,
                        principalTable: "LearningResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningResourceTopicTag_TopicTag_TopicTagId",
                        column: x => x.TopicTagId,
                        principalTable: "TopicTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentFeed_LearningResourceId",
                table: "ContentFeed",
                column: "LearningResourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningResourceTopicTag_TopicTagId",
                table: "LearningResourceTopicTag",
                column: "TopicTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentFeed");

            migrationBuilder.DropTable(
                name: "LearningResourceTopicTag");

            migrationBuilder.DropTable(
                name: "TopicTag");
        }
    }
}
