using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TourAgencyFKFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("00fea9a2-111d-473b-bccc-41f017f2e518"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("17829280-b63e-4be4-822c-165913d955ee"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("19783aae-27ca-4c3f-9ab6-b1845a17841f"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("1b6f466d-06f0-4390-9499-aeec8bb91fef"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3d57717f-4f93-48d1-b10c-60f39bb3661a"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6815f25c-b2b7-45fd-93f1-93f7a90f9e91"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("8d48a314-a296-43b3-90fc-0e3cf8e1f301"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("acf1a40f-1330-4923-abe3-536ae59a13a0"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("adb984ce-ef40-4827-92f4-093b9d61d0bf"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("b5252812-8ce8-446c-8b25-688b0e8cab2e"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("e37fd658-9638-4b52-896f-481dac22ab45"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("e9786557-4633-4b9a-bf99-24e2be984645"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2329d6c-df67-48d3-bbd9-b1b66da8b4d6"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("052a9517-ad4a-4452-8df4-ea64748feb41"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("3dd3f802-e622-45af-9272-3db75d662385"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("5d4b064b-d6af-4a23-be3d-d3bd53ae7562"));

            migrationBuilder.AddColumn<Guid>(
                name: "TourAgencyId",
                table: "Tours",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Tours_TourAgencyId",
                table: "Tours",
                column: "TourAgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_TourAgencies_TourAgencyId",
                table: "Tours",
                column: "TourAgencyId",
                principalTable: "TourAgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourAgencies_TourAgencyId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_TourAgencyId",
                table: "Tours");

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

            migrationBuilder.DropColumn(
                name: "TourAgencyId",
                table: "Tours");

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("052a9517-ad4a-4452-8df4-ea64748feb41"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт в номере", false, "RoomComfort" },
                    { new Guid("3dd3f802-e622-45af-9272-3db75d662385"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт на территории", false, "SanatoriumComfort" },
                    { new Guid("5d4b064b-d6af-4a23-be3d-d3bd53ae7562"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Услуги", false, "Service" }
                });

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 8, 12, 59, 53, 58, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 8, 12, 59, 53, 58, DateTimeKind.Unspecified).AddTicks(8504), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 8, 12, 59, 53, 58, DateTimeKind.Unspecified).AddTicks(8488), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 8, 12, 59, 53, 58, DateTimeKind.Unspecified).AddTicks(8490), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "DateCreated", "FriendlyName", "IsActive", "Name", "RoomId" },
                values: new object[,]
                {
                    { new Guid("00fea9a2-111d-473b-bccc-41f017f2e518"), new Guid("5d4b064b-d6af-4a23-be3d-d3bd53ae7562"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Массаж", false, null, null },
                    { new Guid("17829280-b63e-4be4-822c-165913d955ee"), new Guid("052a9517-ad4a-4452-8df4-ea64748feb41"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Фен", false, null, null },
                    { new Guid("19783aae-27ca-4c3f-9ab6-b1845a17841f"), new Guid("052a9517-ad4a-4452-8df4-ea64748feb41"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Утюг", false, null, null },
                    { new Guid("1b6f466d-06f0-4390-9499-aeec8bb91fef"), new Guid("3dd3f802-e622-45af-9272-3db75d662385"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Спортзал", false, null, null },
                    { new Guid("3d57717f-4f93-48d1-b10c-60f39bb3661a"), new Guid("052a9517-ad4a-4452-8df4-ea64748feb41"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Кондиционер", false, null, null },
                    { new Guid("6815f25c-b2b7-45fd-93f1-93f7a90f9e91"), new Guid("5d4b064b-d6af-4a23-be3d-d3bd53ae7562"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Соляная пещера", false, null, null },
                    { new Guid("8d48a314-a296-43b3-90fc-0e3cf8e1f301"), new Guid("3dd3f802-e622-45af-9272-3db75d662385"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Бассейн без подогрева", false, null, null },
                    { new Guid("acf1a40f-1330-4923-abe3-536ae59a13a0"), new Guid("052a9517-ad4a-4452-8df4-ea64748feb41"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Телевизор", false, null, null },
                    { new Guid("adb984ce-ef40-4827-92f4-093b9d61d0bf"), new Guid("052a9517-ad4a-4452-8df4-ea64748feb41"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Обогреватель", false, null, null },
                    { new Guid("b5252812-8ce8-446c-8b25-688b0e8cab2e"), new Guid("3dd3f802-e622-45af-9272-3db75d662385"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Wi-Fi", false, null, null },
                    { new Guid("e37fd658-9638-4b52-896f-481dac22ab45"), new Guid("5d4b064b-d6af-4a23-be3d-d3bd53ae7562"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Радоновые ванны", false, null, null },
                    { new Guid("e9786557-4633-4b9a-bf99-24e2be984645"), new Guid("3dd3f802-e622-45af-9272-3db75d662385"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Сауна", false, null, null },
                    { new Guid("f2329d6c-df67-48d3-bbd9-b1b66da8b4d6"), new Guid("052a9517-ad4a-4452-8df4-ea64748feb41"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Гладильная доска", false, null, null }
                });
        }
    }
}
