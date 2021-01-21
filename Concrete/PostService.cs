using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TKABlazor.Contracts;
using TKABlazor.Entities;

namespace TKABlazor.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postrepo;

        public PostService(IPostRepo _postrepo)
        {
            this._postrepo = _postrepo;
        }

        public Task<int> CreatePost(TKAPosts tkaposts)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Title", tkaposts.Title, DbType.String);
            dbPara.Add("Description", tkaposts.Description, DbType.String);
            var PostId = Task.FromResult(_postrepo.InsertPost<int>("[dbo].[Add_Post]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return PostId;
        }

        public Task<TKAPosts> GetPostById(int id)
        {
            var tkaposts = Task.FromResult(_postrepo.GetPost<TKAPosts>($"select * from [TKAPosts] where PostId = {id}", null,
                    commandType: CommandType.Text));
            return tkaposts;
        }

        public Task<int> DeletePost(int id)
        {
            var deletepost = Task.FromResult(_postrepo.ExecutePost($"Delete from [TKAPosts] where PostId = {id}", null,
                    commandType: CommandType.Text));
            return deletepost;
        }

        public Task<int> CountPost(string search)
        {
            var totArticle = Task.FromResult(_postrepo.GetPost<int>($"select COUNT(*) from [TKAPosts] WHERE Title like '%{search}%'", null,
                    commandType: CommandType.Text));
            return totArticle;
        }

        public Task<List<TKAPosts>> ListAllPosts(int skip, int take, string orderBy, string direction = "DESC", string search = "")
        {
            var posts = Task.FromResult(_postrepo.GetAllPosts<TKAPosts>
                ($"SELECT * FROM [TKAPosts] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return posts;
        }

        public Task<int> UpdatePost(TKAPosts tkapost)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("PostId", tkapost.PostId);
            dbPara.Add("Title", tkapost.Title, DbType.String);
            dbPara.Add("Description", tkapost.Description, DbType.String);
            var updatepost = Task.FromResult(_postrepo.UpdatePost<int>("[dbo].[Update_Post]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updatepost;
        }
    }
}
