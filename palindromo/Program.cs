
Console.WriteLine("Ingrese una palabra");
string palabraOriginal = Console.ReadLine().ToLower();

if(string.IsNullOrEmpty(palabraOriginal))
{
    Console.WriteLine("Ingresa una palabra valida");
    return;
}

char[] palabraFragmentada = palabraOriginal.ToCharArray();
int index = palabraFragmentada.Count() - 1;
List<char> listaInvertida = new List<char>();

for(int i = index; i >= 0; i--)
{
    listaInvertida.Add(palabraFragmentada[i]);
}

string palabraInvertida = new string(listaInvertida.ToArray());

if (palabraOriginal.ToLower() == palabraInvertida)
{
    Console.WriteLine($"La palabra '{palabraOriginal}' es un palíndromo.");
}
else
{
    Console.WriteLine($"La palabra '{palabraOriginal}' no es un palíndromo.");
}