using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Data.Services.Facade;
using OnlineShopper.Data.Services.Transactions.Facade;
using OnlineShopper.Domain.Models;

namespace OnlineShopper.Data.Services.Transactions.Manager
{
    public class SellProductService : ISellProductsService
    {
        private readonly IProductsService _products;
        private readonly IAccountsService _accounts;

        public SellProductService(IProductsService products, IAccountsService accounts)
        {
            _products = products;
            _accounts = accounts;
        }

        public async Task<Product> SellProduct(int accountId, int productId, bool forCash)
        {
            var account = await _accounts.Get(accountId);
            var product = await _products.Get(productId);

            await _products.UpdateInventory(productId, product.Inventory + 1);

            if (forCash)
            {
                await _accounts.CreditCashBalance(accountId, product.SellPrice);
            }
            else
            {
                await _accounts.CreditCashBalance(accountId, product.VoucherPrice);
            }

            return product;
        }
    }
}
