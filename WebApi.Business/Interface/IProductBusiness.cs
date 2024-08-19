using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Domain;

namespace WebApi.Business.Interface
{
    public interface IProductBusiness
    {
        Task<List<Products>> GetProductsAsync();
    }
}
