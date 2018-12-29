using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CheeseMVC.Migrations
{
    public partial class AddMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheeseMenu_Cheeses_CheeseID",
                table: "CheeseMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_CheeseMenu_Menus_MenuID",
                table: "CheeseMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheeseMenu",
                table: "CheeseMenu");

            migrationBuilder.RenameTable(
                name: "CheeseMenu",
                newName: "CheeseMenus");

            migrationBuilder.RenameIndex(
                name: "IX_CheeseMenu_MenuID",
                table: "CheeseMenus",
                newName: "IX_CheeseMenus_MenuID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheeseMenus",
                table: "CheeseMenus",
                columns: new[] { "CheeseID", "MenuID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CheeseMenus_Cheeses_CheeseID",
                table: "CheeseMenus",
                column: "CheeseID",
                principalTable: "Cheeses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheeseMenus_Menus_MenuID",
                table: "CheeseMenus",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheeseMenus_Cheeses_CheeseID",
                table: "CheeseMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_CheeseMenus_Menus_MenuID",
                table: "CheeseMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheeseMenus",
                table: "CheeseMenus");

            migrationBuilder.RenameTable(
                name: "CheeseMenus",
                newName: "CheeseMenu");

            migrationBuilder.RenameIndex(
                name: "IX_CheeseMenus_MenuID",
                table: "CheeseMenu",
                newName: "IX_CheeseMenu_MenuID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheeseMenu",
                table: "CheeseMenu",
                columns: new[] { "CheeseID", "MenuID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CheeseMenu_Cheeses_CheeseID",
                table: "CheeseMenu",
                column: "CheeseID",
                principalTable: "Cheeses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheeseMenu_Menus_MenuID",
                table: "CheeseMenu",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
