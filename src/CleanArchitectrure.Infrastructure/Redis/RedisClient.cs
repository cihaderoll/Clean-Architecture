using CleanArchitectrure.Application.Interface.Infrastructure;
using CleanArchitectrure.Application.UseCases.Commons.Extensions;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Infrastructure.Redis
{
    public class RedisClient : IRedisClient
    {
        private readonly ConnectionMultiplexer _client;
        private readonly IDatabase _database;

        public RedisClient(IConfiguration config)
        {
            var redisConnStr = config.GetSection("RedisConfig:ConnectionStr")?.Value;

            var redisOpt = new ConfigurationOptions
            {
                EndPoints =
                {
                    redisConnStr
                },

                AsyncTimeout = 10000,
                ConnectTimeout = 10000
            };

            _client = ConnectionMultiplexer.Connect(redisOpt);
            _database = _client.GetDatabase();
        }


        public void Set(string key, string value)
        {
            _database.StringSet(key, value);
        }

        public void Set<T>(string key, T value) where T : class
        {
            _database.StringSet(key, value.ToJson());
        }

        public Task SetAsync(string key, object value)
        {
            return _database.StringSetAsync(key, value.ToJson());
        }

        public void Set(string key, object value, TimeSpan expiration)
        {
            _database.StringSet(key, value.ToJson(), expiration);
        }

        public Task SetAsync(string key, object value, TimeSpan expiration)
        {
            return _database.StringSetAsync(key, value.ToJson(), expiration);
        }

        public T Get<T>(string key) where T : class
        {
            string value = _database.StringGet(key);

            return value.ToObject<T>();
        }

        public bool TryGetValue<T>(string key, out T result) where T : class
        {
            string value = _database.StringGet(key);

            result = value.ToObject<T>();

            return result != null;
        }

        public string Get(string key)
        {
            return _database.StringGet(key);
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            string value = await _database.StringGetAsync(key);

            return value.ToObject<T>();
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }

        
    }
}
