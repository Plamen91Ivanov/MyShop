using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public interface IProductCreateService
    {
        Task<int> Create(string name, string description, decimal price, string location, string image);
    }
}
