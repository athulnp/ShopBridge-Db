using Dapper;
using Microsoft.Extensions.Options;
using ShopBridge.Site.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Site.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IOptions<MyAppSettings> _options;

        public InventoryRepository(IOptions<MyAppSettings> options)
        {
            _options = options;
        }

        public async Task<long> Delete(long inventoryId)
        {
            using (IDbConnection conn = connection)
            {
                string inventoryDetails = "dbo.DeleteInventory";
                var parameter = new DynamicParameters();
                parameter.Add("@ItemId", inventoryId);
                conn.Open();
                var response = await conn.ExecuteAsync(inventoryDetails, param: parameter, commandType: CommandType.StoredProcedure);
                return response;
            }
        }

        public async Task<Inventory> Get(long inventoryId)
        {
            var details = new Inventory();
            using (IDbConnection conn = connection)
            {
                string inventoryDetails = "dbo.GetInventory";
                var parameter = new DynamicParameters();
                parameter.Add("@ItemId", inventoryId);
                conn.Open();
                var response = await conn.QueryAsync<Inventory>(inventoryDetails, param: parameter, commandType: CommandType.StoredProcedure);
                if (response != null && response?.Any() == true)
                    details = response?.FirstOrDefault();
                return details;
            }
        }

        public async Task<List<Inventory>> GetList()
        {
            var listResponse = new List<Inventory>();
            using (IDbConnection conn = connection)
            {
                string listInventory = "dbo.GetListInventory";
                conn.Open();
                var response = await conn.QueryAsync<Inventory>(listInventory, commandType: CommandType.StoredProcedure);
                if(response != null && response?.Any() == true)
                    listResponse = response?.ToList();
                return listResponse;
            }
        }

        public async Task<long> Upsert(Inventory item)
        {
            using (IDbConnection  conn = connection)
            {
                string UpsertInventory = "dbo.UpsertInventory";
                conn.Open();
                item.CreatedBy = "User";
                var response =  await conn.ExecuteAsync(UpsertInventory, item,commandType : CommandType.StoredProcedure);
                return response;
            }
        }

        public IDbConnection connection
        {
            get { return new SqlConnection(_options.Value.ShopBridgeDb); }
        }
    }
}
