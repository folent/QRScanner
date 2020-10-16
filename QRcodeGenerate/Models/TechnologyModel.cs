using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRcodeGenerate.Models
{
    public class TechnologyModel
    {
        [Key]
        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public int Completed { get; set; }
    }
}