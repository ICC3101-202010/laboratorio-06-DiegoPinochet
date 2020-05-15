using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace Lab6_POO_Diego_Pinochet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empresa> listEmpresas = new List<Empresa>();
            string cargar_archivo;
            do
            {
                Console.Write("Quiere usar un archivo para cargar la información?(s/n): ");
                cargar_archivo = Console.ReadLine();
                switch (cargar_archivo)
                {

                    case "s":
                        try
                        {
                            Console.WriteLine("Abriendo archivo");
                            FileStream f = File.Open("empresas.bin",FileMode.Open);
                            listEmpresas = Load_Empresa_Main();

                            Console.WriteLine("Cerrando el archivo");
                            f.Close();
                        }
                        catch (FileNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("No se encontro el archivo, desea crearlo? (s/n): ");
                            string open = Console.ReadLine();
                            switch (open)
                            {
                                case "s":
                                    Console.WriteLine("Ingrese el nombre de la empresa: ");
                                    string nombre = Console.ReadLine();
                                    Console.WriteLine("Ingrese el rut de la empresa: ");
                                    string Rut = Console.ReadLine();

                                    listEmpresas.Add(new Empresa(nombre, Rut));
                                    Save_Empresa_Main(listEmpresas);
                                    break;
                                case "n":
                                    Console.WriteLine("Se cerrará el programa.");
                                    break;
                            }
                        }
                        break;
                    case "n":
                        Console.WriteLine("Ingrese el nombre de la empresa: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut de la empresa: ");
                        string rut = Console.ReadLine();
                        //Console.WriteLine("Ingrese la primera división de su empresa (Area/Departamentos/Secciones/Bloques): ");
                        //string division_empresa = Console.ReadLine();
                        
                        listEmpresas.Add(new Empresa(name, rut));
                        Save_Empresa_Main(listEmpresas);
                        break;
                }
            } while (cargar_archivo != "s" && cargar_archivo != "n");
 
        }
        public static void Save_Empresa_Main(List<Empresa> empresa)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresas.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, empresa);
            formatter.Serialize(stream, "\n");
            stream.Close();
        }
        public static List<Empresa> Load_Empresa_Main()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresas.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            List<Empresa> list_empresa = (List<Empresa>)formatter.Deserialize(stream);
            stream.Close();
            return list_empresa;
        }


    }
}
