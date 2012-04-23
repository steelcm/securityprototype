using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FundDataMaintenance.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var contextBase = filterContext.RequestContext.HttpContext;
            if(contextBase.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new ViewResult { ViewName = "~/Views/Shared/401.cshtml" };
            }else
            {
                FormsAuthentication.RedirectToLoginPage(contextBase.Request.RawUrl);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ReadOnlyAuthorizeAttribute : Attribute, IMetadataAware
    {
        public String Roles { get; set; }
        public bool IsReadOnly { 
            get
            {
                if(this.Roles != null)
                {
                    var roleList = this.Roles.Split(',').Select(o => o.Trim()).ToList();
                    return !(roleList.Where(role => HttpContext.Current.User.IsInRole(role)).Count() > 0);
                }
                return !(HttpContext.Current.User.Identity.IsAuthenticated);
            }
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["IsReadOnly"] = this.IsReadOnly;
        }
        
    }
}