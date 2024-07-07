using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minhaprimeiraapi.Migrations
{
    /// <inheritdoc />
    public partial class KarapinhaDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    appointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    professionalId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    serviceId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    date = table.Column<DateOnly>(type: "DATE", nullable: false),
                    time = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    status_appointment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 15, nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", maxLength: 80, nullable: false),
                    dateModified = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.appointmentId);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentServices",
                columns: table => new
                {
                    appointmentServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointmentId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    serviceId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentServices", x => x.appointmentServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    emailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateSent = table.Column<DateTime>(type: "datetime", nullable: false),
                    statusEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.emailId);
                });

            migrationBuilder.CreateTable(
                name: "Professional",
                columns: table => new
                {
                    professionalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    bi = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    photo = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false),
                    workingHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", maxLength: 80, nullable: false),
                    dateModified = table.Column<DateTime>(type: "datetime2", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.professionalsId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false),
                    additionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.userId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentServices");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Professional");

            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
