using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace DepuradorBin
{
    class Program
    {
        static int cantidad;

        static void Main(string[] args)
        {
            try
            {
                EliminarCarpetas(Environment.CurrentDirectory);

                Console.WriteLine("Proceso Terminado con {0} eliminaciones", cantidad);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public static void EliminarCarpetas(string ruta)
        {
            foreach (string directorio in Directory.GetDirectories(ruta))
            {
                if (directorio.EndsWith("\\bin") || directorio.EndsWith("\\obj"))
                {
                    Directory.Delete(directorio, true);
                    Console.WriteLine("Eliminando {0} ...", directorio);
                    cantidad++;
                }
                else
                {
                    Console.WriteLine("Buscando en {0}... ", directorio);
                    EliminarCarpetas(directorio);
                }
            }
        }
    }
}
