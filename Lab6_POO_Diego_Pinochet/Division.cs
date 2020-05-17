using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    [Serializable]
    public class Division
    {

        private string name;
        public string Name { get => name; set => name = value; }
        

        public override string ToString()
        {
            return "Nombre Division: " + name;
        }
    }
}
