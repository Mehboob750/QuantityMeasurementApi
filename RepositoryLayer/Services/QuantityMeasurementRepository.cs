using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return dBContext.Quantities;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity GetQuantityById(int Id)
        {
            try
            {
                Quantity quantity = dBContext.Quantities.Find(Id);
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Quantity> DeleteQuntityById(int Id)
        {
            try
            {
                List<Quantity> quantity = dBContext.Quantities.ToList();

                if (quantity != null)
                {
                    dBContext.Remove(dBContext.Quantities.Single(a => a.Id == Id));
                    dBContext.SaveChanges();
                }
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
