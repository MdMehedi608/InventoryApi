using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza.Domain.Entities.DataModel
{
    [Table("Unit", Schema ="Inventory")]
    public class Unit
    {
        [Key]
        [Column("UnitId")]
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}

