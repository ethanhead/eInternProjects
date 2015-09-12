using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AptFinder.DAL;

namespace AptFinder.Abstract
{
    public interface IContext
    {
        ApartmentContext AptContext { get; }
    }
}
