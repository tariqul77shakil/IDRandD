using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IDTP.Models
{

    [XmlRoot(ElementName = "info")]
    public class Info
    {
        [XmlElement(ElementName = "locations")]
        public Locations Locations { get; set; }
    }

    [XmlRoot(ElementName = "locations")]
    public class Locations
    {
        [XmlElement(ElementName = "location")]
        public List<Location> Location { get; set; }
    }

    [XmlRoot(ElementName = "location")]
    public class Location
    {
        [XmlElement(ElementName = "Buildings")]
        public Buildings Buildings { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Buildings")]
    public class Buildings
    {
        [XmlElement(ElementName = "Building")]
        public List<Building> Building { get; set; }
    }

    [XmlRoot(ElementName = "Building")]
    public class Building
    {
        [XmlElement(ElementName = "Rooms")]
        public Rooms Rooms { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Rooms")]
    public class Rooms
    {
        [XmlElement(ElementName = "Room")]
        public List<Room> Room { get; set; }
    }

    [XmlRoot(ElementName = "Room")]
    public class Room
    {
        [XmlElement(ElementName = "Capacity")]
        public string Capacity { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

}
