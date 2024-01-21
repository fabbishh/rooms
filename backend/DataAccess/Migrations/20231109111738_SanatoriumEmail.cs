using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SanatoriumEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("02e45b8e-fe3e-4834-b344-c4b4b943f7fe"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("235a51f1-5c6e-41f4-b8b2-4954f73aca79"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("435ac3c1-535c-4562-85a4-d8ff5759b21c"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4a03e800-1a2c-4d0a-8059-b9cf4a234bd9"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("53794149-8624-439c-9154-755452cc234b"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("58221c8a-64ab-4646-8704-df2f236aab40"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("59eea255-d693-4a19-94e1-b6e1e924c106"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("676077c7-89a0-4a7a-b71a-1b75a5173eef"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6cfaeb00-c257-4df8-88a9-80403ddb5821"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("8114b2bc-49ca-437b-a6b6-0f2d698c4362"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("998a7b5c-4f91-4a66-be09-ed77f1f4d0a5"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c929d48c-b28d-4d0a-abc0-76ec887e48ad"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("ca8c4231-27ec-4c21-aa7b-3c9dfff17284"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("0a803579-0462-431f-96c1-c734581a16a3"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("b8b71d14-571e-4175-82ac-4e85f5d28521"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("d90f8c24-7e9a-4387-81f6-e3343a52040f"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sanatoriums",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("4cf6b70b-de60-4b43-ac73-f4f8579638b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт в номере", false, "RoomComfort" },
                    { new Guid("6891d5c1-29b2-4931-9ff0-7106e5e7d7d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт на территории", false, "SanatoriumComfort" },
                    { new Guid("71b1e1a7-8276-4b3e-8e2c-7111a3aed908"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Услуги", false, "Service" }
                });

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 9, 11, 17, 38, 172, DateTimeKind.Unspecified).AddTicks(9174), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 9, 11, 17, 38, 172, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 9, 11, 17, 38, 172, DateTimeKind.Unspecified).AddTicks(9157), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 9, 11, 17, 38, 172, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "DateCreated", "FriendlyName", "IsActive", "Name", "RoomId" },
                values: new object[,]
                {
                    { new Guid("1fd01c03-57c7-4d42-8603-40591a8ec333"), new Guid("6891d5c1-29b2-4931-9ff0-7106e5e7d7d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Бассейн без подогрева", false, null, null },
                    { new Guid("24d8961f-87da-43cf-b582-6b607bd631c1"), new Guid("4cf6b70b-de60-4b43-ac73-f4f8579638b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Фен", false, null, null },
                    { new Guid("32162287-8c3f-41a8-83a7-337887d75494"), new Guid("6891d5c1-29b2-4931-9ff0-7106e5e7d7d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Спортзал", false, null, null },
                    { new Guid("3906cd84-903d-4cb0-a1ab-b843e19c7fff"), new Guid("4cf6b70b-de60-4b43-ac73-f4f8579638b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Телевизор", false, null, null },
                    { new Guid("4ad8492c-b9bf-4feb-a303-4fd1537b8d07"), new Guid("71b1e1a7-8276-4b3e-8e2c-7111a3aed908"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Массаж", false, null, null },
                    { new Guid("544efb33-c5f1-4b45-bde1-89fbcc94c89a"), new Guid("71b1e1a7-8276-4b3e-8e2c-7111a3aed908"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Соляная пещера", false, null, null },
                    { new Guid("75cb975d-ac96-4121-a2c1-1d0e36099a69"), new Guid("6891d5c1-29b2-4931-9ff0-7106e5e7d7d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Wi-Fi", false, null, null },
                    { new Guid("978d2c6e-c3e1-44c7-9340-379b0fd37ac8"), new Guid("71b1e1a7-8276-4b3e-8e2c-7111a3aed908"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Радоновые ванны", false, null, null },
                    { new Guid("a1a184b7-f59f-4a96-8cb5-ec2d46a68702"), new Guid("4cf6b70b-de60-4b43-ac73-f4f8579638b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Обогреватель", false, null, null },
                    { new Guid("b48512fb-e9a2-413c-85db-2ab48ca5832a"), new Guid("4cf6b70b-de60-4b43-ac73-f4f8579638b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Гладильная доска", false, null, null },
                    { new Guid("ce4de236-642b-4b57-b176-0be02faee034"), new Guid("4cf6b70b-de60-4b43-ac73-f4f8579638b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Утюг", false, null, null },
                    { new Guid("dac5368c-211f-46cc-b1bf-cafda013c395"), new Guid("6891d5c1-29b2-4931-9ff0-7106e5e7d7d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Сауна", false, null, null },
                    { new Guid("ed96a070-97dd-4cd8-979e-73722eafc0cc"), new Guid("4cf6b70b-de60-4b43-ac73-f4f8579638b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Кондиционер", false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("1fd01c03-57c7-4d42-8603-40591a8ec333"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("24d8961f-87da-43cf-b582-6b607bd631c1"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("32162287-8c3f-41a8-83a7-337887d75494"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3906cd84-903d-4cb0-a1ab-b843e19c7fff"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4ad8492c-b9bf-4feb-a303-4fd1537b8d07"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("544efb33-c5f1-4b45-bde1-89fbcc94c89a"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("75cb975d-ac96-4121-a2c1-1d0e36099a69"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("978d2c6e-c3e1-44c7-9340-379b0fd37ac8"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a1a184b7-f59f-4a96-8cb5-ec2d46a68702"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("b48512fb-e9a2-413c-85db-2ab48ca5832a"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("ce4de236-642b-4b57-b176-0be02faee034"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("dac5368c-211f-46cc-b1bf-cafda013c395"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("ed96a070-97dd-4cd8-979e-73722eafc0cc"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("4cf6b70b-de60-4b43-ac73-f4f8579638b2"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("6891d5c1-29b2-4931-9ff0-7106e5e7d7d1"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("71b1e1a7-8276-4b3e-8e2c-7111a3aed908"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sanatoriums");

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0a803579-0462-431f-96c1-c734581a16a3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт на территории", false, "SanatoriumComfort" },
                    { new Guid("b8b71d14-571e-4175-82ac-4e85f5d28521"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт в номере", false, "RoomComfort" },
                    { new Guid("d90f8c24-7e9a-4387-81f6-e3343a52040f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Услуги", false, "Service" }
                });

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 8, 13, 1, 6, 127, DateTimeKind.Unspecified).AddTicks(2708), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 8, 13, 1, 6, 127, DateTimeKind.Unspecified).AddTicks(2706), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 8, 13, 1, 6, 127, DateTimeKind.Unspecified).AddTicks(2690), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 8, 13, 1, 6, 127, DateTimeKind.Unspecified).AddTicks(2694), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "DateCreated", "FriendlyName", "IsActive", "Name", "RoomId" },
                values: new object[,]
                {
                    { new Guid("02e45b8e-fe3e-4834-b344-c4b4b943f7fe"), new Guid("0a803579-0462-431f-96c1-c734581a16a3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Сауна", false, null, null },
                    { new Guid("235a51f1-5c6e-41f4-b8b2-4954f73aca79"), new Guid("b8b71d14-571e-4175-82ac-4e85f5d28521"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Телевизор", false, null, null },
                    { new Guid("435ac3c1-535c-4562-85a4-d8ff5759b21c"), new Guid("0a803579-0462-431f-96c1-c734581a16a3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Бассейн без подогрева", false, null, null },
                    { new Guid("4a03e800-1a2c-4d0a-8059-b9cf4a234bd9"), new Guid("b8b71d14-571e-4175-82ac-4e85f5d28521"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Утюг", false, null, null },
                    { new Guid("53794149-8624-439c-9154-755452cc234b"), new Guid("d90f8c24-7e9a-4387-81f6-e3343a52040f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Радоновые ванны", false, null, null },
                    { new Guid("58221c8a-64ab-4646-8704-df2f236aab40"), new Guid("b8b71d14-571e-4175-82ac-4e85f5d28521"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Обогреватель", false, null, null },
                    { new Guid("59eea255-d693-4a19-94e1-b6e1e924c106"), new Guid("b8b71d14-571e-4175-82ac-4e85f5d28521"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Гладильная доска", false, null, null },
                    { new Guid("676077c7-89a0-4a7a-b71a-1b75a5173eef"), new Guid("0a803579-0462-431f-96c1-c734581a16a3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Спортзал", false, null, null },
                    { new Guid("6cfaeb00-c257-4df8-88a9-80403ddb5821"), new Guid("d90f8c24-7e9a-4387-81f6-e3343a52040f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Соляная пещера", false, null, null },
                    { new Guid("8114b2bc-49ca-437b-a6b6-0f2d698c4362"), new Guid("b8b71d14-571e-4175-82ac-4e85f5d28521"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Кондиционер", false, null, null },
                    { new Guid("998a7b5c-4f91-4a66-be09-ed77f1f4d0a5"), new Guid("0a803579-0462-431f-96c1-c734581a16a3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Wi-Fi", false, null, null },
                    { new Guid("c929d48c-b28d-4d0a-abc0-76ec887e48ad"), new Guid("b8b71d14-571e-4175-82ac-4e85f5d28521"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Фен", false, null, null },
                    { new Guid("ca8c4231-27ec-4c21-aa7b-3c9dfff17284"), new Guid("d90f8c24-7e9a-4387-81f6-e3343a52040f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Массаж", false, null, null }
                });
        }
    }
}
