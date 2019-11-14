using System;

namespace errores
{
    class Program
    {
        static void Main(string[] args)
        {
            int valor;
            Console.WriteLine("Ingresa tu edad");
            try
            {
            string captura = Console.ReadLine();
            valor = int.Parse(captura);
            Console.WriteLine("Tienes {0} años",valor);
            }
            catch(FormatException)
            {
                Console.WriteLine("Formato incorrecto");
            }
            catch(DivideByZeroException)
            {
                 Console.WriteLine("No se puede dividir entre cero");
            }
            catch(OverflowException)
            {
                Console.WriteLine("Ingrese un numero mas chico");
            }


            Console.ReadKey();
            
        }
    }
}
