using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Business;
using WebApi.Business.Interface;
using WebApi.Domain;
using WebApi.Data;
using WebApi.Data.Interface;

namespace WebApi.Business.Implementations
{
    public class ProductBusiness : IProductBusiness 
    {
        private readonly IProductDatabase _IProductDatabase;
        public ProductBusiness(IProductDatabase IProductDatabase)
        {
                _IProductDatabase = IProductDatabase;
        }
        public async Task<List<Products>> GetProductsAsync()
        {
            return await _IProductDatabase.GetProductsAsync();
        }
    }
}
