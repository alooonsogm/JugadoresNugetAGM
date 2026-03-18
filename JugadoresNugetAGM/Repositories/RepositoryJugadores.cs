using JugadoresNugetAGM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace JugadoresNugetAGM.Repositories
{
    public class RepositoryJugadores
    {
        private XDocument document;

        public RepositoryJugadores()
        {
            //Para ller un recurso inrustado necesitamos el namespace del proyecto y si estuviera en una carpeta,
            //tambien el nombre de la carpeta y el filename.
            string resourceName = "JugadoresNugetAGM.jugadores.xml";
            //Los datos se recuperan mediante stream.
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName);
            //el fichero XML se almacena en document mediante load.
            this.document = XDocument.Load(stream);
        }

        public List<Jugador> GetJugadores()
        {
            var consulta = from datos in this.document.Descendants("jugador") select datos;
            List<Jugador> jugadores = new List<Jugador>();
            foreach (var tag in consulta)
            {
                Jugador player = new Jugador();
                player.Numero = int.Parse(tag.Element("numero").Value);
                player.Nombre = tag.Element("nombre").Value;
                player.Posicion = tag.Element("posicion").Value;
                player.Edad = int.Parse(tag.Element("edad").Value);
                player.Imagen = tag.Element("imagen").Value;
                jugadores.Add(player);
            }
            return jugadores;
        }
    }
}
