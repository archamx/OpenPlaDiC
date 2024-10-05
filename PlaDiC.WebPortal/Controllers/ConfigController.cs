using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using PlaDiC.Framework;
using System.Reflection;

namespace PlaDiC.WebPortal.Controllers
{
    public class ConfigController : Controller
    {
        private readonly IWebHostEnvironment _env;

        [Authorize]
        public IActionResult ImageGallery()
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

            path += "/wwwroot/images";

            List<GlobalItem> listFiles = new List<GlobalItem>();


            DirectoryInfo di = new DirectoryInfo(path);
            // Create an array representing the files in the current directory.
            System.IO.FileInfo[] fi = di.GetFiles();
            Console.WriteLine("The following files exist in the current directory:");
            // Print out the names of the files in the current directory.
            foreach (System.IO.FileInfo fiTemp in fi)
                listFiles.Add(new GlobalItem(fiTemp.Name, ""));

            return View(listFiles);
        }
/*
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevaImagenGaleria(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images/custom"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return (ActionResult)this.Content("<script language='javascript' type='text/javascript'>document.location='/Configuracion/Galeria'; </script>");
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarImagenGaleria(string Imagen)
        {
            try
            {
                string path = Path.Combine(Server.MapPath("~/Images/custom"),
                                            Path.GetFileName(Imagen));
                System.IO.File.Delete(path);
                ViewBag.Message = "File uploaded successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
            }


            return (ActionResult)this.Content("<script language='javascript' type='text/javascript'>document.location='/Configuracion/Galeria'; </script>");
        }

*/



    }
}
