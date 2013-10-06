using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ru.xnull.Cache;

namespace Test_Ebot.Cache
{
    [TestFixture]
    class CacheImplTest
    {
        [Test]
        public void testPutAngGetObjectFromCacheAndGetDatePutInCache()
        {
            CacheImpl<int, String> cache = new CacheImpl<int, string>();
            cache.put(1, "test");
            cache.put(1, "test2");
            Assert.AreEqual(cache.getObject(1), "test2");
            Assert.AreEqual(cache.getDatePutOfObjectInCache(1).ToString("hh:mm:ss"), DateTime.Now.ToString("hh:mm:ss"));
        }
    }
}
