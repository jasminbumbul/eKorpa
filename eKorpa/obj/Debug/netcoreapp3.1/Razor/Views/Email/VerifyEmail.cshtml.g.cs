#pragma checksum "C:\Users\Jasmin\source\repos\eKorpa\eKorpa\Views\Email\VerifyEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd917835e549f6fcd5964ec7e8314b8821af698f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Email_VerifyEmail), @"mvc.1.0.view", @"/Views/Email/VerifyEmail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Jasmin\source\repos\eKorpa\eKorpa\Views\_ViewImports.cshtml"
using eKorpa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jasmin\source\repos\eKorpa\eKorpa\Views\_ViewImports.cshtml"
using eKorpa.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd917835e549f6fcd5964ec7e8314b8821af698f", @"/Views/Email/VerifyEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10415db88d44a03ea2dda807c1e2b9cac93ce2db", @"/Views/_ViewImports.cshtml")]
    public class Views_Email_VerifyEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h2>Thank you for confirming your email</h2>\r\n<a href=\"/Identity/Account/Login\">Now, please login by clicking here</a>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
