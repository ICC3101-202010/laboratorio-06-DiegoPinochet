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
using System.Threading;

namespace Lab6_POO_Diego_Pinochet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empresa> listEmpresas = new List<Empresa>();
            List<Division> listDivisiones = new List<Division>();
            Division division = new Division();
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
                            Console.WriteLine("Buscando archivo...");
                            Thread.Sleep(1000);
                            FileStream f = File.Open("empresas.bin",FileMode.Open);
                            f.Close();

                            listEmpresas = Load_Empresa_Main();
                            foreach(Empresa empresa in listEmpresas)
                            {
                                Console.WriteLine(empresa.Name + " " + empresa.Rut);
                            }
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
                                    listEmpresas.Add(new Empresa(nombre, Rut, listDivisiones));
                                    Save_Empresa_Main(listEmpresas);
                                    break;
                                case "n":
                                    Console.WriteLine("Se cerrará el programa.");
                                    break;
                            }
                        }
                        break;
                    case "n":
                        if (File.Exists("empresas.bin") == true)
                        {
                            listEmpresas = Load_Empresa_Main();
                        }

                        Console.WriteLine("Ingrese el nombre de la empresa: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut de la empresa: ");
                        string rut = Console.ReadLine();
                        
                        //Bloque:
                        Persona personaBG = new Persona("Tomas", "Pinochet", "1010101", "Encargado");

                        Persona personaB1 = new Persona("Diego","Pinochet","201837396","Personal");
                        Bloque bloque = new Bloque("Bloque 1",personaB1, personaBG);

                        Persona personaB2 = new Persona("Matias", "Pinochet", "20202020", "Personal");
                        Bloque bloque2 = new Bloque("Bloque 2", personaB2, personaBG);

                        List<Bloque> listBloque = new List<Bloque>();


                        //Seccion
                        Persona personaSec = new Persona("Alvaro", "Leguer", "180907698", "Encargado");
                        Seccion seccion = new Seccion("Sección 1",personaSec);

                        List<Seccion> listSeccion = new List<Seccion>();
                        
                        listSeccion.Add(seccion);

                        //Departamento
                        Persona personaDep = new Persona("George", "Fuentes", "309087956", "Encargado");
                        Departamento departamento = new Departamento("Departamento 1",personaDep);
                        List<Departamento> listDep = new List<Departamento>();
                        listDep.Add(departamento);



                        //Console.WriteLine("Ingrese la primera división de su empresa (Area/Departamentos/Secciones/Bloques): ");
                        //string division_empresa = Console.ReadLine();

                        listEmpresas.Add(new Empresa(name, rut, listDivisiones));
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
            stream.Close();
        }
        public static List<Empresa> Load_Empresa_Main()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresas.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Empresa> list_empresa = (List<Empresa>)formatter.Deserialize(stream);
            stream.Close();
            return list_empresa;
        }


    }
}

