using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingEventsDemo.Migrations
{
    public partial class FixingThisByHandIGuess : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.RenameTable(
                name: "Tag",
                newName: "Tags"
            );
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.RenameTable(
                name: "Tags",
                newName: "Tag"
            );
        }
    }
}
