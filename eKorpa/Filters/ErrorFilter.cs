using eKorpa.Helper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace eKorpa.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is UserException)
            {
                context.ModelState.AddModelError("ERROR", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.ModelState.AddModelError("ERROR", "Greška na serveru");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var exceptionHandler = context.Exception;
            if (exceptionHandler != null)
            {
                int bugId = KretanjePoSistemu.Save(context.HttpContext, exceptionHandler);
            }
            context.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
            context.ExceptionHandled = true;
            base.OnException(context);
        }

    }
}
