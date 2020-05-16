using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    [Serializable]
    public class Seccion:Division
    {
        private List<Bloque> listBloque;
        private Persona encargado;
        public Seccion(string Name, Persona Encargado)
        {
            this.Name = Name;
            this.encargado = Encargado;
        }

        public List<Bloque> ListBloque { get => listBloque; set => listBloque = value; }
    }
}
