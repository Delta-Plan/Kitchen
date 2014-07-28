﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Database.Ingredients;

namespace Database.Accessors
{
    public class ProductTypeAccessor : BaseAccessor<ProductTypeAccessor, ProductType>
    {
        private static Dictionary<int, ProductType> _cache = new Dictionary<int, ProductType>();
        private static readonly object CacheLock = new object();
        private static DateTime _cacheUpdated = DateTime.FromBinary(0L);
        private static readonly TimeSpan CachePeriod = new TimeSpan(0,1,0);

        private ProductTypeAccessor() {}

        public override ProductType SelectById(int id)
        {
            ProductType cached;
            if (CacheIsOld())
            {
                TryUpdateCache(id);
                _cache.TryGetValue(id, out cached);
                return cached;
            }
            if (!_cache.TryGetValue(id, out cached))
            {
                DefaultLogger.Warn(string.Format("Product type cache miss. Id: {0}",id));
                TryUpdateCache(id);
                _cache.TryGetValue(id, out cached);
                if (cached==null)
                {
                    DefaultLogger.Error(string.Format("Product type not found by id={0}",id));
                }
            }

            return cached;
        }

        private bool CacheIsOld()
        {
            return _cacheUpdated + CachePeriod < DateTime.Now;
        }

        private void TryUpdateCache(int needidId)
        {
            lock (CacheLock)
            {
                if (_cache.ContainsKey(needidId))
                {
                    return;
                }
                DefaultLogger.Debug("Starting update product type cache");
                var sw = new Stopwatch();
                sw.Start();
                var products = SelectAll().ToList();
                var newCache = new Dictionary<int, ProductType>(products.Count);
                foreach (var productType in products)
                {
                    newCache.Add(productType.Id, productType);
                }
                _cache = newCache;
                _cacheUpdated = DateTime.Now;
                DefaultLogger.Info(string.Format("Product types cache updated in {0}. Items:{1}", sw.Elapsed, products.Count));
            }
        }
    }
}