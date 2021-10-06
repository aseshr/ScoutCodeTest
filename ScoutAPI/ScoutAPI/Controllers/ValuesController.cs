using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using ScoutAPI.Models;
using System.Configuration;

namespace ScoutAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly string _connstring;
        public ValuesController()
        {
            _connstring = ConfigurationManager.AppSettings["ConnString"];
        }
        
        public IHttpActionResult Get(string user)
        {
            List<Task> _tasklist = new List<Task>();
            string queryString = "SELECT * from Task_Master where usr_id = '" + user +"'";
            using (SqlConnection connection = new SqlConnection(_connstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Task _task = new Task();
                        _task.Task_Id = Convert.ToInt32(reader["task_id"]);
                        _task.Task_Title = reader["task_title"].ToString();
                        _task.Task_Description = reader["task_description"].ToString();
                        _task.Task_Status = reader["task_status"].ToString();
                        _task.Date_Created = reader["task_entered"].ToString();
                        _tasklist.Add(_task);
                        Console.WriteLine("Success");
                    }
                }
                catch(Exception ex) { Console.WriteLine(ex.Message); }
            }
            return Ok(_tasklist);
        }

        [System.Web.Http.HttpPost]
        [Route("api/values/{status}/{id}")]
        public IHttpActionResult Post(string status,int id)
        {
            using (SqlConnection connection = new SqlConnection(_connstring))
            {
                string queryString = "update a set a.task_status = '" + status+ "' from Task_Master a where task_id = " + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {}
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return Ok();

        }

        [System.Web.Http.HttpPost]
        [Route("api/values/addtask")]
        public IHttpActionResult Post([FromBody]TaskForm _form)
        {
            using (SqlConnection connection = new SqlConnection(_connstring))
            {
                string queryString = "insert into Task_Master values('"+_form.Task_Title+"','"+_form.Task_Description+"','pushpithat',getdate(),'A')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {}
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return Ok();

        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connstring))
            {
                string queryString = "delete from Task_Master where task_id =" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    { }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return Ok();
        }

        [System.Web.Http.HttpPost]
        [Route("api/values/deleteall")]
        public IHttpActionResult Post([FromBody]int[] id)
        {
            using (SqlConnection connection = new SqlConnection(_connstring))
            {
                string task_id = "";
                for(int i = 0 ;i<id.Length;i++)
                {
                    task_id = task_id + id[i].ToString() + ',';
                }
                string final_ids = task_id.Substring(0, task_id.Length - 1);
                string queryString = "delete from Task_Master where task_id in (" + final_ids + ")";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    { }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return Ok();
        }
    }

    
}
