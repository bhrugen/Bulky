using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;
public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
