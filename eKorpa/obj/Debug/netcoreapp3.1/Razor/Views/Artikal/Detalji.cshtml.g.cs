#pragma checksum "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "498e6a428e7f0197201d7c510d44b805efa08c04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Artikal_Detalji), @"mvc.1.0.view", @"/Views/Artikal/Detalji.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"498e6a428e7f0197201d7c510d44b805efa08c04", @"/Views/Artikal/Detalji.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10415db88d44a03ea2dda807c1e2b9cac93ce2db", @"/Views/_ViewImports.cshtml")]
    public class Views_Artikal_Detalji : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eKorpa.ViewModels.ArtikalDetaljiVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div id=\"formaDetaljiArtikla\">\r\n    <div class=\"slike\">\r\n");
#nullable restore
#line 6 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
         if (Model.Slike != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
             for (int i = 0; i < Model.Slike.Count; i++)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                 if (Model.Slike[i] != null && Model.Thumbnail[i] == 1)
                {
                    var base64 = Convert.ToBase64String(Model.Slike[i]);
                    var imgsrc = string.Format("data:image/gif;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"slika\"");
            BeginWriteAttribute("src", " src=\"", 513, "\"", 526, 1);
#nullable restore
#line 14 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
WriteAttributeValue("", 519, imgsrc, 519, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" />\r\n");
#nullable restore
#line 15 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n");
            WriteLiteral("\r\n</div>\r\n\r\n");
            WriteLiteral("\r\n<link href=\"/css/ArtikalDetalji.css\" rel=\"stylesheet\" />\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eKorpa.ViewModels.ArtikalDetaljiVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
