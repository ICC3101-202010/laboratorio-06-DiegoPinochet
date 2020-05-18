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
                            FileStream f = File.Open("empresas.bin", FileMode.Open);
                            f.Close();

                            listEmpresas = Load_Empresa_Main();
                            foreach (Empresa empresa in listEmpresas)
                            {
                                Console.WriteLine("--------------------------------------------------------------------");
                                Console.WriteLine(empresa.ToString());
                                Console.Write("\n");
                                List<string> listString = new List<string>();
                                foreach (Division division in empresa.ListDivision)
                                {

                                    if (listString.Contains(division.Name) == false) //Agregar alguna manera para que no se repitan las mismas divisiones
                                    {
                                        Console.Write(division.ToString());
                                        Console.WriteLine("\nEncargados: ");
                                        foreach (Persona persona in empresa.ListPersona)
                                        {

                                            if (persona.Job == division.Name && (persona.Personal == "Encargado" || persona.Personal == null))
                                            {
                                                Console.Write(" ---->" + persona.ToString() + "\n\n");
                                            }

                                        }
                                        if (division.Name == "Bloque")
                                        {
                                            Console.WriteLine("\n Personal: ");
                                            foreach (Persona persona in empresa.ListPersona)
                                            {
                                                if (persona.Job == division.Name && persona.Personal == "Personal")
                                                {
                                                    Console.WriteLine("---->" + persona.ToString() + "\n\n");
                                                }
                                            }
                                        }
                                    }
                                    listString.Add(division.Name);


                                }
                                Console.WriteLine("--------------------------------------------------------------------");
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
                                    List<Division> listDivisiones = new List<Division>();
                                    List<Persona> listPersonas = new List<Persona>();
                                    Console.WriteLine("Ingrese el nombre de la empresa: ");
                                    string nombre = Console.ReadLine();
                                    Console.WriteLine("Ingrese el rut de la empresa: ");
                                    string Rut = Console.ReadLine();
                                    bool x = true;
                                    int cantA = 1;
                                    int cantD = 1;
                                    int cantS = 1;
                                    int cantB = 1;
                                    do
                                    {
                                        Console.WriteLine("Ingrese la división de su empresa (Area/Departamento/Seccion/Bloque): ");
                                        string primeraDiv = Console.ReadLine();
                                        string n;
                                        string ln;
                                        string r;
                                        string pert;
                                        string upper;
                                        switch (primeraDiv)
                                        {
                                            case "Area":
                                                Console.WriteLine("Cuantas areas quiere añadir?");
                                                cantA = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < cantA; i++)
                                                {
                                                    Console.WriteLine("Dame el nombre, apellido rut y de que Area esta encargado(A1, A2, etc.).");
                                                    n = Console.ReadLine();
                                                    ln = Console.ReadLine();
                                                    r = Console.ReadLine();
                                                    pert = Console.ReadLine();
                                                    Persona personaArea = new Persona(n, ln, r, "Area", null, pert, null);
                                                    Area area = new Area("Area");
                                                    listPersonas.Add(personaArea);
                                                    listDivisiones.Add(area);
                                                }
                                                break;
                                            case "Departamento":
                                                Console.WriteLine("Cuantas Departamentos quiere añadir por area?");
                                                cantD = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < cantD*cantA; i++)
                                                {
                                                    Console.WriteLine("Dame el nombre, apellido, rut, de que Departamento esta encargado(D1, D2, etc.) y a que area pertenece(A1,A2,etc.).");
                                                    Console.WriteLine("Si no pertenece a ningun area, escriba null");
                                                    n = Console.ReadLine();
                                                    ln = Console.ReadLine();
                                                    r = Console.ReadLine();
                                                    pert = Console.ReadLine();
                                                    upper = Console.ReadLine();
                                                    Persona personaDept = new Persona(n, ln, r, "Departamento", null, pert,upper);
                                                    Departamento departamento = new Departamento("Departamento");
                                                    listPersonas.Add(personaDept);
                                                    listDivisiones.Add(departamento);
                                                }
                                                break;
                                            case "Seccion":
                                                Console.WriteLine("Cuantas Secciones quiere añadir por departamento?");
                                                cantS = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < cantS * cantD; i++)
                                                {
                                                    Console.WriteLine("Dame el nombre, apellido, rut, de que Seccion esta encargado(S1, S2, etc.) y a que departamento pertenece (D1,D2,etc.).");
                                                    Console.WriteLine("Si no pertenece a ningun departamento, escriba null");
                                                    n = Console.ReadLine();
                                                    ln = Console.ReadLine();
                                                    r = Console.ReadLine();
                                                    pert = Console.ReadLine();
                                                    upper = Console.ReadLine();
                                                    Persona personaSeccion = new Persona(n, ln, r, "Seccion", null, pert, upper);
                                                    Seccion seccion = new Seccion("Seccion");
                                                    listPersonas.Add(personaSeccion);
                                                    listDivisiones.Add(seccion);
                                                }
                                                break;
                                            case "Bloque":
                                                Console.WriteLine("Cuantos Bloques quiere añadir por sección?");
                                                cantB = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < cantB * cantS; i++)
                                                {
                                                    Console.WriteLine("Dame el nombre, apellido, rut, de que Bloque esta encargado(B1, B2, etc.) y a que sección pertenece (S1,S2,etc.).");
                                                    Console.WriteLine("Si no pertenece a ninguna seccion, escriba null");
                                                    n = Console.ReadLine();
                                                    ln = Console.ReadLine();
                                                    r = Console.ReadLine();
                                                    pert = Console.ReadLine();
                                                    upper = Console.ReadLine();
                                                    Persona personaBloque = new Persona(n, ln, r, "Bloque", null, pert, upper);
                                                    listPersonas.Add(personaBloque);
                                                }
                                                
                                                Console.WriteLine("Cuanto personal hay en total entre todos los bloques?");
                                                int personal = int.Parse(Console.ReadLine());
                                                for (int p = 0; p < personal; p++)
                                                {
                                                    Console.WriteLine("Dame el nombre, apellido, rut del personal y a que Bloque pertenecen(B1,B2,etc.)");
                                                    n = Console.ReadLine();
                                                    ln = Console.ReadLine();
                                                    r = Console.ReadLine();
                                                    pert = Console.ReadLine();

                                                    Persona personaBloquepersonal = new Persona(n, ln, r, "Bloque", "Personal",pert,null);
                                                    listPersonas.Add(personaBloquepersonal);
                                                }

                                                Bloque bloque = new Bloque("Bloque");
                                                
                                                listDivisiones.Add(bloque);
                                                
                                                x = false;
                                                break;
                                        }
                                    } while (x == true);
                                    listEmpresas.Add(new Empresa(nombre, Rut, listDivisiones, listPersonas));
                                    Save_Empresa_Main(listEmpresas);
                                    Console.WriteLine("Se ha creado la emresa correctamente...");
                                    Thread.Sleep(1000);
                                    break;
                                case "n":
                                    Console.WriteLine("Se cerrará el programa.");
                                    break;
                            }
                        }
                        break;
                    case "n":
                        Console.Clear();
                        if (File.Exists("empresas.bin") == true)
                        {
                            listEmpresas = Load_Empresa_Main();
                        }
                        List<Division> listDiv = new List<Division>();
                        List<Persona> listPerson = new List<Persona>();
                        Console.WriteLine("Ingrese el nombre de la empresa: ");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut de la empresa: ");
                        string ruT = Console.ReadLine();
                        Departamento depto = new Departamento("Departamento");
                        Persona personaDepto = new Persona("Harry", "Potter", "105406789", "Departamento", null,"D1",null);
                        listDiv.Add(depto);
                        listPerson.Add(personaDepto);

                        Seccion secc = new Seccion("Seccion");
                        Persona personaSecc = new Persona("Hermionie", "Granger", "301876540", "Seccion", null,"S1","D1");
                        listDiv.Add(secc);
                        listPerson.Add(personaSecc);

                        Bloque bloq1 = new Bloque("Bloque");
                        Persona personaBE1 = new Persona("Ron","Weasley","109765432","Bloque",null,"B1","S1");
                        Persona personaBP1 = new Persona("Albus", "Dumbledore", "109765489", "Bloque", "Personal","B1",null);
                        Persona personaBP2 = new Persona("Severus", "Snape", "214509090", "Bloque", "Personal","B1",null);
                        listDiv.Add(bloq1);
                        listPerson.Add(personaBE1);
                        listPerson.Add(personaBP1);
                        listPerson.Add(personaBP2);

                        Bloque bloq2 = new Bloque("Bloque");
                        Persona personaBE2 = new Persona("Drako", "Malfoy", "308976543", "Bloque", null,"B2","S1");
                        Persona personaBP12 = new Persona("Neville", "LongBottom", "207965431", "Bloque", "Personal","B2",null);
                        Persona personaBP22 = new Persona("Tom", "Riddle", "015678956", "Bloque", "Personal","B2", null);
                        listDiv.Add(bloq2);
                        listPerson.Add(personaBE2);
                        listPerson.Add(personaBP12);
                        listPerson.Add(personaBP22);

                        listEmpresas.Add(new Empresa(nom, ruT, listDiv, listPerson));
                        Save_Empresa_Main(listEmpresas);
                        Console.WriteLine("Se ha creado la emresa correctamente...");
                        Thread.Sleep(1000);
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

