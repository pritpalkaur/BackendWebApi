
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.Interface
{
    public interface IProductDatabase
    {
        Task<List<Products>> GetProductsAsync();
    }
}
