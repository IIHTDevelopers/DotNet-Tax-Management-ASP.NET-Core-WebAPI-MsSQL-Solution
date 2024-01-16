using System;
using System.Collections.Generic;
using System.Text;

namespace TaxManagement.BusinessLayer.ViewModels
{
    public class TaxViewModel
    {
        public long TaxFormId { get; set; }
        public string FormType { get; set; }
        public DateTime FilingDate { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public int UserId { get; set; }
    }
}
