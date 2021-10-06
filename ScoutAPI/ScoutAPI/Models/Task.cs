using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutAPI.Models
{
    public class Task
    {
      public Int32 Task_Id { get; set; }
      public string Task_Title { get; set; }
      public string Task_Description { get; set; }
      public string Task_Status { get; set; }
      public string Date_Created { get; set; }
    }

    public class TaskForm
    {
        public string Task_Title { get; set; }
        public string Task_Description { get; set; }
    }
}