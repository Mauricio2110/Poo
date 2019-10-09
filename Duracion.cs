using System;

namespace duracion
{
    class Duracion
    {
        public int horas;
        public int minutos;
        public int segundos;

        public Duracion(int horas,int minutos,int segundos)
        {
            this.horas=horas;
            this.minutos=minutos;
            this.segundos=segundos;

        }

        public void print()
        {
            Console.WriteLine("Horas:"+horas+" Minutos:"+minutos+" Segundos:"+segundos);
        }
        public void conversion()
            {

            minutos=(horas*60)+minutos;
            segundos=(minutos*60)+segundos;

            Console.WriteLine("Los segundos son:"+segundos);
            }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Duracion a = new Duracion(2,15,12);
            Duracion b = new Duracion(0,02,15);
            Duracion c = new Duracion(2,00,10);

            
            a.print();
            a.conversion();
            b.print();
            b.conversion();
            c.print();
            c.conversion();


        }
    }
}
