using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Mensajes //esta clase es únicamente para colocar mensajes cortos que son muy repetitivos...
    {
        public void Continuar()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Presiona ENTER para continuar...");
            Console.ResetColor(); Console.ReadKey(); Console.Clear();
        }
        public void ErrorDeFormato()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error de formato. Intenta de nuevo.");
            Console.ResetColor();
        }
        public void Default()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Esta opción no existe"); Console.ResetColor();
            Continuar();
        }

        public void RegistroExitoso()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nVehículo ingresado correctamente.");
            Console.ResetColor();
        }

        public void ProcesandoPago()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Procesando pago");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000); //para esperar un segundo 
                Console.Write(".");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nPago exitoso");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Pulsa ENTER para ver detalles de pago");
            Console.ResetColor(); Console.ReadKey(); Console.Clear();
        }
        public void ProcesandoPagoCancelado()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Procesando pago");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000); //para esperar un segundo 
                Console.Write(".");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nLa fecha de vencimiento ya ha pasado.\n");
            Continuar();
        }
    }
}
