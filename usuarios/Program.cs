
// Lista de usuarios a manipular
List<Usuario> colaboradores = new List<Usuario>();

// Menu de interaccion
while(true)
{
    Console.WriteLine("---- Bienvenido a tu gestion de usuarios ----");
    Console.WriteLine("1. Ver la lista de usuarios");
    Console.WriteLine("2. Crear un usuario");
    Console.WriteLine("3. Editar un usuario");
    Console.WriteLine("4. Eiminar un usuario");
    Console.WriteLine("5. Salir\n");
    Console.WriteLine("Escoge el numero de la accion que deseas realizar");
    string menu = Console.ReadLine();

    // Casos de uso segun la interaccion
    switch(menu)
    {
        case "1":
            ListarUsuarios();
        break;
        case "2":
            CrearUsuario();
        break;
        case "3":
            EditarUsuario();
        break;
        case "4":
            EliminarUsuario();
        break;
        case "5":
            return;
        default:
            Console.WriteLine("Escoge una opcion valida del menu");
        break;
    }
}

// Funcion para crear un usuario
void CrearUsuario() 
{
    Console.WriteLine("---- Creacion de usuario ----");
    Console.WriteLine("Ingresa un nombre:");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingresa la edad:");
    string edad = Console.ReadLine();
    Console.WriteLine("Ingresa la contrasena:");
    string contrasena = Console.ReadLine();

    if(Int32.TryParse(edad, out int edadNumerica))
    {
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(contrasena))
            {
                Usuario nuevoUsuario = new Usuario(nombre, edadNumerica, contrasena);
                colaboradores.Add(nuevoUsuario);
                Console.WriteLine("Usuario creado con exito!\n");
                ListarUsuarios();
            }
            else
            {
                Console.WriteLine("El nombre o contrasena no pueden estar vacios.");
            }
    }
    else
    {
        Console.WriteLine("Ingresa una edad valida!");
    }
}

// Funcion para listar los usuarios
void ListarUsuarios()
{
    Console.WriteLine("---- Lista de usuarios actual ----");
    if(colaboradores.Count == 0)
    {
        Console.WriteLine("No hay usuarios en la lista");
    }
    
    foreach(var usuario in colaboradores)
    {
        Console.WriteLine(usuario.informacion());
    }
    Console.WriteLine("\n");
}

// Funcion para editar un usuario por id
void EditarUsuario()
{
    Console.WriteLine("---- Editar Usuario ----");
    Console.WriteLine("Ingresa el id del usuario a editar:");
    string entrada = Console.ReadLine();

    if (int.TryParse(entrada, out int idBusqueda))
    {
        Usuario usuarioEncontrado = colaboradores.Find(u => u.Id == idBusqueda);

        if (usuarioEncontrado != null)
        {
            Console.WriteLine($"Usuario encontrado: {usuarioEncontrado.Nombre}");
            Console.WriteLine("(Presiona ENTER si no quieres cambiar el valor)");
            Console.Write($"Ingresa un nuevo nombre o conserva el actual: {usuarioEncontrado.Nombre}: ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                usuarioEncontrado.Nombre = nuevoNombre;
            }
            Console.Write($"Ingresa una nueva edad o conserva la actual: {usuarioEncontrado.Edad}: ");
            string nuevaEdad = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaEdad))
            {
                if (Int32.TryParse(nuevaEdad, out int valorEdad))
                {
                    usuarioEncontrado.Edad = valorEdad;
                }
                else
                {
                    Console.WriteLine("Edad invalida (Se conserva la misma edad)");
                }
            }
            Console.Write($"Ingresa una nueva contrasena o conserva la actual: {usuarioEncontrado.Contrasena}: ");
            string nuevaContrasena = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaContrasena))
            {
                usuarioEncontrado.Contrasena = nuevaContrasena;
            }

            Console.WriteLine("Usuario actualizado con éxito!");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado");
        }
    }
    else
    {
        Console.WriteLine("Ingresa un id valido");
    }
    ListarUsuarios();
}

// Funcion para eliminar un usuario por id
void EliminarUsuario()
{
    Console.WriteLine("---- Eliminar Usuario ----");
    Console.WriteLine("Ingresa el id del usuario a eliminar:");
    string entrada = Console.ReadLine();

    if (Int32.TryParse(entrada, out int idBusqueda))
    {
        Usuario usuarioEncontrado = colaboradores.Find(u => u.Id == idBusqueda);

        if (usuarioEncontrado != null)
        {
            colaboradores.Remove(usuarioEncontrado);
            Console.WriteLine($"El usuario con id {idBusqueda} ha sido eliminado.");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado");
        }
    }
    else
    {
        Console.WriteLine("Ingresa un id valido");
    }
    ListarUsuarios();
}

// Clase principal del tipo Usuario
public class Usuario {
    private static int _contadorEstatico = 0;

    public int Id { get; private set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Contrasena { get; set; }

    public Usuario(string nombre, int edad, string contrasena)
    {
        _contadorEstatico++;

        Id = _contadorEstatico;
        Nombre = nombre;
        Edad = edad;
        Contrasena = contrasena;
    }

    public string informacion()
    {
        return $"Id: {Id} - El usuario {Nombre} tiene una edad de {Edad} - Contrasena: {Contrasena}";
    }
}