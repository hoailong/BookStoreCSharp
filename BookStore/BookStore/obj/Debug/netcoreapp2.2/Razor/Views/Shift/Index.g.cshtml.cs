#pragma checksum "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shift\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c09f2f37189686695030074c6aa2c589c23a398"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shift_Index), @"mvc.1.0.view", @"/Views/Shift/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shift/Index.cshtml", typeof(AspNetCore.Views_Shift_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c09f2f37189686695030074c6aa2c589c23a398", @"/Views/Shift/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"970ad2232b60c18355d1b72e2ff9366751045b67", @"/Views/_ViewImports.cshtml")]
    public class Views_Shift_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Shift>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/javascript/shift.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shift\Index.cshtml"
  
    ViewData["Title"] = "Ca làm";

#line default
#line hidden
            BeginContext(69, 3048, true);
            WriteLiteral(@"
<div class=""wrapper wrapper-content animated fadeInRight"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""ibox float-e-margins"">
                <div class=""ibox-title"">
                    <h5>Thể loại</h5>
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
                        <a class=""close-link"">
  ");
            WriteLiteral(@"                          <i class=""fa fa-times""></i>
                        </a>
                    </div>
                </div>
                <div class=""ibox-content"">
                    <div class=""row"">
                        <div class=""col-sm-4 m-b-xs"">
                            <button type=""button"" class=""btn btn-danger"" id=""btn-delete-mul""><i class=""fa fa-ban"" aria-hidden=""true""></i> Xóa</button>
                            <button type=""button"" class=""btn btn-primary"" id=""btn-create""><i class=""fa fa-plus"" aria-hidden=""true""></i> Thêm mới</button>
                        </div>
                        <div class=""col-md-4 col-md-offset-4"">
                            <div class=""input-group"">
                                <input type=""text"" placeholder=""Nhập tên ca làm..."" id=""txtSearch"" class=""form-control"">
                                <span class=""input-group-btn"">
                                    <button type=""button"" class=""btn btn-primary""  id=""btn-search""><i cla");
            WriteLiteral(@"ss=""fa fa-search"" aria-hidden=""true""></i> Tìm kiếm</button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <table class=""table table-hover table-striped table-bordered"" id=""shift-table"">
                        <thead>
                            <tr>
                                <th width=""5%"" style=""text-align: center"">
                                    <input type=""checkbox"" class=""i-checks"" id=""check-all"">
                                </th>
                                <th width=""10%"">#</th>
                                <th width=""50%"">Tên ca làm</th>
                                <th width=""15%"" style=""text-align: center"">Cập nhật</th>
                                <th width=""15%"" style=""text-align: center"">Xóa</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
            BeginContext(3970, 1972, true);
            WriteLiteral(@"                        </tbody>
                    </table>

                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal -->
<div id=""shift-modal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">Ca làm</h4>
            </div>
            <div class=""modal-body"">
                <input type=""hidden"" class=""form-control"" id=""shiftId"">
                <div class=""form-group"">
                    <label for=""shiftName"">Tên ca:</label>
                    <input type=""text"" class=""form-control"" id=""shiftName"">
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" id=""btn-save"" class=""btn btn-primary"">Lưu</button>
                <button type=""butto");
            WriteLiteral(@"n"" class=""btn btn-default"" data-dismiss=""modal"">Hủy</button>
            </div>
        </div>

    </div>
</div>


<div id=""confirm-modal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">Xóa ca làm</h4>
            </div>
            <input type=""hidden"" class=""form-control"" id=""shiftIdDel"">
            <div class=""modal-body"">
                Bạn có chắc muốn xóa?
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" id=""btn-delete"">Xóa</button>
                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Hủy</button>
            </div>
        </div>

    </div>
</div>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5960, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5966, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c09f2f37189686695030074c6aa2c589c23a3989300", async() => {
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
                BeginContext(6011, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Shift>> Html { get; private set; }
    }
}
#pragma warning restore 1591
