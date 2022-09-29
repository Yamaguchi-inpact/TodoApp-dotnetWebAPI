using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using Aspnetserver2.Models;

namespace Aspnetserver2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public readonly IConfiguration _configuration;
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            SELECT * FROM dbo.TodoCategory
                           ";

            DataTable table = new DataTable();
            // appsettings.jsonの接続文字列を取得
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            // 接続のためのオブジェクトを生成
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                // 接続開始
                myConn.Open();
                // SqlCommand：DBにSQL文を送信するためのオブジェクトを生成
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    // SqlDataReader：読み取ったデータを格納するためのオブジェクトを生成
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
            // パラメーターで中身を指定したレコードを追加
            string query = @"
                            SELECT TOP 1 * FROM dbo.TodoCategory
                            WHERE CategoryId = @Id
                           ";
            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new(sqlDataSource))
            {
                myConn.Open();
                using SqlCommand myCommand = new(query, myConn);
                // パラメーターの追加
                myCommand.Parameters.AddWithValue("@Id", id);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myConn.Close();
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Category category)
        {
            string query = @"
                            INSERT INTO dbo.TodoCategory 
                            VALUES (@Category,@Color, @State, getdate(), getdate(), 0)
                           ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Category", category.CategoryName);
                    myCommand.Parameters.AddWithValue("@Color", category.ColorId);
                    myCommand.Parameters.AddWithValue("@State", category.StateId);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPut("{id}")]
        public JsonResult Put(long id, Category category)
        {
            string query = @"
                            UPDATE dbo.TodoCategory
                            SET CategoryName = @Name,
                            StateId = @State,
                            ColorId = @Color,
                            Modified = getdate() 
                            WHERE CategoryId = @Id
                           ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Name", category.CategoryName);
                    myCommand.Parameters.AddWithValue("@State", category.StateId);
                    myCommand.Parameters.AddWithValue("@Color", category.ColorId);
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
                            DELETE FROM dbo.TodoCategory
                            WHERE CategoryId = @Id
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
