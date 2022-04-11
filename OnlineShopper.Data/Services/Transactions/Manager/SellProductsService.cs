using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.Domain.Services.Transactions.Facade;

namespace OnlineShopper.Data.Services.Transactions.Manager
{
    public class SellProductsService : ISellProductsService
    {
        private readonly IProductsService _products;
        private readonly IAccountsService _accounts;

        public SellProductsService(IProductsService products, IAccountsService accounts)
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
