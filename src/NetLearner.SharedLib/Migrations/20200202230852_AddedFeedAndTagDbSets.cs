using Microsoft.EntityFrameworkCore.Migrations;

namespace NetLearner.SharedLib.Migrations
{
    public partial class AddedFeedAndTagDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentFeed_LearningResources_LearningResourceId",
                table: "ContentFeed");

            migrationBuilder.DropForeignKey(
                name: "FK_LearningResourceTopicTag_TopicTag_TopicTagId",
                table: "LearningResourceTopicTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicTag",
                table: "TopicTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentFeed",
                table: "ContentFeed");

            migrationBuilder.RenameTable(
                name: "TopicTag",
                newName: "TopicTags");

            migrationBuilder.RenameTable(
                name: "ContentFeed",
                newName: "ContentFeeds");

            migrationBuilder.RenameIndex(
                name: "IX_ContentFeed_LearningResourceId",
                table: "ContentFeeds",
                newName: "IX_ContentFeeds_LearningResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicTags",
                table: "TopicTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentFeeds",
                table: "ContentFeeds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentFeeds_LearningResources_LearningResourceId",
                table: "ContentFeeds",
                column: "LearningResourceId",
                principalTable: "LearningResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LearningResourceTopicTag_TopicTags_TopicTagId",
                table: "LearningResourceTopicTag",
                column: "TopicTagId",
                principalTable: "TopicTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentFeeds_LearningResources_LearningResourceId",
                table: "ContentFeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_LearningResourceTopicTag_TopicTags_TopicTagId",
                table: "LearningResourceTopicTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicTags",
                table: "TopicTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentFeeds",
                table: "ContentFeeds");

            migrationBuilder.RenameTable(
                name: "TopicTags",
                newName: "TopicTag");

            migrationBuilder.RenameTable(
                name: "ContentFeeds",
                newName: "ContentFeed");

            migrationBuilder.RenameIndex(
                name: "IX_ContentFeeds_LearningResourceId",
                table: "ContentFeed",
                newName: "IX_ContentFeed_LearningResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicTag",
                table: "TopicTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentFeed",
                table: "ContentFeed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentFeed_LearningResources_LearningResourceId",
                table: "ContentFeed",
                column: "LearningResourceId",
                principalTable: "LearningResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LearningResourceTopicTag_TopicTag_TopicTagId",
                table: "LearningResourceTopicTag",
                column: "TopicTagId",
                principalTable: "TopicTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
