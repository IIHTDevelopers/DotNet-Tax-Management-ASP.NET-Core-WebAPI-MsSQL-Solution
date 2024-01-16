using TaxManagement.BusinessLayer.Interfaces;
using TaxManagement.BusinessLayer.ViewModels;
using TaxManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaxManagement.Controllers
{
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;
        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpPost]
        [Route("create-tax")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTax([FromBody] Tax model)
        {
            var TaxExists = await _taxService.GetTaxById(model.TaxFormId);
            if (TaxExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Tax already exists!" });
            var result = await _taxService.CreateTax(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Tax creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Tax created successfully!" });

        }


        [HttpPut]
        [Route("update-tax")]
        public async Task<IActionResult> UpdateTax([FromBody] TaxViewModel model)
        {
            var Tax = await _taxService.UpdateTax(model);
            if (Tax == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Tax With Id = {model.TaxFormId} cannot be found" });
            }
            else
            {
                var result = await _taxService.UpdateTax(model);
                return Ok(new Response { Status = "Success", Message = "Tax updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("delete-Tax")]
        public async Task<IActionResult> DeleteTax(long id)
        {
            var Tax = await _taxService.GetTaxById(id);
            if (Tax == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Tax With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _taxService.DeleteTaxById(id);
                return Ok(new Response { Status = "Success", Message = "Tax deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-Tax-by-id")]
        public async Task<IActionResult> GetTaxById(long id)
        {
            var Tax = await _taxService.GetTaxById(id);
            if (Tax == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Tax With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Tax);
            }
        }

        [HttpGet]
        [Route("get-all-taxes")]
        public async Task<IEnumerable<Tax>> GetAllTaxes()
        {
            return _taxService.GetAllTaxes();
        }
    }
}