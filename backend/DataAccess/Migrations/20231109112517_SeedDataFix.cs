using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("22462aca-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9135), new TimeSpan(0, 3, 0, 0, 0)), "Комфорт на территории", true, "SanatoriumComfort" },
                    { new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9138), new TimeSpan(0, 3, 0, 0, 0)), "Комфорт в номере", true, "RoomComfort" },
                    { new Guid("f993d082-7ef1-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9099), new TimeSpan(0, 3, 0, 0, 0)), "Услуги", true, "Service" }
                });

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 9, 11, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9367), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 9, 11, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9365), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 9, 11, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 9, 11, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9354), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "DateCreated", "FriendlyName", "IsActive", "Name", "RoomId" },
                values: new object[,]
                {
                    { new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"), new Guid("f993d082-7ef1-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9330), new TimeSpan(0, 3, 0, 0, 0)), "Соляная пещера", true, null, null },
                    { new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"), new Guid("22462aca-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9322), new TimeSpan(0, 3, 0, 0, 0)), "Wi-Fi", true, null, null },
                    { new Guid("347087cc-7ef2-11ee-b962-0242ac120002"), new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9309), new TimeSpan(0, 3, 0, 0, 0)), "Кондиционер", true, null, null },
                    { new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"), new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9313), new TimeSpan(0, 3, 0, 0, 0)), "Обогреватель", true, null, null },
                    { new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"), new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9314), new TimeSpan(0, 3, 0, 0, 0)), "Утюг", true, null, null },
                    { new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"), new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9316), new TimeSpan(0, 3, 0, 0, 0)), "Гладильная доска", true, null, null },
                    { new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"), new Guid("22462aca-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9326), new TimeSpan(0, 3, 0, 0, 0)), "Спортзал", true, null, null },
                    { new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"), new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9318), new TimeSpan(0, 3, 0, 0, 0)), "Телевизор", true, null, null },
                    { new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"), new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9320), new TimeSpan(0, 3, 0, 0, 0)), "Фен", true, null, null },
                    { new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"), new Guid("22462aca-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9328), new TimeSpan(0, 3, 0, 0, 0)), "Бассейн без подогрева", true, null, null },
                    { new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"), new Guid("22462aca-7ef2-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9324), new TimeSpan(0, 3, 0, 0, 0)), "Сауна", true, null, null },
                    { new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"), new Guid("f993d082-7ef1-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9333), new TimeSpan(0, 3, 0, 0, 0)), "Массаж", true, null, null },
                    { new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"), new Guid("f993d082-7ef1-11ee-b962-0242ac120002"), new DateTimeOffset(new DateTime(2023, 11, 9, 14, 25, 17, 713, DateTimeKind.Unspecified).AddTicks(9331), new TimeSpan(0, 3, 0, 0, 0)), "Радоновые ванны", true, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"));

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
    }
}
