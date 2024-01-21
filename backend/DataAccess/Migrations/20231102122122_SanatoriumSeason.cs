using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SanatoriumSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("116c162c-9b10-4cb0-b71e-4469da9b0e8b"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13ecd677-bbf1-42a8-a753-3c0fdef804a8"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3b7d621a-dd88-4a63-a34c-0eb47c661f17"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("52b0878f-fb31-4fb1-b4ac-970e28626730"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5417c334-9642-4124-bd89-d7063b787836"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("8255e4e1-ea29-4181-82ff-5b04a496bc1f"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("8883f3d3-e889-4b73-876e-625d6f897214"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("9a5bc088-2994-4c93-8ade-6fdcd003eeb5"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("af6980a3-6d5b-43da-a3cb-0316926da2ab"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("b8b8a185-ba7a-445e-8303-f8969b6cad66"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("be156811-ace9-4f1e-ab41-44d3520652f8"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("e4d42299-2811-4327-a2ff-1e25a95a14d8"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("fa578def-e5d1-462a-b4da-51fc1ff2a41c"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("1e108ca3-ed8e-44f4-8e67-55b2b372b1f7"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("1f9112b2-47ca-4c9c-80a6-c083fb45b90f"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("3bcb2cba-b30e-4b81-8213-e4bc3f10f0a8"));

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Sanatoriums",
                newName: "CheckOutTime");

            migrationBuilder.AddColumn<string>(
                name: "CheckInTime",
                table: "Sanatoriums",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ObjectType",
                table: "Sanatoriums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "Sanatoriums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CheckInTime",
                table: "Sanatoriums");

            migrationBuilder.DropColumn(
                name: "ObjectType",
                table: "Sanatoriums");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Sanatoriums");

            migrationBuilder.RenameColumn(
                name: "CheckOutTime",
                table: "Sanatoriums",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("1e108ca3-ed8e-44f4-8e67-55b2b372b1f7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Услуги", false, "Service" },
                    { new Guid("1f9112b2-47ca-4c9c-80a6-c083fb45b90f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт на территории", false, "SanatoriumComfort" },
                    { new Guid("3bcb2cba-b30e-4b81-8213-e4bc3f10f0a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт в номере", false, "RoomComfort" }
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("116c162c-9b10-4cb0-b71e-4469da9b0e8b"), new Guid("3bcb2cba-b30e-4b81-8213-e4bc3f10f0a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Фен", false, null },
                    { new Guid("13ecd677-bbf1-42a8-a753-3c0fdef804a8"), new Guid("3bcb2cba-b30e-4b81-8213-e4bc3f10f0a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Гладильная доска", false, null },
                    { new Guid("3b7d621a-dd88-4a63-a34c-0eb47c661f17"), new Guid("1f9112b2-47ca-4c9c-80a6-c083fb45b90f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Сауна", false, null },
                    { new Guid("52b0878f-fb31-4fb1-b4ac-970e28626730"), new Guid("3bcb2cba-b30e-4b81-8213-e4bc3f10f0a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Телевизор", false, null },
                    { new Guid("5417c334-9642-4124-bd89-d7063b787836"), new Guid("1e108ca3-ed8e-44f4-8e67-55b2b372b1f7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Соляная пещера", false, null },
                    { new Guid("8255e4e1-ea29-4181-82ff-5b04a496bc1f"), new Guid("1f9112b2-47ca-4c9c-80a6-c083fb45b90f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Wi-Fi", false, null },
                    { new Guid("8883f3d3-e889-4b73-876e-625d6f897214"), new Guid("1e108ca3-ed8e-44f4-8e67-55b2b372b1f7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Радоновые ванны", false, null },
                    { new Guid("9a5bc088-2994-4c93-8ade-6fdcd003eeb5"), new Guid("1f9112b2-47ca-4c9c-80a6-c083fb45b90f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Спортзал", false, null },
                    { new Guid("af6980a3-6d5b-43da-a3cb-0316926da2ab"), new Guid("3bcb2cba-b30e-4b81-8213-e4bc3f10f0a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Утюг", false, null },
                    { new Guid("b8b8a185-ba7a-445e-8303-f8969b6cad66"), new Guid("3bcb2cba-b30e-4b81-8213-e4bc3f10f0a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Кондиционер", false, null },
                    { new Guid("be156811-ace9-4f1e-ab41-44d3520652f8"), new Guid("1e108ca3-ed8e-44f4-8e67-55b2b372b1f7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Массаж", false, null },
                    { new Guid("e4d42299-2811-4327-a2ff-1e25a95a14d8"), new Guid("1f9112b2-47ca-4c9c-80a6-c083fb45b90f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Бассейн без подогрева", false, null },
                    { new Guid("fa578def-e5d1-462a-b4da-51fc1ff2a41c"), new Guid("3bcb2cba-b30e-4b81-8213-e4bc3f10f0a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Обогреватель", false, null }
                });
        }
    }
}
