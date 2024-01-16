using TaxManagement.BusinessLayer.ViewModels;
using TaxManagement.DataLayer;
using TaxManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.BusinessLayer.Services.Repository
{
    public class TaxRepository : ITaxRepository
    {
        private readonly TaxDbContext _dbContext;
        public TaxRepository(TaxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tax> CreateTax(Tax tax)
        {
            try
            {
                var result = await _dbContext.Taxes.AddAsync(tax);
                await _dbContext.SaveChangesAsync();
                return tax;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteTaxById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Taxes.Single(a => a.TaxFormId == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Tax> GetAllTaxes()
        {
            try
            {
                var result = _dbContext.Taxes.
                OrderByDescending(x => x.TaxFormId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Tax> GetTaxById(long id)
        {
            try
            {
                return await _dbContext.Taxes.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<Tax> UpdateTax(TaxViewModel model)
        {
            var Tax = await _dbContext.Taxes.FindAsync(model.TaxFormId);
            try
            {
                Tax.FormType = model.FormType;
                Tax.TaxFormId = model.TaxFormId;
                Tax.UserId = model.UserId;
                Tax.FilingDate = model.FilingDate;
                Tax.TotalTaxAmount = model.TotalTaxAmount;

                _dbContext.Taxes.Update(Tax);
                await _dbContext.SaveChangesAsync();
                return Tax;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}