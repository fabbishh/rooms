using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RoomRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Rooms_RoomId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAttributes_Rooms_RoomId",
                table: "RoomAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_BathroomTypes_BathroomTypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_MealTypes_MealTypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Sanatoriums_SanatoriumId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BathroomTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_MealTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_SanatoriumId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_RoomId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "BathroomTypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BedroomCount",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DoubleBedCount",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MealTypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MinDaysReservation",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PricePerNight",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SanatoriumId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SingleBedCount",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Attributes");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomAttributes",
                newName: "RoomGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAttributes_RoomId",
                table: "RoomAttributes",
                newName: "IX_RoomAttributes_RoomGroupId");

            migrationBuilder.AddColumn<Guid>(
                name: "BathroomTypeId",
                table: "RoomGroups",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "BedroomCount",
                table: "RoomGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RoomGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DoubleBedCount",
                table: "RoomGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MealTypeId",
                table: "RoomGroups",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MinDaysReservation",
                table: "RoomGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerNight",
                table: "RoomGroups",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RoomType",
                table: "RoomGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SanatoriumId",
                table: "RoomGroups",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SingleBedCount",
                table: "RoomGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7531), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7534), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7499), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7755), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7747), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7734), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7738), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7742), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7745), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7753), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 19, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7757), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 16, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7833), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 16, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7832), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 16, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7811), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 8, 16, 50, 2, 691, DateTimeKind.Unspecified).AddTicks(7813), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_RoomGroups_BathroomTypeId",
                table: "RoomGroups",
                column: "BathroomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomGroups_MealTypeId",
                table: "RoomGroups",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomGroups_SanatoriumId",
                table: "RoomGroups",
                column: "SanatoriumId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAttributes_RoomGroups_RoomGroupId",
                table: "RoomAttributes",
                column: "RoomGroupId",
                principalTable: "RoomGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomGroups_BathroomTypes_BathroomTypeId",
                table: "RoomGroups",
                column: "BathroomTypeId",
                principalTable: "BathroomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomGroups_MealTypes_MealTypeId",
                table: "RoomGroups",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomGroups_Sanatoriums_SanatoriumId",
                table: "RoomGroups",
                column: "SanatoriumId",
                principalTable: "Sanatoriums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAttributes_RoomGroups_RoomGroupId",
                table: "RoomAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomGroups_BathroomTypes_BathroomTypeId",
                table: "RoomGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomGroups_MealTypes_MealTypeId",
                table: "RoomGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomGroups_Sanatoriums_SanatoriumId",
                table: "RoomGroups");

            migrationBuilder.DropIndex(
                name: "IX_RoomGroups_BathroomTypeId",
                table: "RoomGroups");

            migrationBuilder.DropIndex(
                name: "IX_RoomGroups_MealTypeId",
                table: "RoomGroups");

            migrationBuilder.DropIndex(
                name: "IX_RoomGroups_SanatoriumId",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "BathroomTypeId",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "BedroomCount",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "DoubleBedCount",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "MealTypeId",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "MinDaysReservation",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "PricePerNight",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "SanatoriumId",
                table: "RoomGroups");

            migrationBuilder.DropColumn(
                name: "SingleBedCount",
                table: "RoomGroups");

            migrationBuilder.RenameColumn(
                name: "RoomGroupId",
                table: "RoomAttributes",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAttributes_RoomGroupId",
                table: "RoomAttributes",
                newName: "IX_RoomAttributes_RoomId");

            migrationBuilder.AddColumn<Guid>(
                name: "BathroomTypeId",
                table: "Rooms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "BedroomCount",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Rooms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DoubleBedCount",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MealTypeId",
                table: "Rooms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MinDaysReservation",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerNight",
                table: "Rooms",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RoomType",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SanatoriumId",
                table: "Rooms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SingleBedCount",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Attributes",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8517), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8801), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8794), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8782), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8784), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8786), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8788), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8798), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8790), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8792), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8800), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8796), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8805), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                columns: new[] { "DateCreated", "RoomId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 7, 18, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8803), new TimeSpan(0, 3, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 7, 15, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 7, 15, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8837), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 7, 15, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8823), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 7, 15, 57, 57, 256, DateTimeKind.Unspecified).AddTicks(8825), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BathroomTypeId",
                table: "Rooms",
                column: "BathroomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MealTypeId",
                table: "Rooms",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SanatoriumId",
                table: "Rooms",
                column: "SanatoriumId");

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
                name: "FK_RoomAttributes_Rooms_RoomId",
                table: "RoomAttributes",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Sanatoriums_SanatoriumId",
                table: "Rooms",
                column: "SanatoriumId",
                principalTable: "Sanatoriums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
