#pragma checksum "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4d75f392a76179bbafedcabc5c84225bc6a5372"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Navigation), @"mvc.1.0.view", @"/Views/Shared/_Navigation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Navigation.cshtml", typeof(AspNetCore.Views_Shared__Navigation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4d75f392a76179bbafedcabc5c84225bc6a5372", @"/Views/Shared/_Navigation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"970ad2232b60c18355d1b72e2ff9366751045b67", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Navigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/profile_small.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 299, true);
            WriteLiteral(@"<nav class=""navbar-default navbar-static-side"" role=""navigation"">
    <div class=""sidebar-collapse"">
        <ul class=""nav metismenu"" id=""side-menu"">
            <li class=""nav-header"">
                <div class=""dropdown profile-element"">
                    <span>
                        ");
            EndContext();
            BeginContext(299, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f4d75f392a76179bbafedcabc5c84225bc6a53724591", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(370, 706, true);
            WriteLiteral(@"
                    </span>
                    <a data-toggle=""dropdown"" class=""dropdown-toggle"" href=""#"">
                        <span class=""clear"">
                            <span class=""block m-t-xs"">
                                <strong class=""font-bold"" id=""user-fullname""></strong>
                            </span> 
                            <span class=""text-muted text-xs block"" id=""user-role"">
                            </span>
                            <span class=""hidden"" id=""user-employeeId""></span>
                        </span>
                    </a>
                    <ul class=""dropdown-menu animated fadeInRight m-t-xs"">
                        <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1076, "\"", 1117, 1);
#line 20 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 1083, Url.Action("Profile", "AppViews"), 1083, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1118, 110, true);
            WriteLiteral(">Thông tin cá nhân</a></li>\r\n                        <li class=\"divider\"></li>\r\n                        <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1228, "\"", 1265, 1);
#line 22 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 1235, Url.Action("Logout", "Admin"), 1235, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1266, 232, true);
            WriteLiteral(">Đăng xuất</a></li>\r\n                    </ul>\r\n                </div>\r\n                <div class=\"logo-element\">\r\n                    HoaiPV\r\n                </div>\r\n            </li>\r\n            <li class=\"\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1498, "\"", 1536, 1);
#line 30 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 1505, Url.Action("Index", "Metrics"), 1505, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1537, 142, true);
            WriteLiteral("><i class=\"fa fa-th-large\"></i> <span class=\"nav-label\">Tổng quan</span></a>\r\n            </li>\r\n            <li class=\"\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1679, "\"", 1718, 1);
#line 33 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 1686, Url.Action("Index", "Rentbook"), 1686, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1719, 140, true);
            WriteLiteral("><i class=\"fa fa-upload\"></i> <span class=\"nav-label\">Thuê Sách</span></a>\r\n            </li>\r\n            <li class=\"\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1859, "\"", 1897, 1);
#line 36 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 1866, Url.Action("Index", "PayBook"), 1866, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1898, 141, true);
            WriteLiteral("><i class=\"fa fa-download\"></i> <span class=\"nav-label\">Trả sách</span></a>\r\n            </li>\r\n            <li class=\"\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2039, "\"", 2078, 1);
#line 39 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2046, Url.Action("Index", "Customer"), 2046, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2079, 139, true);
            WriteLiteral("><i class=\"fa fa-user\"></i> <span class=\"nav-label\">Khách hàng</span></a>\r\n            </li>\r\n            <li class=\"\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2218, "\"", 2265, 1);
#line 42 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2225, Url.Action("Dashboard_1", "Dashboards"), 2225, 40, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2266, 206, true);
            WriteLiteral("><i class=\"fa fa-paper-plane\"></i> <span class=\"nav-label\">Danh mục</span> <span class=\"fa arrow\"></span></a>\r\n                <ul class=\"nav nav-second-level collapse\">\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2472, "\"", 2507, 1);
#line 44 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2479, Url.Action("Index", "Book"), 2479, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2508, 58, true);
            WriteLiteral(">Sách truyện</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2566, "\"", 2605, 1);
#line 45 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2573, Url.Action("Index", "Category"), 2573, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2606, 55, true);
            WriteLiteral(">Lĩnh vực</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2661, "\"", 2698, 1);
#line 46 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2668, Url.Action("Index", "Author"), 2668, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2699, 54, true);
            WriteLiteral(">Tác giả</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2753, "\"", 2793, 1);
#line 47 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2760, Url.Action("Index", "Publisher"), 2760, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2794, 50, true);
            WriteLiteral(">NXB</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2844, "\"", 2879, 1);
#line 48 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2851, Url.Action("Index", "Type"), 2851, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2880, 56, true);
            WriteLiteral(">Loại sách</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2936, "\"", 2975, 1);
#line 49 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2943, Url.Action("Index", "Language"), 2943, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2976, 55, true);
            WriteLiteral(">Ngôn ngữ</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3031, "\"", 3067, 1);
#line 50 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 3038, Url.Action("Index", "State"), 3038, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3068, 62, true);
            WriteLiteral(">Tình trạng sách</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3130, "\"", 3168, 1);
#line 51 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 3137, Url.Action("Index", "Penalty"), 3137, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3169, 106, true);
            WriteLiteral(">Vi phạm</a></li>\r\n                </ul>\r\n            </li>\r\n            <li class=\"\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3275, "\"", 3322, 1);
#line 55 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 3282, Url.Action("Dashboard_1", "Dashboards"), 3282, 40, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3323, 210, true);
            WriteLiteral("><i class=\"fa fa-align-left\"></i> <span class=\"nav-label\">QL thuê - trả</span> <span class=\"fa arrow\"></span></a>\r\n                <ul class=\"nav nav-second-level collapse\">\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3533, "\"", 3571, 1);
#line 57 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 3540, Url.Action("List", "Rentbook"), 3540, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3572, 59, true);
            WriteLiteral(">QL Thuê sách</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3631, "\"", 3668, 1);
#line 58 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 3638, Url.Action("List", "PayBook"), 3638, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3669, 101, true);
            WriteLiteral(">QL Trả sách</a></li>\r\n                </ul>\r\n            </li>\r\n            <li>\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3770, "\"", 3817, 1);
#line 62 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 3777, Url.Action("Dashboard_1", "Dashboards"), 3777, 40, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3818, 205, true);
            WriteLiteral("><i class=\"fa fa-bar-chart-o\"></i> <span class=\"nav-label\">Báo cáo</span> <span class=\"fa arrow\"></span></a>\r\n                <ul class=\"nav nav-second-level collapse\">\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4023, "\"", 4063, 1);
#line 64 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 4030, Url.Action("Rentting", "Report"), 4030, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4064, 68, true);
            WriteLiteral(">Sách truyện đang thuê</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4132, "\"", 4171, 1);
#line 65 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 4139, Url.Action("TopRent", "Report"), 4139, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4172, 61, true);
            WriteLiteral(">Top thuê nhiều</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4233, "\"", 4275, 1);
#line 66 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 4240, Url.Action("GetRevenue", "Report"), 4240, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4276, 123, true);
            WriteLiteral(">Báo cáo doanh Thu</a></li>\r\n                </ul>\r\n            </li>\r\n            <li id=\"management\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4399, "\"", 4446, 1);
#line 70 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 4406, Url.Action("Dashboard_1", "Dashboards"), 4406, 40, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4447, 202, true);
            WriteLiteral("><i class=\"fa fa-desktop\"></i> <span class=\"nav-label\">Quản trị</span> <span class=\"fa arrow\"></span></a>\r\n                <ul class=\"nav nav-second-level collapse\">\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4649, "\"", 4687, 1);
#line 72 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 4656, Url.Action("Account", "Admin"), 4656, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4688, 56, true);
            WriteLiteral(">Tài khoản</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4744, "\"", 4783, 1);
#line 73 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 4751, Url.Action("Index", "Employee"), 4751, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4784, 56, true);
            WriteLiteral(">Nhân viên</a></li>\r\n                    <li class=\"\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4840, "\"", 4876, 1);
#line 74 "D:\C#\BookStoreManagement\BookStore\BookStore\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 4847, Url.Action("Index", "Shift"), 4847, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4877, 93, true);
            WriteLiteral(">Ca làm</a></li>\r\n                </ul>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n</nav>");
            EndContext();
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
