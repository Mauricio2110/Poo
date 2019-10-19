using System;

namespace Pase_de_Parametros
{
    class Valor
    {
        public void Alcuadrado(int a)
        {
            a = a * a;
        }
        public void AlcuadradoR(ref int a)
        {
            a = a * a;
        }
        public void Alcuadrado(in int a)
        {
            a = a * a;
            Console.WriteLine(a);
        }
        public void Suma(int a, int b, out int resultado)
        {
            resultado = a + b;
        }
    }
    class Empleado
    {
        public string Puesto;

        public Empleado()
        {
            Puesto = "Conserje";
        }
        
    }
    class Ascensos
    {
        static public void Mejorar_Puesto(Empleado x)
        {
            x.Puesto = "Maestro";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 3;
            int z;
            
            //Por Valor
            Valor n = new Valor();
            n.Alcuadrado(x);
            Console.WriteLine(x);

            //Por Referencia
            Empleado juan = new Empleado();
            Console.WriteLine(juan.Puesto);
            Ascensos.Mejorar_Puesto(juan);
            Console.WriteLine(juan.Puesto);

            //Ref
            n.AlcuadradoR(ref y);
            Console.WriteLine(y);

            //Out
            n.Suma(x, y, out z);
            Console.WriteLine(z);

            //In
            n.Alcuadrado(in z);
            
        }
    }
}
