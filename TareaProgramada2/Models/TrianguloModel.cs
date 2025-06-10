
using System.ComponentModel.DataAnnotations;

namespace TareaProgramada2.Models;

public class TrianguloModel
{
    [Required(ErrorMessage = "El valor de A es requerido.")]
    [Range(1, 9999, ErrorMessage = "El valor de A debe estar entre 1 y 9999.")]
    public double a { get; set; }
    [Required(ErrorMessage = "El valor de B es requerido.")]
    [Range(1, 9999, ErrorMessage = "El valor de B debe estar entre 1 y 9999.")]
    public double b { get; set; }
    [Required(ErrorMessage = "El valor de C es requerido.")]
    [Range(1, 9999, ErrorMessage = "El valor de C debe estar entre 1 y 9999.")]
    public double c { get; set; }
    //public string TipoTriangulo { get; set; }

    public double Perimetro => a + b + c;
    public double Semiperimetro => Perimetro / 2;
    public double Area
    {
        get
        {
            return Math.Sqrt(Semiperimetro * (Semiperimetro - a) * (Semiperimetro - b) * (Semiperimetro - c));
        }
    }

    public string TipoTriangulo
    {
        get
        {
            if (a == b && b == c)
                return "Equilátero";
            else if (a == b || b == c || a == c)
                return "Isósceles";
            else
                return "Escaleno";
        }
    }

    public double Alfa => Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
    public double Beta => Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);   

    public double Gamma => Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * (180 / Math.PI);
}