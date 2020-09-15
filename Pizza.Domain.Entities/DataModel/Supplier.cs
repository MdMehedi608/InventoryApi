using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza.Domain.Entities.DataModel
{
    [Table("Supplier", Schema = "Inventory")]
    public class Supplier
    {
        [Key]
        [Column("SupplierId")]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }        
        public string PostalCode { get; set; }
        public string VatNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
