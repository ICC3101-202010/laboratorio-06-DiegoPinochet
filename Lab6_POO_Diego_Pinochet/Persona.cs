using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_POO_Diego_Pinochet
{
    [Serializable]
    public class Persona
    {
        private string name;
        private string lastName;
        private string rut;
        private string job;
        private string personal;
        private string dondeSon;

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Job { get => job; set => job = value; }
        public string Personal { get => personal; set => personal = value; }
        public string DondeSon { get => dondeSon; set => dondeSon = value; }

        public Persona(string Name, string LastName, string Rut, string Job, string Personal, string DondeSon)
        {
            this.name = Name;
            this.lastName = LastName;
            this.rut = Rut;
            this.Job = Job;
            this.Personal = Personal;
            this.dondeSon = DondeSon;
        }

        public override string ToString()
        {
            string str;
            str = "Nombre: " + name + ", Apellido: " + lastName + ", Rut: " + rut + ", Pertenece: " + dondeSon;

            return str;
        }

    }
}
