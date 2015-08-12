using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

class Cipher : IDisposable
{
    #region Fields

    private RijndaelManaged AES;

    #endregion

    #region Constructors

    /// <summary>
    /// Initialize the cipher.
    /// </summary>
    /// <param name="key"></param>
    public Cipher(String key)
    {
        using (SHA256Managed SHA = new SHA256Managed())
        {
            AES = new RijndaelManaged();
            AES.Key = SHA.ComputeHash(Encoding.ASCII.GetBytes(key));
            AES.IV = new Byte[16];
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Use the cipher to encrypt.
    /// </summary>
    /// <param name="clear"></param>
    /// <returns></returns>
    public String Encrypt(String clear)
    {
        try
        {
            using (ICryptoTransform encryptor = AES.CreateEncryptor())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        Byte[] bytes = Encoding.ASCII.GetBytes(clear);
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
        catch
        {
            return String.Empty;
        }
    }

    /// <summary>
    /// Use the cipher to decrypt.
    /// </summary>
    /// <param name="ciphred"></param>
    /// <returns></returns>
    public String Decrypt(String ciphred)
    {
        try
        {
            using (ICryptoTransform decryptor = AES.CreateDecryptor())
            {
                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(ciphred)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        catch
        {
            return String.Empty;
        }
    }

    #region IDisposable Members

    /// <summary>
    /// Implement the IDisposable interface.
    /// </summary>
    public void Dispose()
    {
        AES.Clear();
    }

    #endregion

    #endregion
}