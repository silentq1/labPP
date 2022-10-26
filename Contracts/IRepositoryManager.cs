using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IShopRepository Shops { get; }
        IOwnerRepository Owner { get; }
        void Save();
        Task SaveAsync();

    }
}
