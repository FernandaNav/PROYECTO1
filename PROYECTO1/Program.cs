using PROYECTO1;

int opcion = 0;
Mensajes mensaje = new Mensajes();
Estacionamiento estacionamiento = new Estacionamiento();
do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine("                BIENVENIDO");
    Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
    Console.WriteLine("1. Registrar vehículo");
    Console.WriteLine("2. Retirar vehículo");
    Console.WriteLine("3. Visualizar vehículos estacionados");
    Console.WriteLine("4. Visualización de espacios disponibles");
    Console.WriteLine("5. Salir\n");
    Console.ForegroundColor= ConsoleColor.DarkYellow;
    Console.Write("Ingrese la opcion que quieras: ");
    try
    {
        opcion = Convert.ToInt32(Console.ReadLine()); Console.ResetColor();
        switch (opcion)
        {
            case 1:
                Console.Clear();
                estacionamiento.IngresarVehiculo();
                break;
            case 2:
                Console.Clear();
                break;
            case 3:
                estacionamiento.VisualizarVehiculos();
                break;
            case 4:
                Console.Clear();
                break;
            case 5:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("   Que tenga un buen día...");
                Console.WriteLine("-------------------------------"); Console.ResetColor();
                break;
            default:
                mensaje.Default();
                mensaje.Continuar();
                break;
        }
    }
    catch (FormatException)
    {
        mensaje.ErrorDeFormato();
        mensaje.Continuar();
    }
} while(opcion != 5);
