using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlaDiC.Framework;

namespace PlaDiC.WebPortal.Controllers
{
    public class CustomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAnyView(string viewName)
        {
            try
            {
                var lista = new List<Parameter>();

                foreach (var k in Request.Query.Keys)
                {
                    lista.Add(new Parameter(k, Request.Query[k]!));
                }

                TempData["DataQuery"] = JsonConvert.SerializeObject(lista);


                var view = this.View(viewName);
                view.ExecuteResult(this.ControllerContext);
                
                return view;



            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }



            //return View(viewName);
        }




    }



}
