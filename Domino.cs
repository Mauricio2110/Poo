using System;

namespace dominos
{
    class Domino
    {
        private readonly int arriba=0;
        private readonly int abajo=0;

        public Domino(int arribas,int abajos)
        {
            arriba=arribas;
            abajo=abajos;
        }
 

        public static int operator +(Domino a,Domino b)
        {

            return (a.arriba+a.abajo+b.arriba+b.abajo);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Domino a = new Domino(2,0);
            Domino b = new Domino(4,1);
            Console.WriteLine(a+b);
        }
    }
}
