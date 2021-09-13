using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Data
{
    public interface IProfileService
    {
        T GetByName<T>(string name);
    }
}
