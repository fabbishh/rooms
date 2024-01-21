using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class subjectColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FederalDisctrict",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FiasId",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeonameCode",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeonameId",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeonameName",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsoCode",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KladrId",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameWithType",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Okato",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Oktmo",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxOffice",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Timezone",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Subject",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8497), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8500), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8456), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8724), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8702), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8707), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8720), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8711), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8722), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8718), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8728), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 19, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8726), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 16, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8766), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 16, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8765), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 16, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8749), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 16, 51, 35, 652, DateTimeKind.Unspecified).AddTicks(8750), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FederalDisctrict",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "FiasId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "GeonameCode",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "GeonameId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "GeonameName",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "IsoCode",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "KladrId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "NameWithType",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "Okato",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "Oktmo",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "TaxOffice",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "Timezone",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Subject");

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9678), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9644), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9903), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9881), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9885), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9887), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9889), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9899), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9891), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9893), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9901), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9897), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9938), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 18, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9905), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 15, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9973), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 15, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9972), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 15, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9958), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 11, 29, 15, 49, 41, 873, DateTimeKind.Unspecified).AddTicks(9960), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
