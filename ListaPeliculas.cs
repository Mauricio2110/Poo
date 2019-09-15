using System;
using System.Collections.Generic;

namespace Lista
{
    class Program
    {
        static void Main()
        {
            List<String> lista =new List<String>();
                lista.Add("Avatar");
                lista.Add("Avengers");
                lista.Add("Spiderman");
                lista.Add("El viaje de chihiro");
                lista.Add("Transformers");

           foreach(String Pelicula in lista)
                Console.WriteLine(Pelicula);
        }
    }
}
