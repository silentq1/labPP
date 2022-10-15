﻿using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ShopRepository : RepositoryBase<Shop>, IShopRepository
    {
        public ShopRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public IEnumerable<Shop> GetAllShops(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        public Shop GetShop(Guid shopId, bool trackChanges) => FindByCondition(c
            => c.Id.Equals(shopId), trackChanges).SingleOrDefault();
        public void CreateShop(Shop shop) => Create(shop);

        public void DeleteShop(Shop shop)
        {
            Delete(shop);
        }
    }
}
