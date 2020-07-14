﻿using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;

namespace BusinessLayer.Interface
{
    public interface IQuantityMeasurementBusiness
    {
        Quantity ConvertAndAdd(Quantity quantity);

        IEnumerable<Quantity> GetAllQuantity();

        Quantity GetQuantityById(int Id);

        Quantity DeleteQuntityById(int Id);

        Compare CompareAndAdd(Compare compare);

        IEnumerable<Compare> GetAllComparison();

        Compare GetComparisonById(int Id);

        Compare DeleteComparisonById(int Id);

    }
}
