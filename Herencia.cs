using System;

namespace duracion
{
    class Persona
    {
        protected string _nombre="";

        public string Nombre 
        {
            get
            {
                return _nombre;
            }
        }

        public Persona(string n)
        {
            _nombre = n ;
        }

        public void print()
        {
            Console.WriteLine("Mi nombre es{0}",_nombre);
        }

    }
    class Alumno : Persona
    {
        protected string num_control;
        public Alumno(string nombre,string num_control):base(nombre)
        {
            this.num_control=num_control;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Persona tom = new Persona("Tom");
            Persona jim = new Persona("Jim");

            tom.print();
            jim.print();

            Alumno luis = new Alumno("Luis","2021213");
            luis.print();



        }
    }
}
