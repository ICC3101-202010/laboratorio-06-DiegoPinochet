using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    [Serializable]
    public class Bloque:Division
    {
        private Persona personal;
        private Persona encargado;
        public Bloque(string Name, Persona Encargado, Persona Personal)
        {
            this.Name = Name;
            this.personal = Personal;
            this.encargado = Encargado;
        }
    }
}
