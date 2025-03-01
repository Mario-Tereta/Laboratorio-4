using System;
using System.IO;

class Program
{
    // las rutas que se usaran para crear los archivos planos y carpetas, la ruta 0 sirve para crear la carpeta principal al iniciar el programa
    static string ruta0 = @"C:\LabStark\";
    static string ruta = @"C:\LabStark\Tony Stark\Inventos.txt";
    static string ruta2 = @"C:\LabStark\Tony Stark\Backup\Inventos.txt";
    static string ruta3 = @"C:\LabStark\Tony Stark\Archivos Clasificados\Inventos.txt";
    static string ruta4 = @"C:\LabStark\Tony Stark\TopSecret\";
    static string Listado = "C:/LabStark/Tony Stark";
    static string contenido = "Sistema Creado para que Guarde sus inventos el Sr. Stark"; // mensaje que se agrega al crear siempre un nuevo archivo plano.

    static void newdoc(string Nuevaruta) // Esta Función se hizo para crear una carpeta si no existe
    {
        try
        {
            if (!Directory.Exists(Nuevaruta)) // siempre verifica si ya existe la carpeta
            {
                Directory.CreateDirectory(Nuevaruta); // Si no existe, la crea
                Console.WriteLine($"Nueva ruta creada: {Nuevaruta}");
            }
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Error: El directorio no se pudo encontrar.");//se lanza si el sistema no puede encontrar parte de la ruta especificada.
        }
        catch (IOException)
        {
            Console.WriteLine("Error: Hubo un problema al acceder al directorio.");
        }
    }

    static void CrearArchivo(string ruta, string contenido) // Funcion para crear el archivo principal Inventos.txt
    {        
        try
        {
            newdoc(Path.GetDirectoryName(ruta));// se verifica si la carpeta existe, si no la crea

            File.WriteAllText(ruta, contenido);
            Console.WriteLine("Archivo creado en la ruta: " + ruta); // Crear el archivo y escribir el contenido

            string contenidoLeido = File.ReadAllText(ruta); // Leer y mostrar el contenido del archivo
            Console.WriteLine("Contenido del archivo:");
            Console.WriteLine(contenidoLeido);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error: " + e.Message); //imprime un mensaje en la consola que indica que ocurrió un error, seguido del mensaje de la excepción
        }
    }

    static void AgregarInvento(string ruta) //funcion para agregar informacion nueva sin modificar a Inventos.txt
    {
        Console.WriteLine("Ingrese el nuevo invento:");
        string contenido = Console.ReadLine();
        File.AppendAllText(ruta, Environment.NewLine + contenido);
        Console.WriteLine("Archivo modificado con exito");
    }

