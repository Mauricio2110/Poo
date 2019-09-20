using System;

namespace Pelicula
{

    class Pelicula
    {
        public String Titulo;
        public Int16 Año;
        public String Pais;
        public String Director;

    }
    class Program
    {
        static void Main(string[] args)
        {
            Pelicula p1 = new Pelicula();
            Pelicula p2 = new Pelicula();

            p1.Titulo = "Spiderman";
            p1.Año = 2018;
            p1.Pais = "Estados Unidos";
            p1.Director = "Peter Ramsey";

            p2.Titulo = "Avatar";
            p2.Año = 2009;
            p2.Pais = "Estados Unidos";
            p2.Director = "James Cameron";

            Console.WriteLine("{0}, {1}, {2}, {3}\n", p1.Titulo, p1.Año, p1.Pais, p1.Director);
            Console.WriteLine("{0}, {1}, {2}, {3}\n", p2.Titulo, p2.Año, p2.Pais, p2.Director);

            Console.ReadLine();

        }
    }
}
