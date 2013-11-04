using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemcachedProviders.Cache;
using HRR.Core;
using Couchbase;
using Enyim.Caching.Memcached;


namespace HRR.Services
{
    public class MemcacheCacheAdapter : ICacheStorage
    {
        #region ICacheStorage Members
        private readonly static CouchbaseClient _instance;

        static MemcacheCacheAdapter()
        {
            _instance = new CouchbaseClient();
        }
        public static CouchbaseClient Instance { get { return _instance; } }

        public void Remove(string key)
        {
            Instance.Remove(key);
            //DistCache.Remove(key);
        }

        public void Store(string key, object data)
        {
            Instance.Store(StoreMode.Add,key, data);
            //DistCache.Add(key, data);
        }

        public T Retrieve<T>(string key)
        {
            T itemStored = (T)Instance.Get<T>(key);
            if (itemStored == null)
                itemStored = default(T);
            return itemStored;
            //T itemStored = (T)DistCache.Get<T>(key);
            //if (itemStored == null)
            //    itemStored = default(T);
            //return itemStored;
        }

        #endregion
    }
}
