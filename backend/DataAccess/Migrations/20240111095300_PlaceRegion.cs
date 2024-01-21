using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PlaceRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Places");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Places",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(534), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(499), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(816), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(808), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(801), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(803), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(805), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(806), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(814), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(810), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(820), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 12, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(894), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(893), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(876), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(944), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(941), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(946), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(917), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(915), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(910), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("03785f9c-ecdd-4770-9b5b-78c8f3fc2341"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1042), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("67e3166e-7810-4fa2-a4cf-b223eb7d03b1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(964), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(966), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(969), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: new Guid("155d1c26-57e7-4025-ab9e-220c5e6f7cac"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1058), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ef9b18b-8336-4719-8b3b-8e5d6351d457"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1057), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("6e335238-7a18-49bd-9a95-233a6729b49b"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1024), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1025), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("c3cae629-e754-4f4a-858e-aff906c980a4"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1028), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ce1644b1-b242-49c1-9e00-cf30941e3394"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1021), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ed922b7a-222e-436c-ac0d-53c8dcc15851"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1008), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(1009), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e8d2464-51c3-42b5-bd0d-615e7c9f27b0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(986), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b311cf8d-af48-4129-89e0-9f16e7769558"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(991), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5e7a20f-f019-4baf-a986-a04b6b86013a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(989), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0727b36-face-4e75-9371-54908b66fb9b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 9, 53, 0, 656, DateTimeKind.Unspecified).AddTicks(993), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Places_SubjectId",
                table: "Places",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Subjects_SubjectId",
                table: "Places",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Subjects_SubjectId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_SubjectId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Places",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9492), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9494), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AttributeGroups",
                keyColumn: "Id",
                keyValue: new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9457), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9743), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9735), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("347087cc-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9723), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9726), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9728), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9730), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9739), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9731), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9733), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9741), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9737), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9746), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 17, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9744), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("37d57656-b9ad-4c98-8063-b70183a88115"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9890), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "BathroomTypes",
                keyColumn: "Id",
                keyValue: new Guid("692ccc6f-4721-4946-8790-b31b6707d3d3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9888), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d484004-6682-4555-a2b5-15dc28da5a60"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9843), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("af4944ce-e920-4c83-86dd-4a078182a28d"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9846), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9938), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9936), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9941), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9915), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PromoRowPlans",
                keyColumn: "Id",
                keyValue: new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9909), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("03785f9c-ecdd-4770-9b5b-78c8f3fc2341"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(57), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SanatoriumTypes",
                keyColumn: "Id",
                keyValue: new Guid("67e3166e-7810-4fa2-a4cf-b223eb7d03b1"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(59), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9960), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9962), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9965), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9957), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourSeasons",
                keyColumn: "Id",
                keyValue: new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9963), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: new Guid("155d1c26-57e7-4025-ab9e-220c5e6f7cac"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(73), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ef9b18b-8336-4719-8b3b-8e5d6351d457"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(71), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("6e335238-7a18-49bd-9a95-233a6729b49b"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(33), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("c3cae629-e754-4f4a-858e-aff906c980a4"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(35), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(36), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ce1644b1-b242-49c1-9e00-cf30941e3394"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(28), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(29), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "UserCodes",
                keyColumn: "Id",
                keyValue: new Guid("ed922b7a-222e-436c-ac0d-53c8dcc15851"),
                columns: new[] { "DateCreated", "Expires" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(12), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 11, 10, 14, 43, 9, 773, DateTimeKind.Unspecified).AddTicks(14), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e8d2464-51c3-42b5-bd0d-615e7c9f27b0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9987), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b311cf8d-af48-4129-89e0-9f16e7769558"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9993), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5e7a20f-f019-4baf-a986-a04b6b86013a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9991), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0727b36-face-4e75-9371-54908b66fb9b"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 14, 43, 9, 772, DateTimeKind.Unspecified).AddTicks(9995), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
