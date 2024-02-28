using Microsoft.AspNetCore.Mvc;

namespace NicolasSite.Controllers
{
    /// <summary>
    /// Classe lié traitement de fichier de maman
    /// </summary>
    public class MunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Chargment du fichier
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile fileUpload)
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileUpload.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                ViewBag.Message = "Fichier chargé avec succès !";
            }
            else
            {
                ViewBag.Message = "Le fichier est invalide.";
            }

            return View("Index");
        }
    }
}
