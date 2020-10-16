using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QRcodeGenerate.Models
{
    [Table("Operations")]
    public class OperationModel
    {
        [Key]
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int UnderLocationId { get; set; }
        public int MachineId { get; set; }
        public string Name { get; set; } 
    }
 
}