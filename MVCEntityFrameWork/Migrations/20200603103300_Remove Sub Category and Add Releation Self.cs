using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCEntityFrameWork.Migrations
{
    public partial class RemoveSubCategoryandAddReleationSelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInfo_Publisher_PublisherID",
                table: "BookInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInfo_SubCategories_SCategoryID",
                table: "BookInfo");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_BookInfo_SCategoryID",
                table: "BookInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "SCategoryID",
                table: "BookInfo");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "Publishers");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryID",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "PublisherID");

            migrationBuilder.CreateTable(
                name: "Book_Categories",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Categories", x => new { x.BookID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_Book_Categories_BookInfo_BookID",
                        column: x => x.BookID,
                        principalTable: "BookInfo",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Categories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Categories_CategoryID",
                table: "Book_Categories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInfo_Publishers_PublisherID",
                table: "BookInfo",
                column: "PublisherID",
                principalTable: "Publishers",
                principalColumn: "PublisherID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInfo_Publishers_PublisherID",
                table: "BookInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryID",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Book_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryID",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "ParentCategoryID",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "Publisher");

            migrationBuilder.AddColumn<int>(
                name: "SCategoryID",
                table: "BookInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "PublisherID");

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: true),
                    SubCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryID);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookInfo_SCategoryID",
                table: "BookInfo",
                column: "SCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryID",
                table: "SubCategories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInfo_Publisher_PublisherID",
                table: "BookInfo",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "PublisherID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInfo_SubCategories_SCategoryID",
                table: "BookInfo",
                column: "SCategoryID",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
