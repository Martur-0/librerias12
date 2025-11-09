using System;

namespace Semana12_FundamentosDeAlgoritmos
{
    class Libreria
    {
        private string[] nombres = new string[0];
        private double[] precios = new double[0];

      
        public void Registrar()
        {
            Console.WriteLine("\n=== RESGISTRO DE LIBROS ===");
            Console.Write("Ingrese el nombre del libro: ");
            string nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }
            if (Array.Exists(nombres, n => n.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("El libro ya existe en el registro.");
                return;
            }

            Console.Write("Ingrese el precio del libro: ");
            string precioInput = Console.ReadLine();
            if (!double.TryParse(precioInput, out double precio))
            {
                Console.WriteLine("El precio debe ser numérico.");
                return;
            }

            if (precio < 0)
            {
                Console.WriteLine("El precio no puede ser negativo.");
                return;
            }
            if (precio > 1000)
            {
                Console.WriteLine("El precio máximo permitido es 1000.");
              
                
                return;
            }



            Array.Resize(ref nombres, nombres.Length + 1);
            Array.Resize(ref precios, precios.Length + 1);

            nombres[nombres.Length - 1] = nombre;
            precios[precios.Length - 1] = precio;

            Console.WriteLine("Libro registrado correctamente.");
        }

    
        public void Mostrar()
        {
            Console.WriteLine("\n=== LISTA DE LIBROS ===");

            if (nombres.Length == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - S/ {precios[i]:0.00}");
          
            }
        }

       
        public void Modificar()
        {
            Console.WriteLine("\n=== MODIFICAR LIBRO ===");
            Console.Write("Ingrese el nombre del libro a modificar: ");
            string buscar = Console.ReadLine()?.Trim();

            int indice = Array.FindIndex(nombres, n => n.Equals(buscar, StringComparison.OrdinalIgnoreCase));

            if (indice == -1)
            {
                Console.WriteLine(" Libro no encontrado.");
                return;
            }

            Console.Write("Nuevo nombre del libro (enter para mantener): ");
            string nuevoNombre = Console.ReadLine()?.Trim();

            
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                nuevoNombre = nombres[indice];
            }
            else
            {
                if (Array.Exists(nombres, n => n.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase)) &&
                    !nombres[indice].Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(" Ya existe un libro con ese nombre.");
                    return;
                }
            }

            Console.Write("Nuevo precio (enter para mantener): ");
            string precioInput = Console.ReadLine();

            double nuevoPrecio;
            if (string.IsNullOrWhiteSpace(precioInput))
            {
                nuevoPrecio = precios[indice]; 
            }
            else
            {
                if (!double.TryParse(precioInput, out nuevoPrecio))
                {
                    Console.WriteLine(" El precio debe ser numérico.");
                    return;
                }

                if (nuevoPrecio < 0 || nuevoPrecio > 1000)
                {
                    Console.WriteLine(" El precio debe estar entre 0 y 1000.");
                    return;
                }
            }

            nombres[indice] = nuevoNombre;
            precios[indice] = nuevoPrecio;

            Console.WriteLine(" Libro modificado correctamente.");
        }

      
        public void Eliminar()
        {
            Console.WriteLine("\n=== ELIMINAR LIBRO ===");
            Console.Write("Ingrese el nombre del libro a eliminar: ");
            string eliminar = Console.ReadLine()?.Trim();

            int indice = Array.FindIndex(nombres, n => n.Equals(eliminar, StringComparison.OrdinalIgnoreCase));

            if (indice == -1)
            {
                Console.WriteLine(" Libro no encontrado.");
                return;
            }

           
            Console.Write($"¿Seguro que desea eliminar \"{nombres[indice]}\"? (S/N): ");
            string conf = Console.ReadLine()?.Trim().ToUpper();
            if (conf != "S") { Console.WriteLine("Operación cancelada."); return; }

            
            for (int i = indice; i < nombres.Length - 1; i++)
            {
                nombres[i] = nombres[i + 1];
                precios[i] = precios[i + 1];
            }

            Array.Resize(ref nombres, nombres.Length - 1);
            Array.Resize(ref precios, precios.Length - 1);

            Console.WriteLine("Libro eliminado correctamente.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Libreria libreria = new Libreria();
            int opcion = 0;

            do
            {
                Console.WriteLine("\n+++++++++++++++++++++++++++++");
                Console.WriteLine("     MENÚ - LIBRERÍA UPN");
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.WriteLine("1-. Registrar libro");
                Console.WriteLine("2-. Mostrar libros");
                Console.WriteLine("3-. Modificar libro");
                Console.WriteLine("4-. Eliminar libro");
                Console.WriteLine("5-. Salir");
                Console.Write("Seleccione una opción: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out opcion))
                {
                    Console.WriteLine("❌ Ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1: libreria.Registrar(); break;
                    case 2: libreria.Mostrar(); break;
                    case 3: libreria.Modificar(); break;
                    case 4: libreria.Eliminar(); break;
                    case 5: Console.WriteLine("👋 Saliendo del sistema..."); break;
                    default: Console.WriteLine("❌ Opción no válida."); break;
                }

            } while (opcion != 5);
        }
    }
}

