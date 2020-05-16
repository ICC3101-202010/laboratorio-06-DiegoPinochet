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
        private List<Division> listDivision;

        public string Name { get => name; }
        public string Rut { get => rut; }
        public List<Division> ListDivision { get => listDivision; }

        public Empresa(string Name, string Rut,List<Division> ListDivision)
        {
            this.name = Name;
            this.rut = Rut;
            this.listDivision = ListDivision;
        }
        
    }
}
