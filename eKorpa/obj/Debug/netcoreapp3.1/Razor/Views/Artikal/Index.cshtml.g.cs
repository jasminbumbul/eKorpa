#pragma checksum "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6014a16cf7963a2d97933f0fcf4cf40cf4d84010"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Artikal_Index), @"mvc.1.0.view", @"/Views/Artikal/Index.cshtml")]
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
#line 1 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
using eKorpa.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6014a16cf7963a2d97933f0fcf4cf40cf4d84010", @"/Views/Artikal/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10415db88d44a03ea2dda807c1e2b9cac93ce2db", @"/Views/_ViewImports.cshtml")]
    public class Views_Artikal_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ArtikalIndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<a href=\"/Korpa/Detalji\" class=\"btn btn-secondary\">Korpa</a>\r\n<div id=\"containerArtikala\" style=\"display: flex; justify-content: space-evenly; flex-wrap:wrap\">\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
     foreach (var item in Model.rows)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"artikalCopy\" style=\"border: double red 1px; width: 300px; margin:10px; cursor:pointer; text-align:center\">\r\n            <div");
            BeginWriteAttribute("onclick", " onclick=\"", 408, "\"", 448, 3);
            WriteAttributeValue("", 418, "OtvoriDetaljeArtikla(", 418, 21, true);
#nullable restore
#line 12 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
WriteAttributeValue("", 439, item.ID, 439, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 447, ")", 447, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <label> ID </label>\r\n                <span>");
#nullable restore
#line 14 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
                 Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> <br />\r\n                <label> Naziv artikla </label>\r\n                <span>");
#nullable restore
#line 16 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
                 Write(item.NazivArtikla);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n                <label> Kategorija </label>\r\n                <span>");
#nullable restore
#line 18 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
                 Write(item.Kategorija);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n                <label> Naziv prodavača </label>\r\n                <span>");
#nullable restore
#line 20 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
                 Write(item.ImeProdavaca);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n                <label> Cijena artikla </label>\r\n                <span>");
#nullable restore
#line 22 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
                 Write(item.Cijena);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n            </div>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 973, "\"", 1021, 2);
            WriteAttributeValue("", 980, "/Profil/Index?KorisnikID=", 980, 25, true);
#nullable restore
#line 24 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
WriteAttributeValue("", 1005, item.ProdavacId, 1005, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 24 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
                                                           Write(item.ImeProdavaca);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a><br />\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1067, "\"", 1107, 2);
            WriteAttributeValue("", 1074, "/Artikal/Dodaj?ArtikalID=", 1074, 25, true);
#nullable restore
#line 25 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
WriteAttributeValue("", 1099, item.ID, 1099, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Uredi</a>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1134, "\"", 1175, 2);
            WriteAttributeValue("", 1141, "/Artikal/Obrisi?ArtikalID=", 1141, 26, true);
#nullable restore
#line 26 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
WriteAttributeValue("", 1167, item.ID, 1167, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Obrisi</a><br />\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1209, "\"", 1247, 2);
            WriteAttributeValue("", 1216, "/Korpa/Dodaj?ArtikalID=", 1216, 23, true);
#nullable restore
#line 27 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"
WriteAttributeValue("", 1239, item.ID, 1239, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dodaj u korpu</a>\r\n        </div>\r\n");
#nullable restore
#line 29 "C:\Users\Ramki\Source\Repos\webapp\eKorpa\Views\Artikal\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>

<a href=""/Artikal/Dodaj"" class=""btn btn-secondary"">Dodaj</a>

<style>
    body {
        background-color: rgb(45,45,45);
        color: lightcoral;
    }

        body a {
            color: lightblue;
        }
</style>

<script>
    function OtvoriProfilProdavaca(prodavacID) {
        var url = ""/Profil/Index?KorisnikID="" + prodavacID;
        window.open(url, '_self');
    }

    function OtvoriDetaljeArtikla(artikalID) {
        var url = ""/Artikal/Detalji?ArtikalID="" + artikalID;
        window.open(url, '_self');
    }
    //function addRowHandlers() {
    //    var table = document.getElementById(""containerArtikala"");
    //    var rows = table.getElementsByTagName(""artikalCopy"");
    //    for (i = 0; i < rows.length; i++) {
    //        var currentRow = table.rows[i];
    //        var createClickHandler = function (row) {
    //            return function () {
    //                //var cell = row.getElementsByTagName(""td"")[0];
    //                var ");
            WriteLiteral(@"id = currentRow.innerHTML;
    //                url = ""/Artikal/Detalji?ArtikalID="" + id;
    //                window.open(url, '_self');
    //            };
    //        };
    //        currentRow.onclick = createClickHandler(currentRow);
    //    }
    //}
    //window.onload = addRowHandlers();
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ArtikalIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
