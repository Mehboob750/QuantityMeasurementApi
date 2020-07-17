//-----------------------------------------------------------------------
// <copyright file="QuantityMeasurementRepository.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace RepositoryLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CommanLayer;
    using CommanLayer.Model;
    using RepositoryLayer.Interface;

    /// <summary>
    /// This Class is used to implement the methods of interface
    /// </summary>
    public class QuantityMeasurementRepository : IQuantityMeasurementRepository
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityMeasurementRepository"/> class.
        /// </summary>
        public QuantityMeasurementRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityMeasurementRepository"/> class.
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public QuantityMeasurementRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// This Method is used to add new Record
        /// </summary>
        /// <param name="quantity">It contains the Object of Quantity Model</param>
        /// <returns>It returns Added Record</returns>
        public Quantity Add(Quantity quantity)
        {
            try
            {
                var result = this.dbContext.Quantities.FirstOrDefault(value => ((value.ConversionType == quantity.ConversionType) && (value.Value == quantity.Value)));
                if (result == null)
                {
                    this.dbContext.Quantities.Add(quantity);
                    this.dbContext.SaveChanges();
                }
                else
                {
                    return null;
                }

                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Read All Records
        /// </summary>
        /// <returns>It returns All Records</returns>
        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return this.dbContext.Quantities;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Get Quantity Record By Id
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns record of given Id</returns>
        public Quantity GetQuantityById(int id)
        {
            try
            {
                return this.dbContext.Quantities.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Delete Quantity Record By Id
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns the Deleted Record</returns>
        public Quantity DeleteQuntityById(int id)
        {
            try
            {
                Quantity quantity = this.dbContext.Quantities.FirstOrDefault(value => value.Id == id);
                if (quantity != null)
                {
                    this.dbContext.Quantities.Remove(quantity);
                    this.dbContext.SaveChanges();
                }

                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Compare and Add
        /// </summary>
        /// <param name="compare">It contains the Object of Compare Model</param>
        /// <returns>It returns Added Record</returns>
        public Compare AddComparedValue(Compare compare)
        {
            try
            {
                this.dbContext.Comparisons.Add(compare);
                this.dbContext.SaveChanges();
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Read All Records Of Comparisons
        /// </summary>
        /// <returns>It returns All Records</returns>
        public IEnumerable<Compare> GetAllComparison()
        {
            try
            {
                return this.dbContext.Comparisons;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Get Comparison Record By Id
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns record of given Id</returns>
        public Compare GetComparisonById(int id)
        {
            try
            {
                return this.dbContext.Comparisons.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Delete Comparison Record By Id
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns the Deleted Record</returns>
        public Compare DeleteComparisonById(int id)
        {
            try
            {
                Compare compare = this.dbContext.Comparisons.FirstOrDefault(value => value.Id == id);
                if (compare != null)
                {
                    this.dbContext.Comparisons.Remove(compare);
                    this.dbContext.SaveChanges();
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
