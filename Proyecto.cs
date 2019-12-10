using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Proyecto
{
    public class Producto
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int departamento { get; set; }
        public int likes { get; set; }

        public Producto(string c, string d, double p, int dp, int l)
        {
            codigo = c;
            descripcion = d;
            precio = p;
            departamento = dp;
            likes = l;
        }
    }
    public enum FileType
    {
        Text,
        Binary
    }
    public static class ProductoDB
    {
        //Seleccionamos como guardar el archivo
        public static void Escribe(string archivo, List<Producto> productos, FileType t = FileType.Text)
        {
            switch (t)
            {
                case FileType.Text:
                    EscribeTXT(archivo, productos);
                    break;

                case FileType.Binary:
                    EscribeBIN(archivo, productos);
                    break;
            }
        }
        //Para escribir archivo tipo texto
        private static void EscribeTXT(string archivo, List<Producto> productos)
        {
            try
            {
                if (!archivo.ToLower().Contains(".txt"))
                    throw new IOException("Formato incorrecto (Formato correcto '.txt')");

                using (StreamWriter sw = new StreamWriter(new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    foreach (Producto p in productos)
                    {
                        sw.WriteLine("{0}|{1}|{2}|{3}|{4}", p.codigo, p.descripcion, p.precio, p.departamento, p.likes);
                    }
                }
            }
            //Posibles excepcion
            catch (IOException m)
            {
                Console.WriteLine("Error al escribir el archivo {0} {1}", archivo, m.Message);
            }
        }
        //Para escribir archivo tipo binario
        private static void EscribeBIN(string archivo, List<Producto> productos)
        {
            try
            {
                if (!archivo.ToLower().Contains(".bin"))
                    throw new IOException("Formato incorrecto (Formato correcto '.bin')");

                using (BinaryWriter bw = new BinaryWriter(new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    foreach (Producto p in productos)
                    {
                        bw.Write(p.codigo);
                        bw.Write(p.descripcion);
                        bw.Write(p.precio);
                        bw.Write(p.departamento);
                        bw.Write(p.likes);
                    }
                }
            }
            //Posibles excepciones
            catch (IOException m)
            {
                Console.WriteLine("Error al escribir el archivo {0} {1}", archivo, m.Message);
            }
        }
        //Seleccionamos el tipo de archivo
        public static List<Producto> Leer(string archivo, FileType t = FileType.Text)
        {
            switch (t)
            {
                case FileType.Text:
                    return LeerTXT(archivo);

                case FileType.Binary:
                    return LeerBIN(archivo);

                default:
                    return new List<Producto>();
            }
        }
        //Para leer archivo tipo texto
        private static List<Producto> LeerTXT(string archivo)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                if (!archivo.ToLower().Contains(".txt"))
                    throw new IOException("Formato incorrecto (Formato correcto '.txt')");

                using (StreamReader sr = new StreamReader(archivo))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columnas = line.Split('|');
                        if (columnas.Length < 5)
                            continue;
                        productos.Add(new Producto(columnas[0], columnas[1], Double.Parse(columnas[2]), int.Parse(columnas[3]), int.Parse(columnas[4])));
                    }

                }
            }
            //Posibles excepciones
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error no se encontro el archivo {0}", archivo);
            }
            catch (IOException m)
            {
                Console.WriteLine("Error al leer el archivo {0} {1}", archivo, m.Message);
            }
            return productos;
        }
        //Para leer archivo tipo binario
        private static List<Producto> LeerBIN(string archivo)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                if (!archivo.ToLower().Contains(".bin"))
                    throw new IOException("Formato incorrecto (Formato correcto '.bin')");

                using (BinaryReader br = new BinaryReader(new FileStream(archivo, FileMode.Open, FileAccess.Read)))
                {
                    while (br.PeekChar() != -1)
                    {
                        productos.Add(new Producto(br.ReadString(), br.ReadString(), br.ReadDouble(), br.ReadInt32(), br.ReadInt32()));
                    }

                }
            }
            //Posibles excepciones
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error no se encontro el archivo {0}", archivo);
            }
            catch (IOException m)
            {
                Console.WriteLine("Error al leer el archivo {0} {1}", archivo, m.Message);
            }
            return productos;
        }
        //Para ordenar por departamento
        public static void GetDepartment(int Depto, string archivo)
        {
            List<Producto> productos;

            if (archivo.ToLower().Contains(".txt"))
            {
                productos = LeerTXT(archivo);
            }
            else if (archivo.ToLower().Contains(".bin"))
            {
                productos = LeerBIN(archivo);
            }
            else
            {
                Console.WriteLine("Formato incorrecto (Formato correcto '.txt')", archivo);
                return;
            }

            IEnumerable<Producto> productod =
                from p in productos
                where p.departamento == Depto
                select p;
            
            Console.WriteLine("Productos del Departamento {0}", Depto);
            if(Depto>3)
            { Console.WriteLine("Sin Productos registrados"); }

            foreach (Producto p in productod)
            {
                Console.WriteLine("Departamento:{0} Clave:{1} Producto:'{2}' costo: ${3} ({4} Likes)", p.departamento, p.codigo, p.descripcion, p.precio, p.likes);
            }
        }
        //Para ordenar por likes
        public static void OrderByLikes(string archivo)
        {
            List<Producto> productos;
            if (archivo.ToLower().Contains(".txt"))
            {
                productos = LeerTXT(archivo);
            }
            else if (archivo.ToLower().Contains(".bin"))
            {
                productos = LeerBIN(archivo);
            }
            else
            {
                Console.WriteLine("Formato incorrecto (Formato correcto '.txt')", archivo);
                return;
            }

            IEnumerable<Producto> productol =
                from p in productos
                orderby p.likes descending
                select p;
            
            Console.WriteLine("Productos ordenados por Likes:");

            foreach (Producto p in productol)
            {
                Console.WriteLine("Departamento:{0} Clave:{1} Producto:'{2}' costo: ${3} ({4} Likes)", p.departamento, p.codigo, p.descripcion, p.precio, p.likes);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            {
                int e;
                int d;
                List<Producto> productos = new List<Producto>();
                productos.Add(new Producto("AQW", "Cuaderno", 12.00d, 1, 193));
                productos.Add(new Producto("ZWG", "Pegamento", 34.00d, 3, 8));
                productos.Add(new Producto("MNF", "Sacapuntas", 4.00d, 2, 35));
                productos.Add(new Producto("GNR", "Libro de Matematicas", 55.00d, 1, 167));
                productos.Add(new Producto("ZLO", "Calculadora", 99.00d, 3, 169));
                productos.Add(new Producto("CZR", "Cuaderno Cuadriculado", 10.00d, 1, 15));
                productos.Add(new Producto("PKR", "Pluma", 12.00d, 2, 205));
                productos.Add(new Producto("SCH", "Lapiz", 6.00d, 2, 305));
                productos.Add(new Producto("AQW", "Borrador", 3.00d, 2, 26));

                Console.WriteLine("Lista de Productos");
                Console.WriteLine("");
                foreach (Producto p in productos)
                {
                    Console.WriteLine("Departamento:{0} Clave:{1} Producto:'{2}' costo: ${3} ({4} Likes)",p.departamento,p.codigo, p.descripcion, p.precio, p.likes);
                }
                //Metodo para guardar archivo de texto
                ProductoDB.Escribe(@"productos.txt", productos, FileType.Text);
                //Metodo para guardar archivo binario
                ProductoDB.Escribe(@"productos.bin", productos, FileType.Binary);

                Console.WriteLine("");
                Console.WriteLine("¿Que desea hacer?");
                Console.WriteLine("1.-Seleccionar productos de un departamento");
                Console.WriteLine("2.-Ordenar los productos por likes");
                Console.WriteLine("");
                e = int.Parse(Console.ReadLine());

                if(e==1)
                {
                    //Metodo para ordenar por departamento
                    Console.WriteLine("¿Que departamento desea escoger?");
                    Console.WriteLine("1");
                    Console.WriteLine("2");
                    Console.WriteLine("3");
                    Console.WriteLine("");
                    d = int.Parse(Console.ReadLine());
                    ProductoDB.GetDepartment(d, @"productos.txt");

                }
                else if(e==2)
                {
                //Metodo para ordenar por likes
                ProductoDB.OrderByLikes(@"productos.txt");
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta");
                }
            }

        }
    }
}
