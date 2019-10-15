using System;
using System.Collections.Generic;

namespace Musico
{
    class Musico
    {
        protected string nombre;

        public Musico(string n)
        {
            nombre=n;
        }

        public virtual void Afina()
        {
            Console.WriteLine("{0} afinando su instrumento",nombre);
        }

        public void Saluda()
        {
            Console.WriteLine("Hola soy {0}",nombre);
        }
    }
    class Bajista:Musico
    {
        private string bajo;
        
        public Bajista(string no,string b):base(no)
        {
            bajo=b;
        }
        public override void Afina()
        {
            Console.WriteLine("{0} Afinando su {1}",nombre,bajo);
        }
    }
    class Guitarrista:Musico
    {
        private string guitarra;
        
        public Guitarrista(string no,string g):base(no)
        {
            guitarra=g;
        }
        public override void Afina()
        {
            Console.WriteLine("{0} Afinando su {1}",nombre,guitarra);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           Musico tom = new Musico("Tom") ;
           Bajista flea = new Bajista("Flea","Moicarca");
           Guitarrista john = new Guitarrista("John","Sizer");
           // tom.Saluda();     flea.Saluda();
           // tom.Afina();     flea.Afina();

           List<Musico> grupo = new List<Musico>();
           grupo.Add(tom);
           grupo.Add(flea);
           grupo.Add(john);

           foreach(Musico m in grupo)
           {
               m.Saluda();
               m.Afina();
           }
        }
    }
}
