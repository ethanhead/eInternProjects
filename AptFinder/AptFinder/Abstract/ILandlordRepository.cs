﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AptFinder.Models;

namespace AptFinder.Abstract
{
    public interface ILandlordRepository
    {
        IEnumerable<Landlord> Landlords { get; }
    }
}
