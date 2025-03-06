using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OVALGenerator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityBulletins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CveId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    OvalXml = table.Column<string>(type: "xml", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityBulletins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityBulletins_CveId",
                table: "SecurityBulletins",
                column: "CveId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityBulletins");
        }
    }
}
