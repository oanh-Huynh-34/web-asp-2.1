#pragma checksum "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fffaff43de1a5102f41c6473cef5959375a6296"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Order_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Order/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Order/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Order_Index))]
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
#line 1 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\_ViewImports.cshtml"
using DoAnWebBanGiay;

#line default
#line hidden
#line 2 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\_ViewImports.cshtml"
using DoAnWebBanGiay.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fffaff43de1a5102f41c6473cef5959375a6296", @"/Areas/Admin/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c831c9f95c11a2937107bf0968f50f47cee0ba74", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DoAnWebBanGiay.Models.ViewModel.OrderViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class", "btn border", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-normal", "btn btn-default active", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-selected", "btn btn-primary active", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-group m-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::DoAnWebBanGiay.TagHelpers.PageLinkHelper __DoAnWebBanGiay_TagHelpers_PageLinkHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(96, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(98, 6099, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fffaff43de1a5102f41c6473cef5959375a62966050", async() => {
                BeginContext(117, 595, true);
                WriteLiteral(@"
    <br /><br />
    <h2 class=""text-info"">Order List</h2>
    <br />
    <div style=""background-color:aliceblue"" class=""container"">
        <div class=""text-success"">Order Details</div>
        <div class="" container border"" background-color:aliceblue"">
            <div class=""col-12 "" style=""padding-left:30px;"">
                <div class=""row "" style=""padding-top:5px"">
                    <div class=""col-2"">
                        <label>Name : </label>
                    </div>
                    <div class=""col-3"" style=""padding-bottom:15px"">
                        ");
                EndContext();
                BeginContext(713, 83, false);
#line 19 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.Editor("searchName", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
                EndContext();
                BeginContext(796, 248, true);
                WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-2\">\r\n                        <label>Phone Number : </label>\r\n                    </div>\r\n                    <div class=\"col-3\" style=\"padding-bottom:15px\">\r\n                        ");
                EndContext();
                BeginContext(1045, 90, false);
#line 25 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.Editor("searchPhoneNumber", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
                EndContext();
                BeginContext(1135, 407, true);
                WriteLiteral(@"
                    </div>
                </div>
            </div>
            <div class=""col-12 "" style=""padding-left:30px;"">
                <div class=""row "" style=""padding-top:5px"">
                    <div class=""col-2"">
                        <label>Email : </label>
                    </div>
                    <div class=""col-3"" style=""padding-bottom:15px"">
                        ");
                EndContext();
                BeginContext(1543, 84, false);
#line 35 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.Editor("searchEmail", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
                EndContext();
                BeginContext(1627, 1033, true);
                WriteLiteral(@"
                    </div>
                    <div class=""col-2"">
                        <label>Appointment : </label>
                    </div>
                    <div class=""col-3"" style=""padding-bottom:15px"">
                        <script>
                            $(document).ready(function () {
                                var date_input = $('input[name=""date""]'); //our date input has the name ""date""
                                var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : ""body"";
                                var options = {
                                    format: 'mm/dd/yyyy',
                                    container: container,
                                    todayHighlight: true,
                                    autoclose: true,
                                };
                                date_input.datepicker(options);
                            })
                        </script>
               ");
                WriteLiteral("         ");
                EndContext();
                BeginContext(2661, 103, false);
#line 54 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.Editor("datepicker", new { htmlAttributes = new { @class = "form-control", @id = "datepicker" } }));

#line default
#line hidden
                EndContext();
                BeginContext(2764, 409, true);
                WriteLiteral(@"
                    </div>
                </div>
            </div>
            <div class=""col-12 "" style=""padding-left:30px;"">
                <div class=""row "" style=""padding-top:5px"">
                    <div class=""col-2"">
                        <label>Address : </label>
                    </div>
                    <div class=""col-3"" style=""padding-bottom:15px"">
                        ");
                EndContext();
                BeginContext(3174, 86, false);
#line 64 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.Editor("searchAddress", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
                EndContext();
                BeginContext(3260, 587, true);
                WriteLiteral(@"
                    </div>
                    <div class=""col-2"">
                    </div>
                    <div class=""col-3"" style=""padding-bottom:15px"">
                        <button type=""submit"" name=""submit"" value=""Search"" class=""btn btn-primary form-control""><i class=""fa fa-search"">Search</i></button>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <br /><br />
    <div>
        <table class=""table table-striped border"">
            <tr class=""table-info"">
                <th>
                    ");
                EndContext();
                BeginContext(3848, 68, false);
#line 81 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().SalesPerson.Name));

#line default
#line hidden
                EndContext();
                BeginContext(3916, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(3984, 67, false);
#line 84 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().AppointmentDate));

#line default
#line hidden
                EndContext();
                BeginContext(4051, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(4119, 64, false);
#line 87 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().CustomerName));

#line default
#line hidden
                EndContext();
                BeginContext(4183, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(4251, 65, false);
#line 90 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().CustomerEmail));

#line default
#line hidden
                EndContext();
                BeginContext(4316, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(4384, 71, false);
#line 93 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().CustomerPhoneNumber));

#line default
#line hidden
                EndContext();
                BeginContext(4455, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(4523, 59, false);
#line 96 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().address));

#line default
#line hidden
                EndContext();
                BeginContext(4582, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(4650, 63, false);
#line 99 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().isConfirmed));

#line default
#line hidden
                EndContext();
                BeginContext(4713, 98, true);
                WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n                <th></th>\r\n            </tr>\r\n");
                EndContext();
#line 104 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
             foreach (var item in Model.Orders)
            {

#line default
#line hidden
                BeginContext(4875, 72, true);
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(4948, 43, false);
#line 108 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(m => item.SalesPerson.Name));

#line default
#line hidden
                EndContext();
                BeginContext(4991, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(5071, 42, false);
#line 111 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(m => item.AppointmentDate));

#line default
#line hidden
                EndContext();
                BeginContext(5113, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(5193, 39, false);
#line 114 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerName));

#line default
#line hidden
                EndContext();
                BeginContext(5232, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(5312, 40, false);
#line 117 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerEmail));

#line default
#line hidden
                EndContext();
                BeginContext(5352, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(5432, 46, false);
#line 120 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerPhoneNumber));

#line default
#line hidden
                EndContext();
                BeginContext(5478, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(5558, 34, false);
#line 123 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(m => item.address));

#line default
#line hidden
                EndContext();
                BeginContext(5592, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(5672, 38, false);
#line 126 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(m => item.isConfirmed));

#line default
#line hidden
                EndContext();
                BeginContext(5710, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(5789, 54, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5fffaff43de1a5102f41c6473cef5959375a629618955", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 129 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5843, 52, true);
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
                EndContext();
#line 132 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(5910, 34, true);
                WriteLiteral("        </table>\r\n    </div>\r\n    ");
                EndContext();
                BeginContext(5944, 244, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fffaff43de1a5102f41c6473cef5959375a629621042", async() => {
                }
                );
                __DoAnWebBanGiay_TagHelpers_PageLinkHelper = CreateTagHelper<global::DoAnWebBanGiay.TagHelpers.PageLinkHelper>();
                __tagHelperExecutionContext.Add(__DoAnWebBanGiay_TagHelpers_PageLinkHelper);
#line 135 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
__DoAnWebBanGiay_TagHelpers_PageLinkHelper.PageModel = Model.PagingInfo;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __DoAnWebBanGiay_TagHelpers_PageLinkHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __DoAnWebBanGiay_TagHelpers_PageLinkHelper.PageAction = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 135 "D:\Web\DoAnWebBanGiay\DoAnWebBanGiay\Areas\Admin\Views\Order\Index.cshtml"
__DoAnWebBanGiay_TagHelpers_PageLinkHelper.PageClassesEnabled = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("page-classes-enabled", __DoAnWebBanGiay_TagHelpers_PageLinkHelper.PageClassesEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __DoAnWebBanGiay_TagHelpers_PageLinkHelper.PageClass = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __DoAnWebBanGiay_TagHelpers_PageLinkHelper.PageClassNormal = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __DoAnWebBanGiay_TagHelpers_PageLinkHelper.PageClassSelected = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6188, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6197, 14, true);
            WriteLiteral("\r\n\r\n<br />\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6228, 176, true);
                WriteLiteral("\r\n    <script>\r\n\r\n        $(function () {\r\n            $(\"#datepicker\").datepicker({\r\n                minDate: +1, maxDate: \"+3M\"\r\n            });\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DoAnWebBanGiay.Models.ViewModel.OrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
