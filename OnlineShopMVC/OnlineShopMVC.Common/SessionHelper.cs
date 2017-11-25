using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopMVC.Common
{
    public class SessionHelper
    {
        public static void SetSession(UserLogin session)
        {
            HttpContext.Current.Session[CommonConstants.USER_SESSION] = session;
        }

        public static UserLogin GetSession()
        {
            var session = HttpContext.Current.Session[CommonConstants.USER_SESSION];
            if(session == null)
            {
                return null;
            }
            else
            {
                return session as UserLogin;
            }
        }
    }
}