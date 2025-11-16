
Console.WriteLine("Ingresa la posicion hasta la que se calculara la sucesion fibonacci");
string entrada = Console.ReadLine();
int numero;
List<int> serieFibonacci = new List<int>(); 

if (!int.TryParse(entrada, out numero) || numero <= 0)
{
    Console.WriteLine("Ingresa un numero valido (mayor a 0)");
    return;
}

for(int i = 0; i < numero; i++)
{
    if(i == 0)
    {
        serieFibonacci.Add(i);
    }
    else
    {
        if(i == 1)
        {
            serieFibonacci.Add(i);
        }
        else
        {
            int continuacion = serieFibonacci[i - 1] + serieFibonacci[i - 2];
            serieFibonacci.Add(continuacion);
        }
    }
}

string contenido = string.Join(",", serieFibonacci);
string resultado = $"[{contenido}]";
Console.WriteLine(resultado);