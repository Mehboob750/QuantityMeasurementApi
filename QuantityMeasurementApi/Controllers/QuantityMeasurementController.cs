//-----------------------------------------------------------------------
// <copyright file="QuantityMeasurementController.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace QuantityMeasurementApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using BusinessLayer.Interface;
    using CommanLayer.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Quantity Measurement controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityMeasurementController : ControllerBase
    {
        /// <summary>
        /// It is an Reference of IQuantityMeasurement Business
        /// </summary>
        private IQuantityMeasurementBusiness quantityMeasurementBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityMeasurementController"/> class.
        /// </summary>
        /// <param name="quantityMeasurementBusiness">It is an object of IQuantityMeasurement Business</param>
        public QuantityMeasurementController(IQuantityMeasurementBusiness quantityMeasurementBusiness)
        {
            this.quantityMeasurementBusiness = quantityMeasurementBusiness;
        }

        /// <summary>
        /// This Method is used to Add the new record
        /// </summary>
        /// <param name="quantity">It is an object of Quantity Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        public IActionResult ConvertAndAdd([FromBody] Quantity quantity)
        {
            try
            {
                var result = this.quantityMeasurementBusiness.ConvertAndAdd(quantity);
                if (!result.Result.Equals(0))
                {
                    bool success = true;
                    var message = "Data Added Sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Failed To Add Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }

        /// <summary>
        /// This Method is used to Read all the records
        /// </summary>
        /// <returns>Returns the result in SMD format</returns>
        [HttpGet]
        public IActionResult GetAllQuantity()
        {
            try
            {
                var result = this.quantityMeasurementBusiness.GetAllQuantity();
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Read Successfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Unable To Read Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }

        /// <summary>
        /// This Method is used to Read record by Id
        /// </summary>
        /// <param name="Id">It Contains the Id</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpGet("{Id}")]
        public IActionResult GetQuantityById(int Id)
        {
            try
            {
                var result = this.quantityMeasurementBusiness.GetQuantityById(Id);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Found Successfully";
                    return this.Ok(new { success, message, Data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Data Not Found";
                    return this.NotFound(new { success, message, Data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }

        /// <summary>
        /// This Method is used to Delete record by Id
        /// </summary>
        /// <param name="Id">It Contains the Id</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteQuntityById(int Id)
        {
            try
            {
                var result = this.quantityMeasurementBusiness.DeleteQuntityById(Id);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Deleted Successfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Failed To Delete Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }
        
        /// <summary>
        /// This Method is used to Add the new record
        /// </summary>
        /// <param name="compare">It is an object of Quantity Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        [Route("compare")]
        public IActionResult CompareAndAdd([FromBody] Compare compare)
        {
            try
            {
                var result = this.quantityMeasurementBusiness.CompareAndAdd(compare);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Added Successfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Failed To Add Data";
                    return this.BadRequest(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }

        /// <summary>
        /// This Method is used to Read all the records
        /// </summary>
        /// <returns>Returns the result in SMD format</returns>
        [HttpGet]
        [Route("compare")]
        public IActionResult GetAllComparison()
        {
            try
            {
                var result = this.quantityMeasurementBusiness.GetAllComparison();
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Read Successfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Unable To Read Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }

        /// <summary>
        /// This Method is used to Read record by Id
        /// </summary>
        /// <param name="Id">It Contains the Id</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpGet]
        [Route("compare/{Id}")]
        public IActionResult GetComparisonById(int Id)
        {
            try
            {
                var result = this.quantityMeasurementBusiness.GetComparisonById(Id);
                if (!result.Equals(null))
                {
                    var success = true;
                    var message = "Data Found Successfully";
                    return this.Ok(new { success, message, Data = result });
                }
                else
                {
                    var success = false;
                    var message = "Data Not Found";
                    return this.NotFound(new { success, message, Data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }

        /// <summary>
        /// This Method is used to Delete record by Id
        /// </summary>
        /// <param name="Id">It Contains the Id</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpDelete]
        [Route("compare/{Id}")]
        public IActionResult DeleteComparisonById(int Id)
        {
            try
            {
                var result = this.quantityMeasurementBusiness.DeleteComparisonById(Id);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Deleted Successfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Failed To Delete Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }
    }
}