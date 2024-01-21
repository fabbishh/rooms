using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeletedFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "UserRefreshTokens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TourTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Tours",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TourDates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TourDateBookings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TourAgencies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Subjects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SanatoriumTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Sanatoriums",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SanatoriumPlaces",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SanatoriumAttributes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Rooms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RoomReservations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RoomGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RoomAttributes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Reviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "PromoRowItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "PromoBlocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "PromoBlockItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Places",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Photos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "MealTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Guests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Contacts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "BathroomTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Attributes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AttributeGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(6771), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(6773), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7071), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7064), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7046), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7049), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7055), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7068), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7058), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7066), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7075), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 17, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7073), new TimeSpan(0, 3, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 14, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7114), new TimeSpan(0, 0, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 14, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7111), new TimeSpan(0, 0, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 14, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7097), new TimeSpan(0, 0, 0, 0, 0)), false });

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                columns: new[] { "DateCreated", "Deleted" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 14, 8, 23, 104, DateTimeKind.Unspecified).AddTicks(7099), new TimeSpan(0, 0, 0, 0, 0)), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TourTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TourDates");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TourDateBookings");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TourAgencies");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SanatoriumTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Sanatoriums");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SanatoriumPlaces");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SanatoriumAttributes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RoomAttributes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PromoRowItems");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PromoBlocks");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PromoBlockItems");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MealTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "BathroomTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AttributeGroups");

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1096), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1100), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1390), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1343), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1345), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1348), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1350), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1387), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1352), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1381), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1389), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1385), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1394), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 16, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1392), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 13, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 13, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1427), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 13, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1413), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 6, 13, 55, 40, 823, DateTimeKind.Unspecified).AddTicks(1415), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
