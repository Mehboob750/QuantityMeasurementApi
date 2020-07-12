using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuantityMeasurementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityMeasurementController : ControllerBase
    {
        private IQuantityMeasurementBusiness quantityMeasurementBusiness;

        public QuantityMeasurementController(IQuantityMeasurementBusiness quantityMeasurementBusiness)
        {
            this.quantityMeasurementBusiness = quantityMeasurementBusiness;
        }

        [HttpPost]
        public IActionResult Convert([FromBody] Quantity quantity)
        {
            try
            {
                var result = quantityMeasurementBusiness.Convert(quantity);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Added Sucessfully";
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
                return BadRequest(new { success, message = e.Message });
            }
        }

    }
}