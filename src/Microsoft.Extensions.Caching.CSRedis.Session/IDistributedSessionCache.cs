using Microsoft.Extensions.Caching.Distributed;

namespace Microsoft.Extensions.Caching.CSRedis.Session
{
    /// <summary>
    /// 继承于分布式缓存接口。
    /// </summary>
    public interface IDistributedSessionCache : IDistributedCache
    {
    }
}
