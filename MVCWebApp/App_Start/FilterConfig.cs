﻿using System.Web;
using System.Web.Mvc;
using MVCWebApp.Models.Security;

namespace MVCWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // uncomment to ensure only given roles can access ANY page in the app 
            //filters.Add(new CustomAuthorizeAttribute() { Roles = 
            //    Models.Statics.RoleNames.CanEdit + "," + 
            //    Models.Statics.RoleNames.CanManageUsers  + "," + 
            //    Models.Statics.RoleNames.Administrator });

            // uncomment to force HTTPS
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}