using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BathroomAndMealTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("0571d9bd-695f-4262-87f6-dbbf1c071d13"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("08bc7414-a62f-4b96-a321-411db61c8dbb"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("126ee694-0573-4b2d-a6ae-1579fbfc8b78"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13cf8799-9894-4ecb-96db-b1f4999fa252"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("30afe4fa-2464-48c6-90df-1ec5a3b8a016"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4da43408-800c-43c9-9557-62587a0ea449"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("7d11ff4c-1dcd-4db0-99d2-0261bfd11f50"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("974b645a-eb57-49d1-98bc-867f4c7a0ff5"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("af124be5-26c0-48de-9e43-c38b1cee6d74"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c5d5e84d-dcd0-4f42-b52c-9d456d4e1a97"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c74f094e-3a60-4042-9da8-2ab9cc93bc04"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("cf35e3c1-2c24-4378-bc6c-e99e081f6d1d"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("e5d4cd91-d451-4131-9401-0c770ea20e28"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("dd62889d-5390-4b4d-a833-95b396e29c4a"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("e9e15b31-2230-43ec-a993-bbe24c03da4a"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("ed71dd9b-6e35-4687-9cfc-ee9de3247096"));

            migrationBuilder.AddColumn<Guid>(
                name: "BathroomTypeId",
                table: "Rooms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MealTypeId",
                table: "Rooms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Attributes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BathroomTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FriendlyName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BathroomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FriendlyName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("305953aa-9c00-401b-8ec6-5522d7aba2a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Услуги", false, "Service" },
                    { new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт в номере", false, "RoomComfort" },
                    { new Guid("8c7bb2fb-4f95-49b1-8e08-d309b235e1f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт на территории", false, "SanatoriumComfort" }
                });

            migrationBuilder.InsertData(
                table: "BathroomTypes",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("37d57656-b9ad-4c98-8063-b70183a88115"), new DateTimeOffset(new DateTime(2023, 11, 7, 14, 51, 31, 649, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 0, 0, 0, 0)), "На территории санатория", true, null },
                    { new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"), new DateTimeOffset(new DateTime(2023, 11, 7, 14, 51, 31, 649, DateTimeKind.Unspecified).AddTicks(1981), new TimeSpan(0, 0, 0, 0, 0)), "Отдельный", true, null }
                });

            migrationBuilder.InsertData(
                table: "MealTypes",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"), new DateTimeOffset(new DateTime(2023, 11, 7, 14, 51, 31, 649, DateTimeKind.Unspecified).AddTicks(1966), new TimeSpan(0, 0, 0, 0, 0)), "Отдельная", true, null },
                    { new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"), new DateTimeOffset(new DateTime(2023, 11, 7, 14, 51, 31, 649, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 0, 0, 0, 0)), "На территории санатория", true, null }
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "DateCreated", "FriendlyName", "IsActive", "Name", "RoomId" },
                values: new object[,]
                {
                    { new Guid("04bd7cbe-511e-4617-8dfd-387d2cbf3c6b"), new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Телевизор", false, null, null },
                    { new Guid("1f7b5d07-2871-43fa-8871-4e3c2f8207df"), new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Утюг", false, null, null },
                    { new Guid("2499755f-9767-4095-917a-28dc5ab9898f"), new Guid("305953aa-9c00-401b-8ec6-5522d7aba2a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Соляная пещера", false, null, null },
                    { new Guid("3dddb08c-ba78-436b-bd91-f86a5188cbee"), new Guid("305953aa-9c00-401b-8ec6-5522d7aba2a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Радоновые ванны", false, null, null },
                    { new Guid("487eff90-2f90-4f65-886f-94fe9255c044"), new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Гладильная доска", false, null, null },
                    { new Guid("4bba16c3-8271-4b9a-8568-548fe64a174d"), new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Обогреватель", false, null, null },
                    { new Guid("6ed33125-3482-4d83-bd63-f0b10e66bbb0"), new Guid("8c7bb2fb-4f95-49b1-8e08-d309b235e1f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Спортзал", false, null, null },
                    { new Guid("8e058dba-dfa9-4add-a948-d0a22b501066"), new Guid("305953aa-9c00-401b-8ec6-5522d7aba2a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Массаж", false, null, null },
                    { new Guid("9515ad73-8954-47da-b967-b469297a7860"), new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Фен", false, null, null },
                    { new Guid("97c15331-0299-4e00-abde-2b7c1ebb2e7d"), new Guid("8c7bb2fb-4f95-49b1-8e08-d309b235e1f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Wi-Fi", false, null, null },
                    { new Guid("a4d4413f-873d-4cc6-9b54-b743dfe9250d"), new Guid("8c7bb2fb-4f95-49b1-8e08-d309b235e1f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Бассейн без подогрева", false, null, null },
                    { new Guid("abad2e31-939c-40ab-ad03-2b1e99937c47"), new Guid("8c7bb2fb-4f95-49b1-8e08-d309b235e1f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Сауна", false, null, null },
                    { new Guid("fcfa6ad3-da45-4f53-aa7f-75f506fafcc1"), new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Кондиционер", false, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BathroomTypeId",
                table: "Rooms",
                column: "BathroomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MealTypeId",
                table: "Rooms",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_RoomId",
                table: "Attributes",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Rooms_RoomId",
                table: "Attributes",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_BathroomTypes_BathroomTypeId",
                table: "Rooms",
                column: "BathroomTypeId",
                principalTable: "BathroomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_MealTypes_MealTypeId",
                table: "Rooms",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Rooms_RoomId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_BathroomTypes_BathroomTypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_MealTypes_MealTypeId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "BathroomTypes");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BathroomTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_MealTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_RoomId",
                table: "Attributes");

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("04bd7cbe-511e-4617-8dfd-387d2cbf3c6b"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("1f7b5d07-2871-43fa-8871-4e3c2f8207df"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2499755f-9767-4095-917a-28dc5ab9898f"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3dddb08c-ba78-436b-bd91-f86a5188cbee"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("487eff90-2f90-4f65-886f-94fe9255c044"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bba16c3-8271-4b9a-8568-548fe64a174d"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6ed33125-3482-4d83-bd63-f0b10e66bbb0"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("8e058dba-dfa9-4add-a948-d0a22b501066"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("9515ad73-8954-47da-b967-b469297a7860"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("97c15331-0299-4e00-abde-2b7c1ebb2e7d"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a4d4413f-873d-4cc6-9b54-b743dfe9250d"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("abad2e31-939c-40ab-ad03-2b1e99937c47"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("fcfa6ad3-da45-4f53-aa7f-75f506fafcc1"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("305953aa-9c00-401b-8ec6-5522d7aba2a7"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("8c7bb2fb-4f95-49b1-8e08-d309b235e1f2"));

            migrationBuilder.DropColumn(
                name: "BathroomTypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MealTypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Attributes");

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("dd62889d-5390-4b4d-a833-95b396e29c4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт в номере", false, "RoomComfort" },
                    { new Guid("e9e15b31-2230-43ec-a993-bbe24c03da4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Услуги", false, "Service" },
                    { new Guid("ed71dd9b-6e35-4687-9cfc-ee9de3247096"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт на территории", false, "SanatoriumComfort" }
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0571d9bd-695f-4262-87f6-dbbf1c071d13"), new Guid("dd62889d-5390-4b4d-a833-95b396e29c4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Утюг", false, null },
                    { new Guid("08bc7414-a62f-4b96-a321-411db61c8dbb"), new Guid("e9e15b31-2230-43ec-a993-bbe24c03da4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Соляная пещера", false, null },
                    { new Guid("126ee694-0573-4b2d-a6ae-1579fbfc8b78"), new Guid("ed71dd9b-6e35-4687-9cfc-ee9de3247096"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Wi-Fi", false, null },
                    { new Guid("13cf8799-9894-4ecb-96db-b1f4999fa252"), new Guid("dd62889d-5390-4b4d-a833-95b396e29c4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Кондиционер", false, null },
                    { new Guid("30afe4fa-2464-48c6-90df-1ec5a3b8a016"), new Guid("ed71dd9b-6e35-4687-9cfc-ee9de3247096"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Бассейн без подогрева", false, null },
                    { new Guid("4da43408-800c-43c9-9557-62587a0ea449"), new Guid("dd62889d-5390-4b4d-a833-95b396e29c4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Фен", false, null },
                    { new Guid("7d11ff4c-1dcd-4db0-99d2-0261bfd11f50"), new Guid("dd62889d-5390-4b4d-a833-95b396e29c4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Гладильная доска", false, null },
                    { new Guid("974b645a-eb57-49d1-98bc-867f4c7a0ff5"), new Guid("e9e15b31-2230-43ec-a993-bbe24c03da4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Радоновые ванны", false, null },
                    { new Guid("af124be5-26c0-48de-9e43-c38b1cee6d74"), new Guid("dd62889d-5390-4b4d-a833-95b396e29c4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Обогреватель", false, null },
                    { new Guid("c5d5e84d-dcd0-4f42-b52c-9d456d4e1a97"), new Guid("ed71dd9b-6e35-4687-9cfc-ee9de3247096"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Спортзал", false, null },
                    { new Guid("c74f094e-3a60-4042-9da8-2ab9cc93bc04"), new Guid("ed71dd9b-6e35-4687-9cfc-ee9de3247096"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Сауна", false, null },
                    { new Guid("cf35e3c1-2c24-4378-bc6c-e99e081f6d1d"), new Guid("e9e15b31-2230-43ec-a993-bbe24c03da4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Массаж", false, null },
                    { new Guid("e5d4cd91-d451-4131-9401-0c770ea20e28"), new Guid("dd62889d-5390-4b4d-a833-95b396e29c4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Телевизор", false, null }
                });
        }
    }
}
