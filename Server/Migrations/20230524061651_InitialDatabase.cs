using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SoftwareLogAnalizer.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetexPrimaryLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LogInfo = table.Column<string>(type: "text", nullable: false),
                    IsLog = table.Column<bool>(type: "boolean", nullable: false),
                    LogIsStructurated = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetexPrimaryLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceName = table.Column<string>(type: "text", nullable: false),
                    ProjectResourceId = table.Column<int>(type: "integer", nullable: false),
                    ResourceType = table.Column<int>(type: "integer", nullable: false),
                    ResourceCategory = table.Column<int>(type: "integer", nullable: false),
                    ResourceUsageState = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SoftwareName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tNavPrimaryLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TNavLogID = table.Column<long>(type: "bigint", nullable: true),
                    OperationType = table.Column<int>(type: "integer", nullable: true),
                    Feature = table.Column<string>(type: "text", nullable: false),
                    OperationDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ComputerUserName = table.Column<string>(type: "text", nullable: false),
                    WindowsUserName = table.Column<string>(type: "text", nullable: false),
                    ReturnedId = table.Column<int>(type: "integer", nullable: true),
                    IsLog = table.Column<bool>(type: "boolean", nullable: true),
                    LogIsStructurated = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tNavPrimaryLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    ResourceID = table.Column<int>(type: "integer", nullable: false),
                    EmployeType = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Resources_ResourceID",
                        column: x => x.ResourceID,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SoftwareModuleName = table.Column<string>(type: "text", nullable: false),
                    ResourceID = table.Column<int>(type: "integer", nullable: false),
                    SoftwareId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareModules_Resources_ResourceID",
                        column: x => x.ResourceID,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareModules_Softwares_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Softwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WindowsUserName = table.Column<string>(type: "text", nullable: false),
                    ComputerUserName = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareUsers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SoftwareUserId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    SoftwareId = table.Column<int>(type: "integer", nullable: false),
                    SoftwareModuleId = table.Column<int>(type: "integer", nullable: false),
                    LogInDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LogOutDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SessionIsFinished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_SoftwareModules_SoftwareModuleId",
                        column: x => x.SoftwareModuleId,
                        principalTable: "SoftwareModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_SoftwareUsers_SoftwareUserId",
                        column: x => x.SoftwareUserId,
                        principalTable: "SoftwareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Softwares_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Softwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StructuredLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Operation = table.Column<int>(type: "integer", nullable: false),
                    OperationDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SoftwareId = table.Column<int>(type: "integer", nullable: true),
                    SoftwareModuleId = table.Column<int>(type: "integer", nullable: true),
                    SoftwareUserId = table.Column<int>(type: "integer", nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true),
                    LogIsMatched = table.Column<bool>(type: "boolean", nullable: true),
                    ErrorLog = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructuredLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StructuredLogs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StructuredLogs_SoftwareModules_SoftwareModuleId",
                        column: x => x.SoftwareModuleId,
                        principalTable: "SoftwareModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StructuredLogs_SoftwareUsers_SoftwareUserId",
                        column: x => x.SoftwareUserId,
                        principalTable: "SoftwareUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StructuredLogs_Softwares_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Softwares",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ResourceID",
                table: "Employees",
                column: "ResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_EmployeeId",
                table: "Sessions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SoftwareId",
                table: "Sessions",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SoftwareModuleId",
                table: "Sessions",
                column: "SoftwareModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SoftwareUserId",
                table: "Sessions",
                column: "SoftwareUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareModules_ResourceID",
                table: "SoftwareModules",
                column: "ResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareModules_SoftwareId",
                table: "SoftwareModules",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareUsers_EmployeeId",
                table: "SoftwareUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StructuredLogs_EmployeeId",
                table: "StructuredLogs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StructuredLogs_SoftwareId",
                table: "StructuredLogs",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_StructuredLogs_SoftwareModuleId",
                table: "StructuredLogs",
                column: "SoftwareModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StructuredLogs_SoftwareUserId",
                table: "StructuredLogs",
                column: "SoftwareUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetexPrimaryLogs");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "StructuredLogs");

            migrationBuilder.DropTable(
                name: "tNavPrimaryLogs");

            migrationBuilder.DropTable(
                name: "SoftwareModules");

            migrationBuilder.DropTable(
                name: "SoftwareUsers");

            migrationBuilder.DropTable(
                name: "Softwares");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
