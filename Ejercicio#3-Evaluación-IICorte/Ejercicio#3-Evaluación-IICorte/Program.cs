using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_3_Evaluación_IICorte
{
    class Program
    {
        // Diccionario para almacenar el listín telefónico temporalmente en memoria
        static Dictionary<string, string> listin = new Dictionary<string, string>();
        const string archivo = "listin.dat";

        static void Main(string[] args)
        {
            // Cargar los datos del listín desde el archivo al iniciar el programa
            CargarListin();

            int opcion;
            do
            {
                // Menú de opciones
                Console.WriteLine("\n--- Menú de Listín Telefónico ---");
                Console.WriteLine("1. Consultar teléfono de un cliente");
                Console.WriteLine("2. Añadir teléfono de un nuevo cliente");
                Console.WriteLine("3. Eliminar teléfono de un cliente");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ConsultarTelefono();
                        break;
                    case 2:
                        AgregarTelefono();
                        break;
                    case 3:
                        EliminarTelefono();
                        break;
                    case 4:
                        GuardarListin();
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 4); // Ejecuta el menú hasta que se seleccione la opción de salir
        }

        // Método para consultar el teléfono de un cliente
        static void ConsultarTelefono()
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();

            // Verifica si el cliente existe en el diccionario y muestra el teléfono
            if (listin.ContainsKey(nombre))
            {
                Console.WriteLine($"Teléfono de {nombre}: {listin[nombre]}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        // Método para añadir un nuevo cliente con su teléfono
        static void AgregarTelefono()
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el teléfono del cliente: ");
            string telefono = Console.ReadLine();

            // Añade el cliente al diccionario y muestra un mensaje de confirmación
            if (!listin.ContainsKey(nombre))
            {
                listin.Add(nombre, telefono);
                Console.WriteLine("Cliente añadido correctamente.");
            }
            else
            {
                Console.WriteLine("El cliente ya existe en el listín.");
            }
        }

        // Método para eliminar el teléfono de un cliente
        static void EliminarTelefono()
        {
            Console.Write("Ingrese el nombre del cliente a eliminar: ");
            string nombre = Console.ReadLine();

            // Verifica si el cliente existe y lo elimina del diccionario
            if (listin.Remove(nombre))
            {
                Console.WriteLine("Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        // Método para guardar el listín telefónico en un archivo de texto
        static void GuardarListin()
        {
            using (StreamWriter writer = new StreamWriter(archivo))
            {
                foreach (var entrada in listin)
                {
                    writer.WriteLine($"{entrada.Key},{entrada.Value}");
                }
            }
        }

        // Método para cargar el listín telefónico desde un archivo de texto al iniciar el programa
        static void CargarListin()
        {
            if (File.Exists(archivo))
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        if (datos.Length == 2)
                        {
                            listin[datos[0]] = datos[1];
                        }
                    }
                }
            }
        }
    }
}
