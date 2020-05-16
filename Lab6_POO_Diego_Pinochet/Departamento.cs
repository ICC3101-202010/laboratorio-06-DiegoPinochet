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
        private List<Seccion> listSeccion;
        private Persona encargado;
        public Departamento(string Name, Persona Encargado)
        {
            this.Name = Name;
            this.encargado = Encargado;
        }

        public List<Seccion> ListSeccion { get => listSeccion; set => listSeccion = value; }
    }
}
