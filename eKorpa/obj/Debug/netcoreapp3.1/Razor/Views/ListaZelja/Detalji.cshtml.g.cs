#pragma checksum "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\ListaZelja\Detalji.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd344a558ca22a62ed87be0eac2cc1b2876c0df3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ListaZelja_Detalji), @"mvc.1.0.view", @"/Views/ListaZelja/Detalji.cshtml")]
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
#line 1 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\_ViewImports.cshtml"
using eKorpa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\_ViewImports.cshtml"
using eKorpa.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\ListaZelja\Detalji.cshtml"
using eKorpa.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd344a558ca22a62ed87be0eac2cc1b2876c0df3", @"/Views/ListaZelja/Detalji.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"236876972ee11feba0410f29e2861cb42437caf5", @"/Views/_ViewImports.cshtml")]
    public class Views_ListaZelja_Detalji : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListaZeljaDetaljiVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">Naziv proizvoda</th>
            <th scope=""col"">Kategorija</th>
            <th scope=""col"">Stanje na zalihama</th>
            <th scope=""col""></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 18 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\ListaZelja\Detalji.cshtml"
         foreach (var item in Model.rows)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\ListaZelja\Detalji.cshtml"
           Write(item.NazivArtikla);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\ListaZelja\Detalji.cshtml"
           Write(item.Kategorija);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 23 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\ListaZelja\Detalji.cshtml"
           Write(item.StanjeZaliha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 681, "\"", 688, 0);
            EndWriteAttribute();
            WriteLiteral(">Dodaj u korpu</a>\r\n            </td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 764, "\"", 811, 2);
            WriteAttributeValue("", 771, "/ListaZelja/Obrisi?ListaZeljaID=", 771, 32, true);
#nullable restore
#line 28 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\ListaZelja\Detalji.cshtml"
WriteAttributeValue("", 803, item.ID, 803, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">obrisi</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 31 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\ListaZelja\Detalji.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</tbody>\r\n</table>\r\n<a class=\"button\" href=\"/Artikal/Index\">Artikli</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ListaZeljaDetaljiVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
