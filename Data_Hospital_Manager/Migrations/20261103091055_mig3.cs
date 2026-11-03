using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Hospital_Manager.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "FirstName", "HospitalId", "LastName", "PhoneNumber", "Specialty" },
                values: new object[,]
                {
                    { 1, "niya@mail.bg", "Niya", 3, "Ivanova", "0888888888", "Cardiologist" },
                    { 2, "dariya@mail.bg", "Dariya", 4, "Vulkova", "0888888888", "Neurologist" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ivayla@mail.bg", "Ivayla", "Ivanova", "0891234567" },
                    { 2, "petya@mail.bg", "Petya", "Petrova", "0891934567" }
                });

            migrationBuilder.InsertData(
                table: "DoctorsPatients",
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorsPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DoctorsPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorsPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
