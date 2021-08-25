using System;
using System.Collections.Generic;

#nullable disable

namespace Airline_H3.Models
{
    public partial class Airport
    {
        public Airport()
        {
            FlightRouteFromDestAirportNavigations = new HashSet<FlightRoute>();
            FlightRouteToDestAirportNavigations = new HashSet<FlightRoute>();
        }

        public int Id { get; set; }
        public string AirportName { get; set; }
        public string City { get; set; }
        public string Iata { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<FlightRoute> FlightRouteFromDestAirportNavigations { get; set; }
        public virtual ICollection<FlightRoute> FlightRouteToDestAirportNavigations { get; set; }
    }
}
