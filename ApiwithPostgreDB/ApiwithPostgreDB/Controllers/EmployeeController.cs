using ApiwithPostgreDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace ApiwithPostgreDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select EmployeeID as EmployeeID, EmployeeName as EmployeeName, Department as Department, to_char(DateofJoining,'YYYY-MM-DD') as DateofJoining, PhotoFileName as PhotoFileName from Employee";

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
        public JsonResult Post(Employee employee)
        {
            string query = @"insert into Employee(EmployeeName,Department,DateofJoining,PhotoFileName) values (@EmployeeName,@Department,@DateofJoining,@PhotoFileName)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            NpgsqlDataReader myreader;
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, npgsqlConnection))
                {
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@DateofJoining", Convert.ToDateTime(employee.DateofJoining));
                    command.Parameters.AddWithValue("@PhotoFileName", employee.PhotoFileName);
                    myreader = command.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    npgsqlConnection.Close();
                }
            }
            return new JsonResult("Added success");
        }
        [HttpPut]
        public JsonResult Put(Employee employee)
        {
            string query = @"update Employee set EmployeeName = @EmployeeName,Department=@Department,DateofJoining=@DateofJoining,PhotoFileName=@PhotoFileName  where EmployeeID=@EmployeeID";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            NpgsqlDataReader myreader;
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, npgsqlConnection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@DateofJoining",Convert.ToDateTime(employee.DateofJoining));
                    command.Parameters.AddWithValue("@PhotoFileName", employee.PhotoFileName);
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
            string query = @"delete from Employee where EmployeeID=@EmployeeID";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            NpgsqlDataReader myreader;
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, npgsqlConnection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", id);
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
