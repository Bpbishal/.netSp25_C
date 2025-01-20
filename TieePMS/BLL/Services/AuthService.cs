using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Token, TokenDTO>();
            });
            return new Mapper(config);
        }
        public static TokenDTO Authenticate(string uname, string pass) {
            var auth = DataAccessFactory.AuthData();
            pass = CreateMD5(pass).ToLower();
            var user = auth.Authenticate(uname, pass);
            if (user != null) {
                var token = new Token();
                token.Key = Guid.NewGuid().ToString();
                token.CreatedAt = DateTime.Now;
                token.UserId = user.Id;
                var ret = DataAccessFactory.TokenData().Create(token);
                return GetMapper().Map<TokenDTO>(ret);
            }
            return null;
        }
        public static bool IsTokenValid(string token) {
            var tk = DataAccessFactory.TokenData().Get(token);
            if (tk != null && tk.ExpiredAt == null) {
                return true;
            }
            return false;

        }
        public static bool Logout(string token) {
            var tk = DataAccessFactory.TokenData().Get(token);
            tk.ExpiredAt = DateTime.Now;
            return DataAccessFactory.TokenData().Update(tk)!= null;

        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //return Convert.ToHexString(hashBytes); // .NET 5 +

                //Convert the byte array to hexadecimal string prior to.NET 5
                 StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
