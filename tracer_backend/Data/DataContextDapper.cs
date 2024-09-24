using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Design;
using System.Data;
namespace tracer_backend;



public class DataContextDapper
{
    private readonly IConfiguration _config;
    // configuration to access configuration string from file
    public DataContextDapper(IConfiguration configuration){
        _config = configuration;
    }
    // load many data
    public IEnumerable<T> LoadData<T>(string sql){
        // connection
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        // execute the query
        return dbConnection.Query<T>(sql);
    }
    //  load single data
    public T LoadDataSingle<T>(string sql){
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.QuerySingle<T>(sql);
    }
    public T LoadDataSingleWithParameter<T>(string sql, object parameter){
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.QuerySingle<T>(sql,parameter);
    }
    public int ExecuteSqlWithRowCount(string sql){
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Execute(sql);
    }
    public bool ExecuteQuery(string sql){
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Execute(sql)>0;
    }
    public bool ExecuteQueryWithParameter(string sql,object parameter){
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Execute(sql,parameter)>0;
    }
}

