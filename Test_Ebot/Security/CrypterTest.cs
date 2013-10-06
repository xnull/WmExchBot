using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;

namespace Test_Ebot
{
    [TestFixture]
    class CrypterTest
    {
        [Test]
        public void checkCrypt()
        {
            Crypter crypter = new Crypter();            
            String testEncrypt = crypter.EncryptString("test string", "password");
            String testDecrypt = crypter.DecryptString(testEncrypt, "password");
            Assert.AreEqual(testDecrypt, "test string");
        }
    }
}
