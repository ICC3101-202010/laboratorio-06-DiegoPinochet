using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    [Serializable]
    public class Area:Division
    {
        private List<Departamento> listDepartamentos;
        private Persona encargado;
        public Area(string Name, Persona Encargado)
        {
            this.Name = Name;
            this.encargado = Encargado;
        }

        public List<Departamento> ListDepartamentos { get => listDepartamentos; set => listDepartamentos = value; }
    }
}
