using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Data
{
    public interface ISearchService
    {
        IEnumerable<T> Search<T>(string search, string region);
    }
}
