using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewAttributesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(244), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "DateCreated", "Deleted", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("5c52815e-e12b-48fd-8429-b0cf4c3e995d"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 3, 0, 0, 0)), false, "Питание в санатории", true, "SanatoriumFood" },
                    { new Guid("96de2246-871c-4a3d-b8e7-f179816dd483"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(251), new TimeSpan(0, 3, 0, 0, 0)), false, "Питание в номере", true, "RoomFood" },
                    { new Guid("f2782387-51e8-4d8e-93f7-1d2ba96b09c8"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 3, 0, 0, 0)), false, "Санузел", true, "RoomBathroom" }
                });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(556), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(547), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(533), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(538), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(541), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(552), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(543), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(546), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(554), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(560), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(558), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(653), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(652), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(600), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(633), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(709), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(705), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(711), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(677), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(674), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(669), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("03785f9c-ecdd-4770-9b5b-78c8f3fc2341"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(840), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("67e3166e-7810-4fa2-a4cf-b223eb7d03b1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(842), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(735), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(737), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(740), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(732), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(739), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: new Guid("155d1c26-57e7-4025-ab9e-220c5e6f7cac"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(864), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ef9b18b-8336-4719-8b3b-8e5d6351d457"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(862), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("6e335238-7a18-49bd-9a95-233a6729b49b"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(813), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("c3cae629-e754-4f4a-858e-aff906c980a4"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(816), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(816), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ce1644b1-b242-49c1-9e00-cf30941e3394"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(807), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(809), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ed922b7a-222e-436c-ac0d-53c8dcc15851"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(791), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(793), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e8d2464-51c3-42b5-bd0d-615e7c9f27b0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(762), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b311cf8d-af48-4129-89e0-9f16e7769558"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(771), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5e7a20f-f019-4baf-a986-a04b6b86013a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(767), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0727b36-face-4e75-9371-54908b66fb9b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 19, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(774), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "DateCreated", "Deleted", "FriendlyName", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("11698eb0-9f0a-45a4-9f41-ca259932e1ab"), new Guid("5c52815e-e12b-48fd-8429-b0cf4c3e995d"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 3, 0, 0, 0)), false, "Столовая", true, null },
                    { new Guid("18aa3fc7-3d11-42e9-aff7-45210c3ee030"), new Guid("5c52815e-e12b-48fd-8429-b0cf4c3e995d"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(564), new TimeSpan(0, 3, 0, 0, 0)), false, "Кафе", true, null },
                    { new Guid("2bcfe13b-790f-421f-9495-209944f3ce0d"), new Guid("f2782387-51e8-4d8e-93f7-1d2ba96b09c8"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 3, 0, 0, 0)), false, "Отдельный в номере", true, null },
                    { new Guid("3d057402-313b-4d79-87ac-8ddeaf2c99a7"), new Guid("5c52815e-e12b-48fd-8429-b0cf4c3e995d"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 3, 0, 0, 0)), false, "Ресторан", true, null },
                    { new Guid("83ff8a5c-f4ab-42c5-9897-dd8a9fd5bedc"), new Guid("f2782387-51e8-4d8e-93f7-1d2ba96b09c8"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 3, 0, 0, 0)), false, "На этаже общий", true, null },
                    { new Guid("ec03b886-017a-4422-8c2c-f24d8f37ac1c"), new Guid("96de2246-871c-4a3d-b8e7-f179816dd483"), new DateTimeOffset(new DateTime(2024, 1, 17, 22, 23, 33, 823, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 3, 0, 0, 0)), false, "Отдельная кухня в номере", true, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("11698eb0-9f0a-45a4-9f41-ca259932e1ab"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("18aa3fc7-3d11-42e9-aff7-45210c3ee030"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2bcfe13b-790f-421f-9495-209944f3ce0d"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3d057402-313b-4d79-87ac-8ddeaf2c99a7"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("83ff8a5c-f4ab-42c5-9897-dd8a9fd5bedc"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("ec03b886-017a-4422-8c2c-f24d8f37ac1c"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("5c52815e-e12b-48fd-8429-b0cf4c3e995d"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("96de2246-871c-4a3d-b8e7-f179816dd483"));

            migrationBuilder.DeleteData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f2782387-51e8-4d8e-93f7-1d2ba96b09c8"));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4223), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4230), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4190), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4531), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4522), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4475), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4480), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4484), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4527), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4486), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4488), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4529), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4525), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4535), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4533), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4575), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4574), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4558), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4618), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4615), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4596), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4594), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4589), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("03785f9c-ecdd-4770-9b5b-78c8f3fc2341"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4717), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("67e3166e-7810-4fa2-a4cf-b223eb7d03b1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4719), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4637), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4641), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4633), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4639), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: new Guid("155d1c26-57e7-4025-ab9e-220c5e6f7cac"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4733), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ef9b18b-8336-4719-8b3b-8e5d6351d457"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4730), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("6e335238-7a18-49bd-9a95-233a6729b49b"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4698), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("c3cae629-e754-4f4a-858e-aff906c980a4"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4701), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ce1644b1-b242-49c1-9e00-cf30941e3394"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4695), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4696), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ed922b7a-222e-436c-ac0d-53c8dcc15851"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4679), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4681), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e8d2464-51c3-42b5-bd0d-615e7c9f27b0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b311cf8d-af48-4129-89e0-9f16e7769558"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4666), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5e7a20f-f019-4baf-a986-a04b6b86013a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4664), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0727b36-face-4e75-9371-54908b66fb9b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 17, 7, 25, 666, DateTimeKind.Unspecified).AddTicks(4668), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
