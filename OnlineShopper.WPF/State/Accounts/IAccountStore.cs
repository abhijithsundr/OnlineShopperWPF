using OnlineShopper.Domain.Models;
using System;

namespace OnlineShopper.WPF.State.Accounts
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
