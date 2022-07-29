using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMoroni.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ScriptureNotes",
                columns: table => new
                {
                    ScriptureNoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Reference = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Quote = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptureNotes", x => x.ScriptureNoteId);
                    table.ForeignKey(
                        name: "FK_ScriptureNotes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Scripture" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "General Conference Talk" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Article" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Other" });

            migrationBuilder.InsertData(
                table: "ScriptureNotes",
                columns: new[] { "ScriptureNoteId", "Author", "CategoryId", "Link", "Notes", "Quote", "Reference" },
                values: new object[] { 1, null, 1, "https://www.churchofjesuschrist.org/study/scriptures/bofm/alma/48?lang=eng&id=p17#p17", "How can I be more like Moroni?", "Yea, verily, verily I say unto you, if all men had been, and were, and ever would be, like unto Moroni, behold, the very powers of hell would have been shaken forever; yea, the devil would never have power over the hearts of the children of men.", "Alma 48:17" });

            migrationBuilder.InsertData(
                table: "ScriptureNotes",
                columns: new[] { "ScriptureNoteId", "Author", "CategoryId", "Link", "Notes", "Quote", "Reference" },
                values: new object[] { 2, null, 1, "https://www.churchofjesuschrist.org/study/scriptures/bofm/alma/48?lang=eng&id=p17#p17", "How can I be more like Moroni?", "Yea, verily, verily I say unto you, if all men had been, and were, and ever would be, like unto Moroni, behold, the very powers of hell would have been shaken forever; yea, the devil would never have power over the hearts of the children of men.", "Alma 48:17" });

            migrationBuilder.InsertData(
                table: "ScriptureNotes",
                columns: new[] { "ScriptureNoteId", "Author", "CategoryId", "Link", "Notes", "Quote", "Reference" },
                values: new object[] { 3, null, 1, "https://www.churchofjesuschrist.org/study/scriptures/bofm/alma/48?lang=eng&id=p17#p17", "How can I be more like Moroni?", "Yea, verily, verily I say unto you, if all men had been, and were, and ever would be, like unto Moroni, behold, the very powers of hell would have been shaken forever; yea, the devil would never have power over the hearts of the children of men.", "Alma 48:17" });

            migrationBuilder.CreateIndex(
                name: "IX_ScriptureNotes_CategoryId",
                table: "ScriptureNotes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScriptureNotes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
