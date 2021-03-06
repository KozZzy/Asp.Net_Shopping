﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGenelTekrar4.Models.Attribute
{
    public class EmployeeAuthorizeAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["login"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Account/Login");
                return false;
            }
        }
    }
}