//  Route.cs  Ken Schultz (c) 2011
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

using Game.Meta;

namespace Game
{
    /*************************************************************************
     * The Cartography class records an Actor's current position, any explored 
     * objects, and any active routes.  It is used to generate the Actor's map 
     * and is the intersection of actor (player) and galaxy.
     *************************************************************************/
    [Serializable()]
    public class Cartography
    {
        public Coordinate Position { get; set; }            // Current Position
        public List<Coordinate> Explored { get; set; }      // List of explored coordinates
        public List<Route> Routes { get; set; }             // Active routes

        public Cartography()
        {
            Position = new Coordinate();
            Explored = new List<Coordinate>();
            Routes = new List<Route>();
        }
    }

    /*************************************************************************
     * The Coordinate class stores the IDs of a system/planet/zone and the X,Y 
     * position.  Leave null any ID's that don't apply to indicate which level 
     * of the hierarchy the X,Y applies to.
     *************************************************************************/
    [Serializable()]
    public class Coordinate
    {
        [XmlAttribute("SystemID")]
        public int SystemID { get; set; }
        [XmlAttribute("PlanetID")]
        public int PlanetID { get; set; }
        [XmlAttribute("ZoneID")]
        public int ZoneID { get; set; }
        [XmlAttribute("XPos")]
        public int XPos { get; set; }
        [XmlAttribute("YPos")]
        public int YPos { get; set; }

        public Coordinate()
        {
            SystemID = 0;
            PlanetID = 0;
            ZoneID = 0;
            XPos = 0;
            YPos = 0;
        }
    }

    /*******************************************************************
    * A defined ship path for automatic transport and movement.
    *******************************************************************/
    [Serializable()]
    public class Route
    {
        public enum RouteType { Patrol, Transport };

        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Type")]
        public RouteType Type { get; set; }
        [XmlAttribute("Status")]
        public ControlData.Status Status { get; set; }
        public List<Coordinate> Path { get; set; }
        public Fleet Fleet { get; set; }
        public Manifest Manifest { get; set; }

        public Route()
        {
            ID = 0;
            Name = "";
            Type = RouteType.Patrol;
            Status = ControlData.Status.Idle;
            Path = new List<Coordinate>();
            Fleet = new Fleet();
            Manifest = new Manifest();
        }
    }

    /*******************************************************************
    * A group of one or more member ships belonging to a defined route.
    *******************************************************************/
    public class Fleet
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Status")]
        public ControlData.Status Status { get; set; }
        public List<FleetMember> Members { get; set; }

        public Fleet()
        {
            ID = 0;
            Name = "";
            Status = ControlData.Status.Idle;
            Members = new List<FleetMember>();
        }
    }

    /*******************************************************************
    * Each fleet member ship is assigned a role.
    *******************************************************************/
    public class FleetMember
    {
        public enum RoleType { Primary, Escort };

        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Role")]
        public RoleType Role { get; set; }

        public FleetMember()
        {
            ID = 0;
            Name = "";
            Role = RoleType.Primary;
        }
    }

    /*******************************************************************
    * A manifest lists the items and amounts of a designated route.
    *******************************************************************/
    public class Manifest
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        public Manifest()
        {
            ID = 0;
        }
    }
}
