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
        Mensajes mensaje = new Mensajes();
        PagoTarjeta pagoTarjeta = new PagoTarjeta();

        public void IngresarVehiculo() //método para ingresar nuevos vehículos
        {
            int opcionVehiculo = 0;
            bool sideCarM = false;
            string placaA = "", placaM = "", placaC = "";
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("             INGRESAR VEHÍCULO");
                Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
                Console.WriteLine("1. Auto (Q15/h)");
                Console.WriteLine("2. Motocicleta (Q10/h)");
                Console.WriteLine("3. Camión (Q20/h)");
                Console.WriteLine("4. Regresar al menú principal\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                            bool validarCantPuertas = false;
                            int cantidadDePuertas = 0;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("           REGISTRAR AUTO");
                            Console.WriteLine("-----------------------------------------\n"); Console.ResetColor();
                            do
                            {
                                Console.Write("Ingresa la placa: ");
                                placaA = Console.ReadLine();
                            } while (!ValidarPlaca(placaA));
                            if (PlacaExiste(placaA))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("La placa ya está registrada."); //no pueden existir placas repetidas
                                mensaje.Continuar();
                                return;
                            }
                            Console.Write("Ingresa la marca: ");
                            string marcaA = Console.ReadLine();
                            Console.Write("Ingresa la modelo: ");
                            string modeloA = Console.ReadLine();
                            Console.Write("Ingresa la color: ");
                            string colorA = Console.ReadLine();
                            TimeOnly horaA = TimeOnly.FromDateTime(DateTime.Now);
                            Console.WriteLine($"Hora de entrada: {horaA}");
                            do
                            {
                                Console.Write("Ingresa la cantidad de puertas: ");
                                try
                                {
                                    cantidadDePuertas = Convert.ToInt32(Console.ReadLine());
                                    if (cantidadDePuertas > 0)
                                    {
                                        validarCantPuertas = true;
                                    }
                                }
                                catch (FormatException)
                                {
                                    mensaje.ErrorDeFormato(); Console.WriteLine();
                                }
                                catch (OverflowException)
                                {
                                    mensaje.ErrorDeFormato(); Console.WriteLine();
                                }
                            } while (!validarCantPuertas);
                            Auto nuevoAuto = new Auto(placaA, marcaA, modeloA, colorA, horaA, cantidadDePuertas);
                            listaAutos.Add(nuevoAuto);
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
                            do
                            {
                                Console.Write("Ingresa la placa: ");
                                placaM = Console.ReadLine();
                            } while (!ValidarPlaca(placaM));
                            if (PlacaExiste(placaM))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("La placa ya está registrada.");
                                mensaje.Continuar();
                                return;
                            }
                            Console.Write("Ingresa la marca: ");
                            string marcaM = Console.ReadLine();
                            Console.Write("Ingresa la modelo: ");
                            string modeloM = Console.ReadLine();
                            Console.Write("Ingresa la color: ");
                            string colorM = Console.ReadLine();
                            TimeOnly horaM = TimeOnly.FromDateTime(DateTime.Now);
                            Console.WriteLine($"Hora de entrada: {horaM}");
                            Console.Write("¿La motocicleta tiene sidecar? (SI/NO): ");
                            string sideCar = Console.ReadLine();
                            if (sideCar.ToLower() == "si")
                                sideCarM = true;
                            Motocicleta nuevaMoto = new Motocicleta(placaM, marcaM, modeloM, colorM, horaM, sideCarM);
                            listaMotocicletas.Add(nuevaMoto);
                            mensaje.RegistroExitoso();
                            mensaje.Continuar();
                            break;
                        case 3:
                            bool validarCapacidad = false;
                            decimal capacidadDeCarga = 0;
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
                            do
                            {
                                Console.Write("Ingresa la placa: ");
                                placaC = Console.ReadLine();
                            } while (!ValidarPlaca(placaC));
                            if (PlacaExiste(placaC))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("La placa ya está registrada.");
                                mensaje.Continuar();
                                return;
                            }
                            Console.Write("Ingresa la marca: ");
                            string marcaC = Console.ReadLine();
                            Console.Write("Ingresa la modelo: ");
                            string modeloC = Console.ReadLine();
                            Console.Write("Ingresa la color: ");
                            string colorC = Console.ReadLine();
                            TimeOnly horaC = TimeOnly.FromDateTime(DateTime.Now);
                            Console.WriteLine($"Hora de entrada: {horaC}");
                            do
                            {
                                Console.Write("Ingresa la capacidad de carga (kg): ");
                                try
                                {
                                    capacidadDeCarga = Convert.ToDecimal(Console.ReadLine());
                                    if (capacidadDeCarga > 0)
                                    {
                                        validarCapacidad = true;
                                    }
                                }
                                catch (FormatException)
                                {
                                    mensaje.ErrorDeFormato(); Console.WriteLine();
                                }
                            } while (!validarCapacidad);
                            Camion nuevoCamion = new Camion(placaC, marcaC, modeloC, colorC, horaC, capacidadDeCarga);
                            listaCamiones.Add(nuevoCamion);
                            mensaje.RegistroExitoso();
                            mensaje.Continuar();
                            break;
                        case 4:
                            Console.Clear();
                            break;
                    }

                }
                catch (FormatException)
                {
                    mensaje.ErrorDeFormato();
                    mensaje.Continuar();
                }
            } while (opcionVehiculo != 4);
        }

        private bool PlacaExiste(string placa) //método para verificar si la placa es existente
        {
            // Verificar en todas las listas de vehículos
            bool existeEnAutos = listaAutos.Any(a => a.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            bool existeEnMotos = listaMotocicletas.Any(m => m.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            bool existeEnCamiones = listaCamiones.Any(c => c.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));

            return existeEnAutos || existeEnMotos || existeEnCamiones;
        }

        public void RetirarVehiculo()
        {
            TimeOnly horaSalida = TimeOnly.FromDateTime(DateTime.Now);
            int opcionRetirar = 0;
            if (listaAutos.Count == 0 && listaMotocicletas.Count == 0 && listaCamiones.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("No hay vehículos estacionados.");
                mensaje.Continuar();
                return;
            }
            decimal monto = 0;
            bool vehiculoEncontrado = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("              RETIRAR VEHÍCULO");
            Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
            Console.Write("Ingresa la placa del vehículo: ");
            string placaRetirar = Console.ReadLine();

            var vehiculosAEliminar = listaAutos.Concat<Vehiculo>(listaMotocicletas).Concat<Vehiculo>(listaCamiones)
                                               .Where(v => v.Placa.ToLower() == placaRetirar.ToLower()).ToList();
            //se crea una lista temporal que concatena todas las listas para comparar las placas a la variable PlacaRetirar

            if (vehiculosAEliminar.Count > 0)
            {
                foreach (var vehiculo in vehiculosAEliminar)
                {
                    int horas = CalcularHorasEstacionado(horaSalida, vehiculo.HoraDeEntrada);
                    if (vehiculo is Auto)
                    {
                        monto = horas * 15;
                    }
                    else if (vehiculo is Motocicleta)
                    {
                        monto = horas * 10;
                    }
                    else if (vehiculo is Camion)
                    {
                        monto = horas * 20;
                    }
                    Console.WriteLine("Cantidad de horas pasadas: " + horas);
                    Console.WriteLine("Monto total: Q" + monto);

                    // Confirmar el pago
                    Console.Write("¿Está seguro de pagar Q" + monto + "? (SI/NO): ");
                    string confirmarPago = Console.ReadLine();

                    if (confirmarPago.ToLower() == "si")
                    {
                        // Proceder con el pago y eliminar vehículo si el pago es exitoso
                        bool pagoExitoso = ProcesoDePago(monto, vehiculo.HoraDeEntrada, horaSalida);
                        if (pagoExitoso)
                        {
                            EliminarVehiculo(vehiculo);
                        }
                        else
                        {
                            Console.Clear();
                        }
                        vehiculoEncontrado = true;
                    }
                    else
                    {
                        Console.WriteLine("El proceso de pago ha sido cancelado.");
                        mensaje.Continuar();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Vehículo no encontrado.");
                mensaje.Continuar();
            }
        }
        private bool ProcesoDePago(decimal monto, TimeOnly horaEntrada, TimeOnly horaSalida)
        {
            int opcionPago = 0;
            bool pagoExitoso = false;
            do
            {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("              PROCESO DE PAGO");
                Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
                Console.WriteLine("1. Pago en efectivo");
                Console.WriteLine("2. Pago con tarjeta");
                Console.Write("Ingresa la opción de pago: ");
                try
                {
                    opcionPago = Convert.ToInt32(Console.ReadLine());
                    switch (opcionPago)
                    {
                        case 1:
                            mensaje.Continuar();
                            PagoEfectivo pagoEfectivo = new PagoEfectivo();
                            pagoExitoso = pagoEfectivo.ProcesarPago(monto, horaEntrada, horaSalida);
                            return pagoExitoso;
                        case 2:
                            Console.Clear();
                            PagoTarjeta pagoTarjeta = new PagoTarjeta();
                            pagoExitoso = pagoTarjeta.ProcesarPago(monto, horaEntrada, horaSalida);
                            return pagoExitoso;
                        default:
                            mensaje.Default();
                            break;
                    }
                }
                catch (FormatException)
                {
                    mensaje.ErrorDeFormato();
                    mensaje.Continuar();
                }
            } while (opcionPago != 2 && opcionPago != 1);
            return pagoExitoso;
        }
        private void EliminarVehiculo(Vehiculo vehiculo) //método para eliminar un vehículo de una lista específica
        {
            if (vehiculo is Auto)
            {
                listaAutos.Remove(vehiculo as Auto);
            }
            else if (vehiculo is Motocicleta)
            {
                listaMotocicletas.Remove(vehiculo as Motocicleta);
            }
            else if (vehiculo is Camion)
            {
                listaCamiones.Remove(vehiculo as Camion);
            }
        }

        private int CalcularHorasEstacionado(TimeOnly horaSalida, TimeOnly horaEntrada)
        {//calcular las horas de estacionado, aunque realmente tomo los minutos transcurridos como horas...
            TimeSpan tiempoTranscurrido = horaSalida - horaEntrada;
            double minutosTotales = tiempoTranscurrido.TotalMinutes;
            int minutosRedondeados = (int)Math.Ceiling(minutosTotales); //para redondear los minutos al siguiente completo.
            return minutosRedondeados;
        }

        public void VisualizarVehiculos() //método para visualzar los vehículos estacionados
        {
            if (listaAutos.Count == 0 && listaMotocicletas.Count == 0 && listaCamiones.Count == 0)
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
            if (listaAutos.Count > 0) //si la lista de autos está vacía, no mostrara esta parte, funciona igual con las otras listas, respectivamente
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("AUTOS---------------------------------------\n"); Console.ResetColor();
                foreach (var auto in listaAutos)
                {
                    auto.MostrarVehiculos(); Console.WriteLine();
                }
            }
            if (listaMotocicletas.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("MOTOCICLETAS--------------------------------\n"); Console.ResetColor();
                foreach (var moto in listaMotocicletas)
                {
                    moto.MostrarVehiculos(); Console.WriteLine();
                }
            }
            if (listaCamiones.Count > 0)
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

        public void EspaciosDisponibles() //método para mostrar los espacios disponibles del estacionamiento
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("          VEHÍCULOS ESTACIONADOS");
            Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Espacios destinados para autos: 3"); Console.ResetColor();
            int espaciosAutos = (3 - listaAutos.Count);
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
        public void Salida() //mensaje de despedida
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("   Que tenga un buen día...");
            Console.WriteLine("-------------------------------"); Console.ResetColor();
        }
        private bool ValidarPlaca(string placa) //método para validar el length de la placa
        {
            bool validar = false;
            if (placa.Length == 6)
            {
                validar = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("La placa debe ser de 6 caracteres. Intenta de nuevo.\n");
                Console.ResetColor();
            }
            return validar;
        }
    }
}
