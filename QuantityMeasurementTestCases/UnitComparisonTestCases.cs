//-----------------------------------------------------------------------
// <copyright file="UnitComparisonTestCases.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

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
    using RepositoryLayer;
    using RepositoryLayer.Interface;
    using RepositoryLayer.Services;
    using Xunit;

    /// <summary>
    /// This class contains the testcases of unit Comparison
    /// </summary>
    public class UnitComparisonTestCases
    {
        /// <summary>
        /// Created Reference of QuantityMeasurementController
        /// </summary>
        QuantityMeasurementController quantityMeasurementController;

        /// <summary>
        /// Created Reference of IQuantityMeasurementBusiness
        /// </summary>
        IQuantityMeasurementBusiness quantityMeasurementBusiness;

        /// <summary>
        /// Created Reference of IQuantityMeasurementRepository
        /// </summary>
        IQuantityMeasurementRepository quantityMeasurementRepository;

        public static DbContextOptions<ApplicationDbContext> Comparisons { get; }

        /// <summary>
        /// Connection String to connect to Database
        /// </summary>
        public static string sqlConnectionString = "Data Source=DESKTOP-EUJ5D3D;Initial Catalog=QuantityMeasurementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// static Method used to create object of Db context
        /// </summary>
        static UnitComparisonTestCases()
        {
            Comparisons = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(sqlConnectionString).Options;
        }

        /// <summary>
        /// Default constructor used to create new objects
        /// </summary>
        public UnitComparisonTestCases()
        {
            var dbContext = new ApplicationDbContext(Comparisons);
            quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            quantityMeasurementBusiness = new QuantityMeasurementBusiness(quantityMeasurementRepository);
            quantityMeasurementController = new QuantityMeasurementController(quantityMeasurementBusiness);
        }

        /// <summary>
        /// Given 2 FeetToInch And 24 Inch Comapare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 1 YardToInch And 2 FeetToInch compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 1 YardToInch And 36 Inch Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 14 Inch And 2 FeetToInch Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 5 CentimeterToInch And 2 Inch Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given Null And 2 Inch Compare returns badrequestobject
        /// </summary>
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

        /// <summary>
        /// Given 1 GallonToLitre And 3.78 Litre compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 100 MiliLitreToLitre And 10 Litre Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 10 Litre And 10 Litre Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given Null And 3.78 Litre compare returns bad request object
        /// </summary>
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

        /// <summary>
        /// Given 1000 GramsToKilogram And 1 KiloGram Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 1 TonneToKilograms And 100 KiloGram Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 10 kilogram And 10 KiloGram Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given Null And 10 KiloGram Compare returns badrequestobject
        /// </summary>
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

        /// <summary>
        /// Given 22 FahrenheitToCelsius And 10 Celsius Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given 150 Celsius And 150 Celsius Compare returns okObjectResult
        /// </summary>
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

        /// <summary>
        /// Given Null And 150 Celsius Compare returns badrequestobject
        /// </summary>
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

        /// <summary>
        /// This Method is used to get all records returns okObjectResult
        /// </summary>
        [Fact]
        public void GivenController_WhenGetAllMethodUsed_ReturnsResult()
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

        /// <summary>
        /// Given Id When GetById Method used returns okObjectResult 
        /// </summary>
        [Fact]
        public void GivenId_WhenGetByIdMethodUsed_ReturnsResult()
        {
            try
            {
                int id = 13;
                var result = quantityMeasurementController.GetComparisonById(id);
                Assert.IsType<OkObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Given Id When DeleteById Method used returns okObjectResult 
        /// </summary>
        [Fact]
        public void GivenId_WhenDeleteByIdMethodUsed_ReturnsResult()
        {
            try
            {
                int id = 11;
                var result = quantityMeasurementController.DeleteComparisonById(id);
                Assert.IsType<OkObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
