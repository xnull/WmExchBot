using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Security;

namespace ru.xnull
{
    /// <summary>
    /// Шифрование
    /// </summary>
    public interface ICrypter
    {
        string EncryptString(string data, string password);
        string DecryptString(string data, string password);
    }
}
