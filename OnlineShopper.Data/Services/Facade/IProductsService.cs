using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Domain.Models;

namespace OnlineShopper.Data.Services.Facade
{
    public interface IProductsService : IDataService<Product>
    {
        Task<int> UpdateInventory(int productId, int stockCount);
    }
}