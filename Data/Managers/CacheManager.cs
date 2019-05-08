using Data.Helpers;
using StackExchange.Redis;
using System;

namespace Data.Managers
{
    public class CacheManager : CacheHelper, ICacheManager
    {
        private static IDatabase _db;
        private static readonly string host = "localhost";
        private static readonly int port = 6379;

        public CacheManager()
        {
            CreateRedisDatabase();
        }

        private static IDatabase CreateRedisDatabase()
        {
            if (null == _db)
            {
                var option = new ConfigurationOptions { Ssl = false };
                option.EndPoints.Add(host, port);
                var connect = ConnectionMultiplexer.Connect(option);

                _db = connect.GetDatabase();
            }

            return _db;
        }

        public void Clear()
        {
            var server = _db.Multiplexer.GetServer(host, port);

            foreach (var item in server.Keys())
            {
                _db.KeyDelete(item);
            }
        }

        public T Get<T>(string key)
        {
            var rValue = _db.SetMembers(key);

            if (rValue.Length == 0)
            {
                return default(T);
            }

            var result = Deserialize<T>(rValue.ToStringArray());

            return result;
        }

        public bool IsSet(string key)
        {
            return _db.KeyExists(key);
        }

        public bool Remove(string key)
        {
            return _db.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var server = _db.Multiplexer.GetServer(host, port);

            foreach (var item in server.Keys(pattern: "*" + pattern + "*"))
            {
                _db.KeyDelete(item);
            }
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }

            var entryBytes = Serialize(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            _db.SetAdd(key, entryBytes);

            if (cacheTime > 0)
            {
                _db.KeyExpire(key, expiresIn);
            }
        }
    }
}
