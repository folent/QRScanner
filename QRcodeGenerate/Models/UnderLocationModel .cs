using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QRcodeGenerate.Models
{
    [Table("UnderLocations")]
    public class UnderLocationModel
    {
        [Key]
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; } 
    }
}