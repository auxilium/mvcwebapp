using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public static class Statics
    {
        public static class RoleNames
        {
            public const string Administrator = "administrator"; // Aux only
            public const string CanManageUsers = "canmanageusers";
            public const string CanEdit = "canedit";
        }
    }
}