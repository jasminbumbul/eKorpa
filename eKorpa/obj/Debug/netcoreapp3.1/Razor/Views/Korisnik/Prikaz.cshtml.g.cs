#pragma checksum "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Korisnik\Prikaz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f08e3828b3e034d020415ef36a4a06829ca42ebd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Korisnik_Prikaz), @"mvc.1.0.view", @"/Views/Korisnik/Prikaz.cshtml")]
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
#line 1 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\_ViewImports.cshtml"
using eKorpa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\_ViewImports.cshtml"
using eKorpa.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Korisnik\Prikaz.cshtml"
using eKorpa.EntityModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f08e3828b3e034d020415ef36a4a06829ca42ebd", @"/Views/Korisnik/Prikaz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10415db88d44a03ea2dda807c1e2b9cac93ce2db", @"/Views/_ViewImports.cshtml")]
    public class Views_Korisnik_Prikaz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Korisnik\Prikaz.cshtml"
  
    ViewData["Title"] = "Prikaz";
    var korisnici = (List<Korisnik>)ViewData["korisnici"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<table class=\"table table-bordered\">\r\n    <thead>\r\n    <tr>\r\n        <th>Ime</th>\r\n        <th>Prezime</th>\r\n        <th>Opcina stanovanja</th>\r\n    </tr>\r\n    </thead>\r\n\r\n   <tbody>\r\n");
#nullable restore
#line 18 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Korisnik\Prikaz.cshtml"
         foreach (var item in korisnici)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Korisnik\Prikaz.cshtml"
           Write(item.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Korisnik\Prikaz.cshtml"
           Write(item.Prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 25 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Korisnik\Prikaz.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("   </tbody>\r\n\r\n</table>\r\n\r\n");
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
