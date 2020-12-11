using Microsoft.AspNetCore.Identity;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public class CommentServices : ICommentServices
    {
        private readonly RPDbcontext context;

        public CommentServices(RPDbcontext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CommentView>> Gets(int ProductId)
        {
            var Comments = new List<CommentView>();
            var ListComment = context.Comments.Where(e => e.ProductId == ProductId);
            foreach(var item in ListComment)
            {
                var tam = new CommentView()
                {
                    Avatar = item.Avatar,
                    ProductId = item.ProductId,
                    Status = item.Status,
                    Text = item.Text,
                    Time = item.Time,
                    UserId = item.UserId,
                    Vote = item.Vote,
                    UserName = item.UserName
                };

                Comments.Add(tam);
            }
            return Comments;
        }

        public int Post(Comment model)
        {
            model.Status = true;
            model.Time = DateTime.Now;
            model.Vote = 5;
            context.Comments.Add(model);
            return context.SaveChanges();
        }

        public int PostVote(Vote model)
        {
            try
            {
                context.Votes.Add(model);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
