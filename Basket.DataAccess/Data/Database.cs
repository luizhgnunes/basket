using Basket.Common.Models;
using System.Collections.Concurrent;

namespace Basket.DataAccess.Data
{
    internal static class Database
    {
        internal static readonly ConcurrentDictionary<Guid, OrderRequest> Basket = new ConcurrentDictionary<Guid, OrderRequest>();
    }
}
