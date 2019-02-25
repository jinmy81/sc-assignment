using SiteClient.Models;
using System.Web;

namespace SiteClient.Common
{
    public class SessionMng
    {
        private const string CurrAccountKey = "CurrentAccount";

        public static UserModel CurrentAccount
        {
            get
            {
                return (UserModel)HttpContext.Current.Session[CurrAccountKey];
            }
            set
            {
                HttpContext.Current.Session[CurrAccountKey] = value;
            }
        }
    }
}