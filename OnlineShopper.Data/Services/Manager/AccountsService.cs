using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;

namespace OnlineShopper.Data.Services.Manager
{
    public class AccountsService : IAccountsService
    {
        private readonly OnlineShopperDbContext _context;
        private readonly DbSet<Account> _accounts;

        public AccountsService(OnlineShopperDbContext context)
        {
            _context = context;
            _accounts = context.Set<Account>();
        }

        #region Mutations
        public async Task<Account> Create(Account entity)
        {
            var res = await _accounts.AddAsync(entity);
            await _context.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<double> CreditCashBalance(int accountId, double price)
        {
            var account = await _accounts.FindAsync(accountId);

            if (account is null)
            {
                throw new Exception("Account does not exist");
            }

            account.CashBalance += price;

            _accounts.Update(account);
            await _context.SaveChangesAsync();

            return account.CashBalance;
        }

        public async Task<double> CreditVoucherBalance(int accountId, double price)
        {
            var account = await _accounts.FindAsync(accountId);

            if (account is null)
            {
                throw new Exception("Account does not exist");
            }

            account.VoucherBalance += price;

            _accounts.Update(account);
            await _context.SaveChangesAsync();

            return account.VoucherBalance;
        }

        public async Task<double> DebitCashBalance(int accountId, double price)
        {
            var account = await _accounts.FindAsync(accountId);

            if (account is null)
            {
                throw new Exception("Account does not exist");
            }

            account.CashBalance -= price;

            _accounts.Update(account);
            await _context.SaveChangesAsync();

            return account.CashBalance;
        }

        public async Task<double> DebitVoucherBalance(int accountId, double price)
        {
            var account = await _accounts.FindAsync(accountId);

            if (account is null)
            {
                throw new Exception("Account does not exist");
            }

            account.VoucherBalance -= price;

            _accounts.Update(account);
            await _context.SaveChangesAsync();

            return account.VoucherBalance;
        }

        public async Task<bool> Delete(int id)
        {
            var account = await _accounts.FindAsync(id);

            if (account is null)
            {
                throw new Exception("Account does not exist.");
            }

            _accounts.Remove(account);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Account> Update(Account entity)
        {
            var account = _accounts.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return account;
        }
        #endregion

        #region Queries
        public async Task<Account?> Get(int id)
        {
            return await _accounts.FindAsync(id);
        }

        public async Task<IAsyncEnumerable<Account>> GetAll()
        {
            return _accounts.AsAsyncEnumerable<Account>();
        }
        #endregion
    }
}
