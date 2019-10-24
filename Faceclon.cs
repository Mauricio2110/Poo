using System;
using System.Collections.Generic;

namespace Faceclon
{
    abstract class Publicacion
    {
        protected string nombre;
        protected int fecha;
        protected int reacciones;

        public Publicacion(string nombre, int fecha, int reacciones)
        {
            this.nombre = nombre;
            this.fecha = fecha;
            this.reacciones = reacciones;
        }

        public abstract void imprime();

    }

    class Estado : Publicacion
    {
        public string mensaje = "";

        public Estado(string nombre, int fecha, int reacciones, string mensaje):base(nombre,fecha,reacciones)
        {
            this.mensaje = mensaje;
        }

        override public void imprime()
        {
            Console.WriteLine("Estado de {0} del año {1} \n {2} \n {3} reacciones", nombre,fecha,mensaje,reacciones);
        }

    }

    class Foto : Publicacion
    {
        public string foto="";
        public string titulo="";

        public Foto(string nombre, int fecha, int reacciones, string titulo, string foto):base(nombre, fecha, reacciones)
        {
            this.titulo = titulo;
            this.foto = foto;
        }

        override public void imprime()
        {
            Console.WriteLine("Foto de {0} del año {1} \n {2} \n {3} \n {4} reacciones", nombre,fecha,titulo,foto,reacciones);
        }

    }

    class Link : Publicacion
    {
        string link;
        string titulo;

        public Link(string nombre, int fecha, int reacciones,string titulo, string link) : base(nombre, fecha, reacciones)
        {
            this.titulo = titulo;
            this.link = link;
        }

        override public void imprime()
        {
            Console.WriteLine("Link de {0} del año {1} \n {2} \n {3} \n {4} reacciones", nombre, fecha,titulo,link,reacciones);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Publicacion> muro = new List<Publicacion>();
            muro.Add(new Estado("Michelle Ramirez", 2019, 45, "Hoy me siento muy feliz"));
            muro.Add(new Estado("Mario Hermoso", 2019, 12, "Hoy me siento muy feliz"));
            muro.Add(new Link("Ricardo Rodriguez", 2019, 28, "Video muy gracioso","www.youtube.com/videogracioso2019"));
            muro.Add(new Foto("Pamela Valenzuela", 2019, 270, "Mi fin de semana en la playa","foto_en_la_playa.jpg"));
            muro.Add(new Link("Mario Garcia", 2019, 777, "Curso de Programacion en Github", "www.github.com/mariosky/oop"));
            muro.Add(new Foto("Diana Valdez", 2019, 270, "Primer dia de trabajo", "trabajo.jpg"));

            foreach (var item in muro)
            {
                item.imprime();
                Console.WriteLine();
            }
            
        }
    }
}
