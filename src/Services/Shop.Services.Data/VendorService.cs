using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services.Data
{
    public class VendorService : IVendorService
    {
        private readonly IDeletableEntityRepository<CardVendor> vendor;

        public VendorService(IDeletableEntityRepository<CardVendor> vendor)
        {
            this.vendor = vendor;
        }

        public IEnumerable<T> VendorList<T>(string userId)
        {
            var products = this.vendor.All().Where(x => x.UserId == userId).To<T>().ToList();

            return products;
        }
    }
}
