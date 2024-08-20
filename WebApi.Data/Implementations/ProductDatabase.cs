 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Domain;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Interface;

namespace WebApi.Data.Implementations
{
       public class ProductDatabase : IProductDatabase
        {
            private readonly WebApiApplicationDbContext _context;
            public ProductDatabase(WebApiApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Products>> GetProductsAsync()
            {
            var result = await _context.Products.ToListAsync();
                return result;
            }

        }
 }

