using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SanatoriumContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourAgencies_TourAgencyId1",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_TourAgencyId1",
                table: "Tours");

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
                name: "TourAgencyId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TourAgencyId1",
                table: "Tours");

            migrationBuilder.AddColumn<Guid>(
                name: "SanatoriumId",
                table: "Contacts",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SanatoriumId",
                table: "Contacts",
                column: "SanatoriumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Sanatoriums_SanatoriumId",
                table: "Contacts",
                column: "SanatoriumId",
                principalTable: "Sanatoriums",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Sanatoriums_SanatoriumId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SanatoriumId",
                table: "Contacts");

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

            migrationBuilder.DropColumn(
                name: "SanatoriumId",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "TourAgencyId",
                table: "Tours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TourAgencyId1",
                table: "Tours",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("305953aa-9c00-401b-8ec6-5522d7aba2a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Услуги", false, "Service" },
                    { new Guid("7838c94b-53e2-45b5-a478-1b093b7067a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт в номере", false, "RoomComfort" },
                    { new Guid("8c7bb2fb-4f95-49b1-8e08-d309b235e1f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Комфорт на территории", false, "SanatoriumComfort" }
                });

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 7, 14, 51, 31, 649, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 7, 14, 51, 31, 649, DateTimeKind.Unspecified).AddTicks(1981), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 7, 14, 51, 31, 649, DateTimeKind.Unspecified).AddTicks(1966), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 7, 14, 51, 31, 649, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 0, 0, 0, 0)));

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
                name: "IX_Tours_TourAgencyId1",
                table: "Tours",
                column: "TourAgencyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_TourAgencies_TourAgencyId1",
                table: "Tours",
                column: "TourAgencyId1",
                principalTable: "TourAgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
