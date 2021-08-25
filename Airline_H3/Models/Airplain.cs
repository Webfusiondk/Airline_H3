using System;
using System.Collections.Generic;

#nullable disable

namespace Airline_H3.Models
{
    public partial class Airplain
    {
        public Airplain()
        {
            FlightRoutes = new HashSet<FlightRoute>();
        }

        public int Id { get; set; }
        public int? Airlineid { get; set; }
        public string AirplainName { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual ICollection<FlightRoute> FlightRoutes { get; set; }
    }
}
