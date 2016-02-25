using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for Encryptor
/// </summary>
public class Encryptor
{
    public Encryptor()
    {
    }

    public string EncodeTo64(string text)
    {
        byte[] toEncodeAsBytes
              = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
        string returnValue
              = System.Convert.ToBase64String(toEncodeAsBytes);
        return returnValue;
    }
    public string DecodeFrom64(string text)
    {
        byte[] encodedDataAsBytes
            = System.Convert.FromBase64String(text);
        string returnValue =
           System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
        return returnValue;
    }

    public string getSha512(string text)
    {
        System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
        Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(text);
        Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
        HashTool.Clear();
        return Convert.ToBase64String(EncryptedBytes);
    }

    /// <summary>
    /// Cambiar formato de fecha dd/mm/yyyy por yyyy-mm-dd
    /// </summary>
    /// <param name="fecha"></param>
    /// <returns></returns>
    public string cambioFormatoFecha(string fecha)
    {
        string[] split = fecha.Split('/');
        if (split.Count() > 0 && split.Count() == 3)
        {
            return split[2] + "-" + split[1] + "-" + split[0];
        }
        return "";
    }
}