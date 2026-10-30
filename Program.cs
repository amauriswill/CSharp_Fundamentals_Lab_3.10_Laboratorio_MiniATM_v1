using System.Globalization;
using System.Text;

ConfigurarConsola();

string cliente = "Amauris WIllmore";
string numeroCuenta = "1003142";
bool cuentaActiva = !args.Contains("--inactiva", StringComparer.OrdinalIgnoreCase);
decimal saldo = 10000.00m;

MostrarInformacionCuenta(cliente, numeroCuenta, cuentaActiva, saldo);

bool continuar = true;

do
{
    MostrarMenu();
    Console.Write("Seleccione una opción: ");
    string entradaOpcion = Console.ReadLine()?.Trim() ?? string.Empty;

    if (!int.TryParse(entradaOpcion, out int opcion))
    {
        Console.WriteLine("\nError: Entrada no válida. Debe ingresar un número.");
        Console.WriteLine();
        continue;
    }

    switch (opcion)
    {
        case 1:
            ConsultarSaldo(saldo);
            break;
        case 4:
            MostrarDespedida();
            continuar = false;
            break;
        default:
            Console.WriteLine("\nError: Opción no válida. Intente nuevamente.");
            break;
    }

    if (continuar)
    {
        Console.WriteLine();
    }

} while (continuar);

static void ConfigurarConsola()
{
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;
}

static void MostrarInformacionCuenta(string cliente, string cuenta, bool activa, decimal saldo)
{
    Console.WriteLine("========================================");
    Console.WriteLine("         MINI ATM V1 - SESIÓN          ");
    Console.WriteLine("========================================");
    Console.WriteLine($"Cliente: {cliente}");
    Console.WriteLine($"Cuenta:  {cuenta}");
    Console.WriteLine($"Estado:  {(activa ? "Activa" : "Inactiva")}");
    Console.WriteLine($"Saldo:   RD${saldo.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine("========================================");
    Console.WriteLine();
}

static void MostrarMenu()
{
    Console.WriteLine("MENÚ DE OPERACIONES");
    Console.WriteLine("1. Consultar saldo");
    Console.WriteLine("2. Depositar");
    Console.WriteLine("3. Retirar");
    Console.WriteLine("4. Salir");
    Console.WriteLine("========================================");
}

static void ConsultarSaldo(decimal saldo)
{
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("         CONSULTA DE SALDO              ");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"Saldo disponible: RD${saldo.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine("----------------------------------------");
}

static void MostrarDespedida()
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("¡Gracias por utilizar el Mini ATM V1!");
    Console.WriteLine("========================================");
}
