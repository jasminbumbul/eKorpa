#pragma checksum "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7a7f936bc3a8165c0e2d52bd96983540d3eed57"
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
#line 1 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\_ViewImports.cshtml"
using eKorpa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\_ViewImports.cshtml"
using eKorpa.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7a7f936bc3a8165c0e2d52bd96983540d3eed57", @"/Views/Artikal/Detalji.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"236876972ee11feba0410f29e2861cb42437caf5", @"/Views/_ViewImports.cshtml")]
    public class Views_Artikal_Detalji : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eKorpa.ViewModels.ArtikalDetaljiVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("kolicina"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dodaj", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Korpa", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
  
    var claimsIdentity = User.FindFirstValue(ClaimTypes.NameIdentifier);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <div id=\"formaDetaljiArtikla\">\r\n        <div class=\"slike\">\r\n");
#nullable restore
#line 12 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
             if (Model.Slike != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                 for (int i = 0; i < Model.Slike.Count; i++)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                     if (Model.Slike[i] != null && Model.Thumbnail[i] == 1)
                    {
                        var base64 = Convert.ToBase64String(Model.Slike[i]);
                        var imgsrc = string.Format("data:image/gif;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img class=\"slika\"");
            BeginWriteAttribute("src", " src=\"", 696, "\"", 709, 1);
#nullable restore
#line 20 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
WriteAttributeValue("", 702, imgsrc, 702, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" />\r\n");
#nullable restore
#line 21 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n       \r\n\r\n        <div class=\"detalji\">\r\n            <div class=\"nazivArtikla\"> <h1> ");
#nullable restore
#line 28 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                                       Write(Model.NazivArtikla);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1> </div>\r\n            <hr />\r\n            <h4 class=\"cijena\">Cijena  ");
#nullable restore
#line 30 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                                  Write(Model.Cijena);

#line default
#line hidden
#nullable disable
            WriteLiteral(" KM</h4>\r\n");
#nullable restore
#line 31 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
             if (Model.Cijena != Model.CijenaSaPopustom)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4 class=\"cijena\">Cijena sa popustom ");
#nullable restore
#line 33 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                                                 Write(Model.CijenaSaPopustom);

#line default
#line hidden
#nullable disable
            WriteLiteral(" KM</h4>\r\n");
#nullable restore
#line 34 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            <h6>Brend: ");
#nullable restore
#line 37 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                  Write(Model.Brend);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6>Broj u skladištu: ");
#nullable restore
#line 38 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                             Write(Model.BrojUSkladistu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6>Kategorija: ");
#nullable restore
#line 39 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                       Write(Model.Kategorija);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6>Potkategorija: ");
#nullable restore
#line 40 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                          Write(Model.Potkategorija);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6>Velicina: ");
#nullable restore
#line 41 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                     Write(Model.Velicina);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6>Materijal: ");
#nullable restore
#line 42 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                      Write(Model.Materijal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6>Boja: ");
#nullable restore
#line 43 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                 Write(Model.Boja);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <div class=\"kolicina\">\r\n");
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7a7f936bc3a8165c0e2d52bd96983540d3eed5710752", async() => {
                WriteLiteral("\r\n                    <input type=\"text\" name=\"ArtikalID\" hidden");
                BeginWriteAttribute("value", " value=\"", 2036, "\"", 2053, 1);
#nullable restore
#line 50 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
WriteAttributeValue("", 2044, Model.ID, 2044, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <input type=\"number\" min=\"1\" value=\"1\"");
                BeginWriteAttribute("max", " max=\"", 2117, "\"", 2144, 1);
#nullable restore
#line 51 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
WriteAttributeValue("", 2123, Model.BrojUSkladistu, 2123, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"kolicina\" id=\"qty\" class=\"qtyy\" />\r\n\r\n");
#nullable restore
#line 53 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                     if (claimsIdentity == Model.Prodavac)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <button type=\"submit\" disabled class=\"btn btn-dark\">Dodaj u korpu</button>\r\n");
#nullable restore
#line 56 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <button type=\"submit\" class=\"btn btn-dark\">Dodaj u korpu</button>\r\n");
#nullable restore
#line 60 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 2689, "\"", 2736, 2);
            WriteAttributeValue("", 2696, "/Profil/Index?KorisnikID=", 2696, 25, true);
#nullable restore
#line 64 "C:\Users\Jasmin\source\repos\temp\webapp\eKorpa\Views\Artikal\Detalji.cshtml"
WriteAttributeValue("", 2721, Model.Prodavac, 2721, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"margin-top:10px\" class=\"btn btn-warning\">Posjeti profil prodavača</a><br />\r\n        </div>\r\n\r\n\r\n    </div>\r\n</div>\r\n<link href=\"/css/ArtikalDetalji.css\" rel=\"stylesheet\" />\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7a7f936bc3a8165c0e2d52bd96983540d3eed5715120", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
