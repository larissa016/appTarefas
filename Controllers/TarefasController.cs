using Microsoft.AspNetCore.Mvc;

namespace appTarefas.Controllers
{
    public class TarefasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
