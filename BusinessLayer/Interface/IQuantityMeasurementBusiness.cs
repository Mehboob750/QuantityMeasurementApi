﻿using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;

namespace BusinessLayer.Interface
{
    public interface IQuantityMeasurementBusiness
    {
        Quantity Convert(Quantity quantity);
    }
}