using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Domain.Models;

namespace OnlineShopper.Data.Services.Facade
{
    public interface IAccountsService : IDataService<Account>
    {
        Task<double> DebitCashBalance(int accountId, double price);
        Task<double> CreditCashBalance(int accountId, double price);
        Task<double> DebitVoucherBalance(int accountId, double price);
        Task<double> CreditVoucherBalance(int accountId, double price);
    }
}