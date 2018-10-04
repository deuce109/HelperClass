using System;
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
    public static string ToString(this byte[] bytes, string encoding)
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


    public static byte[] ToBytes(this string str, string encoding)
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

}
