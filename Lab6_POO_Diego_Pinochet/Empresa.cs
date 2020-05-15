using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    [Serializable]
    public class Empresa
    {
        private string name;
        private string rut;
        

        public Empresa(string Name, string Rut)
        {
            this.name = Name;
            this.rut = Rut;
        }
        
        public static void SaveDivision(List<Division> listDivision)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresas.bin", FileMode.Create, FileAccess.Write, FileShare.None); //Los guardo en el mismo archivo que en el de las empresas o que?
            formatter.Serialize(stream, listDivision);
            formatter.Serialize(stream, "\n");
            stream.Close();
        }
        public static List<Division> LoadDivision()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresas.bin", FileMode.Create, FileAccess.Write, FileShare.None); //Los guardo en el mismo archivo que en el de las empresas o que?
            List<Division> listDivision = (List<Division>)formatter.Deserialize(stream);
            stream.Close();
            return listDivision;
        }
    }
}
