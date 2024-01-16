using TaxManagement.BusinessLayer.ViewModels;
using TaxManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.BusinessLayer.Interfaces
{
    public interface ITaxService
    {
        List<Tax> GetAllTaxes();
        Task<Tax> CreateTax(Tax tax);
        Task<Tax> GetTaxById(long id);
        Task<bool> DeleteTaxById(long id);
        Task<Tax> UpdateTax(TaxViewModel model);
    }
}
