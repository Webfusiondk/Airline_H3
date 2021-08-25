using System;
using System.Collections.Generic;

#nullable disable

namespace Airline_H3.Models
{
    public partial class Airline
    {
        public Airline()
        {
            Airplains = new HashSet<Airplain>();
            FlightRouteOperators = new HashSet<FlightRoute>();
            FlightRouteOwners = new HashSet<FlightRoute>();
        }

        public int Id { get; set; }
        public string AirlineName { get; set; }

        public virtual ICollection<Airplain> Airplains { get; set; }
        public virtual ICollection<FlightRoute> FlightRouteOperators { get; set; }
        public virtual ICollection<FlightRoute> FlightRouteOwners { get; set; }
    }
}
