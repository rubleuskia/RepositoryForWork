﻿using DatabaseAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        // проверь - нужен ли этот дб-сет здесь создавать (не используется сейчас)
        // еф поидее таблицу должен создать и без него
        public DbSet<FilmModel> FilmModels { get; set; }

        public DbSet<WeatherCityInfo> WeatherCityInfos { get; set; }

        public DbSet<CityModel> Cities { get; set; }

        public DbSet<UserFilmData> UserFilms { get; set; }

        // тоже не используется
        public DbSet<FilmToWeatherMap> FilmToWeatherMaps { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // а это интересно: в чем была проблема, что понадобилось такое добавлять?
            // еще посмотри на вариант - добавлять эту настройку на колонку, а не на всю базу
            // https://docs.microsoft.com/en-us/ef/core/miscellaneous/collations-and-case-sensitivity#column-collation
            base.OnModelCreating(builder.UseCollation("Cyrillic_General_CI_AS"));

            builder.Entity<CityModel>()
                .HasMany(x => x.Users)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId);

            builder.Entity<WeatherCityInfo>() //проверить правильность
                .HasOne(x => x.City)
                .WithOne(x => x.WeatherCitiesInfo)
                .HasForeignKey<CityModel>(x => x.WeatherCitiesInfoId);

            builder.Entity<UserFilmData>()
               .HasOne(x => x.User)
               .WithMany(x => x.UserFilmData)
               .HasForeignKey(x => x.UserId);

            builder.Entity<UserFilmData>()
                .HasOne(x => x.Film)
                .WithMany(x => x.UserFilmDatas)
                .HasForeignKey(x => x.FilmId);
        }
    }
} 
