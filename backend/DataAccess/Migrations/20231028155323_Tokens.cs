using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Tokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Sanatorium_SanatoriumId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Sanatorium_SanatoriumId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanatorium_Users_OwnerId",
                table: "Sanatorium");

            migrationBuilder.DropForeignKey(
                name: "FK_SanatoriumAttributes_Sanatorium_SanatoriumId",
                table: "SanatoriumAttributes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sanatorium",
                table: "Sanatorium");

            migrationBuilder.RenameTable(
                name: "Sanatorium",
                newName: "Sanatoriums");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Rooms",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "BedsNumber",
                table: "Rooms",
                newName: "SingleBedCount");

            migrationBuilder.RenameColumn(
                name: "GuestsNumber",
                table: "RoomReservations",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "RoomReservations",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CheckInDate",
                table: "RoomReservations",
                newName: "EndDate");

            migrationBuilder.RenameIndex(
                name: "IX_Sanatorium_OwnerId",
                table: "Sanatoriums",
                newName: "IX_Sanatoriums_OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPhoneNumberConfirmed",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Tours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "TourBookings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "TourAgencies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TourAgencies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TourAgencies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "TourAgencies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TourAgencies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "SanatoriumAttributes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "BedroomCount",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Rooms",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "DoubleBedCount",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomType",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "RoomReservations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "GuestsCount",
                table: "RoomReservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Photos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "PlaceId",
                table: "Photos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Attributes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Attributes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "FriendlyName",
                table: "Attributes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "AttributeGroups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "FriendlyName",
                table: "AttributeGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Sanatoriums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sanatoriums",
                table: "Sanatoriums",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    TourAgencyId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_TourAgencies_TourAgencyId",
                        column: x => x.TourAgencyId,
                        principalTable: "TourAgencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoRowItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    SanatoriumId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateAccepted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateCanceled = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AdminRequestStatus = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoRowItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoRowItems_Sanatoriums_SanatoriumId",
                        column: x => x.SanatoriumId,
                        principalTable: "Sanatoriums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    OverallRating = table.Column<int>(type: "integer", nullable: false),
                    StaffRating = table.Column<int>(type: "integer", nullable: false),
                    AccommodationRating = table.Column<int>(type: "integer", nullable: false),
                    FoodRating = table.Column<int>(type: "integer", nullable: false),
                    LocationRating = table.Column<int>(type: "integer", nullable: false),
                    EntertainmentRating = table.Column<int>(type: "integer", nullable: false),
                    SanatoriumId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Sanatoriums_SanatoriumId",
                        column: x => x.SanatoriumId,
                        principalTable: "Sanatoriums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAttributes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanatoriumPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlaceId = table.Column<Guid>(type: "uuid", nullable: false),
                    SanatoriumId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanatoriumPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanatoriumPlaces_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanatoriumPlaces_Sanatoriums_SanatoriumId",
                        column: x => x.SanatoriumId,
                        principalTable: "Sanatoriums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromoBlockItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    DateAccepted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateCanceled = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AdminRequestStatus = table.Column<int>(type: "integer", nullable: false),
                    PromoBlockId = table.Column<Guid>(type: "uuid", nullable: false),
                    SanatoriumId = table.Column<Guid>(type: "uuid", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: true),
                    TourAgencyId = table.Column<Guid>(type: "uuid", nullable: true),
                    TourId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoBlockItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoBlockItems_PromoBlocks_PromoBlockId",
                        column: x => x.PromoBlockId,
                        principalTable: "PromoBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromoBlockItems_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromoBlockItems_Sanatoriums_SanatoriumId",
                        column: x => x.SanatoriumId,
                        principalTable: "Sanatoriums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromoBlockItems_TourAgencies_TourAgencyId",
                        column: x => x.TourAgencyId,
                        principalTable: "TourAgencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromoBlockItems_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_GroupId",
                table: "Rooms",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PlaceId",
                table: "Photos",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TourAgencyId",
                table: "Contacts",
                column: "TourAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoBlockItems_PromoBlockId",
                table: "PromoBlockItems",
                column: "PromoBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoBlockItems_RoomId",
                table: "PromoBlockItems",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoBlockItems_SanatoriumId",
                table: "PromoBlockItems",
                column: "SanatoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoBlockItems_TourAgencyId",
                table: "PromoBlockItems",
                column: "TourAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoBlockItems_TourId",
                table: "PromoBlockItems",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoRowItems_SanatoriumId",
                table: "PromoRowItems",
                column: "SanatoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SanatoriumId",
                table: "Reviews",
                column: "SanatoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAttributes_AttributeId",
                table: "RoomAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAttributes_RoomId",
                table: "RoomAttributes",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SanatoriumPlaces_PlaceId",
                table: "SanatoriumPlaces",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SanatoriumPlaces_SanatoriumId",
                table: "SanatoriumPlaces",
                column: "SanatoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Places_PlaceId",
                table: "Photos",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Sanatoriums_SanatoriumId",
                table: "Photos",
                column: "SanatoriumId",
                principalTable: "Sanatoriums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomGroups_GroupId",
                table: "Rooms",
                column: "GroupId",
                principalTable: "RoomGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Sanatoriums_SanatoriumId",
                table: "Rooms",
                column: "SanatoriumId",
                principalTable: "Sanatoriums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanatoriumAttributes_Sanatoriums_SanatoriumId",
                table: "SanatoriumAttributes",
                column: "SanatoriumId",
                principalTable: "Sanatoriums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanatoriums_Users_OwnerId",
                table: "Sanatoriums",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Places_PlaceId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Sanatoriums_SanatoriumId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomGroups_GroupId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Sanatoriums_SanatoriumId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_SanatoriumAttributes_Sanatoriums_SanatoriumId",
                table: "SanatoriumAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanatoriums_Users_OwnerId",
                table: "Sanatoriums");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "PromoBlockItems");

            migrationBuilder.DropTable(
                name: "PromoRowItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "RoomAttributes");

            migrationBuilder.DropTable(
                name: "RoomGroups");

            migrationBuilder.DropTable(
                name: "SanatoriumPlaces");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "PromoBlocks");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_GroupId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PlaceId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sanatoriums",
                table: "Sanatoriums");

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

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsPhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TourAgencies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TourAgencies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TourAgencies");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "TourAgencies");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TourAgencies");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SanatoriumAttributes");

            migrationBuilder.DropColumn(
                name: "BedroomCount",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DoubleBedCount",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MinDaysReservation",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "GuestsCount",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "FriendlyName",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AttributeGroups");

            migrationBuilder.DropColumn(
                name: "FriendlyName",
                table: "AttributeGroups");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Sanatoriums");

            migrationBuilder.RenameTable(
                name: "Sanatoriums",
                newName: "Sanatorium");

            migrationBuilder.RenameColumn(
                name: "SingleBedCount",
                table: "Rooms",
                newName: "BedsNumber");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rooms",
                newName: "RoomNumber");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "RoomReservations",
                newName: "GuestsNumber");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "RoomReservations",
                newName: "CheckOutDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "RoomReservations",
                newName: "CheckInDate");

            migrationBuilder.RenameIndex(
                name: "IX_Sanatoriums_OwnerId",
                table: "Sanatorium",
                newName: "IX_Sanatorium_OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Attributes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sanatorium",
                table: "Sanatorium",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Sanatorium_SanatoriumId",
                table: "Photos",
                column: "SanatoriumId",
                principalTable: "Sanatorium",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Sanatorium_SanatoriumId",
                table: "Rooms",
                column: "SanatoriumId",
                principalTable: "Sanatorium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanatorium_Users_OwnerId",
                table: "Sanatorium",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanatoriumAttributes_Sanatorium_SanatoriumId",
                table: "SanatoriumAttributes",
                column: "SanatoriumId",
                principalTable: "Sanatorium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
