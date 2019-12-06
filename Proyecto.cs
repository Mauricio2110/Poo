using System;
using System.Collections.Generic;
using System.IO;

namespace Proyecto
{
    class Producto
    {
        public string codigo;
        public string descripcion;
        public decimal precio;
        public int departamento;
        public int likes;

        public Producto(string c, string d, decimal p, int dp, int l)
        {
            codigo = c;
            descripcion = d;
            precio = p;
            departamento = dp;
            likes = l;
        }
        public Producto()
        {

        }
    }
    class ProductoDB
    {
        public static void EscribeProductosBIN(string archivo, List<Producto> productos)
        {
            FileStream fs = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter binOut = new BinaryWriter(fs);

            foreach (Producto p in productos)
            {
                binOut.Write(p.codigo);
                binOut.Write(p.descripcion);
                binOut.Write(p.precio);
                binOut.Write(p.descripcion);
                binOut.Write(p.likes);
            }
            binOut.Close();
        }

        public static void EscribeProductosTXT(string archivo, List<Producto> productos)
        {
            FileStream fs = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter txtOut = new StreamWriter(fs);

            foreach (Producto p in productos)
            {
                txtOut.WriteLine("{0}|{1}|{2}|{3}|{4}", p.codigo, p.descripcion, p.precio, p.departamento, p.likes);
            }
            txtOut.Close();
        }

        public static List<Producto> LeeProductosBIN(string archivo)
        {
            List<Producto> productos = new List<Producto>();

            FileStream bs = new FileStream(archivo, FileMode.Open, FileAccess.Read);

            using (BinaryReader binIn = new BinaryReader(bs))
            {
                while (binIn.PeekChar() != -1)
                {
                    Producto producto = new Producto();
                    producto.codigo = binIn.ReadString();
                    producto.descripcion = binIn.ReadString();
                    producto.precio = binIn.ReadInt16();
                    producto.departamento = binIn.ReadInt16();
                    producto.likes = binIn.ReadInt16();

                    productos.Add(producto);
                }
            }
            return productos;
        }

        public static List<Producto> LeeProductosTXT(string archivo)
        {
            List<Producto> productos = new List<Producto>();

            using (StreamReader sr = new StreamReader(archivo))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] columnas = line.Split('|');
                    productos.Add(new Producto(columnas[0], columnas[1], Decimal.Parse(columnas[2]), int.Parse(columnas[3]), int.Parse(columnas[4])));
                }
            }
            return productos;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int e = 1;
            Console.WriteLine("¿Que tipo de guardado desea?");
            Console.WriteLine("1.-Texto \n2.-Binario");
            e = int.Parse(Console.ReadLine());

            switch (e)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Productos Actuales");
                    List<Producto> productost = new List<Producto>();

                    productost.Add(new Producto("aqw", "Cuaderno", 12, 1, 15));
                    productost.Add(new Producto("zwg", "Pegamento", 34, 3, 8));
                    productost.Add(new Producto("mnf", "Sacapuntas", 4, 2, 9));
                    productost.Add(new Producto("gnr", "Libro de Matematicas", 55, 1, 167));
                    productost.Add(new Producto("gnr", "Calculadora", 99, 3, 150));
                    productost.Add(new Producto("gnr", "Pluma", 12, 2, 205));

                    ProductoDB.EscribeProductosTXT(@"productost.txt", productost);

                    List<Producto> productost_guardados = ProductoDB.LeeProductosTXT("productost.txt");
                    foreach (Producto p in productost_guardados)
                    {
                        Console.WriteLine("{0} {1} {2} {3} {4}", p.codigo, p.descripcion, p.precio, p.departamento, p.likes);
                    }

                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Productos Actuales");
                    List<Producto> productosb = new List<Producto>();

                    productosb.Add(new Producto("aqw", "Cuaderno", 12, 1, 15));
                    productosb.Add(new Producto("zwg", "Pegamento", 34, 3, 8));
                    productosb.Add(new Producto("mnf", "Sacapuntas", 4, 2, 9));
                    productosb.Add(new Producto("gnr", "Libro de Matematicas", 55, 1, 167));
                    productosb.Add(new Producto("gnr", "Calculadora", 99, 3, 150));
                    productosb.Add(new Producto("gnr", "Pluma", 12, 2, 205));

                    ProductoDB.EscribeProductosBIN(@"productosb.bin", productosb);

                    List<Producto> productosb_guardados = ProductoDB.LeeProductosBIN("productosb.bin");
                    foreach (Producto p in productosb_guardados)
                    {
                        Console.WriteLine("{0} {1} {2} {3} {4}", p.codigo, p.descripcion, p.precio, p.departamento, p.likes);
                    }

                    break;

            }











            Console.ReadKey();



        }
    }
}
