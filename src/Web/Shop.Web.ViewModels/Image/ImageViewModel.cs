using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Image
{
    public class ImageViewModel : IMapFrom<ImageProduct>
    {
        public string Name { get; set; }
    }
}
