using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Data
{
    public interface IVendorService
    {
        IEnumerable<T> VendorList<T>(string userId);
    }
}
