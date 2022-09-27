using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using Aspnetserver2.Models;

namespace Aspnetserver2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {

        public readonly IConfiguration _configuration;
        public TodoItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            SELECT * FROM dbo.TodoItem
                           ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using(SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            string query = @"
                            SELECT TOP 1 * FROM dbo.TodoItem
                            WHERE TodoItemId = @Id
                           ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new(sqlDataSource))
            {
                myConn.Open();
                using SqlCommand myCommand = new(query, myConn);
                myCommand.Parameters.AddWithValue("@Id", id);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myConn.Close();
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(TodoItem todo)
        {
            string query = @"
                            INSERT INTO dbo.TodoItem 
                            VALUES (@Title, @Text, 'false', getdate(), getdate())
                           ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Title", todo.TodoTitle);
                    myCommand.Parameters.AddWithValue("@Text", todo.TodoText);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPut("{id}")]
        public JsonResult Put(long id, TodoItem todo)
        {
            string query = @"
                            UPDATE dbo.TodoItem 
                            SET TodoTitle = @Title,
                            TodoText = @Text,
                            IsComplete = @IsComplete,
                            Modified = getdate() 
                            WHERE TodoItemId = @Id
                           ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Title", todo.TodoTitle);
                    myCommand.Parameters.AddWithValue("@Text", todo.TodoText);
                    myCommand.Parameters.AddWithValue("@IsComplete", todo.IsComplete);
                    myCommand.Parameters.AddWithValue("@Id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                            DELETE FROM dbo.TodoItem 
                            WHERE TodoItemId = @Id
                           ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
