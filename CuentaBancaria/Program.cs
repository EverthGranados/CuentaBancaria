using CuentaBancaria.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria
{
    class Program
    {
        static List<Cuenta> Cuentas = new List<Cuenta>();
        static List<Transaccion> Transacciones = new List<Transaccion>();
        static void Pedir(string msj, ref int x)
        {
            Console.Write("\n{0}: ", msj);
            x = int.Parse(Console.ReadLine());
        }
        static void Pedir(string msj, ref double x)
        {
            Console.Write("\n{0}: ", msj);
            x = double.Parse(Console.ReadLine());
        }
        static void Pedir(string msj, ref string x)
        {
            Console.Write("\n{0}: ", msj);
            x = Console.ReadLine();
        }
        public static void AgregarCuenta()
        {
            int NumCuenta = 0;
            double Saldo = 0;
            string Titular = "";
            Pedir("Ingrese el numero de cuenta ", ref NumCuenta);
            Pedir("Ingrese el nombre del titular de la cuenta ",ref Titular);
            Pedir("Ingrese la cantidad del depósito inicial ",ref Saldo );

            Cuenta oCuenta = new Cuenta(NumCuenta,Titular,Saldo,true);
            Cuentas.Add(oCuenta); 
        }
        public static void AgregarTransaccion()
        {
            double monto = 0;
            Console.WriteLine("Ingrese el codigo de transaccion: ");
            string codigo = Console.ReadLine();
            Console.WriteLine("Ingrese la descripcion: ");
            string descripcion = Console.ReadLine();
            Pedir("Ingrese el monto depositado: ", ref monto);
            Transaccion transaccion = new Transaccion(codigo, descripcion, DateTime.Now, monto);
            Transacciones.Add(transaccion);
        }
        public static void HacerDepósito()
        {
            Console.WriteLine("Ingrese el numero de cuenta a depositar: ");
            int num = int.Parse(Console.ReadLine());            
            Cuenta cuenta = Cuentas.Find(x => x.NumeroDeCuenta == num);
            if (cuenta != null)
            {
                if (cuenta.Estado)
                {
                    Console.WriteLine("Ingrese la cantidad a depositar: ");
                    double x = double.Parse(Console.ReadLine());
                    cuenta.Saldo += x;
                    AgregarTransaccion();                 
                }
            }
        }
        static void Menu()
        {
            Console.WriteLine("<<<<MENÚ>>>>");
            Console.WriteLine("1. Agregar cuenta");
            Console.WriteLine("2. Depositar a cuenta");
            Console.WriteLine("3. Mostrar cantidad de transacciones");
            Console.WriteLine("4. Buscar transaccion por codigo");
            Console.WriteLine("5. Mostrar informacion de una cuenta");
            Console.WriteLine("0. Salir");
        }

        static void Ejecutar()
        {
            int op = -1;
            do
            {
                Menu();
                Console.Write("Ingrese el numero de la opcion deseada: ");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        AgregarCuenta();
                        break;
                    case 2:
                        HacerDepósito();
                        break;
                    case 3:
                        Console.WriteLine("Cantidad de transacciones: " + Transaccion.ContadorTransaccion);
                        break;
                    case 4:
                        MostrarTransaccionPorCodigo();
                        break;
                    case 5:
                        MostrarCuentaPorCodigo();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida por favor seleccione una opcion válida");
                        break;
                }
            } while (op != 0);
        }
        static void MostrarCuentaPorCodigo()
        {
            Console.Write("Ingrese el numero de cuenta: ");
            int NumCuenta = int.Parse(Console.ReadLine());
            Cuenta cuenta = Cuentas.Find(x => x.NumeroDeCuenta == NumCuenta);
            if (cuenta != null)
            {
                cuenta.MostrarCuenta(NumCuenta);
            }
            else
                Console.WriteLine("No se encontro esa cuenta");
        }
        static void MostrarTransaccionPorCodigo()
        {
            Console.Write("Ingrese el codigo: ");
            string codigo = Console.ReadLine();
            Transaccion transaccion = Transacciones.Find(t => t.Codigo == codigo);
            if (transaccion != null)
            {
                transaccion.MostrarTransaccion(codigo);
            }
            else
                Console.WriteLine("No se encontro la transaccion con ese codigo");
        }
        
        static void Main(string[] args)
        {
            Ejecutar();

            Console.ReadKey();
        }
    }
}
