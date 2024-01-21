using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TourSeasonsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourSeasons_Tours_TourId",
                table: "TourSeasons");

            migrationBuilder.DropIndex(
                name: "IX_TourSeasons_TourId",
                table: "TourSeasons");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "TourSeasons");

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(3803), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(3805), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(3764), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4152), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4145), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4128), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4134), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4136), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4138), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4140), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4142), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4151), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4147), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4156), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4154), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4198), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4197), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4180), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4182), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4239), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4241), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4219), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4217), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4212), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4260), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4261), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4265), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4258), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 23, 36, 550, DateTimeKind.Unspecified).AddTicks(4263), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TourId",
                table: "TourSeasons",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2526), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2529), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2493), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2839), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2817), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2819), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2822), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2824), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2835), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2826), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2828), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2837), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2832), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2843), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 14, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2885), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2869), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2871), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2929), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2926), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2931), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2910), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2908), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2902), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"),
                columns: new[] { "DateCreated", "TourId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"),
                columns: new[] { "DateCreated", "TourId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2947), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"),
                columns: new[] { "DateCreated", "TourId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2950), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"),
                columns: new[] { "DateCreated", "TourId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2943), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"),
                columns: new[] { "DateCreated", "TourId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 12, 16, 11, 22, 31, 4, DateTimeKind.Unspecified).AddTicks(2949), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.CreateIndex(
                name: "IX_TourSeasons_TourId",
                table: "TourSeasons",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourSeasons_Tours_TourId",
                table: "TourSeasons",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id");
        }
    }
}
