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
        private List<Persona> listPersona;

        public string Name { get => name; }
        public string Rut { get => rut; }
        public List<Division> ListDivision { get => listDivision; }
        public List<Persona> ListPersona { get => listPersona; set => listPersona = value; }

        public Empresa(string Name, string Rut,List<Division> ListDivision,List<Persona> ListPersona)
        {
            this.name = Name;
            this.rut = Rut;
            this.listDivision = ListDivision;
            this.listPersona = ListPersona;
        }

        public override string ToString()
        {
            return "Nombre empresa: " + name + " Rut empresa: " + rut;
        }

    }
}
