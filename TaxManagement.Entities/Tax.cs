using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaxManagement.Entities
{
    public class Tax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaxFormId { get; set; }
        public string FormType { get; set; }
        public DateTime FilingDate { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public int UserId { get; set; }
    }
}
