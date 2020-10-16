using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QRcodeGenerate.Models
{
    [Table("Machine")]
    public class MachineModel
    {
        [Key]
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int UnderLocationId { get; set; }
        public string Name { get; set; } 
    }
}