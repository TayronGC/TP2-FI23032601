# Tarea Programada 2 - Aplicación MVC en .NET

**Nombre:** Tayron Jhossue Guzman Campos  
**Carné:** FI23032601  
**Repositorio:** [https://github.com/TayronGC/TP2-FI23032601](https://github.com/TayronGC/TP2-FI23032601)

---

## 📦 Comandos `dotnet` utilizados

```bash
dotnet new sln -n TP2-FI23032601
dotnet new mvc -o TareaProgramada2
dotnet sln add TareaProgramada2
```

## 🤖 Prompts (consultas y respuestas) de ChatGPT utilizados

---

### 🟠 1. Pregunta sobre dónde poner los cálculos del triángulo

**Entrada:**

> Estoy haciendo una página web MVC, en .NET, ¿me recomiendas poner el perímetro, semiperímetro, área, tipo de triángulo, los ángulos alfa, beta y gama en el Modelo de Triángulo o solo mostrar esos cálculos por mensaje?

**Razón:**  
No estaba seguro si colocarlo en el modelo o solo mostrarlo con un `ViewData` o un `ViewBag`.

**Respuesta de ChatGPT:**

Buena pregunta. Si estás haciendo una aplicación MVC en .NET y trabajas con un modelo Triángulo, la mejor práctica depende del rol que quieres que tenga ese modelo.

#### ✅ Recomendación general:
Sí, te recomiendo incluir propiedades calculadas como el perímetro, área, tipo de triángulo y ángulos en el modelo, pero no como campos persistentes (de base de datos), sino como propiedades derivadas (solo de lectura o con getter).

#### 🎯 ¿Por qué incluirlos en el Modelo?

- **Responsabilidad del modelo:** El modelo representa una entidad con lógica de negocio. Un triángulo sabe calcular su área o perímetro; eso no debería depender solo de la vista o el controlador.
- **Reutilización:** Puedes usar esas propiedades en varias vistas o cálculos sin duplicar lógica.
- **Separación de responsabilidades:** Mantienes la lógica fuera del controlador y de la vista.

---

### 🟠 2. Pregunta sobre si los cálculos deben ir en el modelo o en el controlador

**Entrada:**

> ¿Me recomiendas hacer los cálculos de perímetros, semiperímetro, área, los ángulos en el modelo o en el controller?

**Razón:**  
No sabía si poner la lógica en el controller o en el modelo; al principio la tenía en el controller.

**Respuesta de ChatGPT:**

#### 🔹 Responsabilidad del Modelo:
En el patrón MVC, el modelo debe representar los datos y la lógica del dominio. Un triángulo sabe cómo calcular su área, perímetro, ángulos, etc. Esa es su responsabilidad natural.

#### 🔹 Código más limpio y mantenible:
Si haces los cálculos en el controlador, terminas con un `TrianguloController` lleno de lógica matemática, lo cual rompe la separación de responsabilidades.

#### 🔹 Reutilización:
Puedes usar el modelo en distintas partes del sistema (otros controladores, APIs, pruebas unitarias) sin repetir lógica.

#### 🔹 Controladores delgados (Thin Controllers):
Un principio común en MVC es mantener los controladores ligeros. Que solo gestionen la entrada/salida y dejen la lógica pesada al modelo.

---

### 🟠 3. Pregunta sobre mostrar solo dos decimales

**Entrada:**

> ¿Cómo puedo hacer para solo mostrar 2 decimales: 45,492710698341455°?

**Razón:**  
Necesitaba mostrar los ángulos con solo dos cifras decimales en la vista.

**Respuesta de ChatGPT:**

Para mostrar un número con solo 2 decimales en tu aplicación MVC de .NET (por ejemplo, para mostrar un ángulo como `45.49°`), tienes varias opciones dependiendo de dónde quieres formatear el número:

#### ✅ 1. En la Vista Razor (.cshtml):
Usa el método ToString("F2") o string.Format.
```cshtml
<p>Ángulo A: @Model.AnguloA.ToString("F2")°</p>
```

#### ✅ 2. En el Modelo (como propiedad de solo lectura)
Si prefieres devolver el valor ya formateado desde el modelo, puedes crear una propiedad adicional:
```cshtml
public string AnguloAFormateado => AnguloA.ToString("F2");
```

#### ✅ 3. En el Controlador (menos recomendable)
Si vas a pasar el ángulo formateado como parte del ViewModel o ViewBag, puedes hacer:
```cshtml
ViewBag.AnguloA = miTriangulo.AnguloA.ToString("F2");
```