using System;

namespace duracion
{
    class Duracion
    {
        public int horas;
        public int minutos;
        public int segundos;

        public Duracion(int horas, int minutos, int segundos)
        {
            this.horas = horas;
            this.minutos = minutos;
            this.segundos = segundos;

        }

        public Duracion(int segundos)
        {
            conversion_inversa(segundos);




        }
        public void conversion_inversa(int segundos)
        {
            minutos = (segundos / 60);
            horas = (minutos / 60);

            this.segundos = segundos - (minutos * 60);
            minutos = minutos - (horas * 60);

        }

        public void print()
        {
            Console.WriteLine("Horas:" + horas + " Minutos:" + minutos + " Segundos:" + segundos);
        }
        public void conversion()
        {

            minutos = (horas * 60) + minutos;
            segundos = (minutos * 60) + segundos;

            Console.WriteLine("Los segundos son:" + segundos);
        }

        public static int operator +(Duracion a, Duracion b)
        {
            a.segundos = a.segundos + b.segundos;
            int s = a.segundos;

            a.minutos = (a.segundos / 60);
            a.horas = (a.minutos / 60);

            a.segundos = a.segundos - (a.minutos * 60);
            a.minutos = a.minutos - (a.horas * 60);

            Console.WriteLine("Horas:" + a.horas + " Minutos:" + a.minutos + " Segundos:" + a.segundos);
            Console.Write("Los segundos son:");

            return s;
 
            
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Duracion a = new Duracion(2, 15, 12);
            Duracion b = new Duracion(3, 50, 57);
            Duracion d = new Duracion(8023);

            Console.WriteLine("A");
            a.print();
            a.conversion();
            Console.WriteLine("\nB");
            b.print();
            b.conversion();
            Console.WriteLine("\nSuma A+B");
            Console.WriteLine(a + b);
            Console.WriteLine("\nD");
            d.print();
            
        }
    }
}
