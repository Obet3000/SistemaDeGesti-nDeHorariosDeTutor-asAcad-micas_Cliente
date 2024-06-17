using System.Security.Cryptography;
using System.Text;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    public static class Utilidades
    {
        public static string HashContrasenia(string contrasenia)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
