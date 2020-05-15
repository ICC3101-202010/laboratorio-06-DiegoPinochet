using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    [Serializable]
    public class Departamento : Division
    {
        private Dictionary<string, List<Seccion>> dicSeccion;
        public Departamento(string Name)
        {
            this.Name = Name;
        }
    }
}
