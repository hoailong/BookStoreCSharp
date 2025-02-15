#pragma checksum "D:\C#\BookStoreManagement\BookStore\BookStore\Views\RentBook\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0d0f7ec56c984d18d67f5b67c070fb38d8bb7fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RentBook_List), @"mvc.1.0.view", @"/Views/RentBook/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RentBook/List.cshtml", typeof(AspNetCore.Views_RentBook_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d0f7ec56c984d18d67f5b67c070fb38d8bb7fe", @"/Views/RentBook/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"970ad2232b60c18355d1b72e2ff9366751045b67", @"/Views/_ViewImports.cshtml")]
    public class Views_RentBook_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/javascript/list-rentbook.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\RentBook\List.cshtml"
  
    ViewData["Title"] = "Danh sách thuê sách";

#line default
#line hidden
            BeginContext(55, 1214, true);
            WriteLiteral(@"
<div class=""wrapper wrapper-content animated fadeInRight"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""ibox float-e-margins"">
                <div class=""ibox-title"">
                    <h5>Quản lý thuê sách</h5>
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
            WriteLiteral("ink\">\r\n                            <i class=\"fa fa-times\"></i>\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n                <div class=\"ibox-content\">\r\n");
            EndContext();
            BeginContext(2192, 2745, true);
            WriteLiteral(@"
                    <a href=""/"" class=""btn btn-primary pull-left"" id=""btn-create""><i class=""fa fa-plus"" aria-hidden=""true""></i> Thuê sách</a>
                    <table class=""table table-hover table-striped table-bordered"" id=""list-rent-table"">
                        <thead>
                            <tr>
                                <th width=""5%"">#</th>
                                <th width=""10%"">Mã thuê</th>
                                <th width=""15%"">Ngày thuê</th>
                                <th width=""10%"">Mã khách hàng</th>
                                <th width=""10%"">Mã nhân viên</th>
                                <th width=""10%"">Số sách thuê</th>
                                <th width=""10%"">Đặt cọc</th>
                                <th width=""10%"">Trạng thái</th>
                                <th width=""10%"" style=""text-align: center"">Chi tiết</th>
                                <th width=""10%"" style=""text-align: center"">Cập nhật</th>
                 ");
            WriteLiteral(@"           </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>

                </div>
            </div>
        </div>
    </div>
</div>

<style>
    .dataTables_length {
        float: right;
    }
</style>
<!-- Modal -->
<div id=""view-detail-modal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog  modal-lg"">
        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">Chi tiết thuê sách</h4>
            </div>
            <div class=""modal-body"">
                <h3>Mã thuê: <span class=""text-danger"" id=""detail-rentId"">#</span></h3>
                <table class=""table table-hover table-striped table-bordered"" id=""rent-detail-table"">
                    <thead>
                        <tr>
                      ");
            WriteLiteral(@"      <th width=""10%"">#</th>
                            <th width=""15%"">Mã sách</th>
                            <th width=""25%"">Tên sách</th>
                            <th width=""20%"">Trạng thái sách</th>
                            <th width=""15%"">Giá thuê</th>
                            <th width=""15%"">Trạng thái</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Đóng</button>
            </div>
        </div>

    </div>
</div>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4955, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4961, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0d0f7ec56c984d18d67f5b67c070fb38d8bb7fe8196", async() => {
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
                BeginContext(5014, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
