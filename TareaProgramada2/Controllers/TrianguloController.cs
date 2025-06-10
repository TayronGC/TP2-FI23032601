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
            double perimetro = model.Perimetro; // a + b + c;
            double semiperimetro = model.Semiperimetro;
            double area = model.Area;


            //model.Perimetro= a + b + c;
            //model.Semiperimetro = model.Perimetro / 2;
            //model.Area = Math.Sqrt(model.Semiperimetro * (model.Semiperimetro - a) * (model.Semiperimetro - b) * (model.Semiperimetro - c));




            if (a >= b + c || b >= a + c || c >= a + b)
            {
                Console.WriteLine("Los valores ingresados no forman un triángulo válido.");
                //ModelState.AddModelError("", "Los valores ingresados no forman un triángulo válido.");
                ViewData["ErrorMessage"] = "Los valores ingresados no forman un triángulo válido.";
                //return View("Index", model);
                return View("Index", model);
            }

            //perimetro = a + b + c;
            //semiperimetro = perimetro / 2;
            //area = Math.Sqrt(semiperimetro * (semiperimetro - a) * (semiperimetro - b) * (semiperimetro - c));

            // ViewData["Perimetro"] = $"P = {perimetro} u";
            // ViewData["Semiperimetro"] = $"S = {semiperimetro} u";
            // ViewData["Area"] = $"A = {area} u²";
            // ViewData["Alfa"] = $"Alfa = {model.Alfa.ToString("F2")}°";
            // ViewData["Beta"] = $"Beta = {model.Beta.ToString("F2")}°";
            // ViewData["Gamma"] = $"Gamma = {model.Gamma.ToString("F2")}°";

            string tipoTriangulo;

            if (a == b && b == c)
            {
                tipoTriangulo = "Equilátero";
            }
            else if (a == b || b == c || a == c)
            {
                tipoTriangulo = "Isósceles";
            }
            else
            {
                tipoTriangulo = "Escaleno";
            }
            ViewData["TipoTriangulo"] = $"Tipo de triángulo: {tipoTriangulo}";
        }

        return View("Index", model);
    }
    
    
}