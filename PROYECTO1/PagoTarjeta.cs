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

        public override bool ProcesarPago(decimal monto)
        {
            Mensajes mensaje = new Mensajes();
            bool validarNumTarjeta = false, validarCVV = false;
            DateOnly fecha;
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
                    if (numeroTarjeta > 999999  && numeroTarjeta <10000000)
                    {
                        validarNumTarjeta = true;
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
                    if (fecha >= DateOnly.FromDateTime(DateTime.Now))
                    {
                        break; // Si la fecha es válida y no ha vencido, salimos del bucle
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La tarjeta ha expirado. Intenta con otra tarjeta.\n"); Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Formato de fecha inválido.\n"); Console.ResetColor();
                }

            } while (true);
            do
            {
                Console.Write("CVV: ");
                try
                {
                    int cvv = Convert.ToInt32(Console.ReadLine());
                    if(cvv > 99 && cvv < 10000)
                    {
                        validarCVV = true; Console.WriteLine();
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
            Console.Write("Procesando pago");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000); //para esperar un segundo 
                Console.Write(".");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPago exitoso"); Console.ResetColor();
            mensaje.Continuar();
            return true;
        }

    }
}
