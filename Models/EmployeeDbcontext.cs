/*using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapperpractise.Models
{
    public class EmployeeDbcontext
    {
        private readonly IConfiguration _con;
       private readonly string? _connectionstring;
        public EmployeeDbcontext(IConfiguration Con) 
        {
            _con = Con;
            _connectionstring = Con.GetConnectionString("sample");
        }
        public IDbConnection Connetion()
        {
            var connn= new SqlConnection(_connectionstring);
            connn.Open();
            return connn;
        }
    }
}
*/