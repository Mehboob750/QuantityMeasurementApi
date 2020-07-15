using System;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommanLayer;
using CommanLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantityMeasurementApi.Controllers;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using Xunit;

namespace QuantityMeasurementTestCases
{
    public class QuantityMeasurementTestCases
    {
        QuantityMeasurementController quantityMeasurementController;
        IQuantityMeasurementBusiness quantityMeasurementBusiness;
        IQuantityMeasurementRepository quantityMeasurementRepository;

        public static DbContextOptions<ApplicationDbContext> Quantities { get; }

        public static string sqlConnectionString = "Data Source=DESKTOP-EUJ5D3D;Initial Catalog=QuantityMeasurementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static QuantityMeasurementTestCases()
        {
            Quantities = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(sqlConnectionString).Options;
        }

        public QuantityMeasurementTestCases()
        {
            var dbContext = new ApplicationDbContext(Quantities);
            quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            quantityMeasurementBusiness = new QuantityMeasurementBusiness(quantityMeasurementRepository);
           // quantityMeasurementController = new QuantityMeasurementController(quantityMeasurementBusiness);
        }

        [Fact]
        public void GivenFeetToInch_WhenConvertMethodUsed_ReturnsResult()
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
                var okResult = controller.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
