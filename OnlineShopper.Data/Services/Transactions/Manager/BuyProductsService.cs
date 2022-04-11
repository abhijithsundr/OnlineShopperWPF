using System;
using System.Threading.Tasks;
using OnlineShopper.Data.Services.Facade;
using OnlineShopper.Data.Services.Transactions.Facade;
using OnlineShopper.Domain.Models;

namespace OnlineShopper.Data.Services.Transactions.Manager
{
    public class BuyProductsService : IBuyProductsService
    {
        private readonly IProductsService _products; 
        private readonly IAccountsService _accounts;

        public BuyProductsService(IProductsService products, IAccountsService accounts)
        {
            _products = products;
            _accounts = accounts;
        }

        public async Task<Product> BuyProduct(int accountId, int productId, bool forCash)
        {
            var account = await _accounts.Get(accountId);
            var product = await _products.Get(productId);
            
            if (product.Inventory < 1) 
            {
                throw new Exception("Item is currently out of stock.");
            }

            if (forCash)
            {
                if (account.CashBalance < product.BuyPrice) 
                {
                    throw new Exception("You do not have enough cash to purchase this item.");
                }

                await _accounts.DebitCashBalance(accountId, product.BuyPrice);
            }
            else
            {
                if (account.VoucherBalance < product.BuyPrice)
                {
                    throw new Exception("You do not have enough voucher balance to purchase this item");
                }

                await _accounts.DebitVoucherBalance(accountId, product.BuyPrice);
            }

            await _products.UpdateInventory(productId, product.Inventory - 1);

            return product;
        }
    }
}