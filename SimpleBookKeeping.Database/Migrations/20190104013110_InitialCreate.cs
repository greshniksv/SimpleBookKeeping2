using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Plans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostId);
                    table.ForeignKey(
                        name: "FK_Costs_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanMembers",
                columns: table => new
                {
                    PlanMemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMembers", x => x.PlanMemberId);
                    table.ForeignKey(
                        name: "FK_PlanMembers_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostsDetails",
                columns: table => new
                {
                    CostDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostsDetails", x => x.CostDetailId);
                    table.ForeignKey(
                        name: "FK_CostsDetails_Costs_CostId",
                        column: x => x.CostId,
                        principalTable: "Costs",
                        principalColumn: "CostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spends",
                columns: table => new
                {
                    SpendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    CostDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spends", x => x.SpendId);
                    table.ForeignKey(
                        name: "FK_Spends_CostsDetails_CostDetailId",
                        column: x => x.CostDetailId,
                        principalTable: "CostsDetails",
                        principalColumn: "CostDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_Deleted",
                table: "Costs",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_PlanId",
                table: "Costs",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CostsDetails_CostId",
                table: "CostsDetails",
                column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_CostsDetails_Date",
                table: "CostsDetails",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_CostsDetails_Deleted",
                table: "CostsDetails",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMembers_PlanId",
                table: "PlanMembers",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMembers_UserId",
                table: "PlanMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_Deleted",
                table: "Plans",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_End",
                table: "Plans",
                column: "End");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_Start",
                table: "Plans",
                column: "Start");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId",
                table: "Plans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Spends_CostDetailId",
                table: "Spends",
                column: "CostDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Spends_UserId",
                table: "Spends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanMembers");

            migrationBuilder.DropTable(
                name: "Spends");

            migrationBuilder.DropTable(
                name: "CostsDetails");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
