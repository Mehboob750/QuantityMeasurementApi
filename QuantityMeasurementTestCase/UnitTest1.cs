using System;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommanLayer;
using CommanLayer.Model;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementApi.Controllers;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using Xunit;

namespace QuantityMeasurementTestCase
{
    public class UnitTest1
    {
        QuantityMeasurementController quantityMeasurementController;
        IQuantityMeasurementBusiness quantityMeasurementBusiness;
        IQuantityMeasurementRepository quantityMeasurementRepository;
        ApplicationDbContext dbContext;

        public UnitTest1()
        {
            quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            quantityMeasurementBusiness = new QuantityMeasurementBusiness(quantityMeasurementRepository);
            quantityMeasurementController = new QuantityMeasurementController(quantityMeasurementBusiness);
        }

        [Fact]
        public void Test1()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "FeetToInch",
                    Value = 1
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
