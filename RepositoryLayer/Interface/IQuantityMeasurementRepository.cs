//-----------------------------------------------------------------------
// <copyright file="IQuantityMeasurementRepository.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace RepositoryLayer.Interface
{
    using System.Collections.Generic;
    using CommanLayer.Model;

    /// <summary>
    /// Interface of Quantity Measurement Repository Layer
    /// </summary>
    public interface IQuantityMeasurementRepository
    {
        /// <summary>
        /// It is an interface of Add Quantity Method
        /// </summary>
        /// <param name="quantity">It is an object of Quantity Model class</param>
        /// <returns>It returns Added Record</returns>
        Quantity Add(Quantity quantity);

        /// <summary>
        /// It is an interface of Get All Quantity Method
        /// </summary>
        /// <returns>It returns All Records</returns>
        IEnumerable<Quantity> GetAllQuantity();

        /// <summary>
        /// It is an interface of Get Quantity By Id Method
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns record of given Id</returns>
        Quantity GetQuantityById(int id);

        /// <summary>
        /// It is an interface of Delete Quantity By Id Method
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns record of Deleted Id</returns>
        Quantity DeleteQuntityById(int id);

        /// <summary>
        /// It is an interface of Add Method
        /// </summary>
        /// <param name="compare">It is an object of Compare Model class</param>
        /// <returns>It returns Added Record</returns>
        Compare AddComparedValue(Compare compare);

        /// <summary>
        /// It is an interface of Get All Comparison Method
        /// </summary>
        /// <returns>It returns All Records</returns>
        IEnumerable<Compare> GetAllComparison();

        /// <summary>
        /// It is an interface of Get Comparison By Id Method
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns record of given Id</returns>
        Compare GetComparisonById(int id);

        /// <summary>
        /// It is an interface of Delete Comparison By Id Method
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns record of Deleted Id</returns>
        Compare DeleteComparisonById(int id);
    }
}
