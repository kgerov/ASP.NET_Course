using System;
using System.Web.Mvc;
using AutoMapper;
using Snippy.Data.UnitOfWork;
using Snippy.Models;
using Snippy.Web.Models.ViewModels;

namespace Snippy.Web.Controllers
{
    public class CommentController : BaseController
    {
        public CommentController(ISnippyData data)
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string content, int snippetId)
        {
            Comment comment = new Comment()
            {
                Content = content,
                CreationTime = DateTime.Now,
                UserId = this.UserProfile.Id,
                SnippetId = snippetId
            };

            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            var result = Mapper.Map<CommentViewModel>(comment);

            return this.PartialView("DisplayTemplates/CommentViewModel", result);
        }

        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            return this.View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return this.HttpNotFound();
        }

        
    }
}