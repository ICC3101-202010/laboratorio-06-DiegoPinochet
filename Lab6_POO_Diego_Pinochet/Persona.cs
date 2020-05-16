using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    public class Persona
    {
        private string name;
        private string lastName;
        private string rut;
        private string job;

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public Persona(string Name, string LastName, string Rut, string Job)
        {
            this.name = Name;
            this.lastName = LastName;
            this.rut = Rut;
            this.job = Job;
        }

    }
}
