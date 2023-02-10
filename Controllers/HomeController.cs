using Microsoft.AspNetCore.Mvc;

namespace trello;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
