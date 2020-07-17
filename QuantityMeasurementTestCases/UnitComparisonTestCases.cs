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

    public class UnitComparisonTestCases
    {
        QuantityMeasurementController quantityMeasurementController;
        IQuantityMeasurementBusiness quantityMeasurementBusiness;
        IQuantityMeasurementRepository quantityMeasurementRepository;

        public static DbContextOptions<ApplicationDbContext> Comparisons { get; }

        public static string sqlConnectionString = "Data Source=DESKTOP-EUJ5D3D;Initial Catalog=QuantityMeasurementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static UnitComparisonTestCases()
        {
            Comparisons = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(sqlConnectionString).Options;
        }

        public UnitComparisonTestCases()
        {
            var dbContext = new ApplicationDbContext(Comparisons);
            quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            quantityMeasurementBusiness = new QuantityMeasurementBusiness(quantityMeasurementRepository);
            quantityMeasurementController = new QuantityMeasurementController(quantityMeasurementBusiness);
        }

        [Fact]
        public void Given2FeetToInchAnd24Inch_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "FeetToInch",
                    FirstValue = 2,
                    SecondValueUnit = "Inch",
                    SecondValue = 24
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given1YardToInchAnd2FeetToInch_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "YardToInch",
                    FirstValue = 1,
                    SecondValueUnit = "FeetToInch",
                    SecondValue = 2
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given1YardToInchAnd36Inch_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "YardToInch",
                    FirstValue = 1,
                    SecondValueUnit = "Inch",
                    SecondValue = 36
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given14InchAnd2FeetToInch_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "Inch",
                    FirstValue = 14,
                    SecondValueUnit = "FeetToInch",
                    SecondValue = 2
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given5CentimeterToInchValueAnd2InchValue_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "CentimeterToInchValue",
                    FirstValue = 5,
                    SecondValueUnit = "Inch",
                    SecondValue = 2
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenNullAnd2InchValue_WhenCompared_ReturnsBadResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = null,
                    FirstValue = 5,
                    SecondValueUnit = "Inch",
                    SecondValue = 2
                };
                var badResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given1GallonToLitreValueAnd3point78LitreValue_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "volume",
                    FirstValueUnit = "GallonToLitre",
                    FirstValue = 1,
                    SecondValueUnit = "Litre",
                    SecondValue = 3.78
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given100MiliLitreToLitreValueAnd10LitreValue_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "volume",
                    FirstValueUnit = "MiliLitreToLitre",
                    FirstValue = 10000,
                    SecondValueUnit = "Litre",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given10LitreValueAnd10LitreValue_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "volume",
                    FirstValueUnit = "Litre",
                    FirstValue = 10,
                    SecondValueUnit = "Litre",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenNullValueAnd3point78LitreValue_WhenCompared_ReturnsBadResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "volume",
                    FirstValueUnit = null,
                    FirstValue = 1,
                    SecondValueUnit = "Litre",
                    SecondValue = 3.78
                };
                var badResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given1000GramsToKilogramValueAnd1KiloGram_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "weight",
                    FirstValueUnit = "GramsToKilogram",
                    FirstValue = 1000,
                    SecondValueUnit = "kilogram",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given1TonneToKilogramsValueAnd100KiloGram_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "weight",
                    FirstValueUnit = "TonneToKilograms",
                    FirstValue = 1,
                    SecondValueUnit = "kilogram",
                    SecondValue = 100
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given10kilogramValueAnd10KiloGram_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "weight",
                    FirstValueUnit = "kilogram",
                    FirstValue = 10,
                    SecondValueUnit = "kilogram",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenNullAnd10KiloGram_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "weight",
                    FirstValueUnit = null,
                    FirstValue = 10,
                    SecondValueUnit = "kilogram",
                    SecondValue = 10
                };
                var badResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given22FahrenheitToCelsiusAnd10Celsius_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "temperature",
                    FirstValueUnit = "FahrenheitToCelsius",
                    FirstValue = 22,
                    SecondValueUnit = "Celsius",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given150CelsiusAnd150Celsius_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "temperature",
                    FirstValueUnit = "Celsius",
                    FirstValue = 150,
                    SecondValueUnit = "Celsius",
                    SecondValue = 150
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenNullAnd150Celsius_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "temperature",
                    FirstValueUnit = null,
                    FirstValue = 150,
                    SecondValueUnit = "Celsius",
                    SecondValue = 150
                };
                var badResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void Given_WhenRead_ReturnsResult()
        {
            try
            {
                var result = quantityMeasurementController.GetAllComparison();
                Assert.IsType<OkObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
