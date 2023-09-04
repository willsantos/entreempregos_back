using System.Security.Cryptography;
using System.Text;

namespace EntreEmpregos.Service.utils;

public static class Encryption
{
    private static readonly string? Salt =
        Environment.GetEnvironmentVariable("APP_SALT");

    public static string Encrypt(string password)
    {
        var salt = GenerateSalt(16);
        var bytes = Encoding.Unicode.GetBytes(password);
        var inArray = SHA256.HashData(bytes.Concat(salt).ToArray());
        return Convert.ToBase64String(salt.Concat(inArray).ToArray());
    }

    public static bool Verify(string password, string hash)
    {
        var data = Convert.FromBase64String(hash);
        var salt = data.Take(16).ToArray();
        var bytes = Encoding.Unicode.GetBytes(password);
        var inArray = SHA256.HashData(bytes.Concat(salt).ToArray());
        return data.Skip(16).SequenceEqual(inArray);
    }

    private static byte[] GenerateSalt(int size)
    {
        if (Salt is not null)
            Encoding.UTF8.GetBytes(Salt);

        var salt = new byte[size];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }
}