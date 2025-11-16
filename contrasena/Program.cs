string[] mayusculas = ["A", "B", "C", "D", "E", "F", "G", "H"];
string[] minusculas = ["x", "g", "t", "y", "i", "j", "o", "p"];
string[] especiales = ["@", "#", "$", "%", "&", "*", "!", "?"];
string[] numeros = ["1", "2", "3", "4", "5", "6", "7", "8"];
int longitud = 8;
Random aleatorio = new Random();
List<string> contrasena = new List<string>();

for(int i = 0; i < longitud; i++)
{
    int indiceAleatorio;

    if(i == 0)
    {
        indiceAleatorio = aleatorio.Next(mayusculas.Length);
        contrasena.Add(mayusculas[indiceAleatorio]);
    }
    else if(i <= 5)
    {
        indiceAleatorio = aleatorio.Next(minusculas.Length);
        contrasena.Add(minusculas[indiceAleatorio]);
    }
    else if (i == 6)
    {
        indiceAleatorio = aleatorio.Next(especiales.Length);
        contrasena.Add(especiales[indiceAleatorio]);
    }
    else
    {
        indiceAleatorio = aleatorio.Next(numeros.Length);
        contrasena.Add(numeros[indiceAleatorio]);
    }
}

string resultado = string.Join("", contrasena);
Console.WriteLine($"La contraseña generada es: {resultado}");