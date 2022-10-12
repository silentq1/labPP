using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }
        public IEnumerable<Owner> GetAllOwners(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        public Owner GetOwner(Guid ownerId, bool trackChanges) => FindByCondition(c
            => c.Id.Equals(ownerId), trackChanges).SingleOrDefault();
        public void CreateOwner(Owner owner) => Create(owner);
    }
}
