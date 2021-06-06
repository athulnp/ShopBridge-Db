using ShopBridge.Site.Models;
using ShopBridge.Site.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Site.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;
        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> DeleteInventory(long inventoryId)
        {
            var response = await _repository.Delete(inventoryId);
            return response;
        }

        public async Task<Inventory> GetInventoryDetails(long inventoryId)
        {
            var details = new Inventory();
            details = await _repository.Get(inventoryId);
            return details;
        }

        public async Task<List<Inventory>> GetInventoryList()
        {
            var list = new List<Inventory>();
            list = await _repository.GetList();
            return list;
        }

        public async Task<long> UpsertInventory(Inventory item)
        {
            return await _repository.Upsert(item);
        }
    }
}
