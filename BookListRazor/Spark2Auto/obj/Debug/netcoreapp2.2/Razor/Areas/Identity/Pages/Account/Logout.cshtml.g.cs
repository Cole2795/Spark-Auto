#pragma checksum "C:\GIT\Net(online)\BookListRazor\Spark2Auto\Areas\Identity\Pages\Account\Logout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "717290da7507f9329619df9fc5a00aa15ca987a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Spark2Auto.Areas.Identity.Pages.Account.Areas_Identity_Pages_Account_Logout), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Logout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Identity/Pages/Account/Logout.cshtml", typeof(Spark2Auto.Areas.Identity.Pages.Account.Areas_Identity_Pages_Account_Logout), null)]
namespace Spark2Auto.Areas.Identity.Pages.Account
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\GIT\Net(online)\BookListRazor\Spark2Auto\Areas\Identity\Pages\_ViewImports.cshtml"
using Spark2Auto.Areas.Identity;

#line default
#line hidden
#line 3 "C:\GIT\Net(online)\BookListRazor\Spark2Auto\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "C:\GIT\Net(online)\BookListRazor\Spark2Auto\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Spark2Auto.Areas.Identity.Pages.Account;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"717290da7507f9329619df9fc5a00aa15ca987a3", @"/Areas/Identity/Pages/Account/Logout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"497547bddd7c116042a55a5332ab7db72cd1f3d4", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"043b18e00928995f00e0462d079ee455888383a7", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Logout : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\GIT\Net(online)\BookListRazor\Spark2Auto\Areas\Identity\Pages\Account\Logout.cshtml"
  
    ViewData["Title"] = "Log out";

#line default
#line hidden
            BeginContext(65, 18, true);
            WriteLiteral("\n<header>\n    <h1>");
            EndContext();
            BeginContext(84, 17, false);
#line 8 "C:\GIT\Net(online)\BookListRazor\Spark2Auto\Areas\Identity\Pages\Account\Logout.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(101, 79, true);
            WriteLiteral("</h1>\n    <p>You have successfully logged out of the application.</p>\n</header>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LogoutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogoutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogoutModel>)PageContext?.ViewData;
        public LogoutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
