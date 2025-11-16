
string[] palabras = ["andrea", "color", "existencia", "dopamina", "azul", "universo", "carisma", "jurisprudencia"];
Random aleatorio = new Random();
int indiceAleatorio = aleatorio.Next(palabras.Length);
string palabraAleatoria = palabras[indiceAleatorio];

char[] palabraFragmentada = palabraAleatoria.ToCharArray();
int indiceExacto = palabraFragmentada.Count();

List<string> errores = new List<string>();
List<string> aciertos = new List<string>();
List<string> validacion = new List<string>();

string palabraOculta = new string('_', indiceExacto);

Console.WriteLine("---- Reglas ----");
Console.WriteLine("Puedes ingresar una letra para intentar completar la palabra");
Console.WriteLine("Por cada letra que resulte erronea obtendras un punto de error, perderas al llegar a 5 puntos de error");
Console.WriteLine("----------------\n");
Console.WriteLine($"Juego iniciado palabra: {palabraOculta} - pista {indiceExacto} letras");
Console.WriteLine($"Errores: {errores.Count()}\n");

while(errores.Count() < 5)
{
    Console.WriteLine("Ingresa una letra");
    string letra = Console.ReadLine().ToLower();

    if (string.IsNullOrEmpty(letra) || letra.Length > 1)
    {
        Console.WriteLine("Entrada no válida. Debes ingresar UNA sola letra.");
        continue;
    }

    if (aciertos.Contains(letra) || errores.Contains(letra))
    {
        Console.WriteLine($"Ya intentaste con la letra '{letra}'. Prueba otra.");
        continue;
    }

    if(palabraAleatoria.Contains(letra))
    {
        Console.WriteLine($"Acertaste! la palabra contiene la letra {letra}\n");
        aciertos.Add(letra);
    }
    else
    {
        Console.WriteLine($"Mala suerte la palabra no contiene la letra {letra} - Obtuviste un punto de error");
        errores.Add(letra);
        Console.WriteLine($"Errores: {errores.Count()}\n");
    }

    validacion.Clear();
    foreach(char caracter in palabraFragmentada)
    {
        if(aciertos.Contains(caracter.ToString()))
        {
            validacion.Add(caracter.ToString());
        }
        else
        {
            validacion.Add("_");
        }
    }

    string[] palabraActual = validacion.ToArray();
    string resultado = string.Join("", palabraActual);
    Console.WriteLine(resultado);
    if (resultado == palabraAleatoria)
    {
        break;
    }
}

if(errores.Count() == 5)
{
    Console.WriteLine("Perdiste! - Juego terminado");
}
else
{
    Console.WriteLine($"Felicidades ganaste! - la palabra es: {palabraAleatoria}");
}