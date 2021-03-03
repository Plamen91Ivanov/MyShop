using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Data
{
    public interface ICategoriesService
    {
        T ProductsByCategory<T>(string name);
    }
}
