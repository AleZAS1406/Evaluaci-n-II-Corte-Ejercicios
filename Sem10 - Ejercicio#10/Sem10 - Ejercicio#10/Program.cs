    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    namespace Sem10___Ejercicio_10
    {
        class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public int AñoPublicacion { get; set; }
            public decimal Precio { get; set; }

            // Sobreescribimos el método ToString para mostrar la información del libro en formato legible
            public override string ToString()
            {
                return $"Título: {Titulo}, Autor: {Autor}, Año: {AñoPublicacion}, Precio: ${Precio}";
            }
        }

        class Program
        {
            // Lista para almacenar los libros en memoria temporal
            static List<Libro> libros = new List<Libro>();
            // Nombre del archivo binario donde se almacenarán los libros
            const string archivo = "libros.dat";

            static void Main(string[] args)
            {
                // Cargar libros desde el archivo binario al iniciar el programa
                CargarLibros();

                int opcion;
                // Ciclo principal del menú
                do
                {
                    Console.WriteLine("\n--- Menú ---");
                    Console.WriteLine("1. Agregar un libro");
                    Console.WriteLine("2. Listar todos los libros");
                    Console.WriteLine("3. Buscar un libro por título");
                    Console.WriteLine("4. Salir");
                    Console.Write("Seleccione una opción: ");
                    opcion = int.Parse(Console.ReadLine());

                    // Llamada a la opción seleccionada por el usuario
                    switch (opcion)
                    {
                        case 1:
                            AgregarLibro(); // Llama al método para agregar un nuevo libro
                            break;
                        case 2:
                            ListarLibros(); // Llama al método para listar todos los libros
                            break;
                        case 3:
                            BuscarLibro(); // Llama al método para buscar un libro por título
                            break;
                        case 4:
                            GuardarLibros(); // Guarda los libros al archivo antes de salir
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                } while (opcion != 4); // El ciclo se repite hasta que el usuario elija salir
            }

            // Método para agregar un nuevo libro
            static void AgregarLibro()
            {
                Console.Write("Ingrese el título del libro: ");
                string titulo = Console.ReadLine();
                Console.Write("Ingrese el autor del libro: ");
                string autor = Console.ReadLine();
                Console.Write("Ingrese el año de publicación: ");
                int anio = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el precio del libro: ");
                decimal precio = decimal.Parse(Console.ReadLine());

                // Se crea un nuevo libro y se agrega a la lista
                libros.Add(new Libro { Titulo = titulo, Autor = autor, AñoPublicacion = anio, Precio = precio });
                Console.WriteLine("Libro agregado exitosamente.");
            }

            // Método para listar todos los libros almacenados
            static void ListarLibros()
            {
                if (libros.Count == 0)
                {
                    Console.WriteLine("No hay libros almacenados.");
                }
                else
                {
                    Console.WriteLine("\n--- Lista de Libros ---");
                    // Muestra cada libro en la lista
                    foreach (var libro in libros)
                    {
                        Console.WriteLine(libro);
                    }
                }
            }

            // Método para buscar un libro por su título
            static void BuscarLibro()
            {
                Console.Write("Ingrese el título del libro a buscar: ");
                string tituloBusqueda = Console.ReadLine();
                // Busca el libro por título (sin distinguir mayúsculas de minúsculas)
                var libroEncontrado = libros.Find(libro => libro.Titulo.Equals(tituloBusqueda, StringComparison.OrdinalIgnoreCase));

                if (libroEncontrado != null)
                {
                    Console.WriteLine("Libro encontrado:");
                    Console.WriteLine(libroEncontrado);
                }
                else
                {
                    Console.WriteLine("No se encontró un libro con ese título.");
                }
            }

            // Método para guardar la lista de libros en un archivo binario
            static void GuardarLibros()
            {
                // Usa un FileStream para escribir en el archivo binario
                using (FileStream fs = new FileStream(archivo, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, libros); // Serializa la lista de libros
                }
            }

            // Método para cargar la lista de libros desde un archivo binario
            static void CargarLibros()
            {
                // Solo intenta cargar si el archivo existe
                if (File.Exists(archivo))
                {
                    using (FileStream fs = new FileStream(archivo, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        libros = (List<Libro>)formatter.Deserialize(fs); // Deserializa y carga los libros
                    }
                }
            }
        }
    }























