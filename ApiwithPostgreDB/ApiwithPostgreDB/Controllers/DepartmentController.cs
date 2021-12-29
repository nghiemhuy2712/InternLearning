using ApiwithPostgreDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace ApiwithPostgreDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select DepartmentID as DepartmentID, DepartmentName as DepartmentName from Department";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            NpgsqlDataReader myreader;
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, npgsqlConnection))
                {
                    myreader = command.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    npgsqlConnection.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Department department)
        {
            string query = @"insert into Department(DepartmentName) values (@DepartmentName)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            NpgsqlDataReader myreader;
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, npgsqlConnection))
                {
                    command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    myreader = command.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    npgsqlConnection.Close();
                }
            }
            return new JsonResult("Added success");
        }
        [HttpPut]
        public JsonResult Put(Department department)
        {
            string query = @"update Department set DepartmentName = @DepartmentName where DepartMentID=@DepartmentID";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            NpgsqlDataReader myreader;
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, npgsqlConnection))
                {
                    command.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
                    command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    myreader = command.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    npgsqlConnection.Close();
                }
            }
            return new JsonResult("Update success");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from Department where DepartMentID=@DepartmentID";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            NpgsqlDataReader myreader;
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, npgsqlConnection))
                {
                    command.Parameters.AddWithValue("@DepartmentID", id);
                    myreader = command.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    npgsqlConnection.Close();
                }
            }
            return new JsonResult("Delete success");
        }
    }
}
