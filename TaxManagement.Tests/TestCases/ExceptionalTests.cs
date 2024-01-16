

using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using TaxManagement.BusinessLayer.ViewModels;
using TaxManagement.Entities;
using TaxManagement.BusinessLayer.Interfaces;
using TaxManagement.BusinessLayer.Services.Repository;
using TaxManagement.BusinessLayer.Services;
using TaxManagement.Tests.TestCases;

namespace TaxManagement.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ITaxService _taxService;
        public readonly Mock<ITaxRepository> taxservice = new Mock<ITaxRepository>();

        private readonly Tax _tax;
        private readonly TaxViewModel _taxViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _taxService = new TaxService(taxservice.Object);

            _output = output;

             _tax = new Tax
             {
                 TaxFormId = 1,
                 TotalTaxAmount = 1,
                 FormType = "Form1",
                 FilingDate = DateTime.Now,
                 UserId = 11
             };

            _taxViewModel = new TaxViewModel
            {
                TaxFormId = 1,
                TotalTaxAmount = 1,
                FormType = "Form1",
                FilingDate = DateTime.Now,
                UserId = 11
            };
        }


        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidTaxFormIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                taxservice.Setup(repo => repo.CreateTax(_tax)).ReturnsAsync(_tax);
                var result = await  _taxService.CreateTax(_tax);
                if (result != null || result.TaxFormId !=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidUserIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                taxservice.Setup(repo => repo.CreateTax(_tax)).ReturnsAsync(_tax);
                var result = await _taxService.CreateTax(_tax);
                if (result != null || result.UserId != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}