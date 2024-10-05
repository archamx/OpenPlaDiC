using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PlaDiC.WebPortal
{
    public static class ViewResultExtensions
    { 
        /// <summary>
        /// Extends View to get result of view as HTML rendered
        /// Use inside some Action:
        /// 
        /// var view = this.View(“ViewName”);
        /// 
        /// var html = view.ToHtml();
        /// </summary>
        /// <param name="result"></param>
        /// <param name="httpContext"></param>
        /// <returns>HTML code</returns>
        public static string ToHtml(this ViewResult result, HttpContext httpContext)
        {
            var feature = httpContext.Features.Get<IRoutingFeature>();
            var routeData = feature.RouteData;
            var viewName = result.ViewName ?? routeData.Values["action"] as string;
            var actionContext = new ActionContext(httpContext, routeData, new ControllerActionDescriptor());
            var options = httpContext.RequestServices.GetRequiredService<IOptions<MvcViewOptions>>();
            var htmlHelperOptions = options.Value.HtmlHelperOptions;
            var viewEngineResult = result.ViewEngine?.FindView(actionContext, viewName, true) ?? options.Value.ViewEngines.Select(x => x.FindView(actionContext, viewName, true)).FirstOrDefault(x => x != null);
            var view = viewEngineResult.View;
            var builder = new StringBuilder();

            using (var output = new StringWriter(builder))
            {
                var viewContext = new ViewContext(actionContext, view, result.ViewData, result.TempData, output, htmlHelperOptions);

                view
                    .RenderAsync(viewContext)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
            }

            return builder.ToString();
        }
    }
}
