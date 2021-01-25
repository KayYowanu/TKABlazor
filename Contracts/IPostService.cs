using System.Collections.Generic;
using System.Threading.Tasks;
using TKABlazor.Entities;

namespace TKABlazor.Contracts
{
    public interface IPostService
    {
        Task<int> CreatePost(TKAPosts tkaposts);
        Task<int> DeletePost(int Id);
        Task<int> CountPost(string search);
        Task<int> UpdatePost(TKAPosts tkaposts);
        Task<TKAPosts> GetPostById(int Id);
        Task<List<TKAPosts>> ListAllPosts(int skip, int take, string orderBy, string direction, string search);

        /*FOR COMMENT IMPLEMENTATION*/
        Task<int> CreateComment(TKAComments tkacomments, TKAPosts tkaposts);
        Task<int> DeleteComment(int Id);
        Task<int> CountComment(string search);
        Task<int> UpdateComment(TKAComments tkacomments);
        Task<TKAComments> GetCommentById(int Id);
        Task<List<TKAComments>> ListAllComments();
    }
}
