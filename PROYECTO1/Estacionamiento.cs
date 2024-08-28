using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Estacionamiento
    {
        List<Auto> listaAutos = new List<Auto>();
        Mensajes mensaje = new Mensajes();

        public void AgregarVehiculo()
        {
            int opcionVehiculo = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("             INGRESAR VEHÍCULO");
                Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
                Console.WriteLine("1. Auto");
                Console.WriteLine("2. Motocicleta");
                Console.WriteLine("3. Camnión");
                Console.WriteLine("4. Regresar al menú principal\n");
                Console.Write("Ingresa el tipo de vehículo: ");
                try
                {
                    opcionVehiculo = Convert.ToInt32(Console.ReadLine());
                    
                    switch (opcionVehiculo)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("           REGISTRAR AUTO");
                            Console.WriteLine("-----------------------------------------\n"); Console.ResetColor();
                            Console.Write("Ingresa la placa: ");
                            Console.Write("Ingresa la marca: ");
                            Console.Write("Ingresa la modelo: ");
                            Console.Write("Ingresa la color: ");
                            DateTime hora = DateTime.Now;
                            Console.Write($"Fecha y hora de salida: {hora}\n");
                            mensaje.Continuar();
                            break;
                        case 2:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("         REGISTRAR MOTOCICLETA");
                            Console.WriteLine("-----------------------------------------\n"); Console.ResetColor();
                            mensaje.Continuar();
                            break;
                        case 3:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("           REGISTRAR CAMIÓN");
                            Console.WriteLine("-----------------------------------------\n"); Console.ResetColor();
                            mensaje.Continuar();
                            break;
                        case 4:
                            Console.Clear();
                            break;
                    }

                }catch (FormatException)
                {
                    mensaje.ErrorDeFormato();
                    mensaje.Continuar();
                }
            } while (opcionVehiculo != 4);
        }
    }
}
