#pragma checksum "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78b39dd6b42046891f650e8868b439da08e41624"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78b39dd6b42046891f650e8868b439da08e41624", @"/Views/Artikal/Detalji.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10415db88d44a03ea2dda807c1e2b9cac93ce2db", @"/Views/_ViewImports.cshtml")]
    public class Views_Artikal_Detalji : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eKorpa.ViewModels.ArtikalDetaljiVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n<div class=\"artikal-galerija\">  </div>\r\n\r\n<div class=\"detalji\">\r\n    <h1>");
#nullable restore
#line 11 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
   Write(Model.NazivArtikla);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <h3>Cijena: xxxx kmeura</h3>\r\n    <h3>Detalji:<br/>\r\n        Veličina:<br/>\r\n        Materijal:<br/>\r\n    </h3>\r\n    <h3>Kategorija: ");
#nullable restore
#line 17 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
               Write(Model.Kategorija);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <h5>Prodavac: ");
#nullable restore
#line 18 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
             Write(Model.Prodavac);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
</div><br />
<a href=""/Artikal/Index"">Artikli</a>


<style>
    .artikal-galerija {
        position: relative;
        max-width: 50%;
        flex-basis: 50%;
        padding: 0 15px 30px;
    }
    .detalji {
        position: relative;
        padding: 0 15px 30px;
        width: 100%;
    }
    h1, h2, h3{
        padding: 15px;
    }
</style>
");
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
