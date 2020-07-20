//-----------------------------------------------------------------------
// <copyright file="UnitConversionTestCases.cs" company="BridgeLabz Solution">
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
    /// This class contains the testcases of unit conversion
    /// </summary>
    public class UnitConversionTestCases
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

        public static DbContextOptions<ApplicationDbContext> Quantities { get; }

        /// <summary>
        /// Connection String to connect to Database
        /// </summary>
        public static string sqlConnectionString = "Data Source=DESKTOP-EUJ5D3D;Initial Catalog=QuantityMeasurementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// static Method used to create object of Db context
        /// </summary>
        static UnitConversionTestCases()
        {
            Quantities = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(sqlConnectionString).Options;
        }

        /// <summary>
        /// Default constructor used to create new objects
        /// </summary>
        public UnitConversionTestCases()
        {
            var dbContext = new ApplicationDbContext(Quantities);
            quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            quantityMeasurementBusiness = new QuantityMeasurementBusiness(quantityMeasurementRepository);
            quantityMeasurementController = new QuantityMeasurementController(quantityMeasurementBusiness);
        }

        /// <summary>
        /// Given 1 FeetToInch Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenFeetToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "FeetToInch",
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

        /// <summary>
        /// Given 2 YardToInch Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenYardToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "YardToInch",
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

        /// <summary>
        /// Given 3 CentimeterToInch Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenCentimeterToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "CentimeterToInch",
                    Value = 5
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Given 8 Inch Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "Inch",
                    Value = 4
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Given 800 GramsToKilogram Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenGramsToKilogram_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "GramsToKilogram",
                    Value = 600
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Given 800 TonneToKilograms Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenTonneToKilograms_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "TonneToKilograms",
                    Value = 0.9
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Given 9 Kilogram Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenKilograms_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "kilogram",
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

        /// <summary>
        /// Given 7 GallonToLitre Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenGallonToLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "GallonToLitre",
                    Value = 6
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Given 7 MiliLitreToLitre Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenMiliLitreToLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "MiliLitreToLitre",
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

        /// <summary>
        /// Given 15 Litre Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "Litre",
                    Value = 10
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Given 250 FahrenheitToCelsius Convert And AddMethod Used returns OkObjectResult
        /// </summary>
        [Fact]
        public void GivenTemperature_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 200
                };
                var okResult = quantityMeasurementController.ConvertAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Given Null Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given Empty Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given Length With GramsToKilogram Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given Length With GallonToLitre Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given Length With FahrenheitToCelsius Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given weight With FeetToInch Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given weight With GallonToLitre Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given weight With FahrenheitToCelsius Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given volume With FeetToInch Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given volume With GramsToKilogram Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given volume With FahrenheitToCelsius Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given temperature With FeetToInch Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given temperature With GallonToLitre Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// Given temperature With Kilogram Convert And AddMethod Used returns NotFoundObjectResult
        /// </summary>
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

        /// <summary>
        /// This Method is used to get all records returns okObjectResult
        /// </summary>
        [Fact]
        public void GivenController_WhenGetAllMethodUsed_ReturnsResult()
        {
            try
            {
                var result = quantityMeasurementController.GetAllQuantity();
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
                int id = 11;
                var result = quantityMeasurementController.GetQuantityById(id);
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
                int id = 10;
                var result = quantityMeasurementController.DeleteQuntityById(id);
                Assert.IsType<OkObjectResult>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
