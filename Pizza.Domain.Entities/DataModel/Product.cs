using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza.Domain.Entities.DataModel
{
    [Table("Product", Schema = "Inventory")]
    public class Product
    {
        [Key]
        [Column("ProductId")]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int BrandId { get; set; }
        public int TypeId { get; set; }
        public int UnitId { get; set; }
        public string SerialNo { get; set; }
        public string ImageURL { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
