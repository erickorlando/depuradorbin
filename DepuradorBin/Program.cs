using System;
using System.IO;

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
					try
					{
						Directory.Delete(directorio, true);
						Console.WriteLine("Eliminando {0} ...", directorio);
						cantidad++;
					}
					catch (Exception ex)
					{
						Console.WriteLine("No se pudo borrar {0}:{1}", directorio, ex.Message);
					}
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
