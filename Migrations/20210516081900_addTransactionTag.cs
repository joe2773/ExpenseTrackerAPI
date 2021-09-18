using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseTracker.Migrations
{
    public partial class addTransactionTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Transactions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Transactions");
        }
    }
}
