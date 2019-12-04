using CSRedis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.Caching.CSRedis.Session
{
    public static class CSRedisSessionCacheExtensions
    {
        /// <summary>
        /// 添加RedisSession。
        /// </summary>
        /// <param name="services">服务。</param>
        /// <param name="redisClient">redis客户端。</param>
        /// <param name="configure">Session配置。</param>
        /// <returns></returns>
        public static IServiceCollection AddRedisSession(this IServiceCollection services, CSRedisClient redisClient, Action<SessionOptions> configure = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (redisClient == null)
            {
                throw new ArgumentNullException(nameof(redisClient));
            }

            if (configure != null)
            {
                services.Configure(configure);
            }

            services.AddSingleton<IDistributedSessionCache>(new CSRedisSessionCache(redisClient));
            services.TryAddTransient<ISessionStore, DistributedRedisSessionStore>();
            services.AddDataProtection();
            return services;
        }
    }
}
