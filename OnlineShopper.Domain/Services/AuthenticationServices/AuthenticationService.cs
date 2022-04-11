using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;

namespace OnlineShopper.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountsService _accountService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationService(
            IAccountsService accountService,
            IPasswordHasher<User> passwordHasher
        )
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _accountService.GetByUsername(username);

            if (storedAccount == null)
            {
                throw new Exception("User not found.");
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(
                storedAccount.AccountHolder,
                storedAccount.AccountHolder.PasswordHash,
                password
            );

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new Exception("Invalid username or password");
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(
            string email,
            string username,
            string password,
            string confirmPassword
        )
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            Account emailAccount = await _accountService.GetByEmail(email);
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            Account usernameAccount = await _accountService.GetByUsername(username);
            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                User user = new User()
                {
                    Email = email,
                    Username = username,
                    DatedJoined = DateTime.Now
                };

                user.PasswordHash = _passwordHasher.HashPassword(user, password);

                Account account = new Account()
                {
                    AccountHolder = user,
                    CashBalance = 1500,
                    VoucherBalance = 1500
                };

                await _accountService.Create(account);
            }

            return result;
        }
    }
}
