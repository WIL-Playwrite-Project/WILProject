#pragma checksum "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8ba10ea38d3b9b2da647cd6e1c72757c8708cc1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Gallery), @"mvc.1.0.view", @"/Views/Home/Gallery.cshtml")]
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
#line 1 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/_ViewImports.cshtml"
using MvcDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/_ViewImports.cshtml"
using MvcDemo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8ba10ea38d3b9b2da647cd6e1c72757c8708cc1", @"/Views/Home/Gallery.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf7b598472d8473bbbb5c5b0b44298edc81dd481", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Gallery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddImages", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b8ba10ea38d3b9b2da647cd6e1c72757c8708cc14897", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title></title>
    <link rel=""stylesheet"" href=""style.css"">
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/magnific-popup.js/1.1.0/jquery.magnific-popup.min.js""></script>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/magnific-popup.js/1.1.0/magnific-popup.min.css"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

 <style>
        
    *{
  margin: 0;
  padding: 0;
  font-family: ""montserrat"",sans-serif;
  box-sizing: border-box;
}


 .btn {
  background-color: #22B7AD;
  border: none;
  color: #0F3A61;
  padding: 10px;
  font-size: 15px;
  border-radius: 50px;
  margin-left: 10px;
  }


.gallery-section{
  width: 100%;
  padding: 60px 0;
  background: #fcfcfc;
}

.inner-width{
  width: 100%;
  max-width: 1200px;
  margin: auto;
  padding: 0 20px;
}

.gallery-section h1{
  text-align: center;
  color: #333;
  font-family:Hel");
                WriteLiteral(@"veticaNeue-Light;
  color:#0F3A61;
  margin-bottom:20px;

}

.border{
  width: 180px;
  height: 4px;
  background: #333;
  margin: 60px auto;
}

.gallery-section .gallery{
  display: flex;
  flex-wrap: wrap-reverse;
  justify-content: center;
}

.gallery-section .image{
  flex: 25%;
  overflow: hidden;
  cursor: pointer;
}

.gallery-section .image img{
  width: 100%;
  height: 100%;
  transition: 0.4s;
}

.gallery-section .image:hover img{
  transform: scale(1.4) rotate(15deg);
}

");
                WriteLiteral("@media screen and (max-width:960px) {\n  .gallery-section .image{\n    flex: 33.33%;\n  }\n}\n\n");
                WriteLiteral("@media screen and (max-width:768px) {\n  .gallery-section .image{\n    flex: 50%;\n  }\n}\n\n");
                WriteLiteral("@media screen and (max-width:480px) {\n  .gallery-section .image{\n    flex: 100%;\n  }\n}\n\n</style>\n\n  \n\n \n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n");
#nullable restore
#line 110 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
  

    if(Context.Session.GetString("UserRole") != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <center>\n\n     <h4 style=\"font-family:HelveticaNeue-Light;color:#0F3A61; margin-top:7%\">Upload Images</h4>\n     \n     ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b8ba10ea38d3b9b2da647cd6e1c72757c8708cc18179", async() => {
                WriteLiteral("\n\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b8ba10ea38d3b9b2da647cd6e1c72757c8708cc18447", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 119 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
             <div class=""form-group"" style=""clear:both;"">
                <input  name=""postedFiles""  type=""file"" style=""width:400px; height:45px; border-radius:50px;""  class=""form-control"" placeholder=""Images""  multiple />
                
                <p style=""color: red;"">");
#nullable restore
#line 123 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
                                  Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n            </div>\n\n            <div class=\"form-group\" >\n                <input type=\"submit\" value=\"Upload\" style=\"width:150px\" class=\"btn\"  />\n            </div>\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n    </center>\n");
#nullable restore
#line 133 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div style=\"margin-top:2em\">\n\n  <div class=\"gallery-section\">\n      <div class=\"inner-width\">\n        <h1>Gallery</h1>\n        <div class=\"gallery\">\n\n");
#nullable restore
#line 144 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
               
                
                for(int i=0; i<ViewBag.Urls.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                      <a");
            BeginWriteAttribute("href", " href=", 2973, "", 2995, 1);
#nullable restore
#line 148 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
WriteAttributeValue("", 2979, ViewBag.Urls[i], 2979, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"image\">\n                        <img");
            BeginWriteAttribute("src", " src=", 3039, "", 3060, 1);
#nullable restore
#line 149 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
WriteAttributeValue("", 3044, ViewBag.Urls[i], 3044, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 3060, "\"", 3066, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                      </a>  \n");
#nullable restore
#line 151 "/Users/HenryTheeMac/Desktop/Demo/MvcDemo/Views/Home/Gallery.cshtml"
                }
             

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n      </div>\n    </div>\n\n<script>\n    $(\".gallery\").magnificPopup({\n      delegate: \'a\',\n      type: \'image\',\n      gallery:{\n        enabled: true\n      }\n    });\n  </script>\n\n\n\n\n");
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
