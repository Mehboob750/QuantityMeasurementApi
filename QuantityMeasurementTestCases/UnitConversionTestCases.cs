namespace QuantityMeasurementTestCases
{
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

    public class UnitConversionTestCases
    {
        QuantityMeasurementController quantityMeasurementController;
        IQuantityMeasurementBusiness quantityMeasurementBusiness;
        IQuantityMeasurementRepository quantityMeasurementRepository;

        public static DbContextOptions<ApplicationDbContext> Quantities { get; }

        public static string sqlConnectionString = "Data Source=DESKTOP-EUJ5D3D;Initial Catalog=QuantityMeasurementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static UnitConversionTestCases()
        {
            Quantities = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(sqlConnectionString).Options;
        }

        public UnitConversionTestCases()
        {
            var dbContext = new ApplicationDbContext(Quantities);
            quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            quantityMeasurementBusiness = new QuantityMeasurementBusiness(quantityMeasurementRepository);
            quantityMeasurementController = new QuantityMeasurementController(quantityMeasurementBusiness);
        }

        [Fact]
        public void GivenFeetToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
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

        [Fact]
        public void GivenYardToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "YardToInch",
                    Value = 2
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenCentimeterToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "CentimeterToInch",
                    Value = 3
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [Fact]
        public void GivenInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "Inch",
                    Value = 8
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenGramsToKilogram_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "GramsToKilogram",
                    Value = 800
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        [Fact]
        public void GivenTonneToKilograms_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "TonneToKilograms",
                    Value = 0.7
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenKilograms_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "kilogram",
                    Value = 9
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenGallonToLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "GallonToLitre",
                    Value = 7
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenMiliLitreToLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "MiliLitreToLitre",
                    Value = 7
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "Litre",
                    Value = 15
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenTemperature_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 250
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenNull_WhenConverted_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = null,
                    ConversionType = "GramsToKilogram",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenEmpty_WhenConverted_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType ="",
                    ConversionType = "",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Givenlength_WhenConvertedIntoWeight_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "GramsToKilogram",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Givenlength_WhenConvertedIntoVolume_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "GallonToLitre",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Givenlength_WhenConvertedIntoTemperature_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenWeight_WhenConvertedIntoLength_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "FeetToInch",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [Fact]
        public void GivenWeight_WhenConvertedToVolume_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "GallonToLitre",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenWeight_WhenConvertedTemperature_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [Fact]
        public void GivenVolume_WhenConvertedLength_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "FeetToInch",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenVolume_WhenConvertTodWeight_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "GramsToKilogram",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenVolume_WhenConvertToTemperature_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenTemperature_WhenConvertLength_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "FeetToInch",
                    Value = 25
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenTemperature_WhenConvertedToVolume_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "GallonToLitre",
                    Value = 50
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenTemperature_WhenConvertedToWeight_ReturnsBadResult()
        {
            try
            {
                Quantity quantity = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "Kilogram",
                    Value = 5
                };
                var result = quantityMeasurementController.ConvertAndAdd(quantity);
                Assert.IsType<NotFoundObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
    }
}
