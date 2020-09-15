using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza.Domain.Entities.DataModel
{
    [Table("Brand", Schema ="Inventory")]
    public class Brand
    {
        [Key]
        [Column("BrandId")]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandCode { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
