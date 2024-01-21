﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserBirthday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5268), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5270), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5535), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5517), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5524), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5539), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5531), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5537), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5546), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5544), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5587), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5585), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5568), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5636), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5638), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5615), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5611), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("03785f9c-ecdd-4770-9b5b-78c8f3fc2341"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5760), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("67e3166e-7810-4fa2-a4cf-b223eb7d03b1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5761), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5658), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5661), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5655), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5659), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("6e335238-7a18-49bd-9a95-233a6729b49b"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5741), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("c3cae629-e754-4f4a-858e-aff906c980a4"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5743), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5744), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ce1644b1-b242-49c1-9e00-cf30941e3394"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5704), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5704), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ed922b7a-222e-436c-ac0d-53c8dcc15851"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5691), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e8d2464-51c3-42b5-bd0d-615e7c9f27b0"),
                columns: new[] { "Birthday", "DateCreated" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b311cf8d-af48-4129-89e0-9f16e7769558"),
                columns: new[] { "Birthday", "DateCreated" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5e7a20f-f019-4baf-a986-a04b6b86013a"),
                columns: new[] { "Birthday", "DateCreated" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5674), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0727b36-face-4e75-9371-54908b66fb9b"),
                columns: new[] { "Birthday", "DateCreated" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2024, 1, 2, 6, 34, 29, 926, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2371), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2374), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2301), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2670), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2662), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2650), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2652), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2654), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2656), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2666), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2658), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2660), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2674), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 9, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2724), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2723), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2699), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2700), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2772), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2777), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2753), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2751), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2746), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("03785f9c-ecdd-4770-9b5b-78c8f3fc2341"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2880), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("67e3166e-7810-4fa2-a4cf-b223eb7d03b1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2882), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2799), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2803), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2797), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("6e335238-7a18-49bd-9a95-233a6729b49b"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2862), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2863), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("c3cae629-e754-4f4a-858e-aff906c980a4"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2865), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2865), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ce1644b1-b242-49c1-9e00-cf30941e3394"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2859), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2860), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ed922b7a-222e-436c-ac0d-53c8dcc15851"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2845), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2847), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e8d2464-51c3-42b5-bd0d-615e7c9f27b0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b311cf8d-af48-4129-89e0-9f16e7769558"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2822), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5e7a20f-f019-4baf-a986-a04b6b86013a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2820), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0727b36-face-4e75-9371-54908b66fb9b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 6, 12, 33, 922, DateTimeKind.Unspecified).AddTicks(2823), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
