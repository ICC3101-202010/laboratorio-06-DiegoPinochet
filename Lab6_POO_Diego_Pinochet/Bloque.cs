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
        public Bloque(string Name)
        {
            this.Name = Name;
        }
    }
}
