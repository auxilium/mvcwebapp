using MVCWebApp.Models;
using MVCWebApp.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = Statics.RoleNames.Administrator)]
    public class AdminBaseController : Controller
    {

    }
}