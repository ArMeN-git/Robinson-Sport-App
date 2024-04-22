using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RobinsonSportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAssociationContactsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociationContact_Associations_AssociationId",
                table: "AssociationContact");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociationContact_Contacts_ContactPersonId",
                table: "AssociationContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociationContact",
                table: "AssociationContact");

            migrationBuilder.RenameTable(
                name: "AssociationContact",
                newName: "AssociationContacts");

            migrationBuilder.RenameIndex(
                name: "IX_AssociationContact_ContactPersonId",
                table: "AssociationContacts",
                newName: "IX_AssociationContacts_ContactPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociationContacts",
                table: "AssociationContacts",
                columns: new[] { "AssociationId", "ContactPersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationContacts_Associations_AssociationId",
                table: "AssociationContacts",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationContacts_Contacts_ContactPersonId",
                table: "AssociationContacts",
                column: "ContactPersonId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociationContacts_Associations_AssociationId",
                table: "AssociationContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociationContacts_Contacts_ContactPersonId",
                table: "AssociationContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociationContacts",
                table: "AssociationContacts");

            migrationBuilder.RenameTable(
                name: "AssociationContacts",
                newName: "AssociationContact");

            migrationBuilder.RenameIndex(
                name: "IX_AssociationContacts_ContactPersonId",
                table: "AssociationContact",
                newName: "IX_AssociationContact_ContactPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociationContact",
                table: "AssociationContact",
                columns: new[] { "AssociationId", "ContactPersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationContact_Associations_AssociationId",
                table: "AssociationContact",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationContact_Contacts_ContactPersonId",
                table: "AssociationContact",
                column: "ContactPersonId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
