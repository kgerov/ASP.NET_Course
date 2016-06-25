using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StreamPowered.Models;

namespace StreamPowered.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StreamPowered.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StreamPowered.Data.ApplicationDbContext";
        }

        protected override void Seed(StreamPowered.Data.ApplicationDbContext context)
        {
            SeedRolesAndUsers(context);
            SeedGenres(context);
            SeedImage(context);
            SeedGames(context);
            SeedRatings(context);
            SeedReviews(context);
        }

        private static void SeedRolesAndUsers(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User() { UserName = "admin", Email = "admin@example.com" };

                manager.Create(user, "adminPass123");
                manager.AddToRole(user.Id, "Admin");

                user = new User { UserName = "Student", Email = "Student@softuni.bg" };
                manager.Create(user, "studentPass123");

                user = new User() { UserName = "fiLeV", Email = "fiLeV@gmail.com" };
                manager.Create(user, "FiLevs!Sup3rS3cr37!P@ssw0rd");
            }
        }

        private static void SeedGenres(ApplicationDbContext context)
        {
            context.Genres.AddOrUpdate(
                l => l.Id,
                new Genre() { Id = 1, Name = "Action" },
                new Genre() { Id = 2, Name = "RPG" },
                new Genre() { Id = 3, Name = "Funny" },
                new Genre() { Id = 4, Name = "Strategy" },
                new Genre() { Id = 5, Name = "Adventure" },
                new Genre() { Id = 6, Name = "Casual" },
                new Genre() { Id = 7, Name = "Racing" },
                new Genre() { Id = 8, Name = "Sports" },
                new Genre() { Id = 9, Name = "Simulation" });

            context.SaveChanges();
        }

        private static void SeedImage(ApplicationDbContext context)
        {
            context.Images.AddOrUpdate(
                l => l.Id,
                new Image() { Id = 1, Url = "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_34090867f1a02b6c17652ba9043e3f622ed985a9.600x338.jpg?t=1447694262" },
                new Image() { Id = 2, Url = "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_1d30c9a215fd621e2fd74f40d93b71587bf6409c.600x338.jpg?t=1447694262" },
                new Image() { Id = 3, Url = "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_baa02e979cd3852e3c4182afcd603ab64e3502f9.600x338.jpg?t=1447694262" },
                new Image() { Id = 4, Url = "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_ffe584c163a2b16e9c1b733b1c8e2ba669fb1204.600x338.jpg?t=1447694262" }, // End Game 1
                new Image() { Id = 5, Url = "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_4733a1f56becbff21118435bd49561d0ed2392e7.600x338.jpg?t=1447358782" },
                new Image() { Id = 6, Url = "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_f7861bd71e6c0c218d8ff69fb1c626aec0d187cf.600x338.jpg?t=1447358782" },
                new Image() { Id = 7, Url = "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_910437ac708aed7c028f6e43a6224c633d086b0a.600x338.jpg?t=1447358782" }, // End Game 2
                new Image() { Id = 8, Url = "http://cdn.akamai.steamstatic.com/steam/apps/570/ss_09f21774b2309fcb67a2d9f8b385b47c48e985ff.600x338.jpg?t=1447883099" },
                new Image() { Id = 9, Url = "http://cdn.akamai.steamstatic.com/steam/apps/570/ss_2a951d65c6084004dcdc292d4944c0fb4a059624.600x338.jpg?t=1447883099" },
                new Image() { Id = 10, Url = "http://cdn.akamai.steamstatic.com/steam/apps/570/ss_6a426a8d2d15ce7d7d9077f81c95daf3257fe387.600x338.jpg?t=1447883099" }, // End Game 3
                new Image() { Id = 11, Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_ea78dfa1d7d81c3781287cab165f64ca70f1f2ea.600x338.jpg?t=1447687485" },
                new Image() { Id = 12, Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_d1555f147b4667f70fac769985df629cbfda40b8.600x338.jpg?t=1447687485" },
                new Image() { Id = 13, Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_680684304e38a9c58a55866cde99469ae8ef510c.600x338.jpg?t=1447687485" },
                new Image() { Id = 14, Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_be2b9e45c671f95b8bc9fde58dbbd1154b0b633a.600x338.jpg?t=1447687485" },
                new Image() { Id = 15, Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_54a59b51d9a3dbd5cf6b8d8745716b293633a50b.600x338.jpg?t=1447687485" }, // End og Game 4
                new Image() { Id = 16, Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002574.600x338.jpg?t=1447886799" },
                new Image() { Id = 17, Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002575.600x338.jpg?t=1447886799" },
                new Image() { Id = 18, Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002576.600x338.jpg?t=1447886799" },
                new Image() { Id = 19, Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002577.600x338.jpg?t=1447886799" },
                new Image() { Id = 20, Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002579.600x338.jpg?t=1447886799" }, // End of game 5
                new Image() { Id = 21, Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_4162b10390d84aa600e5ed895fdc885482eb2e71.600x338.jpg?t=1421333577" },
                new Image() { Id = 22, Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_ff27d52a103d1685e4981673c4f700b860cb23de.600x338.jpg?t=1421333577" },
                new Image() { Id = 23, Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_65ec9828538eac8db20efc8149990060911fefc4.600x338.jpg?t=1421333577" },
                new Image() { Id = 24, Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_c13ffded1d71bedfa7ede94c11cbd21fbd21a32c.600x338.jpg?t=1421333577" },
                new Image() { Id = 25, Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/0000000827.600x338.jpg?t=1421333577" }, // End of Game 6
                new Image() { Id = 26, Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_e86e8ce863bd67f5fcc5f03b1f4cf75a76f711b6.600x338.jpg?t=1448057367" },
                new Image() { Id = 27, Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_47d9116d5268cf8a64c452cb0f26809a9eaec2e5.600x338.jpg?t=1448057367" },
                new Image() { Id = 28, Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_d0aea9deb102217936445c11b930b915d974e4e3.600x338.jpg?t=1448057367" },
                new Image() { Id = 29, Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_ba7a42fc33abe1b3a616531bbd65aab2e4cb9af4.600x338.jpg?t=1448057367" },
                new Image() { Id = 30, Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_bba495d434a53719c0ff80b77f179c09979e8a09.600x338.jpg?t=1448057367" },
                new Image() { Id = 31, Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_a70d9b23cbd9a7241bdb2795a678fcc2c39d3df4.600x338.jpg?t=1448057367" }); // End of game 7

            context.SaveChanges();
        }

        private static void SeedGames(ApplicationDbContext context)
            {
                var image1 = context.Images.FirstOrDefault(image => image.Id == 1);
                var image2 = context.Images.FirstOrDefault(image => image.Id == 2);
                var image3 = context.Images.FirstOrDefault(image => image.Id == 3);
                var image4 = context.Images.FirstOrDefault(image => image.Id == 4);
                var image5 = context.Images.FirstOrDefault(image => image.Id == 5);
                var image6 = context.Images.FirstOrDefault(image => image.Id == 6);
                var image7 = context.Images.FirstOrDefault(image => image.Id == 7);
                var image8 = context.Images.FirstOrDefault(image => image.Id == 8);
                var image9 = context.Images.FirstOrDefault(image => image.Id == 9);
                var image10 = context.Images.FirstOrDefault(image => image.Id == 10);
                var image11 = context.Images.FirstOrDefault(image => image.Id == 11);
                var image12 = context.Images.FirstOrDefault(image => image.Id == 12);
                var image13 = context.Images.FirstOrDefault(image => image.Id == 13);
                var image14 = context.Images.FirstOrDefault(image => image.Id == 14);
                var image15 = context.Images.FirstOrDefault(image => image.Id == 15);
                var image16 = context.Images.FirstOrDefault(image => image.Id == 16);
                var image17 = context.Images.FirstOrDefault(image => image.Id == 17);
                var image18 = context.Images.FirstOrDefault(image => image.Id == 18);
                var image19 = context.Images.FirstOrDefault(image => image.Id == 19);
                var image20 = context.Images.FirstOrDefault(image => image.Id == 20);
                var image21 = context.Images.FirstOrDefault(image => image.Id == 21);
                var image22 = context.Images.FirstOrDefault(image => image.Id == 22);
                var image23 = context.Images.FirstOrDefault(image => image.Id == 23);
                var image24 = context.Images.FirstOrDefault(image => image.Id == 24);
                var image25 = context.Images.FirstOrDefault(image => image.Id == 25);
                var image26 = context.Images.FirstOrDefault(image => image.Id == 26);
                var image27 = context.Images.FirstOrDefault(image => image.Id == 27);
                var image28 = context.Images.FirstOrDefault(image => image.Id == 28);
                var image29 = context.Images.FirstOrDefault(image => image.Id == 29);
                var image30 = context.Images.FirstOrDefault(image => image.Id == 30);
                var image31 = context.Images.FirstOrDefault(image => image.Id == 31);

                var admin = context.Users.FirstOrDefault(u => u.UserName == "admin");

                context.Games.AddOrUpdate(
                    s => s.Id,
                    new Game()
                    {
                        Id = 1,
                        Title = "Counter-Strike: Global Offensive",
                        Description = "Counter-Strike: Global Offensive (CS: GO) will expand upon the team-based action gameplay that it pioneered when it was launched 14 years ago. CS: GO features new maps, characters, and weapons and delivers updated versions of the classic CS content (de_dust, etc.).",
                        SystemRequirements = "Windows\r\nMINIMUM: \r\nOS: Windows� 7/Vista/XP \r\nProcessor: Intel� Core� 2 Duo E6600 or AMD Phenom� X3 8750 processor or better \r\nMemory: 2 GB RAM \r\nGraphics: Video card must be 256 MB or more and should be a DirectX 9-compatible with support for Pixel Shader 3.0 \r\nDirectX: Version 9.0c \r\nHard Drive: 8 GB available space",
                        Author = admin,
                        GenreId = context.Genres.FirstOrDefault(genre => genre.Name == "Action").Id,
                        Images = new[] { image1, image2, image3, image4 }
                    },
                    new Game()
                    {
                        Id = 2,
                        Title = "Fallout 4",
                        Description = "Bethesda Game Studios, the award-winning creators of Fallout 3 and The Elder Scrolls V: Skyrim, welcome you to the world of Fallout 4 � their most ambitious game ever, and the next generation of open-world gaming.",
                        SystemRequirements = "MINIMUM: \r\nOS: Windows 7/8/10 (64-bit OS required) \r\nProcessor: Intel Core i5-2300 2.8 GHz/AMD Phenom II X4 945 3.0 GHz or equivalent \r\nMemory: 8 GB RAM \r\nGraphics: NVIDIA GTX 550 Ti 2GB/AMD Radeon HD 7870 2GB or equivalent \r\nHard Drive: 30 GB available space\r\nRECOMMENDED: \r\nOS: Windows 7/8/10 (64-bit OS required) \r\nProcessor: Intel Core i7 4790 3.6 GHz/AMD FX-9590 4.7 GHz or equivalent \r\nMemory: 8 GB RAM \r\nGraphics: NVIDIA GTX 780 3GB/AMD Radeon R9 290X 4GB or equivalent \r\nHard Drive: 30 GB available space",
                        Author = admin,
                        GenreId = context.Genres.FirstOrDefault(genre => genre.Name == "Action").Id,
                        Images = new[] { image5, image6, image7 }
                    },
                    new Game()
                    {
                        Id = 3,
                        Title = "Dota 2",
                        Description = "Dota is a competitive game of action and strategy, played both professionally and casually by millions of passionate fans worldwide. Players pick from a pool of over a hundred heroes, forming two teams of five players.",
                        SystemRequirements = "Windows\r\nMINIMUM: \r\nOS: Windows 7 \r\nProcessor: Dual core from Intel or AMD at 2.8 GHz \r\nMemory: 4 GB RAM \r\nGraphics: nVidia GeForce 8600/9600GT, ATI/AMD Radeon HD2600/3600 \r\nDirectX: Version 9.0c \r\nNetwork: Broadband Internet connection \r\nHard Drive: 8 GB available space \r\nSound Card: DirectX Compatible",
                        Author = admin,
                        GenreId = context.Genres.FirstOrDefault(genre => genre.Name == "Strategy").Id,
                        Images = new[] { image8, image9, image10 }
                    },
                    new Game()
                    {
                        Id = 4,
                        Title = "Grand Theft Auto V",
                        Description = "A young street hustler, a retired bank robber and a terrifying psychopath must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody, least of all each other.",
                        SystemRequirements = "MINIMUM: \r\nOS: Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1, Windows Vista 64 Bit Service Pack 2* (*NVIDIA video card recommended if running Vista OS) \r\nProcessor: Intel Core 2 Quad CPU Q6600 @ 2.40GHz (4 CPUs) / AMD Phenom 9850 Quad-Core Processor (4 CPUs) @ 2.5GHz \r\nMemory: 4 GB RAM \r\nGraphics: NVIDIA 9800 GT 1GB / AMD HD 4870 1GB (DX 10, 10.1, 11) \r\nHard Drive: 65 GB available space \r\nSound Card: 100% DirectX 10 compatible\r\nRECOMMENDED: \r\nOS: Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1 \r\nProcessor: Intel Core i5 3470 @ 3.2GHz (4 CPUs) / AMD X8 FX-8350 @ 4GHz (8 CPUs) \r\nMemory: 8 GB RAM \r\nGraphics: NVIDIA GTX 660 2GB / AMD HD 7870 2GB \r\nHard Drive: 65 GB available space \r\nSound Card: 100% DirectX 10 compatible",
                        Author = admin,
                        GenreId = context.Genres.FirstOrDefault(genre => genre.Name == "Adventure").Id,
                        Images = new[] { image11, image12, image13, image14, image15 }
                    },
                    new Game()
                    {
                        Id = 5,
                        Title = "Team Fortress 2",
                        Description = "Nine distinct classes provide a broad range of tactical abilities and personalities. Constantly updated with new game modes, maps, equipment and, most importantly, hats!",
                        SystemRequirements = "Windows\r\nMINIMUM: \r\nOS: Windows� 7 (32/64-bit)/Vista/XP \r\nProcessor: 1.7 GHz Processor or better \r\nMemory: 512 MB RAM \r\nDirectX: Version 8.1 \r\nNetwork: Broadband Internet connection \r\nHard Drive: 15 GB available space \r\nAdditional Notes: Mouse, Keyboard\r\nRECOMMENDED: \r\nOS: Windows� 7 (32/64-bit) \r\nProcessor: Pentium 4 processor (3.0GHz, or better) \r\nMemory: 1 GB RAM \r\nDirectX: Version 9.0c \r\nNetwork: Broadband Internet connection \r\nHard Drive: 15 GB available space \r\nAdditional Notes: Mouse, Keyboard",
                        Author = admin,
                        GenreId = context.Genres.FirstOrDefault(genre => genre.Name == "Action").Id,
                        Images = new[] { image16, image17, image18, image19, image20 }
                    },
                    new Game()
                    {
                        Id = 6,
                        Title = "Garry's Mod",
                        Description = "Garry's Mod is a physics sandbox. There aren't any predefined aims or goals. We give you the tools and leave you to play.",
                        SystemRequirements = "Windows\r\nMINIMUM:  \r\nOS: Windows� Vista/XP/2000 \r\nProcessor: 1.8 GHz Processor \r\nMemory: 2GB RAM \r\nGraphics: DirectX� 9 level Graphics Card (Requires support for SSE) \r\nHard Drive: 1GB \r\nOther Requirements: Internet Connection\r\nMac OS X\r\nMINIMUM: OS X version Snow Leopard 10.6.3, 2GB RAM, NVIDIA GeForce 8 or higher, ATI X1600 or higher, or Intel HD 3000 or higher Mouse, Keyboard, Internet Connection, Monitor",
                        Author = admin,
                        GenreId = context.Genres.FirstOrDefault(genre => genre.Name == "Funny").Id,
                        Images = new[] { image21, image22, image23, image24, image25 }
                    },
                    new Game()
                    {
                        Id = 7,
                        Title = "Verdun",
                        Description = "Verdun is the first multiplayer FPS set in a realistic First World War setting. The merciless trench warfare offers a unique battlefield experience, immersing you and your squad into intense battles of attack and defense.",
                        SystemRequirements = "Windows\r\nMINIMUM: \r\nOS: Windows Vista/7/8 \r\nProcessor: Intel Core2 Duo 2.4Ghz or Higher / AMD 3Ghz or Higher \r\nMemory: 3 GB RAM \r\nGraphics: Geforce GTX 960M / Radeon HD 7750 or higher, 1GB video card memory \r\nDirectX: Version 9.0c \r\nNetwork: Broadband Internet connection \r\nHard Drive: 12 GB available space \r\nAdditional Notes: Multiplayer only, make sure you have a stable and fast internet connection.\r\nRECOMMENDED: \r\nMemory: 4 GB RAM \r\nGraphics: 2GB video card memory",
                        Author = admin,
                        GenreId = context.Genres.FirstOrDefault(genre => genre.Name == "Strategy").Id,
                        Images = new[] { image26, image27, image28, image29, image30, image31 }
                    });

                context.SaveChanges();
        }

        private static void SeedRatings(ApplicationDbContext context)
        {
            var admin = context.Users.FirstOrDefault(u => u.UserName == "admin");
            var Student = context.Users.FirstOrDefault(u => u.UserName == "Student");
            var fiLeV = context.Users.FirstOrDefault(u => u.UserName == "fiLeV");

            context.Ratings.AddOrUpdate(
                c => c.Id,
                new Rating()
                {
                    Id = 1,
                    Value = 5,
                    Author = Student,
                    Game = context.Games.Find(1)
                },
                new Rating()
                {
                    Id = 2,
                    Value = 4,
                    Author = admin,
                    Game = context.Games.Find(1)
                },
                new Rating()
                {
                    Id = 3,
                    Author = Student,
                    Value = 5,
                    Game = context.Games.Find(1)
                },
                new Rating()
                {
                    Id = 4,
                    Author = fiLeV,
                    Value = 5,
                    Game = context.Games.Find(2)
                },
                new Rating()
                {
                    Id = 5,
                    Author = fiLeV,
                    Value = 4,
                    Game = context.Games.Find(2)
                },
                new Rating()
                {
                    Id = 6,
                    Author = fiLeV,
                    Value = 2,
                    Game = context.Games.Find(2)
                },
                new Rating()
                {
                    Id = 7,
                    Author = fiLeV,
                    Value = 5,
                    Game = context.Games.Find(3)
                },
                new Rating()
                {
                    Id = 8,
                    Author = Student,
                    Value = 4,
                    Game = context.Games.Find(3)
                },
                new Rating()
                {
                    Id = 9,
                    Author = admin,
                    Value = 5,
                    Game = context.Games.Find(3)
                },
                new Rating()
                {
                    Id = 10,
                    Author = fiLeV,
                    Value = 4,
                    Game = context.Games.Find(4)
                },
                new Rating()
                {
                    Id = 11,
                    Author = Student,
                    Value = 5,
                    Game = context.Games.Find(4)
                },
                new Rating()
                {
                    Id = 12,
                    Author = fiLeV,
                    Value = 5,
                    Game = context.Games.Find(4)
                },
                new Rating()
                {
                    Id = 13,
                    Author = admin,
                    Value = 5,
                    Game = context.Games.Find(5)
                },
                new Rating()
                {
                    Id = 14,
                    Author = fiLeV,
                    Value = 3,
                    Game = context.Games.Find(5)
                },
                new Rating()
                {
                    Id = 15,
                    Author = Student,
                    Value = 4,
                    Game = context.Games.Find(5)
                },
                new Rating()
                {
                    Id = 16,
                    Author = Student,
                    Value = 5,
                    Game = context.Games.Find(6)
                },
                new Rating()
                {
                    Id = 17,
                    Author = admin,
                    Value = 5,
                    Game = context.Games.Find(6)
                },
                new Rating()
                {
                    Id = 18,
                    Author = Student,
                    Value = 5,
                    Game = context.Games.Find(6)
                },
                new Rating()
                {
                    Id = 19,
                    Author = fiLeV,
                    Value = 5,
                    Game = context.Games.Find(7)
                },
                new Rating()
                {
                    Id = 20,
                    Author = admin,
                    Value = 5,
                    Game = context.Games.Find(7)
                },
                new Rating()
                {
                    Id = 21,
                    Author = admin,
                    Value = 5,
                    Game = context.Games.Find(7)
                });

            context.SaveChanges();
        }

        private static void SeedReviews(ApplicationDbContext context)
        {
            var admin = context.Users.FirstOrDefault(u => u.UserName == "admin");
            var Student = context.Users.FirstOrDefault(u => u.UserName == "Student");
            var fiLeV = context.Users.FirstOrDefault(u => u.UserName == "fiLeV");

            context.Reviews.AddOrUpdate(
                c => c.Id,
                new Review()
                {
                    Id = 1,
                    CreationTime = Convert.ToDateTime("2015-01-21T00:00:00"),
                    Content = "i recommend this game",
                    Author = Student,
                    Game = context.Games.Find(1)
                },
                new Review()
                {
                    Id = 2,
                    CreationTime = Convert.ToDateTime("2014-03-12T00:00:00"),
                    Content = "The good CS with a lot of new benefits and bonuses",
                    Author = fiLeV,
                    Game = context.Games.Find(1)
                },
                new Review()
                {
                    Id = 3,
                    CreationTime = Convert.ToDateTime("2014-10-10T00:00:00"),
                    Content = "It's like Dota 2 but with less wizards and more Russians.",
                    Author = Student,
                    Game = context.Games.Find(1)
                },
                new Review()
                {
                    Id = 4,
                    CreationTime = Convert.ToDateTime("2015-09-14T00:00:00"),
                    Content = "I have lost 10lbs since starting Fallout 4 because I keep forgetting to eat. 10/10 - best fitness game on Steam.",
                    Author = admin,
                    Game = context.Games.Find(2)
                },
                new Review()
                {
                    Id = 5,
                    CreationTime = Convert.ToDateTime("2015-09-14T00:00:00"),
                    Content = "Don't worry, the people who enjoy the game are too busy playing the game to write the positive reviews.\r\n\r\nedit: how is this review helpful\r\n\r\nalso for those who are calling me \"bethedrone\" or w/e I'm not defending the <3 aspects of it. Fallout 4 is a good game, but it certainly isn't the same as the previous games. It got a bit dumbed down in terms of the rpg mechanic, sure, but that doesnt mean the game is bad. I honestly had low hopes for the game and ended up pleasantly surprised.",
                    Author = admin,
                    Game = context.Games.Find(2)
                },
                new Review()
                {
                    Id = 6,
                    CreationTime = Convert.ToDateTime("2015-05-22T00:00:00"),
                    Content = "one of few games that has stood the test of time and been tended well by devlopers. maybe if everyone just abandonded this we'd get HL3 already though. I suppose Valves thinking on it is \"well we have one successfull game still, why bother making another. We use to make games, now we just make money\"",
                    Author = fiLeV,
                    Game = context.Games.Find(5)
                });

            context.SaveChanges();
        }
    }
}