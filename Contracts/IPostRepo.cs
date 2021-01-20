using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace TKABlazor.Contracts
{
    public interface IPostRepo : IDisposable
    {
        DbConnection GetConnection();
        T GetPost<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAllPosts<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int ExecutePost(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T InsertPost<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T UpdatePost<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    }
}
