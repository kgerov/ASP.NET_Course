using System;
using System.Linq;
using AutoMapper;
using StreamPowered.Models;
using StreamPowered.Web.Models.ViewModels;

namespace StreamPowered.Web.App_Start
{
    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Genre, GenreViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(g => g.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(g => g.Name));

            Mapper.CreateMap<Game, GamePreviewModel>()
                .ForMember(g => g.Rating, s => s.MapFrom(gp => (gp.Ratings.Sum(r => r.Value) * 1.0) / gp.Ratings.Count))
                .ForMember(g => g.Image, s => s.MapFrom(gp => gp.Images.FirstOrDefault().Url));

            Mapper.CreateMap<Review, ReviewPreviewModel>()
                .ForMember(g => g.User, s => s.MapFrom(gp => gp.Author.UserName))
                .ForMember(g => g.GameId, s => s.MapFrom(gp => gp.Game.Id))
                .ForMember(g => g.Game, s => s.MapFrom(gp => gp.Game.Title));

            Mapper.CreateMap<Review, ReviewModel>()
                .ForMember(g => g.User, s => s.MapFrom(gp => gp.Author.UserName));

            Mapper.CreateMap<Game, GameViewModel>()
                .ForMember(g => g.Rating, s => s.MapFrom(gp => (gp.Ratings.Sum(r => r.Value) * 1.0) / gp.Ratings.Count))
                .ForMember(g => g.Images, s => s.MapFrom(gp => gp.Images.Select(i => i.Url)))
                .ForMember(g => g.Genre, s => s.MapFrom(gp => gp.Genre))
                .ForMember(g => g.Reviews, s => s.MapFrom(gp => gp.Reviews.OrderByDescending(r => r.CreationTime)))
                .ForMember(g => g.UsersRatings, s => s.MapFrom(gp => gp.Ratings.Select(x => new UserRatingsViewModel(){ Username = x.Author.UserName, Rating = x.Value})));

            Mapper.CreateMap<Genre, GenreDetailsViewModel>()
                .ForMember(g => g.Name, s => s.MapFrom(gp => gp.Name))
                .ForMember(g => g.Id, s => s.MapFrom(gp => gp.Id))
                .ForMember(g => g.Games, s => s.MapFrom(gp => gp.Games.OrderBy(x => x.Title)));
        }
    }
}