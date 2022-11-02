using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private IShopRepository _shopsRepository;
        private IOwnerRepository _ownerRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);
                return _companyRepository;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }
        public IShopRepository Shops
        {
            get
            {
                if (_shopsRepository == null)
                    _shopsRepository = new ShopRepository(_repositoryContext);
                return _shopsRepository;
            }
        }

        public IOwnerRepository Owner
        {
            get
            {
                if (_ownerRepository == null)
                    _ownerRepository = new OwnerRepository(_repositoryContext);
                return _ownerRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
