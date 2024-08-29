using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Estacionamiento
    {
        List<Auto> listaAutos = new List<Auto>();
        List<Motocicleta> listaMotocicletas = new List<Motocicleta>();
        List<Camion> listaCamiones = new List<Camion>();
        List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        Mensajes mensaje = new Mensajes();

        public void IngresarVehiculo()
        {
            int opcionVehiculo = 0;
            bool sideCarM = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("             INGRESAR VEHÍCULO");
                Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
                Console.WriteLine("1. Auto");
                Console.WriteLine("2. Motocicleta");
                Console.WriteLine("3. Camnión");
                Console.WriteLine("4. Regresar al menú principal\n");
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.Write("Ingresa el tipo de vehículo: ");
                try
                {
                    opcionVehiculo = Convert.ToInt32(Console.ReadLine());
                    
                    switch (opcionVehiculo)
                    {
                        case 1:
                            if (listaAutos.Count >= 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("No hay espacios para autos disponibles.");
                                mensaje.Continuar();
                                return;
                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("           REGISTRAR AUTO");
                            Console.WriteLine("-----------------------------------------\n"); Console.ResetColor();
                            Console.Write("Ingresa la placa: ");
                            string placaA = Console.ReadLine();
                            Console.Write("Ingresa la marca: ");
                            string marcaA = Console.ReadLine();
                            Console.Write("Ingresa la modelo: ");
                            string modeloA = Console.ReadLine();
                            Console.Write("Ingresa la color: ");
                            string colorA = Console.ReadLine();
                            DateTime horaA = DateTime.Now;
                            Console.WriteLine($"Fecha y hora de salida: {horaA}");
                            Console.Write("Ingresa la cantidad de puertas: ");
                            int cantidadDePuertas = Convert.ToInt32( Console.ReadLine());
                            Auto nuevoAuto = new Auto(placaA, marcaA, modeloA, colorA, horaA, cantidadDePuertas);
                            listaAutos.Add(nuevoAuto);
                            listaVehiculos.Add(nuevoAuto);
                            mensaje.RegistroExitoso();
                            mensaje.Continuar();
                            break;
                        case 2:
                            if (listaMotocicletas.Count >= 5)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("No hay espacios para motocicletas disponibles.");
                                mensaje.Continuar();
                                break;
                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("         REGISTRAR MOTOCICLETA");
                            Console.WriteLine("-----------------------------------------\n"); Console.ResetColor();
                            Console.Write("Ingresa la placa: ");
                            string placaM = Console.ReadLine();
                            Console.Write("Ingresa la marca: ");
                            string marcaM = Console.ReadLine();
                            Console.Write("Ingresa la modelo: ");
                            string modeloM = Console.ReadLine();
                            Console.Write("Ingresa la color: ");
                            string colorM = Console.ReadLine();
                            DateTime horaM = DateTime.Now;
                            Console.WriteLine($"Fecha y hora de salida: {horaM}");
                            Console.Write("¿La motocicleta tiene sidecar? (SI/NO)");
                            string sideCar = Console.ReadLine();
                            if (sideCar.ToLower() == "si")
                                sideCarM = true;
                            Motocicleta nuevaMoto = new Motocicleta(placaM, marcaM, modeloM, colorM, horaM, sideCarM);
                            listaMotocicletas.Add(nuevaMoto);
                            listaVehiculos.Add(nuevaMoto);
                            mensaje.RegistroExitoso();
                            mensaje.Continuar();
                            break;
                        case 3:
                            if (listaCamiones.Count >= 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("No hay espacios para camiones disponibles.");
                                mensaje.Continuar();
                                break;
                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("           REGISTRAR CAMIÓN");
                            Console.WriteLine("-----------------------------------------\n"); Console.ResetColor();
                            Console.Write("Ingresa la placa: ");
                            string placaC = Console.ReadLine();
                            Console.Write("Ingresa la marca: ");
                            string marcaC = Console.ReadLine();
                            Console.Write("Ingresa la modelo: ");
                            string modeloC = Console.ReadLine();
                            Console.Write("Ingresa la color: ");
                            string colorC = Console.ReadLine();
                            DateTime horaC = DateTime.Now;
                            Console.WriteLine($"Fecha y hora de salida: {horaC}");
                            Console.Write("Ingresa la capacidad de carga (kg): ");
                            decimal capacidadDeCarga = Convert.ToDecimal(Console.ReadLine());
                            Camion nuevoCamion = new Camion(placaC, marcaC, modeloC, colorC, horaC, capacidadDeCarga);
                            listaCamiones.Add(nuevoCamion);
                            listaVehiculos.Add(nuevoCamion);
                            mensaje.RegistroExitoso();
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

        public void RetirarVehiculo()
        {
            int opcionRetirar = 0;
            if (listaVehiculos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("No hay vehículos estacionados.");
                mensaje.Continuar();
                return;
            }
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("              RETIRAR VEHÍCULO");
                Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
                Console.WriteLine("1. Auto");
                Console.WriteLine("2. Motocicleta");
                Console.WriteLine("3. Camnión");
                Console.WriteLine("4. Regresar al menú principal\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Ingresa el tipo de vehículo a retirar: ");
            } while (opcionRetirar != 4);
        }

        private int CalcularHorasEstacionado(DateTime horaSalida, DateTime horaEntrada)
        {
            TimeSpan tiempoTranscurrido = horaSalida - horaEntrada;
            double minutosTotales = tiempoTranscurrido.TotalMinutes;
            int horasRedondeadas = (int)Math.Ceiling(minutosTotales / 60);
            return horasRedondeadas;
        }

        public void VisualizarVehiculos()
        {
            if (listaVehiculos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("No hay vehículos estacionados.");
                mensaje.Continuar();
                return;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("          VEHÍCULOS ESTACIONADOS");
            Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
            if (listaAutos.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("AUTOS---------------------------------------\n"); Console.ResetColor();
                foreach (var auto in listaAutos)
                {
                    auto.MostrarVehiculos(); Console.WriteLine();
                }
            }
            if (listaMotocicletas.Count  > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("MOTOCICLETAS--------------------------------\n"); Console.ResetColor();
                foreach (var moto in listaMotocicletas)
                {
                    moto.MostrarVehiculos(); Console.WriteLine();
                }
            }
            if(listaCamiones.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("CAMIONES------------------------------------\n"); Console.ResetColor();
                foreach (var camion in listaCamiones)
                {
                    camion.MostrarVehiculos(); Console.WriteLine();
                }
            }
            mensaje.Continuar();
        }

        public void EspaciosDisponibles()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("          VEHÍCULOS ESTACIONADOS");
            Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine("Espacios destinados para autos: 3"); Console.ResetColor();
            int espaciosAutos = (3-listaAutos.Count);
            Console.WriteLine($"Espacios disponibles: {espaciosAutos}\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Espacios destinados para motocicletas: 5"); Console.ResetColor();
            int espaciosMotos = (5 - listaMotocicletas.Count);
            Console.WriteLine($"Espacios disponibles: {espaciosMotos}\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Espacios destinados para camiones: 1"); Console.ResetColor();
            int espaciosCamiones = (1 - listaCamiones.Count);
            Console.WriteLine($"Espacios disponibles: {espaciosCamiones}\n");
            mensaje.Continuar();
        }
        public void Salida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("   Que tenga un buen día...");
            Console.WriteLine("-------------------------------"); Console.ResetColor();
        }
    }
}
