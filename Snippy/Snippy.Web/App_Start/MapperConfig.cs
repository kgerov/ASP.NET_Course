using System;
using System.Linq;
using AutoMapper;
using Snippy.Models;
using Snippy.Web.Models.ViewModels;

namespace Snippy.Web.App_Start
{
    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Snippet, SnippetPreviewViewModel>()
                .ForMember(vm => vm.Labels, opt => opt.MapFrom(s => s.Labels.Select(x => new LabelPreviewViewModel() {Id = x.Id, Text = x.Text})));

            Mapper.CreateMap<Snippet, SnippetViewModel>()
                .ForMember(vm => vm.User, opt => opt.MapFrom(s => s.User.UserName))
                .ForMember(vm => vm.Labels, opt => opt.MapFrom(s => s.Labels.Select(x => new LabelViewModel { Id = x.Id, Text = x.Text})))
                .ForMember(vm => vm.Comments, opt => opt.MapFrom(s => s.Comments.OrderByDescending(c => c.CreationTime)));

            //Mapper.CreateMap<SnippetBindingModel, Snippet>()
            //    .ForMember(s => s.Language, opt => opt.MapFrom(bm => new Language() { Id = bm.LanguageId }))
            //    .ForMember(
            //    s => s.Labels,
            //    opt => opt.MapFrom(bm => bm.Labels.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(label => new Label() { Text = label })));

            //Mapper.CreateMap<Snippet, SnippetBindingModel>()
            //    .ForMember(vm => vm.LanguageId, opt => opt.MapFrom(s => s.Language.Id))
            //    .ForMember(vm => vm.Labels, opt => opt.MapFrom(s => string.Join(";", s.Labels.Select(l => l.Text))));

            Mapper.CreateMap<Label, LabelPreviewViewModel>()
                .ForMember(vm => vm.SnippetsCount, opt => opt.MapFrom(s => s.Snippets.Count));

            //Mapper.CreateMap<Label, LabelViewModel>()
            //    .ForMember(vm => vm.SnippetsCount, opt => opt.MapFrom(l => l.Snippets.Count));

            Mapper.CreateMap<Comment, CommentPreviewViewModel>()
                .ForMember(vm => vm.Username, opt => opt.MapFrom(c => c.User.UserName))
                .ForMember(vm => vm.SnippetId, opt => opt.MapFrom(c => c.Snippet.Id))
                .ForMember(vm => vm.SnippetTitle, opt => opt.MapFrom(c => c.Snippet.Title));

            Mapper.CreateMap<Comment, CommentViewModel>()
                .ForMember(vm => vm.User, opt => opt.MapFrom(c => c.User.UserName))
                .ForMember(vm => vm.SnippetId, opt => opt.MapFrom(c => c.Snippet.Id))
                .ForMember(vm => vm.SnippetTitle, opt => opt.MapFrom(c => c.Snippet.Title));

            Mapper.CreateMap<Language, LanguageViewModel>();
        }
    }
}