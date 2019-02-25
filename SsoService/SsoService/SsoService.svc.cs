using SsoService.DAL;
using SsoService.Dto;
using System;
using System.Web.Configuration;

namespace SsoService
{
    public class SsoService : ISsoService
    {
        public LoginDto Login(string userName, string password)
        {
            var dataAccess = new clsRepo(WebConfigurationManager.AppSettings["strDBconn"].ToString());
            var user = dataAccess.SelectUserByUserNamePwd(userName, password);
            if (user != null)
            {
                return new LoginDto
                {
                    Status = true,
                    UserId = user.UserId,
                    UserName = user.UserName
                };
            }

            return new LoginDto { Status = false };
        }

        public RegisterDto Register(string userName, string password)
        {
            try
            {
                var dataAccess = new clsRepo(WebConfigurationManager.AppSettings["strDBconn"].ToString());
                var existingUser = dataAccess.SelectUserByUserName(userName);
                if (existingUser == null)
                {
                    // should decrypt the pwd before store in db, simplify for demo purpose
                    dataAccess.AddUser(userName, password);
                    return new RegisterDto { Status = true };
                }
            }
            catch (Exception ex)
            {
                return new RegisterDto { Status = false, Message = ex.Message };
            }

            return new RegisterDto
            {
                Status = false,
                Message = "UserName already exist in the system."
            };
        }
    }
}