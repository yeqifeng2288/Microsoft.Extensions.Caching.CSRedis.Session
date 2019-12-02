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
        /// 
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddRedisSession(this IServiceCollection services)
        {
            services.TryAddTransient<ISessionStore, DistributedRedisSessionStore>();
            services.AddDataProtection();
            return services;
        }

        /// <summary>
        /// 添加RedisSession。
        /// </summary>
        /// <param name="services">服务。</param>
        /// <param name="configure">Session配置。</param>
        /// <returns></returns>
        public static IServiceCollection AddRedisSession(this IServiceCollection services, Action<SessionOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            services.Configure(configure);
            services.AddRedisSession();
            return services;
        }
    }
}
