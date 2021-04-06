#pragma checksum "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ea7eb6775053ec6afae49b79d717d82f3196b4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Korpa_Detalji), @"mvc.1.0.view", @"/Views/Korpa/Detalji.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7eb6775053ec6afae49b79d717d82f3196b4d", @"/Views/Korpa/Detalji.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10415db88d44a03ea2dda807c1e2b9cac93ce2db", @"/Views/_ViewImports.cshtml")]
    public class Views_Korpa_Detalji : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eKorpa.ViewModels.KorpaDetaljiVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div id=\"main\">\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"list-group\">\r\n");
#nullable restore
#line 8 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
         foreach (var item in Model.rows)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a href=\"#\" class=\"list-group-item list-group-item-action flex align-items-start\">\r\n                <div class=\"d-flex w-100 justify-content-between\">\r\n                    <h5 class=\"mb-1\">Naziv artikla: ");
#nullable restore
#line 12 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                                               Write(item.NazivArtikla);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <small>Kategorija: ");
#nullable restore
#line 13 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                                  Write(item.Kategorija);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                </div>\r\n                <p class=\"mb-1\">\r\n");
#nullable restore
#line 16 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                     if (item.Slika.Count == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h1>Nema slike</h1>\r\n");
#nullable restore
#line 19 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                     for (int i = 0; i < item.Slika.Count; i++)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                         if (item.Slika[i] != null && item.Thumbnail[i] == 1)
                        {
                            var base64 = Convert.ToBase64String(item.Slika[i]);
                            var imgsrc = string.Format("data:image/gif;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 1081, "\"", 1094, 1);
#nullable restore
#line 27 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
WriteAttributeValue("", 1087, imgsrc, 1087, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" /><br />\r\n");
#nullable restore
#line 28 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    Kolicina: ");
#nullable restore
#line 30 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                         Write(item.Kolicina);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    Cijena: ");
#nullable restore
#line 31 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
                       Write(item.Cijena);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1287, "\"", 1324, 2);
            WriteAttributeValue("", 1294, "/Korpa/Obrisi?KorpaID=", 1294, 22, true);
#nullable restore
#line 32 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
WriteAttributeValue("", 1316, item.ID, 1316, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item list-group-item-action flex-row-items-start\">Obrisi</a>\r\n                </p>\r\n                </a>\r\n");
#nullable restore
#line 35 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 38 "C:\Users\Ramki\source\repos\webapp\eKorpa\Views\Korpa\Detalji.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>

<div id=""wrapper"">
    <div class=""dialog"">
        <p id=""dialogText"">Jeste li sigurni da želite dovršiti kupovinu?</p>
        <a href=""#"" id=""daBtn"" onclick=""Naruci()"" class=""btn btn-outline-success"">DA</a>
        <a href=""#"" id=""neBtn"" onclick=""Prekid()""  class=""btn btn-outline-danger"">NE</a>
    </div>
</div>


<a href=""/Artikal/Index"" class=""btn btn-secondary"">Artikli</a>
<button onclick=""ShowDialog()"" class=""btn btn-secondary"">Naruči</button>

<script>
    function ShowDialog() {
        document.getElementById(""wrapper"").style.display = ""flex"";
        document.getElementById(""main"").style.filter = ""blur(8px)"";
        BlurLayout();
    }

    function Naruci() {
        var url = ""/Artikal/Kupi"";

        $.get(url, function (odg) {
            console.log(odg);
            if (odg == ""address404"") {
                alert(""Da bi završili kupovinu, morate imati validnu adresu."");
                Prekid();
            }
            else {
                aler");
            WriteLiteral(@"t(""Kupovina uspješno dovršena."");
                window.location = ""/Korpa/Detalji"";
            }
        })
    }

    function Prekid() {
        document.getElementById(""wrapper"").style.display = ""none"";
        document.getElementById(""main"").style.filter = ""none"";
        DisableBlur();
    }
</script>

<style>
    body {
        background-color: rgb(45,45,45);
        color: lightcoral;
    }

        body a {
            color: lightblue;
        }

    img {
        width: 200px;
    }


    #wrapper {
        display: none;
        justify-content: center;
    }

    .dialog {
        background-color: lightgray;
        position: absolute;
        display: block;
        width: 300px;
        height: 150px;
        top: 35%;
    }

    #daBtn {
        position: relative;
        left: 70px;
        top: 50px;
    }

    #neBtn {
        position: relative;
        left: 125px;
        top: 50px;
    }

    #dialogText {
        position: rel");
            WriteLiteral("ative;\r\n        top: 15px;\r\n    }\r\n</style>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eKorpa.ViewModels.KorpaDetaljiVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
