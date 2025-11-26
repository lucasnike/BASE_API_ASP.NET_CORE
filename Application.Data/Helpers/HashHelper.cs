namespace Application.Data.Helpers;

using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public static class HashHelper
{
    public static string HMACSHA256(string text, string key = "")
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        using (var sha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
        {
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToHexString(hash).ToUpper(); ;
        }
    }

    public static bool CheckHmacSha256(string hashString, string text, string key = "")
    {
        var newHashString = HMACSHA256(text, key);
        return newHashString == hashString;
    }
}
