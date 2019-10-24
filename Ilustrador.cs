using System;
using System.Collections.Generic;

namespace figura
{
    abstract class Figura 
    {
        protected int x;
        protected int y;
        protected string color;

        public Figura(int x, int y, string c){
            this.x = x; this.y = y; color = c;
        }

        public abstract void dibuja();

        public void printColor()
        {
            Console.WriteLine(color);
        }
    }

    class Circulo : Figura 
    {
        public Circulo(int x, int y, string c):base(x , y, c)
        {

        }

        override public void dibuja()
        {
            Console.WriteLine("Se dibuja un Circulo en las coordenadas:({0},{1}) de Color:{2}",x,y, color);
        }
    }

    class Rect : Figura 
    {
        public Rect(int x, int y, string c):base(x , y, c)
        {

        }
        override public void dibuja()
        {
            Console.WriteLine("Se dibuja un Rectangulo en las coordenadas:({0},{1}) de Color:{2}",x,y, color);
        }
    }

    class Triangulo : Figura 
    {
        public Triangulo(int x, int y, string c):base(x , y, c)
        {

        }
        override public void dibuja()
        {
            Console.WriteLine("Se dibuja un Triangulo en las coordenadas:({0},{1}) de Color:{2}",x,y, color);
        }
    }
    class Program{
        static void Main(string[] args)
        {

            List<Figura> figuras = new List<Figura>();

            figuras.Add(new Circulo(5,7,"Blanco"));
            figuras.Add(new Rect(11,21,"Verde"));
            figuras.Add(new Triangulo(19,27,"Azul"));
            figuras.Add(new Circulo(45,32,"Morado"));
            figuras.Add(new Triangulo(6,8,"Amarillo"));
            figuras.Add(new Rect(2,3,"Rojo"));
            figuras.Add(new Circulo(77,69,"Negro"));

            foreach (var item in figuras)
            {
                item.dibuja();
                Console.WriteLine("");
            } 

            }
        }
}