    static void LeerLineaPorLinea(String ruta) //Funcion para leer linea por linea el archivo Inventos.txt
    {
        try
        {        
                string[] lineas = File.ReadAllLines(ruta);
                int i = 0;
                foreach (string linea in lineas)
                {
                    i++;
                    Console.WriteLine($"Linea {i}: " + linea); // se agrega la palabara linea + el numero que corresponde para saber que linea se esta leyendo
            }         
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void LeerTodoElTexto(String ruta) //Funcion para leer todo el texto del archivo Inventos.txt
    {
        try
        {
            string contenido = File.ReadAllText(ruta); // Leer y mostrar el contenido del archivo
            Console.WriteLine(contenido);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CopiarArchivo(string origen, string destino) //Funcion para copiar el archivo Inventos.txt a una nueva ubicacion
    {
        newdoc(Path.GetDirectoryName(destino));
        try
        {
            File.Copy(origen, destino, true);       // Copiar el archivo
            Console.WriteLine("Archivo se copio de forma exitosa." + destino);
            Borrarxseguridad(origen);   // se llama a la funcion para borrar el archivo original tal como se piden el Laboratorio4
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: El archivo 'Inventos.txt' no existe. ¡Ultron debe haberlo borrado!"); // se lanza si el sistema no puede encontrar parte de la ruta especificada.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void MoverArchivo(string origen, string destino) //Funcion para mover el archivo Inventos.txt a una nueva ubicacion
    {
        newdoc(Path.GetDirectoryName(destino));     // se verifica si la carpeta existe, si no la crea

        try
        {
            File.Move(origen, destino);      // Mover el archivo a la nueva direccion
            Console.WriteLine("Archivo se movio de forma exitosa.");
        }
        catch (FileNotFoundException) 
        {
            Console.WriteLine("Error: El archivo 'Inventos.txt' no existe. ¡Ultron debe haberlo borrado!"); // se lanza si el sistema no puede encontrar parte de la ruta especificada.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CrearCarpeta(string TSecret) //Funcion para crear la carpeta Top Secret
    {
        // se verifica si la carpeta existe, si no la crea
        try
        {
            newdoc(Path.GetDirectoryName(TSecret));
            Console.WriteLine("Carpeta Top Secret Creada con Exito....");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: El archivo 'Inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); //imprime un mensaje en la consola que indica que ocurrió un error, seguido del mensaje de la excepción
        }
    }

    static void ListarArchivos(string Listado) //Funcion para listar los archivos de la carpeta Tony Stark
    {
        try
        {
            string[] archivos = Directory.GetFiles(Listado); // Obtener los archivos de la carpeta
            Console.WriteLine("Archivos en el directorio: ");
            foreach (string archivo in archivos)    // Mostrar los archivos
            {
                Console.WriteLine(archivo);
            }
            
            string[] carpetas = Directory.GetDirectories(Listado);  // Obtener las carpetas de la carpeta
            Console.WriteLine("Carpetas en el directorio: ");
            foreach (string carpeta in carpetas)                        // Mostrar las carpetas
            {
                Console.WriteLine(carpeta);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error: " + e.Message);
        }
            }

    static void Borrarxseguridad(string ruta) //Funcion para borrar el archivo original despues de copiarlo
    {
        File.Delete(ruta); // Borrar el archivo original
        Console.WriteLine("\nPor seguridad los archivos copiados son EXTERMINADOS de su origen.");
    }


    static void submenu2()  //submenu para las opciones de resguardo de archivos
    {
        Console.Clear();        //limpia la consola
        Console.WriteLine("------------------Bienvenido al Sistema Stark------------");
        Console.WriteLine("Seleccione entre las opciones para resguardar archivos");
        Console.WriteLine("1. Copiar archivo \n2. Mover Archivos \n3.Crear Carpeta Secreta");
        string Opcion2 = Console.ReadLine();

        switch (Opcion2)
        {
            case "1":
                CopiarArchivo(ruta, ruta2);
                break;
            case "2":
                MoverArchivo(ruta, ruta3);
                break;
            case "3":
                CrearCarpeta(ruta4);
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
        Console.ReadKey(); //espera a que el usuario presione una tecla
    }

    static void submenu1() //submenu para las opciones de archivos
    {
        Console.Clear();
        Console.WriteLine("------------------ Bienvenido al Sistema Stark ------------------");
        Console.WriteLine("Seleccione entre las opciones de archivos");
        Console.WriteLine("1. Crear archivo \n2. Agregar Invento nuevo \n3. Leer Archivos línea por línea \n4. Leer todo el texto del archivo");
        string Opcion2 = Console.ReadLine();

        switch (Opcion2)
        {
            case "1":
                CrearArchivo(ruta, contenido);
                break;
            case "2":
                AgregarInvento(ruta);
                break;
            case "3":
                LeerLineaPorLinea(ruta);
                break;
            case "4":
                LeerTodoElTexto(ruta);
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
        Console.ReadKey();
    }
    static void Main(string[] args)
    {        
        newdoc(Path.GetDirectoryName(ruta0)); //Se crea la carpeta principal desde el arranque del programa
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------------------ Bienvenido al Sistema Stark ------------------");
            Console.WriteLine("1. Opciones de Archivo \n2. Resguardo de Archivo \n3. Listar Archivos \n4. Salir\n");

            string opcion = Console.ReadLine(); // Seleccionar una opción para ir a los otros submenus, de esta forma es mas amigable para el usuario y sencillo de entender

            switch (opcion)
            {
                case "1":
                    submenu1 ();
                    break;                
                case "2":
                    submenu2();
                    break;
                case "3":
                    ListarArchivos(Listado);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
