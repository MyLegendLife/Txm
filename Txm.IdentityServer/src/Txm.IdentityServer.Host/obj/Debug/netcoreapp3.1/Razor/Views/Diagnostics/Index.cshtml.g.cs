#pragma checksum "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1177e61a9cafd0643770b651160368051a3710d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diagnostics_Index), @"mvc.1.0.view", @"/Views/Diagnostics/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1177e61a9cafd0643770b651160368051a3710d1", @"/Views/Diagnostics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b35857dd199098649926cf8d40cf1622e149676b", @"/Views/_ViewImports.cshtml")]
    public class Views_Diagnostics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Txm.IdentityServer.Host.Quickstart.Diagnostics.DiagnosticsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""diagnostics-page"">
    <div class=""lead"">
        <h1>Authentication Cookie</h1>
    </div>

    <div class=""row"">
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Claims</h2>
                </div>
                <div class=""card-body"">
                    <dl>
");
#nullable restore
#line 16 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                         foreach (var claim in Model.AuthenticateResult.Principal.Claims)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>");
#nullable restore
#line 18 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                           Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\n                            <dd>");
#nullable restore
#line 19 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                           Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n");
#nullable restore
#line 20 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </dl>
                </div>
            </div>
        </div>
        
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Properties</h2>
                </div>
                <div class=""card-body"">
                    <dl>
");
#nullable restore
#line 33 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                         foreach (var prop in Model.AuthenticateResult.Properties.Items)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>");
#nullable restore
#line 35 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                           Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\n                            <dd>");
#nullable restore
#line 36 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                           Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n");
#nullable restore
#line 37 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                         if (Model.Clients.Any())
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>Clients</dt>\n                            <dd>\n");
#nullable restore
#line 42 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                              
                                var clients = Model.Clients.ToArray();
                                for(var i = 0; i < clients.Length; i++)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                                     Write(clients[i]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                                                            
                                    if (i < clients.Length - 1)
                                    {
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 49 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                                                       
                                    }
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </dd>\n");
#nullable restore
#line 54 "D:\Projects\Learning\Txm\Txm.IdentityServer\src\Txm.IdentityServer.Host\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </dl>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Txm.IdentityServer.Host.Quickstart.Diagnostics.DiagnosticsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
