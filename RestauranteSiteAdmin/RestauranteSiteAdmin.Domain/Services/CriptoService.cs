using System.Text;

namespace RestauranteSiteAdmin.Domain.Services
{
    public static class CriptoService
    {
        public static string Criptografar(string texto)
        {
            var sourceBytes = Encoding.Unicode.GetBytes(texto);
            var hashBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(sourceBytes);
            var sb = new StringBuilder();
            for (int i = 0; hashBytes != null && i < hashBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", hashBytes[i]);
            }
            return sb.ToString();
        }
    }
}
