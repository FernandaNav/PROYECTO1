using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class PagoTarjeta : Pago
    {
        protected int NumeroDeTarjeta { get; set; }
        protected string NombreTitular { get; set; } 
        protected DateTime FechaVencimiento {  get; set; }
        private int CVV {  get; set; }

        public override bool ProcesarPago(decimal monto, TimeOnly horaEntrada, TimeOnly horaSalida)
        {
            Mensajes mensaje = new Mensajes();
            bool validarNumTarjeta = false, validarCVV = false, validarFecha = false;
            DateOnly fecha = DateOnly.MinValue, ahora = DateOnly.FromDateTime(DateTime.Now);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("              PAGO CON TARJETA");
            Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
            do
            {
                Console.Write("Ingresa el número de tarjeta: ");
                try
                {
                    int numeroTarjeta = Convert.ToInt32(Console.ReadLine());
                    if (numeroTarjeta > 999999  && numeroTarjeta <10000000) //el número de tarjeta debe ser de 7 digitos
                    {
                        validarNumTarjeta = true;
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.DarkGray;
                        Console.WriteLine("La tarjeta debe ser de 7 digitos. Intenta de nuevo.\n");
                        Console.ResetColor();
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
            } while (!validarNumTarjeta);
            Console.Write("Ingresa el nombre del titular: ");
            string nombreTitular = Console.ReadLine();
            do
            {
                Console.Write("Ingresa una fecha (formato: dd/MM/yyyy): ");
                string fechaStr = Console.ReadLine();

                try
                {
                    fecha = DateOnly.ParseExact(fechaStr, "dd/MM/yyyy");
                    validarFecha = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Formato de fecha inválido.\n"); Console.ResetColor();
                }

            } while (!validarFecha);
            do
            {
                Console.Write("CVV: ");
                try
                {
                    int cvv = Convert.ToInt32(Console.ReadLine());
                    if(cvv > 99 && cvv < 10000)
                    {
                        validarCVV = true; Console.WriteLine(); //el cvv debe ser de 3 o 4 digitos
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("El CVV debe ser de 3 o 4 digitos. Intenta de nuevo.\n");
                        Console.ResetColor();
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
            } while (!validarCVV);
            if (fecha < ahora)
            {
                mensaje.ProcesandoPagoCancelado();
                return false; // Si la fecha es válida y no ha vencido, salimos del bucle
            }
            else
            {
                mensaje.ProcesandoPago();//esto es más que todo decoración, para que se vea más bonito...
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("                  FACTURA");
                Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
                Console.WriteLine($"Nombre del titular: {nombreTitular}");
                Console.WriteLine($"Hora de entrada: {horaEntrada}");
                Console.WriteLine($"Hora de salida: {horaSalida}");
                Console.WriteLine($"Monto cancelado: Q{monto}\n");
                mensaje.Continuar();
                return true;
            }
        }

    }
}
