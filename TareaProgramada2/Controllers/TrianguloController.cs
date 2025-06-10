using Microsoft.AspNetCore.Mvc;
using TareaProgramada2.Models;

namespace TareaProgramada2.Controllers;

public class TrianguloController : Controller
{
    private readonly ILogger<TrianguloController> _logger;
    public TrianguloController(ILogger<TrianguloController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Calcular([Bind("a,b,c")] TrianguloModel model)
    {

        if (ModelState.IsValid)
        {
            double a = model.a;
            double b = model.b;
            double c = model.c;

            //Ver si los valores forman un triángulo válido
            //La suma de dos lados debe ser mayor que el tercer lado
            if (a >= b + c || b >= a + c || c >= a + b)
            {
                Console.WriteLine("Los valores ingresados no forman un triángulo válido.");
                //ModelState.AddModelError("", "Los valores ingresados no forman un triángulo válido.");
                ViewData["ErrorMessage"] = "Los valores ingresados no forman un triángulo válido.";
                //return View("Index", model);
                return View("Index");
            }

        }

        return View("Index", model);
    }
    
    
}