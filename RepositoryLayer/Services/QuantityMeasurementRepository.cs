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
                Quantity result = dBContext.Quantities.FirstOrDefault(value => ((value.MeasurementType == quantity.MeasurementType) && (value.ConversionType == quantity.ConversionType) && (value.Value == quantity.Value)));
                if (result!=quantity)
                {
                    dBContext.Quantities.Add(quantity);
                    dBContext.SaveChanges();
                }
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
                return dBContext.Quantities.Find(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity DeleteQuntityById(int Id)
        {
            try
            {
                Quantity quantity = dBContext.Quantities.FirstOrDefault(value=>value.Id == Id);
                if (quantity != null)
                {
                    dBContext.Quantities.Remove(quantity);
                    dBContext.SaveChanges();
                }
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare AddComparedValue(Compare compare)
        {
            try
            {
                dBContext.Comparisons.Add(compare);
                dBContext.SaveChanges();
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Compare> GetAllComparison()
        {
            try
            {
                return dBContext.Comparisons;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare GetComparisonById(int Id)
        {
            try
            {
                return dBContext.Comparisons.Find(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare DeleteComparisonById(int Id)
        {
            try
            {
                Compare compare = dBContext.Comparisons.FirstOrDefault(value => value.Id == Id);
                if (compare != null)
                {
                    dBContext.Comparisons.Remove(compare);
                    dBContext.SaveChanges();
                }
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
