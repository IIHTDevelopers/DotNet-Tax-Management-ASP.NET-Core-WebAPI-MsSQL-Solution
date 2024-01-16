
using TaxManagement.BusinessLayer.Interfaces;
using TaxManagement.BusinessLayer.Services;
using TaxManagement.BusinessLayer.Services.Repository;
using TaxManagement.BusinessLayer.ViewModels;
using TaxManagement.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TaxManagement.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ITaxService _taxService;
        public readonly Mock<ITaxRepository> taxservice = new Mock<ITaxRepository>();

        private readonly Tax _tax;
        private readonly TaxViewModel _taxViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _taxService = new TaxService(taxservice.Object);

            _output = output;

            _tax = new Tax
            {
                TaxFormId= 1,
                TotalTaxAmount= 1,
                FormType="Form1",
                FilingDate= DateTime.Now,
                UserId=11
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
        public async Task<bool> Testfor_Create_Tax()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                taxservice.Setup(repos => repos.CreateTax(_tax)).ReturnsAsync(_tax);
                var result = await _taxService.CreateTax(_tax);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_Update_Tax()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                taxservice.Setup(repos => repos.UpdateTax(_taxViewModel)).ReturnsAsync(_tax);
                var result = await _taxService.UpdateTax(_taxViewModel);
                if (result != null)
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
        public async Task<bool> Testfor_GetTaxById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                taxservice.Setup(repos => repos.GetTaxById(id)).ReturnsAsync(_tax);
                var result = await _taxService.GetTaxById(id);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_DeleteTaxById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                taxservice.Setup(repos => repos.DeleteTaxById(id)).ReturnsAsync(response);
                var result = await _taxService.DeleteTaxById(id);
                //Assertion
                if (result != null)
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