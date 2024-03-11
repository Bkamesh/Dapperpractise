using Azure.Identity;
using Dapper;
using Dapperpractise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Dapperpractise.Services
{
    /*public interface IemployeeService
    {
        
        Task<List<Employee>> Get();
        Task<List<Employee>> Getid(int id);
        Task<int> Insert(Employee emp);
        Task<int> Delete(int Id);
        Task<int> Update(Employee emp);
    }*/
    public class EmployeeService 
    {
        /*private readonly EmployeeDbcontext _em;
        public EmployeeService(EmployeeDbcontext em) 
        {
            _em = em;
        }*/

        readonly string sql_conn = "Server=KAMESH\\SQLEXPRESS; Database=sample;Integrated Security=True;Trust Server Certificate=True";
        readonly string pg_conn = "Server=localhost; Database=postgres; Port=5432; UserId=postgres; Password=kamesh20";

        public async Task<List<Employee>> Get()
        {
            string query = "Select Id from \"Employee\"";
            using (var con = new SqlConnection(sql_conn))
            {
                var empl = await con.QueryAsync<Employee>(query);
                return empl.ToList();
            }
        }

        public async Task<List<Employee>> Getid(int id)
        {
            string query = "Select * from \"Employee\" WHERE \"Id\"=@id";
            using (var con = new SqlConnection(sql_conn))
            {
                var empl = await con.QueryAsync<Employee>(query, new { id });
                return empl.ToList();
            }
        }

        public async Task<int> Insert(Employee emp)
        {
            string query = "INSERT INTO \"Employee\"(\"Id\",\"Name\",\"Dept\") VALUES(@Id,@Name,@Dept)";
            using (var con = new SqlConnection(sql_conn))
            {
                con.Open();
                int rows = await con.ExecuteAsync(query,emp);
                return rows;
            }
        }

        public async Task<int> Delete(int Id)
        {
            string query = "DELETE FROM \"Employee\" WHERE \"Id\"=@Id";
            using (var con = new SqlConnection(sql_conn))
            {
                int rows = await con.ExecuteAsync(query, new {Id});
                return rows;
            }
        }

        public async Task<int> Update(Employee emp)
        {
            string query = "UPDATE \"Employee\"SET \"Name\"=@Name,\"Dept\"=@Dept WHERE \"Id\"=@id";
            using (var con = new SqlConnection(sql_conn))
            {
                int rows = await con.ExecuteAsync(query, emp);
                return rows;
            }
        }
    }
}
