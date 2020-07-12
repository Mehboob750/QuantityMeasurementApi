using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer;
using CommanLayer.Model;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class QuantityMeasurementRepository : IQuantityMeasurementRepository
    {
        private ApplicationDbContext dBContext;

        public QuantityMeasurementRepository(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public Quantity Add(Quantity quantity)
        {
            try
            {
                dBContext.Quantities.Add(quantity);
                dBContext.SaveChanges();
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
