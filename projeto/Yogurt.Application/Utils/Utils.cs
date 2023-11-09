using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;

namespace Yogurt.Application.Utils
{
    public class Utils
    {
        public static string RetornarHash(string? senha)
        {
            string hash;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                hash = Hash.GerarSenhaComHash(sha256Hash, senha);
            }

            return hash;
        }

        public static bool VerificarEmail(string? email)
        {
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }

            return false;
        }

        public static string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email),
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //public static string Testar(string email, string password, string username)
        //{
        //    MySqlConnection conexao = new MySqlConnection(Environment.GetEnvironmentVariable("DatabaseConnection"));

        //    MySqlCommand comando = new MySqlCommand("insert into clowto23_Jovem_Programador.Usuario (Email,Password,Username) values (@Email,@Password,@Username)", conexao);
        //    comando.Parameters.AddWithValue("@Email", email);
        //    comando.Parameters.AddWithValue("@Password", password);
        //    comando.Parameters.AddWithValue("@Username", username);

        //    try
        //    {
        //        conexao.Open();
        //        comando.ExecuteReader();
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //    return "";
        //}
    }
}