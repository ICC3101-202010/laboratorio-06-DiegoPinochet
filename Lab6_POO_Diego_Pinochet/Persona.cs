using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    class Persona
    {
        string name;
        string lastName;
        string rut;
        string job;

        public Persona(string Name, string LastName, string Rut, string Job)
        {
            this.name = Name;
            this.lastName = LastName;
            this.rut = Rut;
            this.job = Job;
        }
    }
}
