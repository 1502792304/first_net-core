using DTO.Interface;
using first_net__core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace first_net__core.Filter
{
    public class authFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (HasAllowAnonymous(context))
            {
                return;
            }
            else
            {
                string user;
                if (!context.HttpContext.Request.Cookies.TryGetValue("user", out user))
                {
                    context.Result = new RedirectToActionResult("login","Login",null);
                }
                //context.Result = new ContentResult() { Content="NO Allow this page"};
            }

        }

        //用于判断Action有没有AllowAnonymous标签，微软写的
        private bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            var filters = context.Filters;
            for (var i = 0; i < filters.Count; i++)
            {
                if (filters[i] is IAllowAnonymousFilter)
                {
                    return true;
                }
            }

            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return true;
            }

            return false;
        }

    }
}
