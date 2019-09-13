using System;

namespace Pelicula
{
    class Pelicula
    {
        private String Titulo;
        private Int16 Año;
        private String Pais;
        private String Director;

        public void SetTitulo(string titulo)
        {
            this.Titulo = titulo;
        }

        public String GetTitulo()
        {
            return this.Titulo;
        }

        public void SetAño(Int16 año)
        {
            this.Año = año;
        }

        public Int16 GetAño()
        {
            return this.Año;
        }

        public void SetDirector(string director)
        {
            this.Director = director;
        }

        public String GetDirector()
        {
            return this.Director;
        }

        public void SetPais(string pais)
        {
            this.Pais = pais;
        }

        public String GetPais()
        {
            return this.Pais;
        }
        
        public Pelicula() 
        {

		}
		public Pelicula(string titulo, Int16 año, string director, string pais)
        {
			this.Titulo = titulo;
			this.Año = año;
            this.Director = director;
            this.Pais = pais;
		}

        public void print()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}\n", this.Titulo, this.Año, this.Director, this.Pais);
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pelicula p1 = new Pelicula();
            Pelicula p2 = new Pelicula();
            p1.SetTitulo("Spiderman:into the spiderverse");
            p1.SetAño(2018); 
            p1.SetDirector("Peter Ramsey");
            p1.SetPais("Estados Unidos");

            p2.SetTitulo("Avatar");
            p2.SetAño(2009);
            p2.SetDirector("James Cameron");
            p2.SetPais("Estados Unidos");

            p1.print();
            p2.print();
            
        }
    }
}
