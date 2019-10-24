using System;
using System.Collections.Generic;

namespace Alumnos
{
    abstract class Alumnos
    {
        protected string nombre,apellido;
        protected int id;
        //Al cambiar algo a private los metodos no funcionan por que deben de estar en la misma clase base o estar definidos como publicos

        public Alumnos(string nombre,string apellido,int id)
        {
            this.nombre=nombre;
            this.apellido=apellido;
            this.id=id;
        }
        public void Datos()
        {
            Console.WriteLine("Alumno {0} {1} con numero de control:{2}", nombre, apellido, id);
            Console.WriteLine("Es necesario que realize su Servicio Social y posteriormente su Residencia");
        }
    }
    class Licenciatura:Alumnos
    {
        public Licenciatura(string nombre, string apellido, int id):base(nombre,apellido,id)
        {

        }
    }
    class Posgrado : Alumnos
    {
        public Posgrado(string nombre, string apellido, int id) : base(nombre, apellido, id)
        {

        }
        new public void Datos()
        {
            Console.WriteLine("Alumno {0} {1} con numero de control:{2}", nombre, apellido, id);
            Console.WriteLine("Es necesario que realize su Tema de Investigacion lo mas pronto posible");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Licenciatura carl = new Licenciatura("Carl","Johnson",18212135);
            Posgrado ana = new Posgrado("Ana", "Caballero", 18717432);

            carl.Datos();
            Console.WriteLine("");
            ana.Datos();


            
           
        }
        
    }
}
