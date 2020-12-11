using RPShop.Models.Entities;
using RPShop.Models.ViewModels.Comment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public interface ICommentServices
    {
        Task<IEnumerable<CommentView>> Gets(int ProductId);
        int Post(Comment model);
        int PostVote(Vote model);

    }
}
