using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;

namespace OnlineShopper.Data.Services.Manager
{
    public class AccountsService : IAccountsService
    {
        public Task<Account> Create(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<double> CreditCashBalance(int accountId, double price)
        {
            throw new NotImplementedException();
        }

        public Task<double> CreditVoucherBalance(int accountId, double price)
        {
            throw new NotImplementedException();
        }

        public Task<double> DebitCashBalance(int accountId, double price)
        {
            throw new NotImplementedException();
        }

        public Task<double> DebitVoucherBalance(int accountId, double price)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Account> Update(int id, Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
