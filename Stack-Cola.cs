using System;

namespace Stack
{
    class Stack<T>
    {
        private T[] elementos;
        public readonly int tamaño;
        private int marca = 0;

        public Stack() : this(100)
        {
        }

        public Stack(int t)
        {
            tamaño = t;
            elementos = new T[tamaño];
        }

        public void Push(T elemento)
        {
            if (marca >= tamaño)
            {
                marca = tamaño ;
                throw new StackOverflowException("La pila esta llena");
            }
            else
            {
                elementos[marca] = elemento;
                marca++;
            }
        }

        public T Pop()
        {
            marca--;

            if (marca >= 0)
            {
                return elementos[marca];
            }
            else
            {
                marca = 0;
                throw new InvalidOperationException("No se puede hacer Pop ya que no quedan elementos");

            }
        }

        public void Cola()
        {
            for(int i=0;i<tamaño;i++)
            {
                Console.WriteLine(elementos[i]);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> orden = new Stack<string>(5);

            orden.Push("1");
            orden.Push("Mundo");
            orden.Push("2");
            orden.Push("Hola");
            
            //Stack

            Console.WriteLine(orden.Pop());
            Console.WriteLine(orden.Pop());
            Console.WriteLine(orden.Pop());
            Console.WriteLine(orden.Pop());

            Console.WriteLine();

            //Cola

            orden.Cola();


        }
    }
}
