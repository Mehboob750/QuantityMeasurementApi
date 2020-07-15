using System;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommanLayer;
using CommanLayer.Model;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using QuantityMeasurementApi.Controllers;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;

namespace QuantityMeasurementTesCases
{
    public class Tests
    {
        QuantityMeasurementController quantityMeasurementController;
        IQuantityMeasurementBusiness quantityMeasurementBusiness;
        IQuantityMeasurementRepository quantityMeasurementRepository;
       // ApplicationDbContext dBContext;

        [SetUp]
        public void Setup()
        {
            quantityMeasurementRepository = new QuantityMeasurementRepository();
            quantityMeasurementBusiness = new QuantityMeasurementBusiness(quantityMeasurementRepository);
            quantityMeasurementController = new QuantityMeasurementController(quantityMeasurementBusiness);
        }

        [Test]
        public async void Test1()
        {
            try
            {
                var controller = new QuantityMeasurementController(quantityMeasurementBusiness);
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "FeetToInch",
                    Value = 1
                };
               var okResult = await controller.ConvertAndAdd(result);
               // Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}