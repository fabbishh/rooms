using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReservationGuests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuestComment",
                table: "RoomReservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanatoriumAdminComment",
                table: "RoomReservations",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false),
                    RoomReservationId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_RoomReservations_RoomReservationId",
                        column: x => x.RoomReservationId,
                        principalTable: "RoomReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9698), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9701), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9662), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9917), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9894), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9898), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9902), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9904), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9906), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9908), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9915), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9912), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9922), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 14, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 11, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9960), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 11, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9959), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 11, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9940), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 11, 52, 31, 550, DateTimeKind.Unspecified).AddTicks(9943), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomReservationId",
                table: "Guests",
                column: "RoomReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropColumn(
                name: "GuestComment",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "SanatoriumAdminComment",
                table: "RoomReservations");

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2418), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2423), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2325), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2627), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2631), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2645), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2637), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2643), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2653), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 16, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2651), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 13, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2692), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 13, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2690), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 13, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2676), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 18, 13, 25, 11, 337, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
