using Domain.Entities;
using Domain.Enums;
using FluentEmail.Core;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HousingReservation.DataAccess
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<UserCode> UserCodes { get; set; }

        public DbSet<Sanatorium> Sanatoriums { get; set; }
        public DbSet<SanatoriumPlace> SanatoriumPlaces { get; set; }
        public DbSet<SanatoriumType> SanatoriumTypes { get; set; }
        public DbSet<SanatoriumAttribute> SanatoriumAttributes { get; set; }
        public DbSet<FavouriteSanatorium> FavouriteSanatoriums { get; set; }

        public DbSet<Domain.Entities.Attribute> Attributes { get; set; }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAttribute> RoomAttributes { get; set; }
        public DbSet<RoomGroup> RoomGroups { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }

        public DbSet<TourAgency> TourAgencies { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourDateBooking> TourDateBookings { get; set; }
        public DbSet<TourDate> TourDates { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<Domain.Entities.TourSeason> TourSeasons { get; set; }
        public DbSet<TourTourSeason> TourTourSeasons { get; set; }
        public DbSet<TourReview> TourReviews { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Place> Places { get; set; }


        public DbSet<Review> Reviews { get; set; }

        public DbSet<PromoBlock> PromoBlocks { get; set; }
        public DbSet<PromoBlockItem> PromoBlockItems { get; set; }
        public DbSet<PromoRowItem> PromoRowItems { get; set; }
        public DbSet<PromoRowPlan> PromoRowPlans { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var serviceGroup = new AttributeGroup { Id = new Guid("f993d082-7ef1-11ee-b962-0242ac120002"), Name = "Service", FriendlyName = "Услуги", IsActive = true, DateCreated = DateTimeOffset.Now };
            var sanatoriumComfortGroup = new AttributeGroup { Id = new Guid("22462aca-7ef2-11ee-b962-0242ac120002"), Name = "SanatoriumComfort", FriendlyName = "Комфорт на территории", IsActive = true, DateCreated = DateTimeOffset.Now };
            var roomComfortGroup = new AttributeGroup { Id = new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"), Name = "RoomComfort", FriendlyName = "Комфорт в номере", IsActive = true, DateCreated = DateTimeOffset.Now };

            var sanatoriumFoodGroup = new AttributeGroup { Id = new Guid("5c52815e-e12b-48fd-8429-b0cf4c3e995d"), Name = "SanatoriumFood", FriendlyName = "Питание в санатории", IsActive = true, DateCreated = DateTimeOffset.Now };
            var roomFoodGroup = new AttributeGroup { Id = new Guid("96de2246-871c-4a3d-b8e7-f179816dd483"), Name = "RoomFood", FriendlyName = "Питание в номере", IsActive = true, DateCreated = DateTimeOffset.Now };
            var roomBathroomGroup = new AttributeGroup { Id = new Guid("f2782387-51e8-4d8e-93f7-1d2ba96b09c8"), Name = "RoomBathroom", FriendlyName = "Санузел", IsActive = true, DateCreated = DateTimeOffset.Now };

            modelBuilder.Entity<AttributeGroup>().HasData(
                serviceGroup,
                sanatoriumComfortGroup,
                roomComfortGroup,
                sanatoriumFoodGroup,
                roomFoodGroup,
                roomBathroomGroup
            );

            modelBuilder.Entity<Domain.Entities.Attribute>().HasData(
                new Domain.Entities.Attribute { Id = new Guid("347087cc-7ef2-11ee-b962-0242ac120002"), FriendlyName = "Кондиционер", AttributeGroupId = roomComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("3a994c2e-7ef2-11ee-b962-0242ac120002"), FriendlyName = "Обогреватель", AttributeGroupId = roomComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("47da53a6-7ef2-11ee-b962-0242ac120002"), FriendlyName = "Утюг", AttributeGroupId = roomComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("4bd6ee92-7ef2-11ee-b962-0242ac120002"), FriendlyName = "Гладильная доска", AttributeGroupId = roomComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("534bc1ca-7ef2-11ee-b962-0242ac120002"), FriendlyName = "Телевизор", AttributeGroupId = roomComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("5dfc8f21-29c4-498c-bc0b-77ac5ab926f9"), FriendlyName = "Фен", AttributeGroupId = roomComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("2af46fa8-356e-4dd8-acc7-832f89685965"), FriendlyName = "Wi-Fi", AttributeGroupId = sanatoriumComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("a25a807c-5302-4ded-855c-eb9c7680e164"), FriendlyName = "Сауна", AttributeGroupId = sanatoriumComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("5212c976-7ddd-4a52-a09d-02e49386ecf1"), FriendlyName = "Спортзал", AttributeGroupId = sanatoriumComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("6f0a922d-8c99-4c5f-908a-4acd765d7253"), FriendlyName = "Бассейн без подогрева", AttributeGroupId = sanatoriumComfortGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("13fe5d14-ea40-498a-9a98-fcc6e75c405a"), FriendlyName = "Соляная пещера", AttributeGroupId = serviceGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("f2bded79-f60c-4db8-9d74-8a4dd6a658fa"), FriendlyName = "Радоновые ванны", AttributeGroupId = serviceGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("c17de769-798d-4d53-98c9-c8881e87f1d2"), FriendlyName = "Массаж", AttributeGroupId = serviceGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("3d057402-313b-4d79-87ac-8ddeaf2c99a7"), FriendlyName = "Ресторан", AttributeGroupId = sanatoriumFoodGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("18aa3fc7-3d11-42e9-aff7-45210c3ee030"), FriendlyName = "Кафе", AttributeGroupId = sanatoriumFoodGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("11698eb0-9f0a-45a4-9f41-ca259932e1ab"), FriendlyName = "Столовая", AttributeGroupId = sanatoriumFoodGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("ec03b886-017a-4422-8c2c-f24d8f37ac1c"), FriendlyName = "Отдельная кухня в номере", AttributeGroupId = roomFoodGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("2bcfe13b-790f-421f-9495-209944f3ce0d"), FriendlyName = "Отдельный в номере", AttributeGroupId = roomBathroomGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now },
                new Domain.Entities.Attribute { Id = new Guid("83ff8a5c-f4ab-42c5-9897-dd8a9fd5bedc"), FriendlyName = "На этаже общий", AttributeGroupId = roomBathroomGroup.Id, IsActive = true, DateCreated = DateTimeOffset.Now }
            );

            modelBuilder.Entity<PromoRowPlan>().HasData(
                new PromoRowPlan { Id = new Guid("c961ccd1-f8f7-40aa-aaa2-a4ecd89fff8b"), DateCreated = DateTimeOffset.UtcNow, Days = 30, Name = "1 месяц", Price = 5000, Deleted = false, IsActive = true },
                new PromoRowPlan { Id = new Guid("8a8aadba-0a2b-40e8-a6c5-5409136b44c6"), DateCreated = DateTimeOffset.UtcNow, Days = 180, Name = "6 месяцев", Price = 25000, Deleted = false, IsActive = true },
                new PromoRowPlan { Id = new Guid("049a090c-96ed-42e2-93a0-3d7f687a9f11"), DateCreated = DateTimeOffset.UtcNow, Days = 360, Name = "12 месяцев", Price = 45000, Deleted = false, IsActive = true }
            );

            modelBuilder.Entity<PromoBlock>().HasData(
                new PromoBlock { Id = new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Промо блок 1", Price = 5000 },
                new PromoBlock { Id = new Guid("03edae16-f426-4a37-8a83-081a44c3e17a"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Промо блок 2", Price = 5000 },
                new PromoBlock { Id = new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Промо блок 3", Price = 5000 }
                );

            modelBuilder.Entity<Domain.Entities.TourSeason>().HasData(
                new Domain.Entities.TourSeason { Id = new Guid("a870a5ca-f146-4faf-87ec-e482b2a5b96b"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Зима", Value = 0 },
                new Domain.Entities.TourSeason { Id = new Guid("1d1b1fb6-3bb5-47bc-a29c-e1448f4c354f"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Весна", Value = 1 },
                new Domain.Entities.TourSeason { Id = new Guid("4c00d748-1da9-42e0-8a2f-5bd5efb9f228"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Лето", Value = 2 },
                new Domain.Entities.TourSeason { Id = new Guid("fe73dfc4-17b6-425a-b6fb-38739e74369e"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Осень", Value = 3 },
                new Domain.Entities.TourSeason { Id = new Guid("7c63ca4c-bdeb-4fbf-b143-f8fa8b051865"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Круглогодично", Value = 4 }
                );

            modelBuilder.Entity<User>().HasData(
               new User { Id = new Guid("9e8d2464-51c3-42b5-bd0d-615e7c9f27b0"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Role = Role.Admin, Email = "admin@test.ru"},
               new User { Id = new Guid("c5e7a20f-f019-4baf-a986-a04b6b86013a"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Role = Role.TourAgencyAdmin, Email = "touragency@test.ru" },
               new User { Id = new Guid("b311cf8d-af48-4129-89e0-9f16e7769558"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Role = Role.SanatoriumAdmin, Email = "sanatorium@test.ru" },
               new User
               {
                   Id = new Guid("e0727b36-face-4e75-9371-54908b66fb9b"),
                   DateCreated = DateTimeOffset.UtcNow,
                   Deleted = false,
                   IsActive = true,
                   Role = Role.User,
                   Email = "user@test.ru"
               }
               );

            modelBuilder.Entity<UserCode>().HasData(
                 new UserCode { Id = new Guid("ed922b7a-222e-436c-ac0d-53c8dcc15851"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Code = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c", Expires = DateTimeOffset.UtcNow.AddMonths(10), UserId = new Guid("9e8d2464-51c3-42b5-bd0d-615e7c9f27b0") },
                 new UserCode { Id = new Guid("ce1644b1-b242-49c1-9e00-cf30941e3394"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Code = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c", Expires = DateTimeOffset.UtcNow.AddMonths(10), UserId = new Guid("c5e7a20f-f019-4baf-a986-a04b6b86013a") },
                 new UserCode { Id = new Guid("6e335238-7a18-49bd-9a95-233a6729b49b"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Code = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c", Expires = DateTimeOffset.UtcNow.AddMonths(10), UserId = new Guid("b311cf8d-af48-4129-89e0-9f16e7769558") },
                 new UserCode { Id = new Guid("c3cae629-e754-4f4a-858e-aff906c980a4"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Code = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c", Expires = DateTimeOffset.UtcNow.AddMonths(10), UserId = new Guid("e0727b36-face-4e75-9371-54908b66fb9b") }
                );

            modelBuilder.Entity<SanatoriumType>().HasData(
                new SanatoriumType { Id = new Guid("03785f9c-ecdd-4770-9b5b-78c8f3fc2341"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Санаторий" },
                new SanatoriumType { Id = new Guid("67e3166e-7810-4fa2-a4cf-b223eb7d03b1"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Пансионат" });

            modelBuilder.Entity<TourType>().HasData(
                new TourType { Id = new Guid("2ef9b18b-8336-4719-8b3b-8e5d6351d457"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Экскурсия" },
                new TourType { Id = new Guid("155d1c26-57e7-4025-ab9e-220c5e6f7cac"), DateCreated = DateTimeOffset.UtcNow, Deleted = false, IsActive = true, Name = "Экспедиция" });

            QueryFilter( modelBuilder );
        }

        private void QueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<UserRefreshToken>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<UserCode>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Sanatorium>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<SanatoriumPlace>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<SanatoriumType>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<SanatoriumAttribute>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Domain.Entities.Attribute>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<AttributeGroup>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Room>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<RoomAttribute>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<RoomGroup>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<RoomReservation>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<TourAgency>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Tour>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<TourDateBooking>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<TourDate>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<TourType>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Photo>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Place>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Review>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<PromoBlock>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<PromoBlockItem>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<PromoRowItem>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<PromoRowPlan>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Contact>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Guest>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Subject>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<Domain.Entities.TourSeason>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<TourTourSeason>().HasQueryFilter(x => !x.Deleted);
        }



    }
}
