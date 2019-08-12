using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Slick.Database.Migrations
{
    public partial class contracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialisations_SpecialisationLevel_SpecialisationLevelId",
                table: "Specialisations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialisationLevel",
                table: "SpecialisationLevel");

            migrationBuilder.RenameTable(
                name: "SpecialisationLevel",
                newName: "SpecialisationLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialisationLevels",
                table: "SpecialisationLevels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContractTypeId = table.Column<Guid>(nullable: false),
                    ConsultantId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    SignedDate = table.Column<DateTime>(nullable: true),
                    Salary = table.Column<decimal>(nullable: true),
                    DocumentUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ConsultantId",
                table: "Contracts",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialisations_SpecialisationLevels_SpecialisationLevelId",
                table: "Specialisations",
                column: "SpecialisationLevelId",
                principalTable: "SpecialisationLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialisations_SpecialisationLevels_SpecialisationLevelId",
                table: "Specialisations");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialisationLevels",
                table: "SpecialisationLevels");

            migrationBuilder.RenameTable(
                name: "SpecialisationLevels",
                newName: "SpecialisationLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialisationLevel",
                table: "SpecialisationLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialisations_SpecialisationLevel_SpecialisationLevelId",
                table: "Specialisations",
                column: "SpecialisationLevelId",
                principalTable: "SpecialisationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
