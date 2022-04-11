using System.Threading.Tasks;
using OnlineShopper.Domain.Models;

namespace OnlineShopper.Domain.Services.Transactions.Facade
{
    public interface IBuyProductsService
    {
        Task<Product> BuyProduct(int accountId, int productId, bool forCash);
    }
}
