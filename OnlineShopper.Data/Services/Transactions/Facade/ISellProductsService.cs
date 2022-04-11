using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Domain.Models;

namespace OnlineShopper.Data.Services.Transactions.Facade
{
    public interface ISellProductsService
    {
        Task<Product> SellProduct(int accountId, int productId, bool forCash);
    }
}