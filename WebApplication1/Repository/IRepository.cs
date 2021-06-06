using ShopBridge.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Site.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<long> Upsert(T item);
        Task<List<T>> GetList();
        Task<T> Get(long inventoryId);
        Task<long> Delete(long inventoryId);
    }
}
