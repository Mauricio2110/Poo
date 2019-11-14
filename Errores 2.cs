using System;

namespace errores
{
    class NegativeIntegerException:Exception
    {
        public NegativeIntegerException():base("Hubo un error")
        {

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int valor=0;
            Console.WriteLine("Ingresa tu edad");
            try
            {
            valor = int.Parse(Console.ReadLine());

            if (valor < 0)
            {
                throw new NegativeIntegerException();
            }

            Console.WriteLine("Tienes {0} años",valor);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally");                
            }


            Console.ReadKey();
            
        }
    }
}
