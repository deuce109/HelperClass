using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

public static class Helper
{

    /// <summary>
    /// Converts string to byte array using default encoding
    /// </summary>
    /// <param name="str"></param>
    /// <returns>byte[]</returns>
    public static byte[] ToByteArray(this string str)
    {
        return Encoding.Default.GetBytes(str);
    }

    /// <summary>
    /// Converts byte array to string using specified encoding
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="Encoding"></param>
    /// <returns>string</returns>
    public static string ToString(this byte[] bytes, string encoding = null)
    {
        if (encoding!=null)
        switch (encoding.ToUpper())
        {
            case "ASCII":
                return System.Text.Encoding.ASCII.GetString(bytes);

            case "UTF7": case "UTF-7": case "UTF 7":
                return System.Text.Encoding.UTF7.GetString(bytes);

            case "UTF8": case "UTF-8": case "UTF 8":
                return System.Text.Encoding.UTF8.GetString(bytes);
                
            case "UTF32": case "UTF-32": case "UTF 32":
                return System.Text.Encoding.UTF7.GetString(bytes);

            case "BASE64": case "BASE-64": case "BASE 64":
                return Convert.ToBase64String(bytes);

            case "UNICODE":
                return System.Text.Encoding.Unicode.GetString(bytes);

            case "BIGENDIANUNICODE": case "BIG ENDIAN UNICODE": case "BIG-ENDIAN UNICODE":
                return System.Text.Encoding.Unicode.GetString(bytes);

            case "DEFAULT":
                return System.Text.Encoding.Default.GetString(bytes);

            default:
                return System.Text.Encoding.Default.GetString(bytes);
        } 
        else
        {
            return System.Text.Encoding.Default.GetString(bytes);
        }       
    }

    /// <summary>
    /// Convert byte array to string using default encoding
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns>string</returns>
    public static string GetString(this byte[] bytes)
    {
        return Encoding.Default.GetString(bytes);
    }


    public static byte[] ToByteArray(this string str, string encoding)
    {
        if (encoding!=null)
        switch (encoding.ToUpper())
        {
            case "ASCII":
                return System.Text.Encoding.ASCII.GetBytes(str);

            case "UTF7": case "UTF-7": case "UTF 7":
                return System.Text.Encoding.UTF7.GetBytes(str);

            case "UTF8": case "UTF-8": case "UTF 8":
                return System.Text.Encoding.UTF8.GetBytes(str);
                
            case "UTF32": case "UTF-32": case "UTF 32":
                return System.Text.Encoding.UTF7.GetBytes(str);

            case "BASE64": case "BASE-64": case "BASE 64":
                return Convert.FromBase64String(str);

            case "UNICODE":
                return System.Text.Encoding.Unicode.GetBytes(str);

            case "BIGENDIANUNICODE": case "BIG ENDIAN UNICODE": case "BIG-ENDIAN UNICODE":
                return System.Text.Encoding.Unicode.GetBytes(str);

            case "DEFAULT":
                return System.Text.Encoding.Default.GetBytes(str);

            default:
                return System.Text.Encoding.Default.GetBytes(str);
        } 
        else
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }       
    }

    public static byte[] ToByteArray(this object obj)
    {
        if (obj is byte[])
        {
            return obj as byte[];
        }
        else if (obj is IList<byte>)
        {
            IList<byte> bytes = obj as IList<byte>;
            byte[] outBytes = new byte[bytes.Count];

            for (int i = 0; i < bytes.Count; i++)
            {
                outBytes[i]  = bytes[i];
            }
            return outBytes;
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }

    public static Stream ToStream(this object obj)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            formatter.Serialize(ms, obj);
            return ms;
        }
    }

    public static byte[] GetHashBytes(this object obj,HashAlgorithms algoName)
    {

        HashAlgorithm algo;
        switch (algoName)
        {
            case HashAlgorithms.SHA512:
                algo = new SHA512Managed();
                break;
            case HashAlgorithms.SHA256:
                algo = new SHA256Managed();
                break;
            case HashAlgorithms.SHA384:
                algo = new SHA384Managed();
                break;
            default :
                algo = new SHA512Managed();
                break;
        
        }
        byte[] hashBytes;

        if (obj is byte[])
        {
            hashBytes = obj as byte[];
        }
        else
        {
            byte[] bytes = obj.ToByteArray();
            hashBytes = algo.ComputeHash(bytes);
        }
        return hashBytes;
    }

    public enum HashAlgorithms{
        SHA512,
        SHA256,
        SHA384
    }

    public static byte[] GetHashBytes(this object obj, HashAlgorithms algoName, int saltLength)
    {
        byte[] hashBytes = obj.GetHashBytes(algoName);

        byte[] salt = new byte[saltLength];

        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        rng.GetBytes(salt);

        byte[] hashAndSalt = new byte[hashBytes.Length + salt.Length];

        for (int i =0; i<hashAndSalt.Length; i++)
        {
            if (i<hashBytes.Length)
            {
                hashAndSalt[i] = hashBytes[i];
            }
            else
            {
                int saltIndex = i-hashBytes.Length;
                hashAndSalt[i] = salt[saltIndex];
            }
        }

        return hashAndSalt;
    }

}
