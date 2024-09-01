using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class PagoEfectivo : Pago
    {
        public override bool ProcesarPago(decimal monto, TimeOnly horaEntrada, TimeOnly horaSalida)
        {
            int[] billetes = { 200, 100, 50, 20, 10, 5, 1 };
            int[] cantidadBilletes = new int[billetes.Length];
            Mensajes mensaje = new Mensajes();
            decimal billete = 0, totalIngresado = 0;
            bool validarBillete = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("              PAGO EN EFECTIVO");
            Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
            Console.WriteLine($"Monto a pagar: Q{monto}\n");
            do
            {
                Console.Write("Ingresa un billete: Q");
                try
                {
                    billete = Convert.ToDecimal(Console.ReadLine());

                    // Verificar si el billete es válido
                    if (billetes.Contains((int)billete)) 
                    {
                        totalIngresado += billete;

                        if (totalIngresado < monto) //en caso de que la cantidad de billetes ingresados no sea suficiente
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Monto insuficiente, ingrese más billetes.\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            // Total ingresado es suficiente
                            break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Este billete no es válido.\n");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    mensaje.ErrorDeFormato();
                }
                catch (OverflowException)
                {
                    mensaje.ErrorDeFormato();
                }
            } while (true);

            decimal cambio = billete - monto; //calcular el cambio

            for (int i = 0; i < billetes.Length; i++)
            {
                cantidadBilletes[i] = (int)(cambio / billetes[i]); //para recorrer la lista de billetes y calcular el cambio con
                cambio %= billetes[i];                             //los billetes necesarios
            }
            mensaje.ProcesandoPago();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("                  FACTURA");
            Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
            Console.WriteLine($"Hora de entrada: {horaEntrada}");
            Console.WriteLine($"Hora de salida: {horaSalida}");
            Console.WriteLine($"Efectivo recibido Q{totalIngresado}");
            Console.WriteLine($"\nTotal: Q{monto}");
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine("\nCambio a devolver-------------------------"); Console.ResetColor();
            if(totalIngresado == monto)
            {
                Console.WriteLine("Q0.00");
            }
            for (int i = 0; i < billetes.Length; i++)
            {
                if (cantidadBilletes[i] > 0)
                {
                    Console.WriteLine($"Billetes de Q{billetes[i]}: {cantidadBilletes[i]}");
                }
            }
            Console.WriteLine();
            mensaje.Continuar();
            return true;
        }
    }
}
