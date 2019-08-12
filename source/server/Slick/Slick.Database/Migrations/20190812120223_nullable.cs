using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Slick.Database.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Addresses_AddressId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Consultants_ConsultantId",
                table: "Contracts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultantId",
                table: "Contracts",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Consultants",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Addresses_AddressId",
                table: "Consultants",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Consultants_ConsultantId",
                table: "Contracts",
                column: "ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Addresses_AddressId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Consultants_ConsultantId",
                table: "Contracts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultantId",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Consultants",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Addresses_AddressId",
                table: "Consultants",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Consultants_ConsultantId",
                table: "Contracts",
                column: "ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
