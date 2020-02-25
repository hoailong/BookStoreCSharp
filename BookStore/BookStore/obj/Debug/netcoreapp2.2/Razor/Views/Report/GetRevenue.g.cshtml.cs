#pragma checksum "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Report\GetRevenue.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cacfd162aab800552c454b6b00d714f3cde44863"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_GetRevenue), @"mvc.1.0.view", @"/Views/Report/GetRevenue.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Report/GetRevenue.cshtml", typeof(AspNetCore.Views_Report_GetRevenue))]
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
#line 1 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\_ViewImports.cshtml"
using BookStore;

#line default
#line hidden
#line 2 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\_ViewImports.cshtml"
using BookStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cacfd162aab800552c454b6b00d714f3cde44863", @"/Views/Report/GetRevenue.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"970ad2232b60c18355d1b72e2ff9366751045b67", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_GetRevenue : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookRent>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/javascript/report/revenue.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Report\GetRevenue.cshtml"
  
    ViewData["Title"] = "Báo cáo doanh thu";

#line default
#line hidden
            BeginContext(83, 3009, true);
            WriteLiteral(@"
<div class=""wrapper wrapper-content animated fadeInRight"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""ibox float-e-margins"">
                <div class=""ibox-title"">
                    <h5>Báo cáo doanh thu</h5>
                    <div class=""ibox-tools"">
                        <a class=""collapse-link"">
                            <i class=""fa fa-chevron-up""></i>
                        </a>
                        <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"">
                            <i class=""fa fa-wrench""></i>
                        </a>
                        <ul class=""dropdown-menu dropdown-user"">
                            <li>
                                <a href=""#"">Config option 1</a>
                            </li>
                            <li>
                                <a href=""#"">Config option 2</a>
                            </li>
                        </ul>
                        <a class=""close-l");
            WriteLiteral(@"ink"">
                            <i class=""fa fa-times""></i>
                        </a>
                    </div>
                </div>
                <div class=""ibox-content"">
                    <div class=""row"">
                        <div class=""col-md-6 input-group pull-right"">
                            <input class=""form-control"" type=""text"" name=""daterange"" value=""01/01/2015 - 01/31/2015"" id=""date-ranger"">
                            <span class=""input-group-btn"">
                                <button type=""button"" class=""btn btn-primary"" id=""btn-search""><i class=""fa fa-search"" aria-hidden=""true""></i> Tìm kiếm</button>
                            </span>
                        </div>
                        <div class=""col-md-6 search_revenue"">
                            <a class=""btn btn-info"" id=""day"">Hôm nay</a>&nbsp;
                            <a class=""btn btn-info"" id=""month"">Tháng này</a>&nbsp;
                            <a class=""btn btn-info"" id=""quarter"">Quý nà");
            WriteLiteral(@"y</a>&nbsp;
                            <a class=""btn btn-info"" id=""year"">Năm này</a>&nbsp;
                        </div>
                    </div>
                    <p style=""text-align: left; margin-top: 10px; text-decoration: underline; font-size: 20px; color:red"">Tổng tiền thu: <strong id=""total_money""></strong> vnđ</p>
                    <table class=""table table-hover table-bordered"" id=""rentting-table"">
                        <thead>
                            <tr>
                                <th width=""10%"">STT</th>
                                <th width=""20%"">Khách hàng</th>
                                <th width=""20%"">Nhân viên</th>
                                <th width=""20%"" style=""text-align:center"">Thời gian</th>
                                <th width=""10%"" style=""text-align:center"">Tổng tiền</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
            BeginContext(3499, 148, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(3665, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3671, 54, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cacfd162aab800552c454b6b00d714f3cde448637390", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3725, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookRent>> Html { get; private set; }
    }
}
#pragma warning restore 1591
