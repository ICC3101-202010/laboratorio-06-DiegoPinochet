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
        //Mediante una console.readline() ver cual seria la división primaria de la empresa, y entregar el diccionario
        //correspondiente.
        private Dictionary<string, List<Area>> dicArea;
        private Dictionary<string, List<Departamento>> dicDepartamento;
        private Dictionary<string, List<Seccion>> dicSeccion;
        private Dictionary<string, List<Bloque>> dicBloque;


        private string name;
        public string Name { get => name; set => name = value; }
    }
}
