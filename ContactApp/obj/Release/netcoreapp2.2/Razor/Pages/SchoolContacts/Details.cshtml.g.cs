#pragma checksum "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a89dc5bc6cd3ffd7cfe1c944ac64ea7cb8b2ad2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ContactApp.Pages.SchoolContacts.Pages_SchoolContacts_Details), @"mvc.1.0.razor-page", @"/Pages/SchoolContacts/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/SchoolContacts/Details.cshtml", typeof(ContactApp.Pages.SchoolContacts.Pages_SchoolContacts_Details), null)]
namespace ContactApp.Pages.SchoolContacts
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\_ViewImports.cshtml"
using ContactApp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a89dc5bc6cd3ffd7cfe1c944ac64ea7cb8b2ad2", @"/Pages/SchoolContacts/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"293a7733316af1f26c29defe7fce4aca489ec550", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SchoolContacts_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(105, 151, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>SchoolContact</h4>\r\n    <hr />\r\n    <dl class=\"row border col-sm-12\">\r\n        <dt class=\"col-sm-3\">\r\n            ");
            EndContext();
            BeginContext(257, 54, false);
#line 15 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SchoolContact.Name));

#line default
#line hidden
            EndContext();
            BeginContext(311, 78, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3 font-weight-light\">\r\n            ");
            EndContext();
            BeginContext(390, 50, false);
#line 18 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayFor(model => model.SchoolContact.Name));

#line default
#line hidden
            EndContext();
            BeginContext(440, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
            EndContext();
            BeginContext(501, 69, false);
#line 21 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SchoolContact.ContactMobileNumber));

#line default
#line hidden
            EndContext();
            BeginContext(570, 78, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3 font-weight-light\">\r\n            ");
            EndContext();
            BeginContext(649, 65, false);
#line 24 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayFor(model => model.SchoolContact.ContactMobileNumber));

#line default
#line hidden
            EndContext();
            BeginContext(714, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
            EndContext();
            BeginContext(775, 71, false);
#line 27 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SchoolContact.ContactWhatsAppNumber));

#line default
#line hidden
            EndContext();
            BeginContext(846, 78, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3 font-weight-light\">\r\n            ");
            EndContext();
            BeginContext(925, 67, false);
#line 30 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayFor(model => model.SchoolContact.ContactWhatsAppNumber));

#line default
#line hidden
            EndContext();
            BeginContext(992, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
            EndContext();
            BeginContext(1053, 57, false);
#line 33 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SchoolContact.EmailId));

#line default
#line hidden
            EndContext();
            BeginContext(1110, 78, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3 font-weight-light\">\r\n            ");
            EndContext();
            BeginContext(1189, 53, false);
#line 36 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayFor(model => model.SchoolContact.EmailId));

#line default
#line hidden
            EndContext();
            BeginContext(1242, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
            EndContext();
            BeginContext(1303, 62, false);
#line 39 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SchoolContact.YourBirthDay));

#line default
#line hidden
            EndContext();
            BeginContext(1365, 78, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3 font-weight-light\">\r\n            ");
            EndContext();
            BeginContext(1444, 58, false);
#line 42 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayFor(model => model.SchoolContact.YourBirthDay));

#line default
#line hidden
            EndContext();
            BeginContext(1502, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
            EndContext();
            BeginContext(1563, 64, false);
#line 45 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SchoolContact.SpouseBirthDay));

#line default
#line hidden
            EndContext();
            BeginContext(1627, 78, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3 font-weight-light\">\r\n            ");
            EndContext();
            BeginContext(1706, 60, false);
#line 48 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayFor(model => model.SchoolContact.SpouseBirthDay));

#line default
#line hidden
            EndContext();
            BeginContext(1766, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
            EndContext();
            BeginContext(1827, 66, false);
#line 51 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SchoolContact.KidsNameBirthDay));

#line default
#line hidden
            EndContext();
            BeginContext(1893, 78, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9 font-weight-light\">\r\n            ");
            EndContext();
            BeginContext(1972, 62, false);
#line 54 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayFor(model => model.SchoolContact.KidsNameBirthDay));

#line default
#line hidden
            EndContext();
            BeginContext(2034, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
            EndContext();
            BeginContext(2095, 65, false);
#line 57 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SchoolContact.CurrentLocation));

#line default
#line hidden
            EndContext();
            BeginContext(2160, 78, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9 font-weight-light\">\r\n            ");
            EndContext();
            BeginContext(2239, 61, false);
#line 60 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
       Write(Html.DisplayFor(model => model.SchoolContact.CurrentLocation));

#line default
#line hidden
            EndContext();
            BeginContext(2300, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2347, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a89dc5bc6cd3ffd7cfe1c944ac64ea7cb8b2ad211737", async() => {
                BeginContext(2407, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 65 "C:\Users\rajkumar.joseph\Documents\GitHub\RajSample\ContactApp\Pages\SchoolContacts\Details.cshtml"
                           WriteLiteral(Model.SchoolContact.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2415, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2423, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a89dc5bc6cd3ffd7cfe1c944ac64ea7cb8b2ad214090", async() => {
                BeginContext(2445, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2461, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactApp.Pages.SchoolContacts.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContactApp.Pages.SchoolContacts.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContactApp.Pages.SchoolContacts.DetailsModel>)PageContext?.ViewData;
        public ContactApp.Pages.SchoolContacts.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591