using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAllOwners(bool trackChanges);
        Owner GetOwner(Guid ownerId, bool trackChanges);
    }
}
