#pragma checksum "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36b341a848e8d1de0c226de3714fa818f7f970c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ScopeListItem), @"mvc.1.0.view", @"/Views/Shared/_ScopeListItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36b341a848e8d1de0c226de3714fa818f7f970c1", @"/Views/Shared/_ScopeListItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b35857dd199098649926cf8d40cf1622e149676b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ScopeListItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Txm.IdentityServer.Host.Quickstart.Consent.ScopeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<li class=\"list-group-item\">\n    <label>\n        <input class=\"consent-scopecheck\"\n               type=\"checkbox\"\n               name=\"ScopesConsented\"");
            BeginWriteAttribute("id", "\n               id=\"", 217, "\"", 256, 2);
            WriteAttributeValue("", 237, "scopes_", 237, 7, true);
#nullable restore
#line 8 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 244, Model.Value, 244, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", "\n               value=\"", 257, "\"", 292, 1);
#nullable restore
#line 9 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 280, Model.Value, 280, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("checked", "\n               checked=\"", 293, "\"", 332, 1);
#nullable restore
#line 10 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 318, Model.Checked, 318, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("disabled", "\n               disabled=\"", 333, "\"", 374, 1);
#nullable restore
#line 11 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 359, Model.Required, 359, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n");
#nullable restore
#line 12 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
         if (Model.Required)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"hidden\"\n                   name=\"ScopesConsented\"");
            BeginWriteAttribute("value", "\n                   value=\"", 492, "\"", 531, 1);
#nullable restore
#line 16 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 519, Model.Value, 519, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n");
#nullable restore
#line 17 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <strong>");
#nullable restore
#line 18 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
           Write(Model.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\n");
#nullable restore
#line 19 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
         if (Model.Emphasize)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"glyphicon glyphicon-exclamation-sign\"></span>\n");
#nullable restore
#line 22 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </label>\n");
#nullable restore
#line 24 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
     if (Model.Required)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span><em>(required)</em></span>\n");
#nullable restore
#line 27 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
     if (Model.Description != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"consent-description\">\n            <label");
            BeginWriteAttribute("for", " for=\"", 904, "\"", 929, 2);
            WriteAttributeValue("", 910, "scopes_", 910, 7, true);
#nullable restore
#line 31 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 917, Model.Value, 917, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 31 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
                                        Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n        </div>\n");
#nullable restore
#line 33 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Shared\_ScopeListItem.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Txm.IdentityServer.Host.Quickstart.Consent.ScopeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
