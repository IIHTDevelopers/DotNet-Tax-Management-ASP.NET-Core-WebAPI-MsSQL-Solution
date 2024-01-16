using TaxManagement.BusinessLayer.Interfaces;
using TaxManagement.BusinessLayer.Services.Repository;
using TaxManagement.BusinessLayer.ViewModels;
using TaxManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.BusinessLayer.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;

        public TaxService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public async Task<Tax> CreateTax(Tax tax)
        {
            return await _taxRepository.CreateTax(tax);
        }

        public async Task<bool> DeleteTaxById(long id)
        {
            return await _taxRepository.DeleteTaxById(id);
        }

        public List<Tax> GetAllTaxes()
        {
            return _taxRepository.GetAllTaxes();
        }

        public async Task<Tax> GetTaxById(long id)
        {
            return await _taxRepository.GetTaxById(id);
        }

        public async Task<Tax> UpdateTax(TaxViewModel model)
        {
            return await _taxRepository.UpdateTax(model);
        }
    }
}