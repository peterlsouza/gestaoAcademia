#pragma checksum "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbf777f4b553e122308bfe1ce3d32d8da1b5fb5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ListagemExercicioFicha_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ListagemExercicioFicha/Default.cshtml")]
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
#line 1 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\_ViewImports.cshtml"
using GestaoAcademia;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\_ViewImports.cshtml"
using GestaoAcademia.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbf777f4b553e122308bfe1ce3d32d8da1b5fb5c", @"/Views/Shared/Components/ListagemExercicioFicha/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d56b5bc8f21502f4e34ee01f8293f7aa835ee5e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ListagemExercicioFicha_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GestaoAcademia.Dominio.Models.ListaExercicio>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div>\r\n        <h5>Exercicios</h5>\r\n        <hr />\r\n        <div>\r\n            <table class=\"table hover striped highlight centered\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>\r\n                            ");
#nullable restore
#line 11 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                       Write(Html.DisplayNameFor(model => model.Exercicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 14 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                       Write(Html.DisplayNameFor(model => model.Frequencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 17 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                       Write(Html.DisplayNameFor(model => model.Repeticoes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 20 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                       Write(Html.DisplayNameFor(model => model.Carga));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 25 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 29 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Exercicio.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 32 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Frequencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 35 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Repeticoes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 38 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Carga));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 41 "C:\Labs\Udemy_DotNet\GestaoAcademia\GestaoAcademia\GestaoAcademia\Views\Shared\Components\ListagemExercicioFicha\Default.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GestaoAcademia.Dominio.Models.ListaExercicio>> Html { get; private set; }
    }
}
#pragma warning restore 1591
