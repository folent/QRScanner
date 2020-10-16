using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRcodeGenerate.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public int TechnologyId { get; set; }
        public int Completed { get; set; }
    }
}