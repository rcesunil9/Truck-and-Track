using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrucknDriver.Services
{
    public interface IRepositoryWrapper
    {
        IAccountRepository AccountRepo { get; }
        Task Save();
    }
}
